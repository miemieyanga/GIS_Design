﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GISDesign_ZY
{
    abstract class Renderer
    {
        public RendererType Type;
    }

    /// <summary>
    /// 简单渲染器
    /// </summary>
    class SimpleRenderer:Renderer
    {
        public Symbol MSymbol;
        public SimpleRenderer()
        {
            Type = RendererType.SimpleRenderer;
        }
    }

    /// <summary>
    /// 唯一值渲染器
    /// </summary>
    class UniqueValueRenderer : Renderer
    {
        public string Field;
        public string FieldLabel;
        public bool ShowFieldLabel;
        public int ValueCount;
        public Symbol DefaultSymbol;
        public bool ShowDefaultSymbol;
        private List<string> values;
        private List<Symbol> symbols;

        public UniqueValueRenderer()
        {
            Type = RendererType.UniqueValueRenderer;
            ShowFieldLabel = true;
            ValueCount = 0;
            ShowDefaultSymbol = true;
            values = new List<string>();
            symbols = new List<Symbol>();
        }

        public string Value(int index)
        {
            if (index >= values.Count || index < 0)
                throw new Exception("超出范围");

            return values[index];
        }

        public Symbol Symbol(int index)
        {
            if (index >= values.Count || index < 0)
                throw new Exception("超出范围");

            return symbols[index];
        }

        public void AddValue(string value, Symbol symbol)
        {
            values.Add(value);
            symbols.Add(symbol.Clone());
            ValueCount += 1;
        }

        public Symbol FindSymbol(string value)
        {
            int index = values.IndexOf(value);
            if(index==-1)
                throw new Exception("未设置指定的值");

            return symbols[index];
        }

        public void RandomColor(int minR,int minG,int minB,
            int maxR,int maxG,int maxB)
        {
            Random random = new Random();
            for (int i = 0; i < ValueCount; i++)
            {
                int R = (int)(random.NextDouble() * (maxR - minR))+minR;
                int G = (int)(random.NextDouble() * (maxG - minG))+minG;
                int B = (int)(random.NextDouble() * (maxB - minB))+minB;
                int rgb = 256*R + 256*256 * G + 256*256 * 256 * B;
                Color curColor = Color.FromArgb(rgb);
                Symbol curSymbol = symbols[i];
                switch (curSymbol.Type)
                {
                    case SymbolType.SimpleMarkerSymbol:
                        SimpleMarkerSymbol simpleMarkerSymbol = (SimpleMarkerSymbol)curSymbol;
                        simpleMarkerSymbol.MColor = curColor;
                        symbols[i] = simpleMarkerSymbol;
                        break;
                    case SymbolType.SimpleLineSymbol:
                        SimpleLineSymbol simpleLineSymbol = (SimpleLineSymbol)curSymbol;
                        simpleLineSymbol.MColor = curColor;
                        symbols[i] = simpleLineSymbol;
                        break;
                    case SymbolType.SimpleFillSymbol:
                        SimpleFillSymbol simpleFillSymbol = (SimpleFillSymbol)curSymbol;
                        simpleFillSymbol.FillColor = curColor;
                        simpleFillSymbol.OutlineColor = curColor;
                        symbols[i] = simpleFillSymbol;
                        break;
                    case SymbolType.HatchFillSymbol:
                        HatchFillSymbol hatchFillSymbol = (HatchFillSymbol)curSymbol;
                        hatchFillSymbol.BackColor = curColor;
                        hatchFillSymbol.OutlineColor = curColor;
                        symbols[i] = hatchFillSymbol;
                        break;
                    default:
                        break;
                }

            }
        }
    }

    /// <summary>
    /// 分级渲染器
    /// </summary>
    class ClassBreaksRenderer : Renderer
    {
        public string Field;
        public string FieldLabel;
        public bool ShowFieldLabel;
        public int BreakCount;
        private List<Symbol> symbols;
        private List<double> breaks;

        public ClassBreaksRenderer()
        {
            ShowFieldLabel = true;
            BreakCount = 0;
            symbols = new List<Symbol>();
            breaks = new List<double>();
        }

        public double Break(int index)
        {
            if (index >= breaks.Count || index < 0)
                throw new Exception("超出范围");

            return breaks[index];
        }

        public Symbol Symbol(int index)
        {
            if (index >= breaks.Count || index < 0)
                throw new Exception("超出范围");

            return symbols[index];
        }

        /// <summary>
        /// 添加分隔值和对应符号，分隔值是当前区间最左边的点
        /// </summary>
        public void AddBreak(double mBreak, Symbol symbol)
        {
            if (breaks.Count == 0)
            {
                breaks.Add(mBreak);
                Symbol curSymbol = symbol.Clone();
                symbols.Add(curSymbol);
                BreakCount = 0;
            }
            else
            {
                if (mBreak <= breaks[BreakCount])
                {
                    throw new Exception("错误的值");
                }

                breaks.Add(mBreak);
                Symbol curSymbol = symbol.Clone();
                symbols.Add(curSymbol);
                BreakCount += 1;
            }
        }

        public void RampColors(Color sColor, Color eColor)
        {
            for(int i = 0; i < BreakCount + 1; i++)
            {
                Color curColor = Color.FromArgb(i*Math.Abs(eColor.ToArgb() - sColor.ToArgb())/
                    (BreakCount + 1)+Math.Min(eColor.ToArgb(), sColor.ToArgb()));
                Symbol curSymbol = symbols[i];
                switch (curSymbol.Type)
                {
                    case SymbolType.SimpleMarkerSymbol:
                        SimpleMarkerSymbol simpleMarkerSymbol = (SimpleMarkerSymbol)curSymbol;
                        simpleMarkerSymbol.MColor = curColor;
                        symbols[i] = simpleMarkerSymbol;
                        break;
                    case SymbolType.SimpleLineSymbol:
                        SimpleLineSymbol simpleLineSymbol = (SimpleLineSymbol)curSymbol;
                        simpleLineSymbol.MColor = curColor;
                        symbols[i] = simpleLineSymbol;
                        break;
                    case SymbolType.SimpleFillSymbol:
                        SimpleFillSymbol simpleFillSymbol = (SimpleFillSymbol)curSymbol;
                        simpleFillSymbol.FillColor = curColor;
                        simpleFillSymbol.OutlineColor = curColor;
                        symbols[i] = simpleFillSymbol;
                        break;
                    case SymbolType.HatchFillSymbol:
                        HatchFillSymbol hatchFillSymbol = (HatchFillSymbol)curSymbol;
                        hatchFillSymbol.BackColor = curColor;
                        hatchFillSymbol.OutlineColor = curColor;
                        symbols[i] = hatchFillSymbol;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 生成分级大小，仅支持点样式
        /// </summary>
        public void SizeSymbol(double sSize, double eSize)
        {
            if (eSize <= sSize)
            {
                throw new Exception("参数错误");
            }

            for (int i = 0; i < BreakCount + 1; i++)
            {
                double curSize = i * (eSize - sSize) /(BreakCount + 1) + sSize;
                switch (symbols[i].Type)
                {
                    case SymbolType.SimpleMarkerSymbol:
                        SimpleMarkerSymbol simpleMarkerSymbol = (SimpleMarkerSymbol)symbols[i];
                        simpleMarkerSymbol.Size = curSize;
                        break;
                    default:
                        break;
                }
            }
        }

        public Symbol FindSymbol(double value)
        {
            if (symbols.Count == 0)
                throw new Exception("空的符号数组");
            if (symbols.Count == 1)
                return symbols[0];
            if (value >= breaks[BreakCount])
            {
                return symbols[BreakCount];
            }
            if (value < breaks[1])
            {
                return symbols[0];
            }

            int index = 0;
            bool found = false;
            for(int i = 1; i < BreakCount; i++)
            {
                if (value >= breaks[i] && value < breaks[i + 1])
                {
                    index = i;
                    found = true;
                    break;
                }
            }

            if (found)
            {
                return symbols[index];
            }
            else
            {
                throw new Exception("找不到对应符号");
            }
        }
    }
}