using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GISDesign_ZY
{
    abstract class Symbol
    {
        public string Label;
        /// <summary>
        /// 符号是否可见
        /// </summary>
        public bool Visible;

        /// <summary>
        /// 当前符号类型
        /// </summary>
        public SymbolType Type;

        public abstract Symbol Clone();
    }

    /// <summary>
    /// 简单点符号
    /// </summary>
    class SimpleMarkerSymbol:Symbol
    {
        /// <summary>
        /// 点的样式
        /// </summary>
        public MarkerStyleConstant Style;

        public double Size;
        public double OffsetX;
        public double OffsetY;
        public double Angle;
        public Color MColor;
        
        public SimpleMarkerSymbol()
        {
            Type = SymbolType.SimpleMarkerSymbol;
            Visible = true;
            Style = MarkerStyleConstant.MCircle;
            Size = 5;  //5个像素大小
            OffsetX = OffsetY = 0;
            Angle = 0;
            MColor = Color.Black;
        }

        public override Symbol Clone()
        {
            SimpleMarkerSymbol res = new SimpleMarkerSymbol();
            res.Label = Label;
            res.Visible = Visible;
            res.Style = Style;
            res.Size = Size;
            res.OffsetX = OffsetX;
            res.OffsetY = OffsetY;
            res.Angle = Angle;
            res.MColor = MColor;
            return res;
        }
    }

    /// <summary>
    /// 简单线符号
    /// </summary>
    class SimpleLineSymbol : Symbol
    {
        /// <summary>
        /// 线的样式
        /// </summary>
        public LineStyleConstant Style;

        public double Width;
        public Color MColor;

        public SimpleLineSymbol()
        {
            Type = SymbolType.SimpleLineSymbol;
            Visible = true;
            Width = 1;
            Style = LineStyleConstant.LSolid;
            MColor = Color.Black;
        }

        public override Symbol Clone()
        {
            SimpleLineSymbol res = new SimpleLineSymbol();
            res.Label = Label;
            res.Visible = Visible;
            res.Style = Style;
            res.Width = Width;
            res.MColor = MColor;
            return res;
        }
    }
    
    /// <summary>
    /// 简单填充符号
    /// </summary>
    class SimpleFillSymbol : Symbol
    {
        /// <summary>
        /// 填充样式
        /// </summary>
        public FillStyleConstant FillStyle;

        /// <summary>
        /// 边界的样式
        /// </summary>
        public LineStyleConstant OutlineStyle;

        public double OutlineWidth;
        public Color FillColor;
        public Color OutlineColor;

        public SimpleFillSymbol()
        {
            Type = SymbolType.SimpleFillSymbol;
            Visible = true;
            OutlineStyle = LineStyleConstant.LSolid;
            OutlineColor = Color.Red;
            FillStyle = FillStyleConstant.FColor;
            FillColor = Color.Black;
            OutlineWidth = 1;
        }

        public override Symbol Clone()
        {
            SimpleFillSymbol res = new SimpleFillSymbol();
            res.Label = Label;
            res.Visible = Visible;
            res.FillStyle = FillStyle;
            res.OutlineStyle = OutlineStyle;

            res.OutlineWidth = OutlineWidth;
            res.FillColor = FillColor;
            res.OutlineColor = OutlineColor;
            return res;
        }
    }

    /// <summary>
    /// 阴影符号
    /// </summary>
    class HatchFillSymbol : Symbol
    {
        /// <summary>
        /// 阴影样式
        /// </summary>
        public HatchStyleConstant HatchStyle;

        /// <summary>
        /// 阴影线条颜色
        /// </summary>
        public Color HatchColor;

        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackColor;

        /// <summary>
        /// 边界的样式
        /// </summary>
        public LineStyleConstant OutlineStyle;

        public double OutlineWidth;
        public Color OutlineColor;

        public HatchFillSymbol()
        {
            Type = SymbolType.HatchFillSymbol;
            Visible = true;
            OutlineStyle = LineStyleConstant.LSolid;
            OutlineColor = Color.Red;
            OutlineWidth = 1;
            HatchStyle = HatchStyleConstant.HLine;
            HatchColor = Color.Green;
            BackColor = Color.White;
        }

        public override Symbol Clone()
        {
            HatchFillSymbol res = new HatchFillSymbol();
            res.Label = Label;
            res.Visible = Visible;
            res.HatchStyle = HatchStyle;
            res.OutlineStyle = OutlineStyle;

            res.OutlineWidth = OutlineWidth;
            res.HatchColor = HatchColor;
            res.BackColor = BackColor;
            res.OutlineColor = OutlineColor;
            return res;
        }
    }
}
