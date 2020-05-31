using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GISDesign_ZY.winForms
{
    public partial class AddFeatureFrm : Form
    {
        public AddFeatureFrm(MapControl mcmap, MapManager map)
        {
            InitializeComponent();
            mcMap = mcmap;
            Map = map;
            foreach (Layer layer in Map.Layers)
            {
                comboBox1.Items.Add(layer.Name);
            }
            if(comboBox1.Items.Count>0)
                comboBox1.Text = comboBox1.Items[0].ToString();
        }

        #region 字段

        private MapControl mcMap;
        private MapManager Map;
        private Layer layer;

        #endregion

        #region 属性

        /// <summary>
        /// 获取选中图层
        /// </summary>
        public Layer ChosenLayer
        {
            get { return layer; }
        }



        #endregion

        #region 事件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer = Map.GetLayerByName(comboBox1.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
