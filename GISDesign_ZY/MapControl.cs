﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryIofly;

namespace GISDesign_ZY
{
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();
            this.MouseWheel += MapControl_MouseWheel;
        }

        #region 字段

        //设计时属性变量
        private bool _SelfMouseWheel = true; //接受鼠标滑轮事件是是否自动缩放
        private Color _TrackingColor = Color.DarkGreen;  //描绘要素的颜色

        //运行时属性变量
        public List<Layer> _Layers = new List<Layer>(); //图层集合
        private double _DisplayScale = 1D; //显示比例尺倒数
        public List<Layer> _SelectedLayers = new List<Layer>(); //选中图层集合

        //内部变量
        private double mOffsetX = 0D, mOffsetY = 0D; //窗口左上点地图坐标
        private int mMapOpStyle = 0; //地图操作类型,0无1放大2缩小3漫游4编辑5选择6新建要素
        private Layer mTrackingLayer; //用户正在描绘的图层
        private Layer mEditingLayer; //用户正在编辑的图层
        private bool Editing = false;  //用户是否找到将编辑的节点
        private int[] EditIndex = new int[2];   //记录编辑节点在所属图层中序号信息 
        private List<PointF> TrackingFeature = new List<PointF>();  //记录正在跟踪的要素坐标
        private PointF mMouseLocation = new PointF(); //鼠标当前位置，用于漫游、拉框
        private PointF mStartPoint = new PointF(); //鼠标按下位置，用于拉框

        //鼠标光标
        private Cursor mCur_Cross = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().
            GetManifestResourceStream("GISDesign_ZY.Resources.Cross.ico"));
        private Cursor mCur_ZoomIn = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().
            GetManifestResourceStream("GISDesign_ZY.Resources.ZoomIn.ico"));
        private Cursor mCur_ZoomOut = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().
            GetManifestResourceStream("GISDesign_ZY.Resources.ZoomOut.ico"));
        private Cursor mCur_PanUp = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().
            GetManifestResourceStream("GISDesign_ZY.Resources.PanUp.ico"));

        //常量
        private const float mcTrackingWidth = 1F; //描绘要素的边界宽度
        private const float mcVertexHandleSize = 7F; //描绘要素顶点手柄大小
        private const float mcZoomRatio = 1.2F; //缩放系数
        private Color mcSelectingBoxColor = Color.DarkGreen; //选择盒颜色
        private const float mcSelectingBoxWidth = 2F; //选择盒边界宽度
        private Color mcSelectionColor = Color.Cyan; //选中要素颜色

        #endregion

        #region 属性

        [Browsable(true), Description("指示接收到鼠标滚轮事件时是否自动缩放")]
        public bool SelfMouseWheel
        {
            get { return _SelfMouseWheel; }
            set { _SelfMouseWheel = value; }
        }

        //运行时属性

        /// <summary>
        /// 获取或设置图层集合
        /// </summary>
        [Browsable(false)]
        public Layer[] Layers
        {
            get { return _Layers.ToArray(); }
            set
            {
                _Layers.Clear();
                _Layers.AddRange(value);
            }
        }

        /// <summary>
        /// 获取或设置选中要素的图层集合
        /// </summary>
        [Browsable(false)]
        public Layer[] SelectedLayers
        {
            get { return _SelectedLayers.ToArray(); }
            set
            {
                _SelectedLayers.Clear();
                _SelectedLayers.AddRange(value);
            }
        }

        /// <summary>
        /// 获取显示比例尺倒数
        /// </summary>
        [Browsable(false)]
        public double DisplayScale
        {
            get { return _DisplayScale; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 将地图坐标转换为屏幕坐标
        /// </summary>
        /// <param name="point">地图坐标</param>
        /// <returns></returns>
        public PointD FromMapPoint(PointD point)
        {
            PointD sPoint = new PointD((point.X - mOffsetX) / _DisplayScale, (point.Y - mOffsetY) / _DisplayScale);
            return sPoint;
        }

        /// <summary>
        /// 将屏幕坐标转换为地图坐标
        /// </summary>
        /// <param name="point">屏幕坐标</param>
        /// <returns></returns>
        public PointD ToMapPoint(PointD point)
        {
            double x = point.X * _DisplayScale + mOffsetX;
            double y = point.Y * _DisplayScale + mOffsetY;
            PointD sPoint = new PointD(x, y);
            return sPoint;
        }

        /// <summary>
        /// 以指定点为中心放大
        /// </summary>
        /// <param name="center">缩放中心</param>
        /// <param name="ratio">缩放系数</param>
        public void ZoomByCenter(PointD center, double ratio)
        {
            double sDisplayScale;
            sDisplayScale = _DisplayScale / ratio;

            double sOffsetX, sOffsetY;
            sOffsetX = mOffsetX + (1 - 1 / ratio) * (center.X - mOffsetX);
            sOffsetY = mOffsetY + (1 - 1 / ratio) * (center.Y - mOffsetY);

            mOffsetX = sOffsetX;
            mOffsetY = sOffsetY;
            _DisplayScale = sDisplayScale;

            //触发事件
            if (DisplayScaleChanged != null)
                DisplayScaleChanged(this);
        }

        /// <summary>
        /// 将地图操作设置为放大状态
        /// </summary>
        public void ZoomIn()
        {
            mMapOpStyle = 1; //记录操作状态
            this.Cursor = mCur_ZoomIn; //更改光标
        }

        /// <summary>
        /// 将地图操作设置为缩小状态
        /// </summary>
        public void ZoomOut()
        {
            mMapOpStyle = 2; //记录操作状态
            this.Cursor = mCur_ZoomOut; //更改光标
        }

        /// <summary>
        /// 将地图操作设置为漫游状态
        /// </summary>
        public void Pan()
        {
            mMapOpStyle = 3; //记录操作状态
            this.Cursor = mCur_PanUp; //更改光标
        }

        /// <summary>
        /// 将地图操作设置为编辑状态
        /// </summary>
        public void TrackPolygon(Layer editingLayer)
        {            
            mMapOpStyle = 4; //记录操作状态
            this.Cursor = mCur_Cross; //更改光标
            mEditingLayer = editingLayer;
        }

        /// <summary>
        /// 将地图操作设置为选择要素状态
        /// </summary>
        public void SelectFeature()
        {
            mMapOpStyle = 5; //记录操作状态
            this.Cursor = Cursors.Arrow; //更改光标
        }

        /// <summary>
        /// 将地图操作设置为新建要素状态
        /// </summary>
        public void TrackFeature(Layer trackLayer)
        {
            mMapOpStyle = 6; //记录操作状态
            this.Cursor = mCur_Cross; //更改光标
            mTrackingLayer = trackLayer;
        }

        /// <summary>
        /// 在给定图层末尾添加新建的要素
        /// </summary>
        public void AddFeature(Layer layer)
        {
            object[] objs = new object[layer.MRecords.fields.Count()];
            //按图层类型添加
            switch (layer.FeatureType)
            {
                case FeatureTypeConstant.PointD:
                    {
                        objs[0] = "PointD";
                        objs[1] = ToMapPoint(new PointD(TrackingFeature[0].X, TrackingFeature[0].Y));
                        Record record = new Record(objs);
                        layer.MRecords.records.Append(record);
                        break;
                    }
                case FeatureTypeConstant.Polyline:
                    {
                        objs[0] = "Polyline";
                        PointD[] pts = new PointD[TrackingFeature.Count];
                        for (int i = 0; i < TrackingFeature.Count; i++)
                        {
                            pts[i] = ToMapPoint(new PointD(TrackingFeature[i].X, TrackingFeature[i].Y));
                        }
                        objs[1] = new Polyline(pts);
                        Record record = new Record(objs);
                        layer.MRecords.records.Append(record);
                        break;
                    }
                case FeatureTypeConstant.MultiPolyline:
                    {
                        objs[0] = "MultiPolyline";
                        Polyline[] pls = new Polyline[1];
                        PointD[] pts = new PointD[TrackingFeature.Count];
                        for (int i = 0; i < TrackingFeature.Count; i++)
                        {
                            pts[i] = ToMapPoint(new PointD(TrackingFeature[i].X, TrackingFeature[i].Y));
                        }
                        pls[0] = new Polyline(pts);
                        objs[1] = new MultiPolyline(pls);
                        Record record = new Record(objs);
                        layer.MRecords.records.Append(record);
                        break;
                    }
                case FeatureTypeConstant.Polygon:
                    {
                        objs[0] = "Polygon";
                        PointD[] pts = new PointD[TrackingFeature.Count];
                        for (int i = 0; i < TrackingFeature.Count; i++)
                        {
                            pts[i] = ToMapPoint(new PointD(TrackingFeature[i].X, TrackingFeature[i].Y));
                        }
                        objs[1] = new Polygon(pts);
                        Record record = new Record(objs);
                        layer.MRecords.records.Append(record);
                        break;
                    }
                case FeatureTypeConstant.MultiPolygon:
                    {
                        objs[0] = "MultiPolygon";
                        Polygon[] pgs = new Polygon[1];
                        PointD[] pts = new PointD[TrackingFeature.Count];
                        for (int i = 0; i < TrackingFeature.Count; i++)
                        {
                            pts[i] = ToMapPoint(new PointD(TrackingFeature[i].X, TrackingFeature[i].Y));
                        }
                        pgs[0] = new Polygon(pts);
                        objs[1] = new MultiPolygon(pgs);
                        Record record = new Record(objs);
                        layer.MRecords.records.Append(record);
                        break;
                    }
            }
            TrackingFeature.Clear();
        }

        /// <summary>
        /// 根据矩形盒进行选择，返回选中要素的图层集合
        /// </summary>
        /// <param name="box">矩形盒</param>
        /// <returns></returns>
        public Layer[] SelectByBox(RectangleD box)
        {
            List<Layer> sSels = new List<Layer>();  //记录给定矩形盒选中要素的图层集合
            //逐个图层判断是否有要素选入
            for (int i = 0; i < _Layers.Count; i++)
            {
                if (_Layers[i].Selectable == true && _Layers[i].Visible == true)//判断图层是否可见、可选
                {
                    //创建记录该图层被选要素的图层
                    string name = _Layers[i].Name + "_SelectedFeatures";
                    Layer layer = new Layer(name, _Layers[i].Descript);
                    layer.FeatureType = _Layers[i].FeatureType;                   
                    //存入选中要素坐标信息
                    layer.MRecords = _Layers[i].MRecords.SelectByBox(box);
                    sSels.Add(layer);
                }
            }
            return sSels.ToArray();
        }

        /// <summary>
        /// 点选，返回选中要素的图层集合
        /// </summary>
        /// <param name="point">选择点</param>
        /// <returns></returns>
        public Layer[] SelectByPoint(PointD point)
        {
            List<Layer> sSels = new List<Layer>();  //记录点选中要素的图层集合
            //逐个图层判断是否有要素选入
            for (int i = 0; i < _Layers.Count; i++)
            {
                if (_Layers[i].Selectable == true && _Layers[i].Visible == true)//判断图层是否可见、可选
                {
                    //创建记录该图层被选要素的图层
                    string name = _Layers[i].Name + "_SelectedFeatures";
                    Layer layer = new Layer(name, _Layers[i].Descript);
                    layer.FeatureType = _Layers[i].FeatureType;
                    //设置选中要素的符号样式
                    SimpleRenderer simpleRenderer = new SimpleRenderer();
                    switch (layer.FeatureType)
                    {
                        case FeatureTypeConstant.PointD:
                            SimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbol();
                            simpleMarkerSymbol.MColor = _TrackingColor;
                            simpleRenderer.MSymbol = simpleMarkerSymbol;
                            break;
                        case FeatureTypeConstant.Polyline:
                        case FeatureTypeConstant.MultiPolyline:
                            SimpleLineSymbol simpleLineSymbol = new SimpleLineSymbol();
                            simpleLineSymbol.MColor = _TrackingColor;
                            simpleLineSymbol.Width = 2;
                            simpleRenderer.MSymbol = simpleLineSymbol;
                            break;
                        case FeatureTypeConstant.Polygon:
                        case FeatureTypeConstant.MultiPolygon:
                            SimpleFillSymbol simpleFillSymbol = new SimpleFillSymbol();
                            simpleFillSymbol.OutlineColor = _TrackingColor;
                            simpleFillSymbol.OutlineWidth = 2;
                            simpleFillSymbol.FillStyle = FillStyleConstant.FTransparent;
                            simpleRenderer.MSymbol = simpleFillSymbol;
                            break;
                    }
                    layer.MRenderer = simpleRenderer;
                    //存入选中要素坐标信息
                    layer.MRecords = _Layers[i].MRecords.SelectByPoint(point, 8);
                    sSels.Add(layer);
                }
            }
            return sSels.ToArray();
        }

        #endregion

        #region 事件

        public delegate void DisplayScaleChangedHandle(object sender);

        /// <summary>
        /// 显示比例尺发生了变化
        /// </summary>
        [Browsable(true), Description("显示比例尺发生了变化")]
        public event DisplayScaleChangedHandle DisplayScaleChanged;


        public delegate void SelectingByBoxFinishedHandle(object sender, RectangleD box);

        /// <summary>
        /// 用户框选操作结束
        /// </summary>
        [Browsable(true), Description("用户框选操作结束")]
        public event SelectingByBoxFinishedHandle SelectingByBoxFinished;


        public delegate void SelectingByPointFinishedHandle(object sender, PointD point);

        /// <summary>
        /// 用户点选操作结束
        /// </summary>
        [Browsable(true), Description("用户点选操作结束")]
        public event SelectingByPointFinishedHandle SelectingByPointFinished;

        #endregion

        #region 私有函数
        //绘制点图层
        private void DrawPointLayer(Graphics g, Layer curLayer)
        {
            Renderer curRenderer = curLayer.MRenderer;
            SimpleMarkerSymbol curSymbol = new SimpleMarkerSymbol();
            int index;  //绑定字段的索引
            string field;  //绑定字段

            //判断渲染器类型
            switch (curRenderer.Type)
            {
                case RendererType.SimpleRenderer:
                    SimpleRenderer simpleRenderer = (SimpleRenderer)curRenderer;
                    for (int i = 0; i < curLayer.MRecords.records.Count(); i++)
                    {
                        Record r = curLayer.MRecords.records.Item(i);
                        PointD ScreenPoint = FromMapPoint((PointD)r.Value(1)); //double型屏幕坐标
                        //获取符号
                        curSymbol = (SimpleMarkerSymbol)simpleRenderer.MSymbol;
                        //绘制
                        DrawSymbol.DrawMarkerSymbol(g, curSymbol, new PointF((float)ScreenPoint.X, (float)ScreenPoint.Y));
                    }
                    break;
                case RendererType.UniqueValueRenderer:
                    UniqueValueRenderer uniqueValueRenderer = (UniqueValueRenderer)curRenderer;
                    field = uniqueValueRenderer.Field;  //绑定的字段
                    index = curLayer.MRecords.fields.GetIndexOfField(field);  //绑定字段的索引
                    for (int i = 0; i < curLayer.MRecords.records.Count(); i++)
                    {
                        Record r = curLayer.MRecords.records.Item(i);
                        PointD ScreenPoint = FromMapPoint((PointD)r.Value(1)); //double型屏幕坐标
                        //找出当前值对应的符号
                        string value = r.Value(index).ToString();
                        curSymbol = (SimpleMarkerSymbol)uniqueValueRenderer.FindSymbol(value);
                        //绘制
                        DrawSymbol.DrawMarkerSymbol(g, curSymbol, new PointF((float)ScreenPoint.X, (float)ScreenPoint.Y));
                    }
                    break;
                case RendererType.ClassBreaksRenderer:
                    ClassBreaksRenderer classBreaksRenderer = (ClassBreaksRenderer)curRenderer;
                    field = classBreaksRenderer.Field;  //绑定的字段
                    index = curLayer.MRecords.fields.GetIndexOfField(field);  //绑定字段的索引
                    for (int i = 0; i < curLayer.MRecords.records.Count(); i++)
                    {
                        Record r = curLayer.MRecords.records.Item(i);
                        PointD ScreenPoint = FromMapPoint((PointD)r.Value(1)); //double型屏幕坐标
                        //找出当前值对应的符号
                        double value = Convert.ToDouble(r.Value(index));
                        curSymbol = (SimpleMarkerSymbol)classBreaksRenderer.FindSymbol(value);
                        //绘制
                        DrawSymbol.DrawMarkerSymbol(g, curSymbol, new PointF((float)ScreenPoint.X, (float)ScreenPoint.Y));
                    }
                    break;
            }
        }

        //绘制线图层
        private void DrawPolylineLayer(Graphics g, Layer curLayer)
        {
            Renderer curRenderer = curLayer.MRenderer;
            SimpleLineSymbol curSymbol = new SimpleLineSymbol();
            int index;  //绑定字段的索引
            string field;  //绑定字段

            for (int i = 0; i < curLayer.MRecords.records.Count(); i++)
            {
                Record r = curLayer.MRecords.records.Item(i);
                //判断渲染器类型
                switch (curRenderer.Type)
                {
                    case RendererType.SimpleRenderer:
                        SimpleRenderer simpleRenderer = (SimpleRenderer)curRenderer;
                        curSymbol = (SimpleLineSymbol)simpleRenderer.MSymbol;
                        break;
                    case RendererType.UniqueValueRenderer:
                        UniqueValueRenderer uniqueValueRenderer = (UniqueValueRenderer)curRenderer;
                        field = uniqueValueRenderer.Field;  //绑定的字段
                        index = curLayer.MRecords.fields.GetIndexOfField(field);  //绑定字段的索引
                        //找出当前值对应的符号
                        string value = r.Value(index).ToString();
                        curSymbol = (SimpleLineSymbol)uniqueValueRenderer.FindSymbol(value);
                        break;
                    case RendererType.ClassBreaksRenderer:
                        ClassBreaksRenderer classBreaksRenderer = (ClassBreaksRenderer)curRenderer;
                        field = classBreaksRenderer.Field;  //绑定的字段
                        index = curLayer.MRecords.fields.GetIndexOfField(field);  //绑定字段的索引                   
                        //找出当前值对应的符号
                        double CBvalue = Convert.ToDouble(r.Value(index));
                         curSymbol = (SimpleLineSymbol)classBreaksRenderer.FindSymbol(CBvalue);
                        break;
                }
                //判断图层类型并绘制
                PointF[] sScreenPoints;
                Polyline polyline = new Polyline();
                int sPointCount = 0;
                PointD sScreenPoint;
                switch (curLayer.FeatureType)
                {
                    case FeatureTypeConstant.Polyline:
                        polyline = (Polyline)r.Value(1);
                        //坐标转换
                        sPointCount = polyline.PointCount; //折线顶点数
                        sScreenPoints = new PointF[sPointCount]; //顶点屏幕坐标
                        for (int k = 0; k < sPointCount; k++)
                        {
                            sScreenPoint = FromMapPoint(polyline.GetPointD(k)); //double型屏幕坐标
                            sScreenPoints[k].X = (float)sScreenPoint.X;
                            sScreenPoints[k].Y = (float)sScreenPoint.Y;
                        }
                        //绘制
                        DrawSymbol.DrawLineSymbol(g, curSymbol, sScreenPoints, sPointCount);
                        break;
                    case FeatureTypeConstant.MultiPolyline:
                        MultiPolyline multiPolyline = (MultiPolyline)r.Value(1);
                        for (int j = 0; j < multiPolyline.PolylineCount(); j++)
                        {
                            polyline = multiPolyline.GetPolyline(j);
                            //坐标转换
                            sPointCount = polyline.PointCount; //折线顶点数
                            sScreenPoints = new PointF[sPointCount]; //顶点屏幕坐标
                            for (int k = 0; k < sPointCount; k++)
                            {
                                sScreenPoint = FromMapPoint(polyline.GetPointD(k)); //double型屏幕坐标
                                sScreenPoints[k].X = (float)sScreenPoint.X;
                                sScreenPoints[k].Y = (float)sScreenPoint.Y;
                            }
                            //绘制
                            DrawSymbol.DrawLineSymbol(g, curSymbol, sScreenPoints, sPointCount);
                        }
                        break;
                    default:
                        break;
                }               
            }
        }

        //绘制多边形图层
        private void DrawPolygonLayer(Graphics g, Layer curLayer)
        {
            Renderer curRenderer = curLayer.MRenderer;
            SimpleFillSymbol curSymbol = new SimpleFillSymbol();

            for (int i = 0; i < curLayer.MRecords.records.Count(); i++)
            {
                Record r = curLayer.MRecords.records.Item(i);
                //判断渲染器类型
                switch (curRenderer.Type)
                {
                    case RendererType.SimpleRenderer:
                        SimpleRenderer simpleRenderer = (SimpleRenderer)curRenderer;
                        curSymbol = (SimpleFillSymbol)simpleRenderer.MSymbol;
                        break;
                    case RendererType.UniqueValueRenderer:
                        {
                            UniqueValueRenderer uniqueValueRenderer = (UniqueValueRenderer)curRenderer;
                            string field = uniqueValueRenderer.Field;  //绑定的字段
                            int index = curLayer.MRecords.fields.GetIndexOfField(field);  //绑定字段的索引
                            //找出当前值对应的符号
                            string value = r.Value(index).ToString();
                            curSymbol = (SimpleFillSymbol)uniqueValueRenderer.FindSymbol(value);
                            break;
                        }
                    case RendererType.ClassBreaksRenderer:
                        {
                            ClassBreaksRenderer classBreaksRenderer = (ClassBreaksRenderer)curRenderer;
                            string field = classBreaksRenderer.Field;  //绑定的字段
                            int index = curLayer.MRecords.fields.GetIndexOfField(field);  //绑定字段的索引                   
                            //找出当前值对应的符号
                            double CBvalue = Convert.ToDouble(r.Value(index));
                            curSymbol = (SimpleFillSymbol)classBreaksRenderer.FindSymbol(CBvalue);
                            break;
                        }
                }
                //判断图层类型并绘制
                Polygon polygon = new Polygon();
                int sPointCount = 0; //折线顶点数
                PointF[] sScreenPoints; //顶点屏幕坐标
                PointD sScreenPoint; //double型屏幕坐标
                switch (curLayer.FeatureType)
                {
                    case FeatureTypeConstant.Polygon:
                        polygon = (Polygon)r.Value(1);
                        //坐标转换
                        sPointCount = polygon.PointCount; //折线顶点数
                        sScreenPoints = new PointF[sPointCount]; //顶点屏幕坐标
                        for (int k = 0; k < sPointCount; k++)
                        {
                            sScreenPoint = FromMapPoint(polygon.GetPointD(k)); //double型屏幕坐标
                            sScreenPoints[k].X = (float)sScreenPoint.X;
                            sScreenPoints[k].Y = (float)sScreenPoint.Y;
                        }
                        //绘制
                        DrawSymbol.DrawFillSymbol(g, curSymbol, sScreenPoints, sPointCount);
                        break;
                    case FeatureTypeConstant.MultiPolygon:
                        MultiPolygon multiPolygon = (MultiPolygon)r.Value(1);
                        for (int j = 0; j < multiPolygon.PolygonCount(); j++)
                        {
                            polygon = multiPolygon.GetPolygon(j);
                            //坐标转换
                            sPointCount = polygon.PointCount; //折线顶点数
                            sScreenPoints = new PointF[sPointCount]; //顶点屏幕坐标
                            for (int k = 0; k < sPointCount; k++)
                            {
                                sScreenPoint = FromMapPoint(polygon.GetPointD(k)); //double型屏幕坐标
                                sScreenPoints[k].X = (float)sScreenPoint.X;
                                sScreenPoints[k].Y = (float)sScreenPoint.Y;
                            }
                            //绘制
                            DrawSymbol.DrawFillSymbol(g, curSymbol, sScreenPoints, sPointCount);
                        }
                        break;
                    default:
                        break;

                }
            }
        }

        //绘制选中要素的图层
        private void DrawSelectedFeatures(Graphics g)
        {
            //设置图层样式符号
            for(int i=0;i<_SelectedLayers.Count;i++)
            {
                SimpleRenderer simpleRenderer = new SimpleRenderer();
                switch (_SelectedLayers[i].FeatureType)
                {
                    case FeatureTypeConstant.PointD:
                        SimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbol();
                        simpleMarkerSymbol.MColor = mcSelectionColor;
                        simpleRenderer.MSymbol = simpleMarkerSymbol;
                        break;
                    case FeatureTypeConstant.Polyline:
                    case FeatureTypeConstant.MultiPolyline:
                        SimpleLineSymbol simpleLineSymbol = new SimpleLineSymbol();
                        simpleLineSymbol.MColor = mcSelectionColor;
                        simpleLineSymbol.Width = 2;
                        simpleRenderer.MSymbol = simpleLineSymbol;
                        break;
                    case FeatureTypeConstant.Polygon:
                    case FeatureTypeConstant.MultiPolygon:
                        SimpleFillSymbol simpleFillSymbol = new SimpleFillSymbol();
                        simpleFillSymbol.OutlineColor = mcSelectionColor;
                        simpleFillSymbol.OutlineWidth = 2;
                        simpleFillSymbol.FillStyle = FillStyleConstant.FTransparent;
                        simpleRenderer.MSymbol = simpleFillSymbol;
                        break;
                }
                _SelectedLayers[i].MRenderer = simpleRenderer;
            }
            //绘制
            DrawLayers(g, _SelectedLayers);
        }

        //绘制跟踪图层
        private void DrawTrackingLayers(Graphics g)
        {
            int sPointCount = TrackingFeature.Count;
            if (sPointCount == 0)
                return;
            Pen sTrackingpen = new Pen(_TrackingColor, mcTrackingWidth);
            for (int i = 0; i < sPointCount - 1; i++)
            { 
                g.DrawLine(sTrackingpen, TrackingFeature[i], TrackingFeature[i + 1]); 
            }
            //绘制跟踪要素顶点手柄
            SolidBrush sVertexBrush = new SolidBrush(_TrackingColor);
            for (int i = 0; i < sPointCount; i++)
            {
                RectangleF sRect = new RectangleF(TrackingFeature[i].X - mcVertexHandleSize / 2, TrackingFeature[i].Y - mcVertexHandleSize / 2, mcVertexHandleSize, mcVertexHandleSize);
                g.FillRectangle(sVertexBrush, sRect);
            }
            //绘制橡皮筋
            if (mMapOpStyle == 6)
            {
                switch (mTrackingLayer.FeatureType)
                {
                    case FeatureTypeConstant.PointD:
                        break;
                    case FeatureTypeConstant.Polyline:
                    case FeatureTypeConstant.MultiPolyline:
                        g.DrawLine(sTrackingpen, TrackingFeature[sPointCount - 1], mMouseLocation);
                        break;
                    case FeatureTypeConstant.Polygon:
                    case FeatureTypeConstant.MultiPolygon:
                        if (sPointCount == 1)
                        {
                            g.DrawLine(sTrackingpen, TrackingFeature[0], mMouseLocation);
                        }
                        else
                        {
                            g.DrawLine(sTrackingpen, TrackingFeature[0], mMouseLocation);
                            g.DrawLine(sTrackingpen, TrackingFeature[sPointCount - 1], mMouseLocation);
                        }
                        break;
                }
            }
            //释放资源
            sTrackingpen.Dispose();
            sVertexBrush.Dispose();
        }

        //绘制给定图层集
        private void DrawLayers(Graphics g, List<Layer> layers)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].Visible == true)
                {
                    switch (layers[i].FeatureType)
                    {
                        case FeatureTypeConstant.PointD:
                            DrawPointLayer(g, layers[i]);
                            break;
                        case FeatureTypeConstant.Polyline:
                        case FeatureTypeConstant.MultiPolyline:
                            DrawPolylineLayer(g, layers[i]);
                            break;
                        case FeatureTypeConstant.Polygon:
                        case FeatureTypeConstant.MultiPolygon:
                            DrawPolygonLayer(g, layers[i]);
                            break;
                    }
                }
            }
        }

        //判断是否定位到编辑图层某个要素的节点
        private void CheckEditPoint(PointD MouseMapPosition)
        {
            switch (mEditingLayer.FeatureType)
            {
                case FeatureTypeConstant.PointD:
                    for (int i = 0; i < mEditingLayer.MRecords.records.Count(); i++)
                    {
                        Record r = mEditingLayer.MRecords.records.Item(i);
                        PointD point = (PointD)r.Value(1);
                        //判断是否定位到可编辑结点
                        if (point.Distance(MouseMapPosition) < 8)
                        {
                            Editing = true;
                            //将编辑要素放置最后
                            mEditingLayer.MRecords.records.Delete(i);
                            mEditingLayer.MRecords.records.Append(r);
                            break;
                        }
                    }
                    break;
                case FeatureTypeConstant.Polyline:
                    for (int i = 0; i < mEditingLayer.MRecords.records.Count() && !Editing; i++)
                    {
                        Record r = mEditingLayer.MRecords.records.Item(i);
                        Polyline polyline = (Polyline)r.Value(1);
                        //逐个节点判断
                        for (int k = 0; k < polyline.PointCount; k++)
                        {
                            PointD point = polyline.GetPointD(k);
                            if (point.Distance(MouseMapPosition) < 8)
                            {
                                Editing = true;
                                //将编辑要素放置最后
                                mEditingLayer.MRecords.records.Delete(i);
                                mEditingLayer.MRecords.records.Append(r);
                                //记录节点序号
                                EditIndex[0] = k;
                                break;
                            }
                        }
                    }
                    break;
                case FeatureTypeConstant.MultiPolyline:
                    for (int i = 0; i < mEditingLayer.MRecords.records.Count() && !Editing; i++)
                    {
                        Record r = mEditingLayer.MRecords.records.Item(i);
                        MultiPolyline multiPolyline = (MultiPolyline)r.Value(1);
                        //逐个线要素判断
                        for (int j = 0; j < multiPolyline.PolylineCount() && !Editing; j++)
                        {
                            Polyline polyline = multiPolyline.GetPolyline(j);
                            //逐个节点判断
                            for (int k = 0; k < polyline.PointCount; k++)
                            {
                                PointD point = polyline.GetPointD(k);
                                //判断是否定位到可编辑结点
                                if (point.Distance(MouseMapPosition) < 8)
                                {
                                    Editing = true;
                                    //将编辑要素放置最后
                                    mEditingLayer.MRecords.records.Delete(i);
                                    mEditingLayer.MRecords.records.Append(r);
                                    //记录节点序号
                                    EditIndex[0] = j;
                                    EditIndex[0] = k;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case FeatureTypeConstant.Polygon:
                    for (int i = 0; i < mEditingLayer.MRecords.records.Count() && !Editing; i++)
                    {
                        Record r = mEditingLayer.MRecords.records.Item(i);
                        Polygon polygon = (Polygon)r.Value(1);
                        //逐个节点判断
                        for (int k = 0; k < polygon.PointCount; k++)
                        {
                            PointD point = polygon.GetPointD(k);
                            //判断是否定位到可编辑结点
                            if (point.Distance(MouseMapPosition) < 8)
                            {
                                Editing = true;
                                //将编辑要素放置最后
                                mEditingLayer.MRecords.records.Delete(i);
                                mEditingLayer.MRecords.records.Append(r);
                                //记录节点序号
                                EditIndex[0] = k;
                                break;
                            }
                        }
                    }
                    break;
                case FeatureTypeConstant.MultiPolygon:
                    for (int i = 0; i < mEditingLayer.MRecords.records.Count() && !Editing; i++)
                    {
                        Record r = mEditingLayer.MRecords.records.Item(i);
                        MultiPolygon multiPolygon = (MultiPolygon)r.Value(1);
                        //逐个多边形判断
                        for (int j = 0; j < multiPolygon.PolygonCount() && !Editing; j++)
                        {
                            Polygon polygon = multiPolygon.GetPolygon(j);
                            //逐个节点判断
                            for (int k = 0; k < polygon.PointCount; k++)
                            {
                                PointD point = polygon.GetPointD(k);
                                //判断是否定位到可编辑结点
                                if (point.Distance(MouseMapPosition) < 8)
                                {
                                    Editing = true;
                                    //将编辑要素放置最后
                                    mEditingLayer.MRecords.records.Delete(i);
                                    mEditingLayer.MRecords.records.Append(r);
                                    //记录节点序号
                                    EditIndex[0] = j;
                                    EditIndex[0] = k;
                                    break;
                                }
                            }
                        }
                    }
                    break;
            }
        }

        //编辑节点
        private void EditPoint(PointD MouseMapPosition)
        {
            int recordsCount = mEditingLayer.MRecords.records.Count();
            Record record = mEditingLayer.MRecords.records.Item(recordsCount - 1);
            object[] objs = new object[mEditingLayer.MRecords.fields.Count()];
            objs[0] = record.Value(0);
            for (int i = 2; i < mEditingLayer.MRecords.fields.Count(); i++)
            {
                objs[i] = record.Value(i);
            }
            //根据图层类型修改节点位置
            switch (mEditingLayer.FeatureType)
            {
                case FeatureTypeConstant.PointD:
                    objs[1] = MouseMapPosition;
                    break;
                case FeatureTypeConstant.Polyline:
                    {
                        //节点位置更改后的polyline
                        Polyline polyline = (Polyline)record.Value(1);
                        PointD[] pts = new PointD[polyline.PointCount];
                        for (int i = 0; i < polyline.PointCount; i++)
                        {
                            if (i == EditIndex[0])
                                pts[i] = MouseMapPosition;
                            else
                                pts[i] = polyline.GetPointD(i);
                        }
                        polyline = new Polyline(pts);
                        objs[1] = polyline;
                        record = new Record(objs);
                        //更新
                        mEditingLayer.MRecords.records.Delete(recordsCount - 1);
                        mEditingLayer.MRecords.records.Append(record);
                    }
                    break;
                case FeatureTypeConstant.MultiPolyline:
                    {
                        //节点位置更改后的multipolyline
                        MultiPolyline multipolyline = (MultiPolyline)record.Value(1);
                        Polyline[] pls = new Polyline[multipolyline.PolylineCount()];
                        for (int i = 0; i < multipolyline.PolylineCount(); i++)
                        {
                            if (i == EditIndex[0])
                            {
                                Polyline polyline = multipolyline.GetPolyline(i).Clone();
                                PointD[] pts = new PointD[polyline.PointCount];
                                for (int j = 0; j < polyline.PointCount; j++)
                                {
                                    if (j == EditIndex[1])
                                        pts[j] = MouseMapPosition;
                                    else
                                        pts[j] = polyline.GetPointD(i);
                                }
                                pls[i] = new Polyline(pts);
                            }
                            else
                                pls[i] = multipolyline.GetPolyline(i);
                        }
                        multipolyline = new MultiPolyline(pls);
                        objs[1] = multipolyline;
                        record = new Record(objs);
                        //更新
                        mEditingLayer.MRecords.records.Delete(recordsCount - 1);
                        mEditingLayer.MRecords.records.Append(record);
                    }
                    break;
                case FeatureTypeConstant.Polygon:
                    {
                        //节点位置更改后的polygon
                        Polygon polygon = (Polygon)record.Value(1);
                        PointD[] pts = new PointD[polygon.PointCount];
                        for (int i = 0; i < polygon.PointCount; i++)
                        {
                            if (i == EditIndex[0])
                                pts[i] = MouseMapPosition;
                            else
                                pts[i] = polygon.GetPointD(i);
                        }
                        polygon = new Polygon(pts);
                        objs[1] = polygon;
                        record = new Record(objs);
                        //更新
                        mEditingLayer.MRecords.records.Delete(recordsCount - 1);
                        mEditingLayer.MRecords.records.Append(record);
                    }
                    break;
                case FeatureTypeConstant.MultiPolygon:
                    {
                        //节点位置更改后的multipolygon
                        MultiPolygon multipolygon = (MultiPolygon)record.Value(1);
                        Polygon[] pgs = new Polygon[multipolygon.PolygonCount()];
                        for (int i = 0; i < multipolygon.PolygonCount(); i++)
                        {
                            if (i == EditIndex[0])
                            {
                                Polygon polygon = multipolygon.GetPolygon(i).Clone();
                                PointD[] pts = new PointD[polygon.PointCount];
                                for (int j = 0; j < polygon.PointCount; j++)
                                {
                                    if (j == EditIndex[1])
                                        pts[j] = MouseMapPosition;
                                    else
                                        pts[j] = polygon.GetPointD(i);
                                }
                                pgs[i] = new Polygon(pts);
                            }
                            else
                                pgs[i] = multipolygon.GetPolygon(i);
                        }
                        multipolygon = new MultiPolygon(pgs);
                        objs[1] = multipolygon;
                        record = new Record(objs);
                        //更新
                        mEditingLayer.MRecords.records.Delete(recordsCount - 1);
                        mEditingLayer.MRecords.records.Append(record);
                    }
                    break;
            }
        }

        #endregion

        #region 母版事件处理

        //鼠标双击
        private void MapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (mMapOpStyle)
            {
                case 0:
                    break;
                case 1: //放大
                    break;
                case 2: //缩小
                    break;
                case 3: //漫游
                    break;
                case 4: //编辑
                    break;
                case 5: //选择
                    break;
                case 6: //新建要素
                    if (e.Button == MouseButtons.Left)  //输入多边形结束
                    {
                        //根据图层类型判断是否可以结束输入
                        switch (mTrackingLayer.FeatureType)
                        {
                            case FeatureTypeConstant.PointD:
                                if (TrackingFeature.Count > 0)    //顶点数目大于0才能结束输入点要素
                                {
                                    AddFeature(mTrackingLayer);
                                }
                                break;
                            case FeatureTypeConstant.Polyline:
                            case FeatureTypeConstant.MultiPolyline:
                                if (TrackingFeature.Count >= 2)    //顶点数目大于等于2才能结束输入线要素
                                {
                                    AddFeature(mTrackingLayer);
                                }
                                break;
                            case FeatureTypeConstant.Polygon:
                            case FeatureTypeConstant.MultiPolygon:
                                if (TrackingFeature.Count >= 3)    //顶点数目大于等于3才能结束输入多边形要素
                                {
                                    AddFeature(mTrackingLayer);
                                }
                                break;
                        }
                        Refresh();
                    }
                    break;
            }
        }

        //鼠标按下
        private void MapControl_MouseDown(object sender, MouseEventArgs e)
        {
            switch (mMapOpStyle)
            {
                case 0:
                    break;
                case 1: //放大
                    if (e.Button == MouseButtons.Left)
                    {
                        PointD sMouseLocation = new PointD(e.Location.X, e.Location.Y);
                        PointD sPoint = ToMapPoint(sMouseLocation);
                        ZoomByCenter(sPoint, mcZoomRatio);
                        Refresh();
                    }
                    break;
                case 2: //缩小
                    if (e.Button == MouseButtons.Left)
                    {
                        PointD sMouseLocation = new PointD(e.Location.X, e.Location.Y);
                        PointD sPoint = ToMapPoint(sMouseLocation);
                        ZoomByCenter(sPoint, 1 / mcZoomRatio);
                        Refresh();
                    }
                    break;
                case 3: //漫游
                    if (e.Button == MouseButtons.Left)
                    {
                        mMouseLocation.X = e.Location.X;
                        mMouseLocation.Y = e.Location.Y;
                    }
                    break;
                case 4: //编辑
                    if (e.Button == MouseButtons.Left)
                    {
                        //鼠标位置在地图上的坐标
                        PointD MouseMapPosition = new PointD(e.Location.X, e.Location.Y);
                        //检查是否定位到节点
                        CheckEditPoint(MouseMapPosition);
                    }
                    break;
                case 5: //选择
                    if (e.Button == MouseButtons.Left)
                    {
                        if (e.Clicks == 1)  //点选
                        {
                            PointD SelPoint = ToMapPoint(new PointD(e.Location.X, e.Location.Y));
                            if (SelectingByPointFinished != null)
                                SelectingByPointFinished(this, SelPoint);//触发事件，并传递选择的点
                        }
                        else
                        {
                            mStartPoint = e.Location;  //框选
                        }                            
                    }
                    break;
                case 6: //新建要素
                    if (e.Button == MouseButtons.Left && e.Clicks == 1)  //选择新点
                    {
                        //判断图层类型并给予相应操作
                        switch (mTrackingLayer.FeatureType)
                        {
                            case FeatureTypeConstant.PointD:
                                TrackingFeature[0] = new PointF(e.Location.X, e.Location.Y);
                                break;
                            case FeatureTypeConstant.Polyline:
                            case FeatureTypeConstant.MultiPolyline:
                            case FeatureTypeConstant.Polygon:
                            case FeatureTypeConstant.MultiPolygon:
                                TrackingFeature.Add(new PointF(e.Location.X, e.Location.Y));
                                break;
                        }
                        Refresh();
                    }
                    else if (e.Button == MouseButtons.Right && e.Clicks == 1)    //取消上一个选择点
                    {
                        //判断图层类型并给予相应操作
                        switch (mTrackingLayer.FeatureType)
                        {
                            case FeatureTypeConstant.PointD:
                                TrackingFeature.Clear();
                                break;
                            case FeatureTypeConstant.Polyline:
                            case FeatureTypeConstant.MultiPolyline:
                            case FeatureTypeConstant.Polygon:
                            case FeatureTypeConstant.MultiPolygon:
                                if (TrackingFeature.Count > 0)
                                    TrackingFeature.RemoveAt(TrackingFeature.Count - 1);
                                break;
                        }
                        Refresh();
                    }
                    break;
            }
        }

        //鼠标松开
        private void MapControl_MouseUp(object sender, MouseEventArgs e)
        {
            switch (mMapOpStyle)
            {
                case 0:
                    break;
                case 1: //放大
                    break;
                case 2: //缩小
                    break;
                case 3: //漫游
                    break;
                case 4: //编辑
                    if (e.Button == MouseButtons.Left)
                    { 
                        Editing = false;                       
                    }
                    break;
                case 5: //选择
                    if (e.Button == MouseButtons.Left)
                    {
                        double sMinX = Math.Min(mStartPoint.X, e.Location.X);
                        double sMaxX = Math.Max(mStartPoint.X, e.Location.X);
                        double sMinY = Math.Min(mStartPoint.Y, e.Location.Y);
                        double sMaxY = Math.Max(mStartPoint.Y, e.Location.Y);
                        PointD sTopLeft = new PointD(sMinX, sMinY);
                        PointD sBottomRight = new PointD(sMaxX, sMaxY);
                        PointD sTopLeftOnMap = ToMapPoint(sTopLeft);
                        PointD sBottomRightOnMap = ToMapPoint(sBottomRight);
                        RectangleD sSelBox = new RectangleD(sTopLeftOnMap.X, sBottomRightOnMap.X, sTopLeftOnMap.Y, sBottomRightOnMap.Y);
                        Refresh();
                        if (SelectingByBoxFinished != null)
                            SelectingByBoxFinished(this, sSelBox);//触发事件，并传递选择盒
                    }
                    break;
                case 6: //新建要素
                    break;
            }
        }

        //鼠标移动
        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            switch (mMapOpStyle)
            {
                case 0:
                    break;
                case 1: //放大
                    break;
                case 2: //缩小
                    break;
                case 3: //漫游
                    if (e.Button == MouseButtons.Left)
                    {
                        PointD sPreMouseLocation = new PointD(mMouseLocation.X, mMouseLocation.Y);
                        PointD sPrePoint = ToMapPoint(sPreMouseLocation);
                        PointD sCurMouseLocation = new PointD(e.Location.X, e.Location.Y);
                        PointD sCurPoint = ToMapPoint(sCurMouseLocation);
                        mOffsetX = mOffsetX + sPrePoint.X - sCurPoint.X;
                        mOffsetY = mOffsetY + sPrePoint.Y - sCurPoint.Y;
                        Refresh();
                        mMouseLocation.X = e.Location.X;
                        mMouseLocation.Y = e.Location.Y;
                    }
                    break;
                case 4: //编辑
                    if (e.Button == MouseButtons.Left && Editing)
                    {
                        //鼠标位置在地图上的坐标
                        PointD MouseMapPosition = new PointD(e.Location.X, e.Location.Y);
                        EditPoint(MouseMapPosition);                       
                        Refresh();
                    }
                    break;
                case 5: //选择
                    if (e.Button == MouseButtons.Left)
                    {
                        Refresh();
                        Graphics g = Graphics.FromHwnd(this.Handle);
                        Pen sBoxPen = new Pen(mcSelectingBoxColor, mcSelectingBoxWidth);
                        float sMinX = Math.Min(mStartPoint.X, e.Location.X);
                        float sMaxX = Math.Max(mStartPoint.X, e.Location.X);
                        float sMinY = Math.Min(mStartPoint.Y, e.Location.Y);
                        float sMaxY = Math.Max(mStartPoint.Y, e.Location.Y);
                        g.DrawRectangle(sBoxPen, sMinX, sMinY, sMaxX - sMinX, sMaxY - sMinY);
                        g.Dispose();
                    }
                    break;
                case 6: //新建要素
                    mMouseLocation.X = e.Location.X;
                    mMouseLocation.Y = e.Location.Y;
                    break;
            }
        }

        //鼠标滑轮
        private void MapControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_SelfMouseWheel == true)
            {
                if (e.Delta > 0)
                {
                    PointD sCenterPoint = new PointD(this.ClientSize.Width / 2, this.ClientSize.Height / 2);//屏幕中心点
                    PointD sCenterPointOnMap = ToMapPoint(sCenterPoint);
                    ZoomByCenter(sCenterPointOnMap, mcZoomRatio);
                    Refresh();
                }
                else
                {
                    PointD sCenterPoint = new PointD(this.ClientSize.Width / 2, this.ClientSize.Height / 2);//屏幕中心点
                    PointD sCenterPointOnMap = ToMapPoint(sCenterPoint);
                    ZoomByCenter(sCenterPointOnMap, 1 / mcZoomRatio);
                    Refresh();
                }
            }
        }

        //母版重绘
        private void MapControl_Paint(object sender, PaintEventArgs e)
        {
            //绘制所有图层集
            DrawLayers(e.Graphics, _Layers);
            //绘制选中要素图层集
            DrawSelectedFeatures(e.Graphics);            
            //绘制跟踪要素           
            DrawTrackingLayers(e.Graphics);
        }

        #endregion
    }
}