using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GISDesign_ZY
{
    public class LabelRenderer
    {
        /// <summary>
        /// 是否使用注记
        /// </summary>
        public bool Used;
        private string _field;
        public TextSymbol MTextSymbol;

        /// <summary>
        /// 获取设置绑定字段
        /// </summary>
        public string Field
        {
            set
            {
                _field = value;
                Used = true;
            }
            get
            {
                return _field;
            }
        }

        public LabelRenderer()
        {
            Used = false;
            MTextSymbol = new TextSymbol();  //默认符号
        }

    
    }

    /// <summary>
    /// 注记文字符号类
    /// </summary>
    public class TextSymbol
    {
        public string FontName { get; set; }
        public int FontSize { get; set; }
        public bool FontBold { get; set; }
        public bool FontItalic { get; set; }
        public bool FontUnderline { get; set; }
        public Color FontColor { get; set; }

        /// <summary>
        /// 顺时针旋转角度，角度制
        /// </summary>
        public double Angle { get; set; }
        /// <summary>
        /// x方向偏移像素数
        /// </summary>
        public double OffsetX { get; set; }
        /// <summary>
        /// y方向偏移像素数
        /// </summary>
        public double OffsetY { get; set; }


        public TextSymbol()
        {
            FontName = "宋体";
            FontSize = 12;
            FontBold = false;
            FontItalic = false;
            FontUnderline = false;
            FontColor = Color.Black;
            Angle = 0;
            OffsetX = 0;
            OffsetY = 0;
        }

        public TextSymbol(string name, int size)
        {
            FontName = name;
            FontSize = size;
            FontBold = false;
            FontItalic = false;
            FontUnderline = false;
            FontColor = Color.Black;
            Angle = 0;
            OffsetX = 0;
            OffsetY = 0;
        }

        public Font ToFont()
        {
            FontStyle style = new FontStyle();
            if (FontBold && FontItalic && FontUnderline)
                style = FontStyle.Bold | FontStyle.Italic | FontStyle.Underline;
            else if (FontItalic && FontUnderline)
                style = FontStyle.Italic | FontStyle.Underline;
            else if (FontBold && FontUnderline)
                style = FontStyle.Bold | FontStyle.Underline;
            else if (FontBold && FontItalic)
                style = FontStyle.Bold | FontStyle.Italic;
            else if (FontBold)
                style = FontStyle.Bold;
            else if (FontItalic)
                style = FontStyle.Italic;
            else if (FontUnderline)
                style = FontStyle.Underline;

            Font res = new Font(FontName,FontSize, style);
            return res;
        }
    }
}
