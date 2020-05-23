using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GISDesign_ZY
{
    /// <summary>
    /// 生成随机颜色的类
    /// </summary>
    class RandomColorRampClass
    {
        public int beginR, endR, beginG, endG, beginB, endB;
        public int size;
        public ColorRampClass colors;
        public RandomColorRampClass()
        {
            beginR = beginG = beginB = 0;
            endR = endG = endB = 255;
            size = 100;
            colors = new ColorRampClass(size);
        }

        /// <summary>
        /// 生成随机色带
        /// </summary>
        public void CreateRamap()
        {
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                int R = (int)(random.NextDouble() * (endR - beginR)) + beginR;
                int G = (int)(random.NextDouble() * (endG - beginG)) + beginG;
                int B = (int)(random.NextDouble() * (endB - beginB)) + beginB;
                int rgb = 256 * R + 256 * 256 * G + 256 * 256 * 256 * B;
                Color curColor = Color.FromArgb(rgb);
                colors.colors[i] = curColor;
            }
        }
    }

    /// <summary>
    /// 色带类
    /// </summary>
    class ColorRampClass
    {
        public Color[] colors;
        public int curPos;
        public ColorRampClass(int size)
        {
            curPos = 0;
            colors = new Color[size];
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
    }
}
