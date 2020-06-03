using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryIofly;
using System.IO;

namespace GISDesign_ZY
{

    [Serializable]
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
        /// 通过图层名称来删除图层
        /// </summary>
        public void DelLayerByName(string name)
        {
            Layer curLayer = GetLayerByName(name);
            Layers.Remove(curLayer);
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
            tempLayer.SetLayerFeatureType(tempLayer.FeatureTypeString);
            RectangleD mbr = tempLayer.GetExtent();
            tempLayer.SetExtent(mbr.MinX, mbr.MinY, mbr.MaxX, mbr.MaxY);
            tempLayer.MRenderer = RendererFactory.CreateSimpleRenderer(SymbolFactory.CreateSymbol(tempLayer.FeatureType));
            return tempLayer;
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
