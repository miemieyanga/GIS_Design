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
    public partial class attributeList : Form
    {
        public GeoRecordset recordset;
        private GeoRecordset tempset;
        public attributeList(GeoRecordset geoRecordset)
        {
            InitializeComponent();
            this.dataGridView1.DataSource= geoRecordset.GetDataTable();
            recordset = geoRecordset;
            tempset = new GeoRecordset(recordset.fields, recordset.records);
        }

        private void 添加字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addField addfield = new addField(recordset);
            addfield.Show();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = recordset.GetDataTable();
            this.dataGridView1.DataSource = tempset.GetDataTable();
            tempset.fields = recordset.fields;
            tempset.records = recordset.records;
        }

        private void 属性查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectByAttribute ByAttribute = new selectByAttribute(recordset, tempset);
            ByAttribute.Show();
        }
    }
}
