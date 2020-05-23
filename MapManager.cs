using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISDesign_ZY
{
    class MapManager
    {

        public List<Layer> Layers;
        //Projection projection;  //投影

        public MapManager()
        {
            Layers = new List<Layer>();
        }

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
        public void OpenLayerFile(string path)
        {
            char[] separator = {'/'};
            string[] strs = path.Split(separator);
            string fileName = strs[strs.Length - 1];
            Layer tempLayer = new Layer(fileName.Substring(0,fileName.Length-4));
            tempLayer.MRecords =  tempLayer.MGeoDataIO.OpenShapeFile(path);
            //PointD, Polyline, Polygon, MultiPolygon, MultiPolyline
            switch (tempLayer.MRecords.fields.Item(0).valueType)
            {
                case "PointD":
                    tempLayer.FeatureType = FeatureTypeConstant.PointD;
                    break;
                case "Polyline":
                    tempLayer.FeatureType = FeatureTypeConstant.Polyline;
                    break;
                case "Polygon":
                    tempLayer.FeatureType = FeatureTypeConstant.Polygon;
                    break;
                case "MultiPolygon":
                    tempLayer.FeatureType = FeatureTypeConstant.MultiPolygon;
                    break;
                case "MultiPolyline":
                    tempLayer.FeatureType = FeatureTypeConstant.MultiPolyline;
                    break;
            }
            Layers.Add(tempLayer);
        }

        /// <summary>
        /// 保存一个图层文件s
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

        }

        /// <summary>
        /// 保存一个项目文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public void SaveProject(string path)
        {

        }
    }
}
