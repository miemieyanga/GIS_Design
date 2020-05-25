using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.IO;

namespace ClassLibraryIofly
{
    public class GeoDataIO
    {
        //private GeoRecordset geoRecordset = new GeoRecordset();
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
                    tempColumnName = Encoding.GetEncoding("UTF-8").GetString(fieldNameAscii).Trim();  // 将字段名称（Ascii）转为字符串
                    tempColumnName = tempColumnName.Replace("\0", "");
                    //获取字段的类型
                    tempBytes = br.ReadBytes(1);
                    fieldType = Encoding.GetEncoding("UTF-8").GetString(tempBytes).Trim();
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
            if (tempbyte == 0x0D)
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
                                    string tempStr1 = Encoding.GetEncoding("UTF-8").GetString(tempBytes).Trim();
                                    int tempNum = Convert.ToInt32(tempStr1);
                                    geoRecordset.records.Item(i).Append(tempNum);
                                    //Property.RecordList.Set_Value(i, tempNum);
                                    //temp.Add(tempNum);
                                    break;
                                case "double":
                                    string tempStr2 = Encoding.GetEncoding("UTF-8").GetString(tempBytes).Trim();
                                    double tempDouble =Convert.ToDouble(tempStr2);
                                    geoRecordset.records.Item(i).Append(tempDouble);
                                    //Property.RecordList.Set_Value(i, tempDouble);
                                    //temp.Add(tempDouble);
                                    break;
                                case "string":
                                    string tempStr3 = Encoding.GetEncoding("UTF-8").GetString(tempBytes).Trim();
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
            fields.Append(value);
            fields.Append(type);
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

        public bool SaveToBitMap(string filename, GeoRecordset geoset)
        {
            return true;
        }

    }
}
