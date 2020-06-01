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


namespace GISFinal
{
    public partial class IdentifyResultForm : Form
    {
        private MapControl mcMap;
        public IdentifyResultForm(MapControl mapControl)
        {
            InitializeComponent();
            mcMap = mapControl;
            if (mcMap.SelectedLayers.Count() >= 1)
                this.dataGridView1.DataSource = mcMap.SelectedLayers.Last().MRecords.GetDataTable();
        }


    }
}
