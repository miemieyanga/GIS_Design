using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GISDesign_ZY;

namespace GISDesign_ZY
{
    public static class DrawSymbol
    {
        //计算点旋转后的位置
        private static PointF Rotate(PointF point0, PointF originP, double angle)
        {
            float cosA = (float)Math.Cos(angle * Math.PI / 180);
            float sinA = (float)Math.Sin(angle * Math.PI / 180);
            PointF point = new PointF();
            point.X = (originP.X - point0.X) * cosA + (originP.Y - point0.Y) * sinA + point0.X;
            point.Y = (originP.Y - point0.Y) * cosA - (originP.X - point0.X) * sinA + point0.Y;
            return point;
        }
        
        //绘制简单点符号
        public static void DrawMarkerSymbol(Graphics g, SimpleMarkerSymbol curSymbol, PointF ScreenPoint)
        {
            PointF p0 = new PointF((float)(ScreenPoint.X + curSymbol.OffsetX), (float)(ScreenPoint.Y + curSymbol.OffsetY));
            PointF r1 = Rotate(p0, new PointF(p0.X - (float)curSymbol.Size / 2, p0.Y - (float)curSymbol.Size / 2), curSymbol.Angle);
            PointF r2 = Rotate(p0, new PointF(p0.X - (float)curSymbol.Size / 2, p0.Y + (float)curSymbol.Size / 2), curSymbol.Angle);
            PointF r3 = Rotate(p0, new PointF(p0.X + (float)curSymbol.Size / 2, p0.Y - (float)curSymbol.Size / 2), curSymbol.Angle);
            PointF r4 = Rotate(p0, new PointF(p0.X + (float)curSymbol.Size / 2, p0.Y + (float)curSymbol.Size / 2), curSymbol.Angle);
            PointF r5 = Rotate(p0, new PointF(p0.X , p0.Y - (float)curSymbol.Size / 2), curSymbol.Angle);
            PointF[] rectangle = { r1, r2, r3, r4 };
            PointF[] triangle = { r2, r4, r5 };
            //判断点要素符号并进行绘制
            switch (curSymbol.Style)
            {
                case MarkerStyleConstant.MCircle:
                    g.DrawEllipse(new Pen(curSymbol.MColor), new RectangleF((float)(ScreenPoint.X - curSymbol.Size / 2 + curSymbol.OffsetX), (float)(ScreenPoint.Y - curSymbol.Size / 2 + curSymbol.OffsetY), (float)curSymbol.Size, (float)curSymbol.Size));
                    break;
                case MarkerStyleConstant.MSolidCircle:
                    g.FillEllipse(new SolidBrush(curSymbol.MColor), new RectangleF((float)(ScreenPoint.X - curSymbol.Size / 2 + curSymbol.OffsetX), (float)(ScreenPoint.Y - curSymbol.Size / 2 + curSymbol.OffsetY), (float)curSymbol.Size, (float)curSymbol.Size));
                    break;
                case MarkerStyleConstant.MRectengle:
                    g.DrawPolygon(new Pen(curSymbol.MColor), rectangle);
                    break;
                case MarkerStyleConstant.MSolidRectengle:
                    g.FillPolygon(new SolidBrush(curSymbol.MColor), rectangle);
                    break;
                case MarkerStyleConstant.MTriangle:
                    g.DrawPolygon(new Pen(curSymbol.MColor), triangle);
                    break;
                case MarkerStyleConstant.MSolidTriangle:                    
                    g.FillPolygon(new SolidBrush(curSymbol.MColor), triangle);
                    break;
                case MarkerStyleConstant.MDotCircle:
                    g.DrawEllipse(new Pen(curSymbol.MColor), new RectangleF((float)(ScreenPoint.X - curSymbol.Size / 2 + curSymbol.OffsetX), (float)(ScreenPoint.Y - curSymbol.Size / 2 + curSymbol.OffsetY), (float)curSymbol.Size, (float)curSymbol.Size));
                    g.FillEllipse(new SolidBrush(curSymbol.MColor), new RectangleF((float)(ScreenPoint.X - curSymbol.Size / 8 + curSymbol.OffsetX), (float)(ScreenPoint.Y - curSymbol.Size / 8 + curSymbol.OffsetY), (float)curSymbol.Size / 4, (float)curSymbol.Size / 4));
                    break;
                case MarkerStyleConstant.MDoubleCircle:
                    g.DrawEllipse(new Pen(curSymbol.MColor), new RectangleF((float)(ScreenPoint.X - curSymbol.Size / 2 + curSymbol.OffsetX), (float)(ScreenPoint.Y - curSymbol.Size / 2 + curSymbol.OffsetY), (float)curSymbol.Size, (float)curSymbol.Size));
                    g.DrawEllipse(new Pen(curSymbol.MColor), new RectangleF((float)(ScreenPoint.X - curSymbol.Size / 4 + curSymbol.OffsetX), (float)(ScreenPoint.Y - curSymbol.Size / 4 + curSymbol.OffsetY), (float)curSymbol.Size / 2, (float)curSymbol.Size / 2));
                    break;
            }
        }

        //绘制简单线符号
        public static void DrawLineSymbol(Graphics g, SimpleLineSymbol curSymbol, RectangleF rectangle)
        {
            Pen pen = new Pen(curSymbol.MColor, (float)curSymbol.Width);
            //判断线要素符号确定线类型
            switch (curSymbol.Style)
            {
                case LineStyleConstant.LSolid:
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case LineStyleConstant.LDash:
                    pen.DashStyle = DashStyle.Dash;
                    break;
                case LineStyleConstant.LDot:
                    pen.DashStyle = DashStyle.Dot;
                    break;
                case LineStyleConstant.LDashDot:
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                case LineStyleConstant.LDashDotDash:
                    pen.DashStyle = DashStyle.DashDotDot;
                    break;
            }
            //绘制
            g.DrawLine(pen, new PointF(rectangle.X, rectangle.Y+rectangle.Height/2), new PointF(rectangle.X+ rectangle.Width, rectangle.Y + rectangle.Height / 2));
        }

        //绘制简单线符号
        public static void DrawLineSymbol(Graphics g, SimpleLineSymbol curSymbol,PointF frm, PointF to)
        {
            Pen pen = new Pen(curSymbol.MColor, (float)curSymbol.Width);
            //判断线要素符号确定线类型
            switch (curSymbol.Style)
            {
                case LineStyleConstant.LSolid:
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case LineStyleConstant.LDash:
                    pen.DashStyle = DashStyle.Dash;
                    break;
                case LineStyleConstant.LDot:
                    pen.DashStyle = DashStyle.Dot;
                    break;
                case LineStyleConstant.LDashDot:
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                case LineStyleConstant.LDashDotDash:
                    pen.DashStyle = DashStyle.DashDotDot;
                    break;
            }
            //绘制
            g.DrawLine(pen, frm,to);
        }

        public static void DrawLineSymbol(Graphics g, SimpleLineSymbol curSymbol, PointF[] sScreenPoints, int sPointCount)
        {
            Pen pen = new Pen(curSymbol.MColor, (float)curSymbol.Width);
            //判断线要素符号确定线类型
            switch (curSymbol.Style)
            {
                case LineStyleConstant.LSolid:
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case LineStyleConstant.LDash:
                    pen.DashStyle = DashStyle.Dash;
                    break;
                case LineStyleConstant.LDot:
                    pen.DashStyle = DashStyle.Dot;
                    break;
                case LineStyleConstant.LDashDot:
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                case LineStyleConstant.LDashDotDash:
                    pen.DashStyle = DashStyle.DashDotDot;
                    break;
            }
            //绘制
            for (int k = 0; k < sPointCount - 1; k++)
            {
                g.DrawLine(pen, sScreenPoints[k], sScreenPoints[k + 1]);
            }
        }

        //绘制简单面符号
        public static void DrawFillSymbol(Graphics g, SimpleFillSymbol curSymbol, RectangleF rectangle)
        {
            //判断填充样式并填充
            switch (curSymbol.FillStyle)
            {
                case FillStyleConstant.FColor:
                    g.FillRectangle(new SolidBrush(curSymbol.FillColor), rectangle);
                    break;
                case FillStyleConstant.FTransparent:
                    break;
            }
            //绘制边框
            SimpleLineSymbol outline = new SimpleLineSymbol();
            outline.Style = curSymbol.OutlineStyle;
            outline.Width = curSymbol.OutlineWidth;
            outline.MColor = curSymbol.OutlineColor;
            //TODO
            DrawBoundary(g, outline, rectangle);
        }

        //绘制简单面符号
        public static void DrawFillSymbol(Graphics g, SimpleFillSymbol curSymbol, PointF[] sScreenPoints, int sPointCount)
        {
            //判断填充样式并填充
            switch (curSymbol.FillStyle)
            {
                case FillStyleConstant.FColor:
                    g.FillPolygon(new SolidBrush(curSymbol.FillColor), sScreenPoints);
                    break;
                case FillStyleConstant.FTransparent:
                    break;
            }
            //绘制边框
            sScreenPoints[sPointCount].X = sScreenPoints[0].X;
            sScreenPoints[sPointCount].Y = sScreenPoints[0].Y;
            sPointCount++;
            SimpleLineSymbol outline = new SimpleLineSymbol();
            outline.Style = curSymbol.OutlineStyle;
            outline.Width = curSymbol.OutlineWidth;
            outline.MColor = curSymbol.OutlineColor;
            DrawLineSymbol(g, outline, sScreenPoints, sPointCount);
        }

        //绘制阴影符号
        public static void DrawHatchSymbol(Graphics g, HatchFillSymbol curSymbol, PointF[] sScreenPoints, int sPointCount)
        {
            //判断阴影类型并填充
            switch (curSymbol.HatchStyle)
            {
                case HatchStyleConstant.HLine:
                    g.FillPolygon(new HatchBrush(HatchStyle.Vertical, curSymbol.HatchColor, curSymbol.BackColor), sScreenPoints);
                    break;
                case HatchStyleConstant.HDot:
                    g.FillPolygon(new HatchBrush(HatchStyle.Percent10, curSymbol.HatchColor, curSymbol.BackColor), sScreenPoints);
                    break;
                case HatchStyleConstant.HCrossLine:
                    g.FillPolygon(new HatchBrush(HatchStyle.Cross, curSymbol.HatchColor, curSymbol.BackColor), sScreenPoints);
                    break;
            }
            //绘制边框
            sScreenPoints[sPointCount].X = sScreenPoints[0].X;
            sScreenPoints[sPointCount].Y = sScreenPoints[0].Y;
            sPointCount++;
            SimpleLineSymbol outline = new SimpleLineSymbol();
            outline.Style = curSymbol.OutlineStyle;
            outline.Width = curSymbol.OutlineWidth;
            outline.MColor = curSymbol.OutlineColor;
            DrawLineSymbol(g, outline, sScreenPoints, sPointCount);
        }

        //绘制边框
        public static void DrawBoundary(Graphics g, SimpleLineSymbol curSymbol, RectangleF rectangle)
        {
            Pen pen = new Pen(curSymbol.MColor, (float)curSymbol.Width);
            //判断线要素符号确定线类型
            switch (curSymbol.Style)
            {
                case LineStyleConstant.LSolid:
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case LineStyleConstant.LDash:
                    pen.DashStyle = DashStyle.Dash;
                    break;
                case LineStyleConstant.LDot:
                    pen.DashStyle = DashStyle.Dot;
                    break;
                case LineStyleConstant.LDashDot:
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                case LineStyleConstant.LDashDotDash:
                    pen.DashStyle = DashStyle.DashDotDot;
                    break;
            }
            g.DrawRectangle(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        //绘制阴影符号
        public static void DrawHatchSymbol(Graphics g, HatchFillSymbol curSymbol,RectangleF rectangle)
        {
            //判断阴影类型并填充
            switch (curSymbol.HatchStyle)
            {
                case HatchStyleConstant.HLine:
                    g.FillRectangle(new HatchBrush(HatchStyle.Vertical,curSymbol.HatchColor, curSymbol.BackColor), rectangle);
                    break;
                case HatchStyleConstant.HDot:
                    g.FillRectangle(new HatchBrush(HatchStyle.Percent10, curSymbol.HatchColor, curSymbol.BackColor), rectangle);
                    break;
                case HatchStyleConstant.HCrossLine:
                    g.FillRectangle(new HatchBrush(HatchStyle.Cross, curSymbol.HatchColor, curSymbol.BackColor), rectangle);
                    break;
            }
            //绘制边框

            SimpleLineSymbol outline = new SimpleLineSymbol();
            outline.Style = curSymbol.OutlineStyle;
            outline.Width = curSymbol.OutlineWidth;
            outline.MColor = curSymbol.OutlineColor;
            DrawBoundary(g, outline, rectangle);
            //DrawLineSymbol(g, outline, rectangle);
        }

        //绘制符号样例
        public static void DrawAnySymbol(Graphics g,Symbol curSymbol, RectangleF rectangle)
        {
            switch (curSymbol.Type)
            {
                case SymbolType.SimpleMarkerSymbol:
                    SimpleMarkerSymbol s = (SimpleMarkerSymbol)curSymbol;
                    DrawMarkerSymbol(g, s,new PointF(rectangle.X+rectangle.Width/2,rectangle.Y+rectangle.Height/2));
                    break;
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol s1 = (SimpleLineSymbol)curSymbol;
                    DrawLineSymbol(g, s1, rectangle); 
                    break;
                case SymbolType.SimpleFillSymbol:
                    SimpleFillSymbol s2 = (SimpleFillSymbol)curSymbol;
                    DrawFillSymbol(g, s2, rectangle);
                    break;
                case SymbolType.HatchFillSymbol:
                    HatchFillSymbol s3 = (HatchFillSymbol)curSymbol;
                    DrawHatchSymbol(g, s3, rectangle);
                    break;
            }
        }

        public static Bitmap GetBitmapOfSymbol(Symbol curSymbol, RectangleF rectangle)
        {
            Bitmap res = new Bitmap((int)rectangle.Width, (int)rectangle.Height);
            Graphics g = Graphics.FromImage(res);

            DrawAnySymbol(g, curSymbol, rectangle);
            return res;
        }
    }   
}
