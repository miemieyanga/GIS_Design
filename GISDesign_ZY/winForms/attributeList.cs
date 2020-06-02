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
using GISDesign_ZY;

namespace GISFinal
{
    public partial class attributeList : Form
    {
        public GeoRecordset recordset;
        private GeoRecordset tempset;
        public GeoRecordset selGoerecordset;
        public List<GeoRecordset> historyGeorecordset=new List<GeoRecordset>();
        MapControl mapControl;
        public attributeList(Layer layer, MapControl mcMap)
        {
            InitializeComponent();
            this.dataGridView1.DataSource= layer.MRecords.GetDataTable();
            recordset = layer.MRecords;
            tempset = new GeoRecordset(recordset.fields, recordset.records);
           if(mcMap.SelectedLayers.Count()>=1)
                selGoerecordset = mcMap.SelectedLayers.Last().MRecords;   //这里可改进
            mapControl = mcMap;
        }

        private void 添加字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyGeorecordset.Add(new GeoRecordset(recordset.fields.Clone(), recordset.records.Clone()));
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
            historyGeorecordset.Add(new GeoRecordset(recordset.fields.Clone(), recordset.records.Clone()));
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

        private void 已选记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapControl.SelectedLayers.Count() == 1)
            {
                selGoerecordset = mapControl.SelectedLayers[0].MRecords;
                if(selGoerecordset.fields.Count()>0)
                {
                    this.dataGridView1.DataSource = selGoerecordset.GetDataTable();
                }
                
            }

        }

        private void 所有记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = recordset.GetDataTable();
        }

        private void 撤销修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(historyGeorecordset.Count()>0)
            {
                recordset = historyGeorecordset.Last();
                historyGeorecordset.RemoveAt(historyGeorecordset.Count() - 1);
                this.dataGridView1.DataSource = recordset.GetDataTable();
            }

        }

        private void 删除字段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyGeorecordset.Add(new GeoRecordset(recordset.fields.Clone(), recordset.records.Clone()));
            delField del = new delField(recordset);
            del.Show();
        }
    }
}
