using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryIofly;
using System.IO;

namespace GISDesign_ZY
{
    public class MapManager
    {
        #region 字段

        public string name;
        public List<Layer> Layers;
        private ProjectionType projectionType;  //投影类型
        public Projection projection;  //投影类

        private CoordinateType coordinateType;  //地理坐标系类型

        #endregion

        public MapManager()
        {
            Layers = new List<Layer>();
            coordinateType = CoordinateType.WGS84;
        }

        /// <summary>
        /// 设置投影类型
        /// </summary>
        public void SetProjection(ProjectionType t)
        {
            projectionType = t;
            switch (t)
            {
                case ProjectionType.None:  //没有投影
                    break;
                case ProjectionType.ETC:
                    projection = new ProjectionETC();
                    projection.LngLatToXY(this);
                    break;
                default:
                    throw new Exception("未实现的投影");
            }
        }

        public RectangleD GetExtent()
        {
            double minX = double.MaxValue, minY = double.MaxValue, 
                maxX = double.MinValue,maxY = double.MinValue;

            foreach(Layer layer in Layers)
            {
                RectangleD rectangleD = layer.GetExtent();
                if (rectangleD.MinX < minX)
                    minX = layer.MinX;
                if (rectangleD.MaxX > maxX)
                    maxX = layer.MaxX;
                if (rectangleD.MinY < minY)
                    minY = layer.MinY;
                if (rectangleD.MaxY > maxY)
                    maxY = layer.MaxY;
            }
            return new RectangleD(minX, minY, maxX, maxY);
        }

        /// <summary>
        /// 通过图层名称来获取图层
        /// </summary>
        public Layer GetLayerByName(string name)
        {
            foreach(Layer layer in Layers)
            {
                if(layer.Name == name)
                {
                    return layer;
                }
            }

            //找不到则报错
            throw new Exception("没有这样的图层");
        }

        /// <summary>
        /// 打开一个图层文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public Layer OpenLayerFile(string path)
        {
            char[] separator = {'\\'};
            string[] strs = path.Split(separator);
            string fileName = strs[strs.Length - 1];
            Layer tempLayer = new Layer(fileName.Substring(0,fileName.Length-4));
            tempLayer.MRecords =  tempLayer.MGeoDataIO.OpenShapeFile(path);
            tempLayer.DataSource = path;

            tempLayer.FeatureTypeString = tempLayer.MRecords.valueType;
            int cntOfRecords = tempLayer.MRecords.records.Count();
            List<PointD> points = new List<PointD>();
            switch (tempLayer.MRecords.valueType)
            {
                case "PointD":
                    tempLayer.FeatureType = FeatureTypeConstant.PointD;

                    for(int i=0;i< cntOfRecords; i++)
                    {
                        PointD curPointD = (PointD)tempLayer.MRecords.records.Item(i).Value(1);
                        points.Add(curPointD);
                    }
                    break;
                case "Polyline":
                    tempLayer.FeatureType = FeatureTypeConstant.Polyline;

                    for (int i = 0; i < cntOfRecords; i++)
                    {
                        Polyline curPolyline = (Polyline)tempLayer.MRecords.records.Item(i).Value(1);
                        points.AddRange(curPolyline.points.ToList());
                    }
                    break;
                case "Polygon":
                    tempLayer.FeatureType = FeatureTypeConstant.Polygon;

                    for (int i = 0; i < cntOfRecords; i++)
                    {
                        Polygon curPolyline = (Polygon)tempLayer.MRecords.records.Item(i).Value(1);
                        points.AddRange(curPolyline.points.ToList());
                    }
                    break;
                case "MultiPolygon":
                    tempLayer.FeatureType = FeatureTypeConstant.MultiPolygon;
                    break;
                case "MultiPolyline":
                    tempLayer.FeatureType = FeatureTypeConstant.MultiPolyline;
                    break;
            }

            RectangleD mbr = GetMBR(points.ToArray());
            tempLayer.SetExtent(mbr.MinX, mbr.MinY, mbr.MaxX, mbr.MaxY);
            tempLayer.MRenderer = RendererFactory.CreateSimpleRenderer(SymbolFactory.CreateSymbol(tempLayer.FeatureType));
            return tempLayer;
        }

        /// <summary>
        /// 保存一个图层文件
        /// </summary>
        /// <param name="layer">要保存的图层</param>
        /// <param name="path">文件路径</param>
        public void SaveLayer(Layer layer,string path)
        {

        }

        /// <summary>
        /// 打开一个项目文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public void OpenProjectFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Layers.Clear();

                string n = sr.ReadLine();
                name = n;
                string ct = sr.ReadLine();
                switch (ct)
                {
                    case "WGS84":
                        coordinateType = CoordinateType.WGS84;
                        break;
                    case "None":
                        coordinateType = CoordinateType.None;
                        break;
                    default:
                        throw new Exception("未实现的类型");
                }
                string pt = sr.ReadLine();
                switch (pt)
                {
                    case "ETC":
                        projectionType = ProjectionType.ETC;
                        projection = new ProjectionETC();
                        break;
                    case "None":
                        projectionType = ProjectionType.None;
                        break;
                    default:
                        throw new Exception("未实现的类型");
                }
                int numOfLayers = Convert.ToInt16(sr.ReadLine());
                for(int i = 0; i < numOfLayers; i++)
                {
                    string nameOfLayer = sr.ReadLine();
                    string descript = sr.ReadLine();
                    string curDatasource = sr.ReadLine();
                    Layer curLayer = OpenLayerFile(curDatasource);
                    curLayer.Name = nameOfLayer;
                    curLayer.Descript = descript;
                    Layers.Add(curLayer);
                }
                projection.LngLatToXY(this);
            }
        }

        /// <summary>
        /// 保存一个项目文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public void SaveProject(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(name);
                sw.WriteLine(coordinateType);  //地理坐标系
                sw.WriteLine(projectionType);  //投影坐标系
                sw.WriteLine(Layers.Count);  //图层数量
                foreach(Layer layer in Layers)
                {
                    sw.WriteLine(layer.Name);
                    sw.WriteLine(layer.Descript);
                    sw.WriteLine(layer.DataSource);
                }
            }
        }

        //获取外包矩形
        private RectangleD GetMBR(PointD[] polygon)
        {
            double minX = polygon[0].X, minY = polygon[0].Y,
                maxX = polygon[0].X, maxY = polygon[0].Y;
            foreach (PointD point in polygon)
            {
                if (point.X < minX)
                    minX = point.X;
                if (point.X > maxX)
                    maxX = point.X;
                if (point.Y < minY)
                    minY = point.Y;
                if (point.Y > maxY)
                    maxY = point.Y;
            }
            return new RectangleD(minX,minY,maxX,maxY);
        }
    }
}
