using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GISDesign_ZY
{
    /// <summary>
    /// 随机色带类
    /// </summary>
    class RandomColorRampClass
    {
        #region 属性
        public int beginR, endR, beginG, endG, beginB, endB;
        private int curPos;
        public int Size;
        public Color[] colors;

        public int rampCountToShow;   //bitmap上显示多少个颜色

        #endregion

        #region 构造函数
        public RandomColorRampClass(int s)
        {
            beginR = beginG = beginB = 0;
            endR = endG = endB = 255;
            rampCountToShow = 20;
            Size = s;
            colors = new Color[s];
            CreateRamap();
        }

        public RandomColorRampClass(int br, int er, int bg, int eg, int bb, 
            int eb, int size)
        {
            beginR = br;
            beginB = bb;
            beginG = bg;
            endR = er;
            endG = eg;
            endB = eb;
            Size = size;
            rampCountToShow = 20;
            colors = new Color[size];
            CreateRamap();
        }
        #endregion

        #region 方法

        /// <summary>
        /// 复位
        /// </summary>
        public void Reset()
        {
            curPos = 0;
        }

        /// <summary>
        /// 获取下一个颜色
        /// </summary>
        public Color Next()
        {
            int i = curPos;
            if (i >= colors.Length)
                i = i % colors.Length;
            curPos = curPos + 1;
            return colors[i];
        }

        /// <summary>
        /// 生成随机色带
        /// </summary>
        public void CreateRamap()
        {
            Random random = new Random();
            for (int i = 0; i < Size; i++)
            {
                int R = (int)(random.NextDouble() * (endR - beginR)) + beginR;
                int G = (int)(random.NextDouble() * (endG - beginG)) + beginG;
                int B = (int)(random.NextDouble() * (endB - beginB)) + beginB;
                Color curColor = Color.FromArgb(R,G,B);
                colors[i] = curColor;
            }
        }

        /// <summary>
        /// 绘制色带
        /// </summary>
        /// <param name="bbox">bitmap的范围</param>
        public void DrawRamp(Graphics g,Rectangle bbox)
        {
            Pen pen = new Pen(Color.White);
            for (int i = 0; i < rampCountToShow; i++)
            {
                Color c = Next();
                SolidBrush brush = new SolidBrush(c);
                g.FillRectangle(brush,bbox.X+i*bbox.Width/ rampCountToShow,bbox.Y,
                    bbox.Width / rampCountToShow,bbox.Height);
                //g.DrawRectangle(pen, bbox.X + i * bbox.Width / rampCountToShow, bbox.Y,
                    //bbox.Width / rampCountToShow, bbox.Height);
            }
            pen.Width = 3;
            g.DrawRectangle(pen, bbox);
            curPos = 0;
        }

        #endregion
    }

    /// <summary>
    /// 色带类
    /// </summary>
    class ColorRampClass
    {
        # region 属性
        public Color[] colors;
        private int curPos;
        public int Size;
        public Color beginColor, endColor;
        #endregion

        #region 构造函数
        /// <summary>
        ///  生成渐变色带
        /// </summary>
        /// <param name="size">颜色数量</param>
        public ColorRampClass(int size)
        {
            curPos = 0;
            Size = size;
            colors = new Color[size];
        }
        /// <summary>
        /// 生成渐变色带
        /// </summary>
        /// <param name="size">颜色数量</param>
        /// <param name="b">开始颜色</param>
        /// <param name="e">结束颜色</param>
        public ColorRampClass(int size, Color b, Color e)
        {
            curPos = 0;
            colors = new Color[size];
            beginColor = b;
            endColor = e;
            RampColors();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 复位
        /// </summary>
        public void Reset()
        {
            curPos = 0;
        }

        /// <summary>
        /// 生成色带
        /// </summary>
        public void RampColors()
        {
            for (int i = 0; i < Size; i++)
            {
                Color curColor = Color.FromArgb(i * Math.Abs(endColor.ToArgb() - beginColor.ToArgb()) /
                    Size + Math.Min(endColor.ToArgb(), beginColor.ToArgb()));
                colors[i] = curColor;
            }
        }

        /// <summary>
        /// 获取色带的bitmap
        /// </summary>
        /// <param name="bbox">bitmap的范围</param>
        /// <returns></returns>
        public void DrawRamp(Graphics g,Rectangle bbox)
        {
            LinearGradientBrush brush = new 
                LinearGradientBrush(bbox, beginColor, endColor, LinearGradientMode.Horizontal);
            g.FillRectangle(brush, bbox);
            Pen pen = new Pen(Color.White);
            pen.Width = 3;
            g.DrawRectangle(pen, bbox);
            curPos = 0;
        }

        /// <summary>
        /// 获取下一个颜色
        /// </summary>
        public Color Next()
        {
            int i = curPos;
            if (i >= colors.Length)
                i = i % colors.Length;
            curPos = curPos + 1;
            return colors[i];
        }

        #endregion
    }
}
