using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GISDesign_ZY;
using ClassLibraryIofly;

namespace GISFinal
{
    public partial class mainForm : Form
    {
        #region 字段

        private MapManager map;


        #endregion


        public mainForm()
        {
            InitializeComponent();
        }

        #region 事件
        //初始化窗体
        private void Form1_Load(object sender, EventArgs e)
        {
            map = new MapManager();
        }

        private void 视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void gelatoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 平移选中要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //打开一个shapefile
        private void Shapefile文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openShapefileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openShapefileDialog.FileName;
                map.Layers.Add(map.OpenLayerFile(path));
                //更新treeview视图
                if (layerTreeView.Nodes.Count == 0)
                {
                    TreeNode root = new TreeNode("NewAntMap");
                    layerTreeView.Nodes.Add(root);
                }
                layerTreeView.Nodes[0].Nodes.Add(map.Layers[map.Layers.Count-1].Name);
                layerTreeView.ExpandAll();
                mcMap._Layers.Add(map.Layers[map.Layers.Count - 1]);
                mcMap.Refresh();
            }
        }

        private void AntMap文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                map = new MapManager();
                map.OpenProjectFile(openProjectFileDialog.FileName);
                //TODO:打开后刷新地图控件
                if (layerTreeView.Nodes.Count == 0)
                {
                    TreeNode root = new TreeNode(map.name);
                    layerTreeView.Nodes.Add(root);
                }
                foreach (Layer layer in map.Layers)
                {
                    layerTreeView.Nodes[0].Nodes.Add(layer.Name);
                }
                layerTreeView.ExpandAll();
            }
        }
        #endregion

        //treeView节点绘制
        private void TreeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

        }

        //treeView鼠标抬起3
        private void LayerTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            //右键抬起产生菜单
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = layerTreeView.GetNodeAt(ClickPoint);
                if (CurrentNode == null|| CurrentNode.Parent == null)
                    return;
                layerTreeView.SelectedNode = CurrentNode;
                layerContextMenuStrip.Show(layerTreeView, ClickPoint);
            }
        }

        //treeView右键菜单中属性选项被按下
        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer curLayer = map.GetLayerByName(layerTreeView.SelectedNode.Text);
            LayerProperties layerProperties = new LayerProperties(curLayer);
            //TODO：MAP绘制事件
            layerProperties.FinishSettingLayer += drawForTest;
            layerProperties.Show();
        }

        private void drawForTest(object s)
        {

        }

        private void 打开属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer curLayer = map.GetLayerByName(layerTreeView.SelectedNode.Text);
            attributeList attribute = new attributeList(curLayer.MRecords);
            attribute.Show();
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                map.SaveProject(saveProjectFileDialog.FileName);
            }
        }

        //显示鼠标位置
        private void McMap_MouseMove(object sender, MouseEventArgs e)
        {
            PointD sMouseLocation = new PointD(e.Location.X, e.Location.Y);
            PointD sPointOnMap = mcMap.ToMapPoint(sMouseLocation);
            statusPosition.Text = "X:" + sPointOnMap.X.ToString("0.00") + " Y:" +
                sPointOnMap.Y.ToString("0.00");
        }

        private void 平移_Click(object sender, EventArgs e)
        {
            mcMap.Pan();
        }

        private void 放大_Click(object sender, EventArgs e)
        {
            mcMap.ZoomIn();
        }

        private void 缩小_Click(object sender, EventArgs e)
        {
            mcMap.ZoomOut();
        }
    }
}
