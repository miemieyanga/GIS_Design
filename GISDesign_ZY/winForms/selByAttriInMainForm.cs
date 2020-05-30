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
    public partial class selByAttriInMainForm : Form
    {
        private MapControl mcMap;
        private MapManager Map;
        Layer selLayer;
        public selByAttriInMainForm(MapControl mcmap, MapManager map)
        {
            InitializeComponent();
            mcMap = mcmap;
            Map = map;
            foreach (Layer layer in Map.Layers)
            {
                layerSelect.Items.Add(layer.Name);
            }

        }



        private void layerSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            selLayer = Map.GetLayerByName(layerSelect.Text);
            GeoRecordset recordset = selLayer.MRecords;
            for (int i = 0; i < recordset.fields.Count(); i++)
            {
                fieldSelect.Items.Add(recordset.fields.Item(i).name);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string fname = fieldSelect.Text;
            string condition = conditionSelect.Text;
            string value = textBox1.Text;

            GeoRecordset newRecordset = selLayer.MRecords.SelectByField(fname, condition, value);

            string name = selLayer.Name + "_SelectedFeatures";
            Layer layer = new Layer(name, selLayer.Descript);
            layer.FeatureType = selLayer.FeatureType;
            //存入选中要素坐标信息
            layer.MRecords = newRecordset;
            //List<Layer> layers = mcMap.SelectedLayers;
            Layer[] layers = new Layer[1];
            layers[0] = layer;
            mcMap.SelectedLayers=layers;
            mcMap.Refresh();
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
