using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ClassLibraryIofly;

namespace GISDesign_ZY
{
    /// <summary>
    /// Renderer使用的用例
    /// </summary>
    static class RendererUseCase
    {
        /// <summary>
        /// 从打开图层、生成渲染器到调用渲染器绘制的过程
        /// </summary>
        public static void UseCase1(Graphics g)
        {
            //打开图层
            MapManager map = new MapManager();
            map.OpenLayerFile("D:/课程/大三上/GIS实验/dazuoye/XY小学.shp");
            Layer curLayer = map.GetLayerByName("XY小学");

            //生成并绑定渲染器,应该先判断图层要素是哪种类型，然后得到SymbolType。这里略过
            //因为还没有读取属性数据，这里采用第一个内设字段来绑定渲染器
            Renderer tempRenderer = RendererFactory.CreateUniqueValueRenderer(curLayer.MRecords,"值",SymbolType.SimpleMarkerSymbol);
            curLayer.MRenderer = tempRenderer;

            //绘制,还是要判断图层要素类型然后调用相应的绘制方法
            switch (curLayer.FeatureType)
            {
                case FeatureTypeConstant.PointD:
                    Renderer curRenderer = curLayer.MRenderer;
                    //渲染器类型判断
                    switch (curRenderer.Type)
                    {
                        case RendererType.UniqueValueRenderer:
                            UniqueValueRenderer uniqueValueRenderer = (UniqueValueRenderer)curRenderer;
                            string field = uniqueValueRenderer.Field;  //绑定的字段
                            int index = curLayer.MRecords.fields.GetIndexOfField(field);  //绑定字段的索引
                            for (int i=0;i< curLayer.MRecords.records.Count(); i++)
                            {
                                Record r = curLayer.MRecords.records.Item(i);
                                PointD curP = (PointD)r.Value(1);

                                //找出当前值对应的符号
                                string value = r.Value(index).ToString();
                                SimpleMarkerSymbol curSymbol = (SimpleMarkerSymbol)uniqueValueRenderer.FindSymbol(value);

                                //按点符号样式进行绘制
                                g.FillEllipse(new SolidBrush(curSymbol.MColor), 
                                    new RectangleF((float)(curP.X-curSymbol.Size/2+curSymbol.OffsetX),
                                    (float)(curP.Y - curSymbol.Size / 2 + curSymbol.OffsetY), 
                                    (float)curSymbol.Size, (float)curSymbol.Size));
                            }
                            break;

                        //略过其他渲染器类型

                        default:
                            break;
                    }
                    break;
                case FeatureTypeConstant.Polyline:
                    break;
                case FeatureTypeConstant.Polygon:
                    break;
                case FeatureTypeConstant.MultiPolygon:
                    break;
                case FeatureTypeConstant.MultiPolyline:
                    break;
            }
        }
    }
}
