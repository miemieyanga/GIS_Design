using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ClassLibraryIofly
{
    public class GeoDataIO
    {
        public GeoDataIO()
        {

        }
        public bool SaveToBitMap(string filename, GeoRecordset geoset)
        {
            return true;
        }

        public GeoRecordset OpenShapeFile(string filename)
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



            

            return new GeoRecordset(fields,records);
        }
    }
}
