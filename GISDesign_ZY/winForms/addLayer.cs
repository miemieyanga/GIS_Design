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
    public partial class addLayer : Form
    {
        public Layer newLayer;

        public addLayer()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addLayer_Load(object sender, EventArgs e)
        {
            typeSelect.SelectedIndex = 0;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Dispose();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            newLayer = new Layer(0,nameInput.Text, typeSelect.SelectedItem.ToString(),commentInput.Text);
            Field type = new Field("类型", "string");
            Field value = new Field("值", "value");
            newLayer.MRecords.fields.Append(type);
            newLayer.MRecords.fields.Append(value);
            this.DialogResult = DialogResult.OK;
            Dispose();
        }
    }
}
