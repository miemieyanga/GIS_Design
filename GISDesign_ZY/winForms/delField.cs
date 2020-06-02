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
    public partial class delField : Form
    {
        private GeoRecordset recordset;
        public delField(GeoRecordset georecordset)
        {
            InitializeComponent();
            recordset = georecordset;
            for(int i=0; i<recordset.fields.Count();i++)
            {
                fieldSelect.Items.Add(recordset.fields.Item(i).name);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string name = fieldSelect.Text;
            int index = recordset.fields.GetIndexOfField(name);
            recordset.DeleteField(index);
            this.Close();
        }
    }
}
