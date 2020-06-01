using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ClassLibraryIofly
{

    /// <summary>
    /// GeoRecordset类
    /// </summary>
    /// 
    [Serializable]
    public class GeoRecordset
    {//todo: 判断record里面的值的类型是否和字段匹配
        public Fields fields;
        public Records records;
        public string valueType;

        public GeoRecordset()
        {

        }

        public GeoRecordset(string vType)
        {
            fields = new Fields();
            records = new Records();
            valueType = vType;
        }


        public GeoRecordset(Fields fs, Records rs)
        {
            fields = fs;
            records = rs;
            if (records.Count() > 0)
                valueType = records.Item(0).Value(0).ToString();
            else
                valueType = null;
        }

        public DataTable GetDataTable()
        {
            DataTable Data = new DataTable();
            Data.Columns.Add("FID");
            for (int i = 2; i < fields.Count(); i++)
            {
                Data.Columns.Add(fields.Item(i).name);
                
            }

            for (int i = 0; i < records.Count(); i++)
            {
                Data.Rows.Add();
                Data.Rows[i][0] = i;
                for (int j = 1; j < records.Item(i).Count() - 1; j++)
                {
                    if (records.Item(i).Value(j + 1)!=null)
                        Data.Rows[i][j] = records.Item(i).Value(j + 1).ToString();
                    else
                        Data.Rows[i][j] = "";
                }
            }
            return Data;
        }


        /// <summary>
        /// 检查是否所有记录值类型与对应字段相符
        /// </summary>
        /// <returns></returns>
        public bool CheckValueType()
        {
            for(int i=0;i<records.Count();i++)
            {
                for (int j = 0; j < fields.Count(); j++)
                {
                    if (records.Item(i).Value(j).GetType().Name != fields.Item(j).valueType)
                        return false;
                }
            }
            return true;
        }



        /// <summary>
        /// 根据field名称返回值集合
        /// </summary>
        /// <returns></returns>
        public List<object> GetValuesByField(string name)
        {
            int index = -1;
            List<object> values = new List<object>();
            //object[] values = new object[0];
            for(int i=0;i<fields.Count();i++)
            {
                if(name==fields.Item(i).name)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
                return values;
            else
            {
                for(int j=0;j<records.Count();j++)
                {
                    values.Add(records.Item(j).Value(index));
                }
                values = values.Distinct().ToList();
            }

            return values;
        }



        /// <summary>
        /// 根据索引号删除Field，同步删除相关联的record.value
        /// </summary>
        /// <param name="index"></param>
        public void DeleteField(int index)
        {
            fields.Delete(index);
            for (int i = 0; i < records.Count(); i++)
            {
                records.Item(i).Delete(index);
            }

        }

        /// <summary>
        /// 按属性选择，支持>、<、=三个简单条件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="condition"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public GeoRecordset SelectByField(string name, string condition, string value)
        {
            int index = fields.GetIndexOfField(name);
            Records newRecords = new Records();
            Fields newFields = fields;
            for(int i=0; i<records.Count();i++)
            {
                object tempValue = records.Item(i).Value(index);
                if (condition=="=")
                {
                    if (tempValue.ToString() == value && tempValue.GetType().Name == "string" )
                    {
                        newRecords.Append(records.Item(i));
                    }
                    else if (Convert.ToDouble(tempValue) == Convert.ToDouble(value) && tempValue.GetType().Name != "string")
                    {
                        newRecords.Append(records.Item(i));
                    }
                }
                else if(condition==">")
                {
                    if (Convert.ToDouble(tempValue) > Convert.ToDouble(value) && tempValue.GetType().Name != "string")
                    {
                        newRecords.Append(records.Item(i));
                    }

                }
                else if(condition=="<")
                {
                    if (Convert.ToDouble(tempValue) < Convert.ToDouble(value) && tempValue.GetType().Name != "string")
                    {
                        newRecords.Append(records.Item(i));
                    }
                }

                else
                {
                    return new GeoRecordset();
                }
            }
            return new GeoRecordset(newFields, newRecords);
        }

        /// <summary>
        /// 点选要素
        /// </summary>
        /// <param name="point"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public GeoRecordset SelectByPoint(PointD point, double tolerance)
        {
            Records newRecords = new Records();
            Fields newFeilds = fields;
            for (int i = 0; i < records.Count(); i++)
            {
                string valuetype = (string)(records.Item(i).Value(0));

                if (valuetype == typeof(PointD).Name)
                {
                    PointD tempPt = (PointD)records.Item(i).Value(1);

                    if (tempPt.isNearPoint(point, tolerance))
                    {
                        newRecords.Append(records.Item(i));
                    }
                }
                else if (valuetype == typeof(Polygon).Name)
                {
                    Polygon temppolygon = (Polygon)records.Item(i).Value(1);
                    if(temppolygon.isContainPoint(point))
                    {
                        newRecords.Append(records.Item(i));
                    }
                }
                else if (valuetype == typeof(MultiPolygon).Name)
                {
                    MultiPolygon tempmpolygon = (MultiPolygon)records.Item(i).Value(1);
                    if (tempmpolygon.isContainPoint(point))
                    {
                        newRecords.Append(records.Item(i));
                    }
                }
                else if (valuetype == typeof(Polyline).Name)
                {
                    Polyline temppolyline = (Polyline)records.Item(i).Value(1);
                    if(temppolyline.isNearPoint(point,tolerance))
                    {
                        newRecords.Append(records.Item(i));
                    }
                }
                else if(valuetype == typeof(MultiPolyline).Name)
                {
                    MultiPolyline tempmpolyline = (MultiPolyline)records.Item(i).Value(1);
                    if (tempmpolyline.isNearPoint(point, tolerance))
                    {
                        newRecords.Append(records.Item(i));
                    }
                }
            }
            return new GeoRecordset(newFeilds, newRecords);
        }


        /// <summary>
        /// 完全位于矩形内的图形被选中
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public GeoRecordset SelectByBox(RectangleD box)
        {
            Records newRecords = new Records();
            Fields newFeilds = fields;
            for (int i = 0; i < records.Count(); i++)
            {
                string valuetype = (string)(records.Item(i).Value(0));
                if (valuetype == typeof(PointD).Name)
                {
                    PointD tempPt = (PointD)records.Item(i).Value(1);

                    if (tempPt.isInBox(box))
                    {
                        newRecords.Append(records.Item(i));
                    }
                }
                else if (valuetype == typeof(Polygon).Name
                    || valuetype == typeof(MultiPolygon).Name
                    || valuetype == typeof(Polyline).Name
                    || valuetype == typeof(MultiPolyline).Name)
                {
                    object temp = records.Item(i).Value(1);
                    object[] para = new object[1];
                    para[0] = box;
                    object tempIsIn = temp.GetType().GetMethod("isInBox").Invoke(temp, para);
                    bool isIn = Convert.ToBoolean(tempIsIn);
                    if (isIn)
                    {
                        newRecords.Append(records.Item(i));
                    }
                }
            }

            return new GeoRecordset(newFeilds, newRecords);
        }



        /// <summary>
        /// 根据行索引号数组进行选择
        /// </summary>
        /// <param name="indices"></param>
        /// <returns></returns>
        public GeoRecordset SelectByIndices(int[] indices)
        {
            Records newRecords = new Records();
            for(int i=0; i<indices.Count();i++)
            {
                newRecords.Append(records.Item(indices[i]));
            }

            Fields newFeilds = fields;

            return new GeoRecordset(newFeilds, newRecords);
        }

    }


    /// <summary>
    /// Field类
    /// </summary>
    /// 
    [Serializable]
    public class Field
    {
        public string name;
        public string valueType;

        public Field(string n, string vt)
        {
            name = n;
            valueType = vt;
        }
    }


    /// <summary>
    /// Fields类
    /// </summary>
    /// 
    [Serializable]
    public class Fields
    {
        public Field[] fields;
        private List<Field> _fields = new List<Field>();

        public Fields()
        {

        }

        public Fields(Field[] fds)
        {
            _fields.AddRange(fds);
            fields = fds;
        }

        /// <summary>
        /// 根据字段名称返回字段索引,找不到返回-1
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public int GetIndexOfField(string name)
        {
            int index = -1;
            for (int i = 0; i < _fields.Count(); i++)
            {
                if (name == _fields[i].name)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }


        /// <summary>
        /// 根据索引号返回Field
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Field Item(int index)
        {
            return _fields[index];
        }


        /// <summary>
        /// 返回名字为name的第一个Field
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Field Item(string name)
        {
            int count = _fields.Count;
            for (int i = 0; i < count; i++)
            {
                if (_fields[i].name == name)
                {
                    return _fields[i];
                }
            }
            return null;
        }


        /// <summary>
        /// 返回fields的数量
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _fields.Count;
        }


        /// <summary>
        /// 添加field
        /// </summary>
        /// <param name="field"></param>
        public void Append(Field field)
        {
            _fields.Add(field);
        }

        ///
        /// <summary>
        /// 根据索引号移除field
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            _fields.Remove(_fields[index]);
            //_fields[index].name = "";
            //_fields[index].valueType = string;
        }


        public Fields Clone()
        {
            Fields newFields = new Fields();
            for(int i=0;i<Count();i++)
            {
                Field temp = new Field(_fields[i].name, _fields[i].valueType);
                newFields.Append(temp);
            }
            return newFields;
        }


    }


    /// <summary>
    /// Record类
    /// </summary>
    /// 
    [Serializable]
    public class Record
    {
        object[] values;
        List<object> _values = new List<object>();


        public Record(object[] v)
        {
            _values.AddRange(v);
            values = v;
        }

        /// <summary>
        /// 根据索引返回value
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object Value(int index)
        {
            return _values[index];
        }

        /// <summary>
        /// 返回value的数目
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _values.Count;
        }


        /// <summary>
        /// 添加value
        /// </summary>
        /// <param name="value"></param>
        public void Append(object value)
        {
            _values.Add(value);
        }


        /// <summary>
        /// 根据索引号删除value
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            _values.Remove(_values[index]);
            //_values[index] = "";
        }

        /// <summary>
        /// 设置value
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newValue"></param>
        public void SetValue(int index, object newValue)
        {
            _values[index] = newValue;
        }

    }


    /// <summary>
    /// Records类
    /// </summary>
    /// 
    [Serializable]
    public class Records
    {
        Record[] records;
        List<Record> _records = new List<Record>();

        public Records()
        {
            ;
        }
        public Records(Record[] rds)
        {
            _records.AddRange(rds);
            records = rds;
        }

        /// <summary>
        /// 根据索引号返回Record
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Record Item(int index)
        {
            return _records[index];
        }


        /// <summary>
        /// 返回Record数目
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _records.Count;
        }


        /// <summary>
        /// 添加Record
        /// </summary>
        /// <param name="record"></param>
        public void Append(Record record)
        {

            _records.Add(record);
        }


        /// <summary>
        /// 根据索引号删除Record
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            _records.Remove(_records[index]);
        }

        public Records Clone()
        {
            Records newRecords = new Records();
            for(int i=0;i<Count();i++)
            {
                object[] value = new object[Item(i).Count()];
                for(int j=0;j<Item(i).Count();j++)
                {
                    value[j] = Item(i).Value(j);
                }
                Record temp = new Record(value);
                newRecords.Append(temp);
            }
            return newRecords;
        }


    }

}
