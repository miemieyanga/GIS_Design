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
    public partial class selectByAttribute : Form
    {
        GeoRecordset recordset;
        GeoRecordset tempset;
        public selectByAttribute(GeoRecordset geoRecordset, GeoRecordset temp)
        {
            InitializeComponent();
            recordset = geoRecordset;
            tempset=temp;
        }

        private void selectByAttribute_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            string fname = fieldSelect.Text;
            string condition = conditionSelect.Text;
            string value = textBox1.Text;

            GeoRecordset newRecordset = recordset.SelectByField(fname, condition, value);
            tempset.fields = newRecordset.fields;
            tempset.records = newRecordset.records;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
