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
using GISDesign_ZY.winForms;

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
            mcMap._Layers = map.Layers;
            ShowScale();
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
                if (map.projection == null)
                {
                    map.projection = new ProjectionETC();
                }
                Layer cl = map.Layers[map.Layers.Count - 1];
                map.projection.LngLatToXY(cl);
                mcMap.Extent(map.Layers[map.Layers.Count - 1]);
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
                mcMap.Extent(map.GetExtent());
            }
        }
        #endregion

        //显示比例尺
        private void ShowScale()
        {
            statusScale.Text = "1:" + mcMap.DisplayScale.ToString("0.00");
        }


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
            layerProperties.FinishSettingLayer += drawForTest;
            layerProperties.FinishSettingLabel += DrawText;
            layerProperties.Show();
        }

        private void DrawText(object sender)
        {
            mcMap.Refresh();
        }

        private void drawForTest(object s)
        {
            mcMap.Extent(map.GetLayerByName(layerTreeView.SelectedNode.Text));
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

        private void LayerTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void LayerTreeView_DragDrop(object sender, DragEventArgs e)
        {
            Point Position = new Point();
            TreeNode myNode = null;
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                myNode = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
            }
            else
            {
                MessageBox.Show("error");
            }
            Position.X = e.X;
            Position.Y = e.Y;
            Position = layerTreeView.PointToClient(Position);
            TreeNode DropNode = this.layerTreeView.GetNodeAt(Position);
            // 1.目标节点不是空。2.目标节点不是被拖拽接点的字节点。3.目标节点不是被拖拽节点本身
            if (DropNode != null && DropNode.Parent != myNode && DropNode != myNode)
            {
                TreeNode DragNode = (TreeNode)myNode.Clone();
                // 将被拖拽节点从原来位置删除。
                myNode.Remove();
                // 在目标节点下增加被拖拽节点
                int index = layerTreeView.Nodes[0].Nodes.IndexOf(DropNode);
                layerTreeView.Nodes[0].Nodes.Insert(index,myNode);
            }
            // 如果目标节点不存在，即拖拽的位置不存在节点，那么就将被拖拽节点放在根节点之下
            if (DropNode == null)
            {
                TreeNode DragNode = (TreeNode)myNode.Clone();
                myNode.Remove();
                layerTreeView.Nodes[0].Nodes.Add(DragNode);
            }

            //跟新图层顺序
            List<Layer> res = new List<Layer>();
            for(int i=0;i< layerTreeView.Nodes[0].Nodes.Count; i++)
            {
                string n = layerTreeView.Nodes[0].Nodes[i].Text;
                Layer layer = map.GetLayerByName(n);
                res.Add(layer);
            }
            map.Layers = res;
            mcMap._Layers = res;
            mcMap.Refresh();
        }

        private void LayerTreeView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        //框选完成
        private void McMap_SelectingByBoxFinished(object sender, RectangleD box)
        {
            Layer[] sLayers = mcMap.SelectByBox(box);   //选中要素图层集合
            mcMap.SelectedLayers = sLayers;
            mcMap.Refresh();
        }

        //点选完成
        private void McMap_SelectingByPointFinished(object sender, PointD point)
        {
            Layer[] sLayers = mcMap.SelectByPoint(point);   //选中要素图层集合
            mcMap.SelectedLayers = sLayers;
            mcMap.Refresh();
        }

        //地图比例尺发生了变化
        private void McMap_DisplayScaleChanged(object sender)
        {
            ShowScale();
        }

        private void 选择要素_Click(object sender, EventArgs e)
        {
            mcMap.SelectFeature();
        }

        private void 选择要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mcMap.SelectFeature();
        }

        private void 按属性选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selByAttriInMainForm selByAttri = new selByAttriInMainForm(mcMap, map);
            selByAttri.Show();
        }

        private void 添加指北针ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mcMap.GetCompass();
        }

        private void 添加比例尺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mcMap.GetScale();
        }

        private void 缩放至图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer curLayer = map.GetLayerByName(layerTreeView.SelectedNode.Text);
            mcMap.Extent(curLayer);
        }

        private void 添加静态注记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mcMap.AddStaticNotes();
        }

        private void 添加要素ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddFeatureFrm addFeatureFrm = new AddFeatureFrm(mcMap, map);
            if (addFeatureFrm.ShowDialog(this) == DialogResult.OK)
            {
                Layer layer = addFeatureFrm.ChosenLayer;
                if(layer != null)
                    mcMap.TrackFeature(layer);
            }
            addFeatureFrm.Dispose();
        }

        private void 编辑选中要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFeatureFrm addFeatureFrm = new AddFeatureFrm(mcMap, map);
            if (addFeatureFrm.ShowDialog(this) == DialogResult.OK)
            {
                Layer layer = addFeatureFrm.ChosenLayer;
                if (layer != null)
                    mcMap.EditLayer(layer);
            }
            addFeatureFrm.Dispose();
        }
    }
}
