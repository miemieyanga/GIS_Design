using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GISDesign_ZY
{
    public static class SymbolFactory
    {

        //通过符号类型产生符号
        static public Symbol CreateSymbol(SymbolType mSymbolType)
        {
            Symbol cSymbol = new SimpleMarkerSymbol();
            switch (mSymbolType)
            {
                case SymbolType.SimpleMarkerSymbol:
                    cSymbol = new SimpleMarkerSymbol();
                    break;
                case SymbolType.SimpleLineSymbol:
                    cSymbol = new SimpleLineSymbol();
                    break;
                case SymbolType.SimpleFillSymbol:
                    cSymbol = new SimpleFillSymbol();
                    break;
                case SymbolType.HatchFillSymbol:
                    cSymbol = new HatchFillSymbol();
                    break;
                default:
                    throw new Exception("未实现的类型");
            }
            return cSymbol;
        }

        //通过集合要素类型产生符号
        static public Symbol CreateSymbol(FeatureTypeConstant featureType)
        {
            Symbol cSymbol = new SimpleMarkerSymbol();
            switch (featureType)
            {
                case FeatureTypeConstant.PointD:
                    cSymbol = new SimpleMarkerSymbol();
                    break;
                case FeatureTypeConstant.Polyline:
                    cSymbol = new SimpleLineSymbol();
                    break;
                case FeatureTypeConstant.MultiPolyline:
                    cSymbol = new SimpleLineSymbol();
                    break;
                case FeatureTypeConstant.Polygon:
                    cSymbol = new SimpleFillSymbol();
                    break;
                case FeatureTypeConstant.MultiPolygon:
                    cSymbol = new SimpleFillSymbol();
                    break;
                default:
                    throw new Exception("未实现的类型");
            }
            return cSymbol;
        }

        /// <summary>
        /// 通过几何要素类型与颜色产生符号
        /// </summary>
        static public Symbol CreateSymbol(FeatureTypeConstant featureType, Color color)
        {
            Symbol cSymbol = new SimpleMarkerSymbol();
            switch (featureType)
            {
                case FeatureTypeConstant.PointD:
                    SimpleMarkerSymbol tempSymbol1 = new SimpleMarkerSymbol();
                    tempSymbol1.MColor = color;
                    cSymbol = tempSymbol1;
                    break;
                case FeatureTypeConstant.Polyline:
                    SimpleLineSymbol tempSymbol2 =  new SimpleLineSymbol();
                    tempSymbol2.MColor = color;
                    cSymbol = tempSymbol2;
                    break;
                case FeatureTypeConstant.MultiPolyline:
                    SimpleLineSymbol tempSymbol3 = new SimpleLineSymbol();
                    tempSymbol3.MColor = color;
                    cSymbol = tempSymbol3;
                    break;
                case FeatureTypeConstant.Polygon:
                    SimpleFillSymbol tempSymbol4 = new SimpleFillSymbol();
                    tempSymbol4.FillColor = color;
                    tempSymbol4.OutlineColor = color;
                    cSymbol = tempSymbol4;
                    break;
                case FeatureTypeConstant.MultiPolygon:
                    SimpleFillSymbol tempSymbol5 = new SimpleFillSymbol();
                    tempSymbol5.FillColor = color;
                    tempSymbol5.OutlineColor = color;
                    cSymbol = tempSymbol5;
                    break;
                default:
                    throw new Exception("未实现的类型");
            }
            return cSymbol;
        }

        /// <summary>
        /// 通过几何要素类型与大小产生符号
        /// </summary>
        static public Symbol CreateSymbol(FeatureTypeConstant featureType, int size)
        {
            Symbol cSymbol = new SimpleMarkerSymbol();
            switch (featureType)
            {
                case FeatureTypeConstant.PointD:
                    SimpleMarkerSymbol tempSymbol1 = new SimpleMarkerSymbol();
                    tempSymbol1.Size = size;
                    cSymbol = tempSymbol1;
                    break;
                case FeatureTypeConstant.Polyline:
                    SimpleLineSymbol tempSymbol2 = new SimpleLineSymbol();
                    tempSymbol2.Width = size;
                    cSymbol = tempSymbol2;
                    break;
                case FeatureTypeConstant.MultiPolyline:
                    SimpleLineSymbol tempSymbol3 = new SimpleLineSymbol();
                    tempSymbol3.Width = size;
                    cSymbol = tempSymbol3;
                    break;
                case FeatureTypeConstant.Polygon:
                    SimpleMarkerSymbol tempSymbol4 = new SimpleMarkerSymbol();
                    tempSymbol4.Size = size;
                    cSymbol = tempSymbol4;
                    break;
                case FeatureTypeConstant.MultiPolygon:
                    SimpleMarkerSymbol tempSymbol5 = new SimpleMarkerSymbol();
                    tempSymbol5.Size = size;
                    cSymbol = tempSymbol5;
                    break;
                default:
                    throw new Exception("未实现的类型");
            }
            return cSymbol;
        }
    }
}
