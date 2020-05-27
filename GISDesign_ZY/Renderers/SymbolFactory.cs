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
        public static MarkerStyleConstant[] MarkerStyles =
        {
         MarkerStyleConstant.MCircle, MarkerStyleConstant.MSolidCircle, MarkerStyleConstant.MRectengle,
        MarkerStyleConstant.MSolidRectengle, MarkerStyleConstant.MTriangle, MarkerStyleConstant.MSolidTriangle,
        MarkerStyleConstant.MDotCircle, MarkerStyleConstant.MDoubleCircle
        };

        public static LineStyleConstant[] LineStyles =
        {
            LineStyleConstant.LSolid, LineStyleConstant.LDash,
            LineStyleConstant.LDot, LineStyleConstant.LDashDot,
            LineStyleConstant.LDashDotDash
        };

        public static Color[] FillStyles =
        {
            Color.Black,Color.Red,Color.Blue,Color.Gray,Color.Green
        };

        public static HatchStyleConstant[] HatchStyles =
        {
            HatchStyleConstant.HCrossLine,HatchStyleConstant.HDot,HatchStyleConstant.HLine
        };

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

        //通过符号类型产生所有样式的符号
        static public Symbol[] CreateAllSymbols(SymbolType mSymbolType)
        {
            List<Symbol> cSymbols = new List<Symbol>();
            switch (mSymbolType)
            {
                case SymbolType.SimpleMarkerSymbol:
                    foreach(MarkerStyleConstant s in MarkerStyles)
                    {
                        SimpleMarkerSymbol cSymbol1 = new SimpleMarkerSymbol();
                        cSymbol1.Size = 30;
                        cSymbol1.Style = s;
                        cSymbols.Add(cSymbol1);
                    }
                    break;
                case SymbolType.SimpleLineSymbol:
                    foreach (LineStyleConstant s in LineStyles)
                    {
                        SimpleLineSymbol cSymbol2 = new SimpleLineSymbol();
                        cSymbol2.Width = 3;
                        cSymbol2.Style = s;
                        cSymbols.Add(cSymbol2);
                    }
                    break;
                case SymbolType.SimpleFillSymbol:
                    for (int i=0;i<5;i++)
                    {
                        SimpleFillSymbol cSymbol3 = new SimpleFillSymbol();
                        cSymbol3.FillColor = FillStyles[i];
                        cSymbols.Add(cSymbol3);
                    }
                    break;
                case SymbolType.HatchFillSymbol:
                    foreach (HatchStyleConstant s in HatchStyles)
                    {
                        HatchFillSymbol cSymbol4 = new HatchFillSymbol();
                        cSymbol4.HatchStyle = s;
                        cSymbols.Add(cSymbol4);
                    }
                    break;
            }
            return cSymbols.ToArray();
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
                    SimpleFillSymbol tempSymbol4 = new SimpleFillSymbol();
                    tempSymbol4.OutlineWidth = size;
                    cSymbol = tempSymbol4;
                    break;
                case FeatureTypeConstant.MultiPolygon:
                    SimpleFillSymbol tempSymbol5 = new SimpleFillSymbol();
                    tempSymbol5.OutlineWidth = size;
                    cSymbol = tempSymbol5;
                    break;
                default:
                    throw new Exception("未实现的类型");
            }
            return cSymbol;
        }
    }
}
