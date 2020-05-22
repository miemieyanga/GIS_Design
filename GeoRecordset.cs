﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryIofly
{
    /// <summary>
    /// GeoRecordset类
    /// </summary>
    class GeoRecordset
    {
        public Fields fields;
        public Records records;


        public GeoRecordset()
        {
            ;
        }

        public GeoRecordset(Fields fs, Records rs)
        {
            fields = fs;
            records = rs;
        }

        public bool Open(string filename)
        {
            return true;
        }


        public bool Save(string filename)
        {
            return true;
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


        public GeoRecordset SelectByText(string text)
        {
            return new GeoRecordset();
        }

        public GeoRecordset SelectByPoint(PointD point)
        {
            return new GeoRecordset();
        }

        /// <summary>
        /// 完全位于矩形内的图形被选中
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public GeoRecordset SelectByBox(RectangleD box)
        {
            for (int i = 0; i < fields.Count(); i++)
            {
                if(fields.Item(i).valueType==typeof(PointD))
                {
                    ;
                }
                else if (fields.Item(i).valueType == typeof(Polygon) 
                    || fields.Item(i).valueType == typeof(MultiPolygon)
                    || fields.Item(i).valueType == typeof(Polyline)
                    || fields.Item(i).valueType == typeof(MultiPolyline))
                {
                    ;
                }
            }



            return new GeoRecordset();
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
    public class Field
    {
        public string name;
        public Type valueType;

        public Field(string n, Type vt)
        {
            name = n;
            valueType = vt;
        }
    }


    /// <summary>
    /// Fields类
    /// </summary>
    public class Fields
    {
        public Field[] fields;
        private List<Field> _fields = new List<Field>();

        public Fields(Field[] fds)
        {
            _fields.AddRange(fds);
            fields = fds;
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




    }


    /// <summary>
    /// Record类
    /// </summary>
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



    }


    /// <summary>
    /// Records类
    /// </summary>
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




    }

}
