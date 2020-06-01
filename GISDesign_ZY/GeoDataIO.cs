using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.IO;
using GISFinal;
using GISDesign_ZY;

namespace ClassLibraryIofly
{

    [Serializable]
    public class GeoDataIO
    {
        //private GeoRecordset geoRecordset = new GeoRecordset();
        public string myEncoding = "utf-8";
        public GeoDataIO()
        {

        }



        /// <summary>
        /// 读取DBF文件中的属性数据
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="geoRecordset"></param>
        /// <returns></returns>
        public GeoRecordset ReadDbf(string filename, GeoRecordset geoRecordset)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            //跳过前面4个
            br.ReadBytes(4);
            //文件中的记录数，即行数
            int RowCount = br.ReadInt32();
            //文件头的长度
            int HeadLength = br.ReadInt16();
            //每行的长度
            int RowLength = br.ReadInt16();
            //计算字段数目
            int ColumnCount = (HeadLength - 33) / 32;
            //跳过20个，直接到32
            br.ReadBytes(20);

            int i, j;
            byte[] tempBytes = null;
            byte tempbyte;
            string fieldType = null;
            string[] sFieldType = null;
            int[] fieldLength = null;

            // 添加表格的列
            if (ColumnCount > 0)
            {
                
                fieldLength = new int[ColumnCount];
                sFieldType = new string[ColumnCount];
                for (i = 0; i < ColumnCount; i++)
                {
                    string tempColumnName;  //存储字段的名称
                    //提前读取11个为列名称

                    Byte[] fieldNameAscii = br.ReadBytes(11);    // 字段名称（Ascii）
                    tempColumnName = Encoding.GetEncoding(myEncoding).GetString(fieldNameAscii).Trim();  // 将字段名称（Ascii）转为字符串
                    tempColumnName = tempColumnName.Replace("\0", "");
                    //获取字段的类型
                    tempBytes = br.ReadBytes(1);
                    fieldType = Encoding.GetEncoding(myEncoding).GetString(tempBytes).Trim();
                    fieldType = fieldType.Replace("\0", "");
                    //fieldType = DataConstant.ConvertBytesToString(tempBytes);
                    switch (fieldType)
                    {
                        case "N":
                            sFieldType[i] = "double";
                            break;
                        case "F":
                            sFieldType[i] = "double";   //其实这个是float型，但是没有定义dbFloat，所以用了double
                            break;
                        case "C":
                            sFieldType[i] = "string";
                            break;
                        case "I":
                            sFieldType[i] = "int";
                            break;
                        case "B":
                            sFieldType[i] = "double";
                            break;
                        default:
                            sFieldType[i] = "string";
                            break;
                    }
                    //再跳过4个
                    br.ReadBytes(4);
                    //获取字段长度
                    tempbyte = br.ReadByte();
                    fieldLength[i] = (int)tempbyte;
                    //跳过剩下的字节，15个
                    br.ReadBytes(15);
                    //新加Field
                    Field tempField = new Field(tempColumnName, sFieldType[i]);
                    geoRecordset.fields.Append(tempField);
                    //Property.FieldsList.Append(new Field(tempColumnName, sFieldType[i]));
                }
            }

            //获取头文件的最后一个字节，值应为0D
            tempbyte = br.ReadByte();
            if (tempbyte == 0x0D) //tempbyte == 0x0D
            {
                //添加表格的行及数据
                if (RowCount > 0)
                {
                    for (i = 0; i < RowCount; i++)
                    {
                        //List<Record> sRec = Property.RecordList;
                        //每行数据中第一个20，跳过
                        br.ReadByte();
                        //新建一个列表，待会儿插入record第二项，用于储存属性
                        //List<object> temp=new List<object>();
                        for (j = 0; j < ColumnCount; j++)
                        {
                            tempBytes = br.ReadBytes(fieldLength[j]);
                            //string tempStr = Encoding.GetEncoding("GBK").GetString(tempBytes).Trim();
                            switch (sFieldType[j])
                            {
                                case "int":
                                    string tempStr1 = Encoding.GetEncoding(myEncoding).GetString(tempBytes).Trim();
                                    int tempNum = Convert.ToInt32(tempStr1);
                                    geoRecordset.records.Item(i).Append(tempNum);
                                    //Property.RecordList.Set_Value(i, tempNum);
                                    //temp.Add(tempNum);
                                    break;
                                case "double":
                                    string tempStr2 = Encoding.GetEncoding(myEncoding).GetString(tempBytes).Trim();
                                    //string tempStr2 = Encoding.ASCII.GetString(tempBytes).Trim();
                                    double tempDouble;
                                    try
                                    {
                                        tempDouble = Convert.ToDouble(tempStr2);
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            tempDouble = BitConverter.ToDouble(tempBytes, 0);
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                tempDouble =(double) Convert.ToSingle(tempStr2);
                                            }
                                            catch
                                            {
                                                tempDouble =(double) BitConverter.ToSingle(tempBytes, 0);
                                            }
                                        }
                                        
                                    }

                                    //
                                    geoRecordset.records.Item(i).Append(tempDouble);
                                    //Property.RecordList.Set_Value(i, tempDouble);
                                    //temp.Add(tempDouble);
                                    break;
                                case "string":
                                    string tempStr3 = Encoding.GetEncoding(myEncoding).GetString(tempBytes);
                                    tempStr3= tempStr3.Replace("\0", "");
                                    tempStr3 = tempStr3.Trim();
                                    geoRecordset.records.Item(i).Append(tempStr3);
                                    //temp.Add(tempStr);
                                    break;
                            }
                        }
                        //Property._Records.Set_Value(i, temp);
                    }
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            br.Close();
            fs.Close();
            //SaveMap("d://mymap2.map");//保存为mymap
            //ReadMap("d://mymap2.map");
            return geoRecordset;
        }


        /// <summary>
        /// 读取SHP文件中的要素数据
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public GeoRecordset ReadShp(string filename)
        {
           
            shp读取.Shapefile shp = new shp读取.Shapefile(filename);
            shp读取.FeatureClass fc = shp.GetFeature();
            List<shp读取.PointFeature> pts = fc.points;
            List<shp读取.PolylineFeature> pls = fc.polylines;
            List<shp读取.PolygonFeature> pgs = fc.polygons;
 
            Fields fields = new Fields();
            Records records = new Records();
            Field type = new Field("类型", "string");
            Field value = new Field("值", "value");
            fields.Append(type);
            fields.Append(value);
            
            if(pts!=null)
            {
                PointD[] points = new PointD[pts.Count];
                for (int i = 0; i < pts.Count; i++)
                {
                    points[i] = new PointD(pts[i].x, pts[i].y);
                    object[] objs = new object[2];
                    objs[0] = "PointD";
                    objs[1] = points[i];
                    Record record = new Record(objs);
                    records.Append(record);
                }
            }
            if(pls!=null)
            {
                Polyline[] polylines = new Polyline[pls.Count];
                for (int i = 0; i < pls.Count; i++)
                {
                    PointD[] temppts = new PointD[pls[i].points.Count()];
                    for (int j = 0; j < pls[i].points.Count(); j++)
                    {
                        temppts[j] = new PointD(pls[i].points[j].X, pls[i].points[j].Y);
                    }
                    polylines[i] = new Polyline(temppts);
                    object[] objs = new object[2];
                    objs[0] = "Polyline";
                    objs[1] = polylines[i];
                    Record record = new Record(objs);
                    records.Append(record);
                }
            }

            if(pgs!=null)
            {
                Polygon[] polygons = new Polygon[pgs.Count];
                for (int i = 0; i < pgs.Count; i++)
                {
                    PointD[] temppts = new PointD[pgs[i].points.Count()];
                    for (int j = 0; j < pgs[i].points.Count(); j++)
                    {
                        temppts[j] = new PointD(pgs[i].points[j].X, pgs[i].points[j].Y);
                    }
                    polygons[i] = new Polygon(temppts);
                    object[] objs = new object[2];
                    objs[0] = "Polygon";
                    objs[1] = polygons[i];
                    Record record = new Record(objs);
                    records.Append(record);
                }
            }

            //geoRecordset.fields = fields;
            //geoRecordset.records = records;

            

            return new GeoRecordset(fields,records);
        }


        /// <summary>
        /// 读取SHP文件和DBF文件，参数为SHP文件完整路径
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public GeoRecordset OpenShapeFile(string filename)
        {
            string shpFilename = filename;
            string dbfFilename = filename.Substring(0, filename.Length - 3) + "dbf";
            GeoRecordset geoRecordset = ReadShp(shpFilename);
            geoRecordset = ReadDbf(dbfFilename, geoRecordset);
            return geoRecordset;
        }

        /// <summary>
        /// 将要素数据写入SHP文件
        /// </summary>
        /// <param name="filename"></param>
        public void WriteShp(string filename, Layer layer)
        {
            FileStream fs = new FileStream(filename+"shp", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < 6; i++)
                bw.Write(0);

            Int32 TypeCode;//要素类型对应的编码
            Int32 FileLength = 100;//文件长度，初值为头文件长度50
            Records records = layer.MRecords.records;
            switch(layer.FeatureType)
            {
                case FeatureTypeConstant.PointD:
                    TypeCode = 1;
                    for (int i = 0; i < records.Count(); i++)
                    {
                        FileLength += 28;
                    }
                    break;

                case FeatureTypeConstant.Polyline:
                    TypeCode = 3;
                    for (int i = 0; i < records.Count(); i++)
                    {
                        FileLength += 100;
                    }
                    break;

                case FeatureTypeConstant.Polygon:
                    TypeCode = 5;
                    break;
                default:
                    throw new FileLoadException("不支持的数据类型");
            }
            bw.Write(shp读取.Shapefile.ReverseByte(FileLength));
            bw.Write(1000);//写入版本号
            bw.Write(TypeCode);//写入几何类型
                               //写入MBR数据
            bw.Write(layer.GetExtent().MinX);
            bw.Write(layer.GetExtent().MinY);
            bw.Write(layer.GetExtent().MaxX);
            bw.Write(layer.GetExtent().MaxY);
            //最大、最小Z值、M值为0
            for (int i = 0; i < 4; i++)
            {
                bw.Write((double)0);
            }

            //写空间数据
            switch (TypeCode)
            {
                case 1://空间数据几何类型为点                   
                    {
                        int RecordNum = records.Count();
                        for (int i = 0; i < RecordNum; i++)
                        {
                            bw.Write(shp读取.Shapefile.ReverseByte(i + 1));//ID
                            bw.Write(shp读取.Shapefile.ReverseByte(10));//坐标记录长度
                            bw.Write(1);//几何类型
                                        //坐标信息
                            PointD mpoint = (PointD)records.Item(i).Value(1);
                            bw.Write(mpoint.X);
                            bw.Write(mpoint.Y);
                        }
                    }
                    break;
                case 3://空间数据几何类型为线
                    {


                        int RecordNum = records.Count();
                        for (int i = 0; i < RecordNum; i++)
                        {
                            bw.Write(shp读取.Shapefile.ReverseByte(i + 1));//ID

                            Polyline mPolyLine = (Polyline)records.Item(i).Value(1);
                            bw.Write(shp读取.Shapefile.ReverseByte(100));//坐标记录长度
                            bw.Write(3);//写入几何类型
                                        //MBR数据
                            bw.Write(mPolyLine.GetEnvelope().MinX);
                            bw.Write(mPolyLine.GetEnvelope().MinY);
                            bw.Write(mPolyLine.GetEnvelope().MaxX);
                            bw.Write(mPolyLine.GetEnvelope().MaxY);
                            Int32 NumParts = 1;
                            bw.Write(NumParts);//子线段个数
                            Int32 NumPoints =  mPolyLine.PointCount;
                            bw.Write(NumPoints);//点个数
                            Int32 parts = 0;
                            bw.Write(parts);//每个子线段的点坐标信息在所有点坐标信息中的起始位置，第一个为0

                            //点坐标信息
                            for (int k = 0; k < NumPoints; k++)
                            {
                                bw.Write(mPolyLine.GetPointD(k).X);
                                bw.Write(mPolyLine.GetPointD(k).Y);

                            }
                        }
                    }
                    break;
                case 5://空间数据几何类型为多边形
                    {
                        int RecordNum = records.Count();
                        for (int i = 0; i < RecordNum; i++)
                        {
                            bw.Write(shp读取.Shapefile.ReverseByte(i + 1));//ID

                            Polygon mPolygon = (Polygon)records.Item(i).Value(1);
                            bw.Write(shp读取.Shapefile.ReverseByte(100));//坐标记录长度
                            bw.Write(5);//写入几何类型
                                        //MBR数据
                            bw.Write(mPolygon.GetEnvelope().MinX);
                            bw.Write(mPolygon.GetEnvelope().MinY);
                            bw.Write(mPolygon.GetEnvelope().MaxX);
                            bw.Write(mPolygon.GetEnvelope().MaxY);
                            Int32 NumParts = 1;
                            bw.Write(NumParts);//子环个数
                            Int32 NumPoints = mPolygon.PointCount;
                            bw.Write(NumPoints);//点个数
                            Int32 parts = 0;
                            bw.Write(parts);//每个子环的点坐标信息在所有点坐标信息中的起始位置，第一个为0

                            for(int j=0;j<mPolygon.PointCount;j++)
                            {
                                bw.Write(mPolygon.GetPointD(j).X);
                                bw.Write(mPolygon.GetPointD(j).Y);
                            }
                            //bw.Write(mPolygon.GetPointD(0).X);
                            //bw.Write(mPolygon.GetPointD(0).Y);

                        }
                    }
                    break;
                default:
                    throw new FileLoadException("不支持的数据类型");
            }
            bw.Dispose();
            fs.Dispose();

        }

        /// <summary>
        /// 将属性数据写入DBF文件
        /// </summary>
        /// <param name="filename"></param>
        public void WriteDbf(string filename, Layer layer)
        {
            FileStream fs = new FileStream(filename + "dbf", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            Records records = layer.MRecords.records;
            Fields fields = layer.MRecords.fields;
            int numField = fields.Count() - 2;
            int num = numField * 32 + 33;
            int numRecord = records.Count();
            bw.Write((byte)0);  //版本
            bw.Write((byte)20); //年
            bw.Write((byte)06); //月
            bw.Write((byte)02); //日

            bw.Write(numRecord);  //文件中的记录条数

            bw.Write((Int16)num); //文件头中的字节数
            bw.Write((Int16)10000); //一条记录中的字节长度，由于长度不好确定，随便赋个值
            for(int i=0;i<20;i++)
            {
                bw.Write((byte)0); //这部分信息暂时无用
            }
            //写入字段信息
            for (int i = 0; i < numField; i++)
            {
                string fieldName = fields.Item(i + 2).name;
                fieldName = fieldName.PadRight(11, '\0');
                Byte[] fieldNameAscii = System.Text.Encoding.ASCII.GetBytes(fieldName); // 将字段名称转为Ascii码
                bw.Write(fieldNameAscii);
                int fieldByteLen;
                switch(fields.Item(i+2).valueType)
                {
                    case "int":
                        byte[] typeIAscii = System.Text.Encoding.ASCII.GetBytes("I");
                        bw.Write(typeIAscii);
                        fieldByteLen = 4;
                        break;

                    case "double":
                        byte[] typeBAscii = System.Text.Encoding.ASCII.GetBytes("B");
                        bw.Write(typeBAscii);
                        fieldByteLen = 8;
                        break;

                    case "string":
                        byte[] typeCAscii = System.Text.Encoding.ASCII.GetBytes("C");
                        bw.Write(typeCAscii);
                        fieldByteLen = 128;
                        break;

                    default:
                        byte[] typeAscii = System.Text.Encoding.ASCII.GetBytes("C");
                        bw.Write(typeAscii);
                        fieldByteLen = 128;
                        break;
                }

                bw.Write(0);
                bw.Write((byte)fieldByteLen);
                for(int x=0; x<15;x++)
                {
                    bw.Write((byte)0);
                }

            }

            bw.Write((byte)0x0D);

            //写入属性信息
            for(int i=0;i<numRecord;i++)
            {
                bw.Write((byte)0x20);
                for(int j=2;j<records.Item(i).Count();j++)
                {
                    object value = records.Item(i).Value(j);
                    switch(fields.Item(j).valueType)
                    {
                        case "int":
                            Int32 valueInt;
                            if (value == null)
                                valueInt = 0;
                            else
                                valueInt = (Int32)value;
                            bw.Write(valueInt);
                            break;

                        case "double":
                            double valueDouble;
                            if (value == null)
                                valueDouble = 0;
                            else
                                valueDouble = (double)value;

                            bw.Write(valueDouble);
                            break;

                        case "string":
                            string valueStr;
                            if (value == null)
                                valueStr = "";
                            else
                                valueStr = (string)value;
                            //valueStr = valueStr.PadRight(128, '\0');
                            valueStr=valueStr.Trim();
                            int len = System.Text.Encoding.UTF8.GetBytes(valueStr).Length;
                            int delta = 2 * len / 3;
                            valueStr = valueStr.PadRight(128-delta, '\0');
                            byte[] str = System.Text.Encoding.UTF8.GetBytes(valueStr);
                            bw.Write(str);
                            break;

                        default:
                            string valueStr2;
                            if (value == null)
                                valueStr2 = "";
                            else
                                valueStr2 = (string)value;
                            valueStr2 = valueStr2.Trim();
                            int len2 = System.Text.Encoding.UTF8.GetBytes(valueStr2).Length;
                            int delta2 = 2 * len2 / 3;
                            valueStr2 = valueStr2.PadRight(128 - delta2, '\0');
                            byte[] str2 = System.Text.Encoding.UTF8.GetBytes(valueStr2);
                            bw.Write(str2);
                            break;
                    }
                }
            }

            bw.Write((byte)0x1A);
            bw.Dispose();
            fs.Dispose();
        }

        public void SaveShapeFile(string filename, Layer layer)
        {
            ProjectionETC projectionETC = new ProjectionETC();
            projectionETC.XYToLnglat(layer);
            WriteShp(filename, layer);
            WriteDbf(filename, layer);
        }


        public bool SaveToBitMap(string filename, MapControl mapControl)
        {
            Bitmap bmp = mapControl.GetBitmap();
            //FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            //bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
            bmp.Save(filename);
            return true;
        }

    }
}
