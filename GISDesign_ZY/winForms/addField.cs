using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryIofly;

namespace GISFinal
{
    public partial class addField : Form
    {
        GeoRecordset recordset;
        public addField(GeoRecordset geoRecordset)
        {
            
            InitializeComponent();
            recordset = geoRecordset;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string fname = nameInput.Text;
            string type = typeSelect.Text;
            string svalue = valueInput.Text;
            object value;
            int ivalue;
            if (type == "double")
                value = Convert.ToDouble(svalue);
            else if (type == "int")
                value = Convert.ToInt32(svalue);
            else
                value = Convert.ToString(svalue);
            recordset.fields.Append(new Field(fname, type));
            for(int i=0;i<recordset.records.Count();i++)
            {
                recordset.records.Item(i).Append(value);
            }
            
            this.Close();
            
        }

        private void typeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
