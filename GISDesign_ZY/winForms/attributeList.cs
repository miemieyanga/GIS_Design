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

        /// <summary>
        /// 编辑属性值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int numRecord = e.RowIndex;
            int numField = e.ColumnIndex;
            object temp = dataGridView1[numField, numRecord].Value;
            string type = recordset.fields.Item(numField+1).valueType;
            object temp2;
            switch(type)
            {
                case "int":
                    temp2 = Convert.ToInt32(temp);
                    break;

                case "string":
                    temp2 = Convert.ToString(temp);
                    break;

                case "double":
                    temp2 = Convert.ToDouble(temp);
                    break;

                default:
                    temp2 = Convert.ToString(temp);
                    break;
            }
            recordset.records.Item(numRecord).SetValue(numField+1, temp2);
        }
    }
}
