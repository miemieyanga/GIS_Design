using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GIS_Design;
using ClassLibraryIofly;

namespace GISDesign_ZY
{
    public partial class LayerProperties : Form
    {
        #region 属性

        // 当前窗体的图层
        internal Layer curLayer;

        // 存储用于生成渲染器的符号和值
        private Symbol simpleRendererSymbol;
        private List<string> uniqueRendererValues;
        private List<double> classbreakRendererBreaks;
        private List<Symbol> symbols;
        private List<string> fieldLabels;
        private TextSymbol textSymbol;
        private Symbol symbolToReset;
        private int rowToSet, columnToSet;
        private Symbol defaultSymbol;
        private ColorRampClass curColorRamp;

        //随即色带类集合
        private RandomColorRampClass[] randomRampColors
            = {new RandomColorRampClass(100),
            new RandomColorRampClass(0,255,0,0,0,0,100) ,
            new RandomColorRampClass(0,0,0,255,0,0,100),
            new RandomColorRampClass(0,0,0,0,0,255,100),
            new RandomColorRampClass(0,255,0,255,0,0,100)};
        private ColorRampClass[] rampColors
            = {new ColorRampClass(100,Color.White,Color.Red),
        new ColorRampClass(100,Color.Green,Color.Red),
        new ColorRampClass(100,Color.Blue,Color.Red)};

        #endregion

        #region 构造
        public LayerProperties(Layer layer)
        {
            InitializeComponent();
            uniqueRendererValues = new List<string>();
            classbreakRendererBreaks = new List<double>();
            symbols = new List<Symbol>();
            fieldLabels = new List<string>();
            curLayer = layer;
            if(layer.MRenderer.Type == RendererType.SimpleRenderer)
            {
                SimpleRenderer simple = (SimpleRenderer)layer.MRenderer;
                simpleRendererSymbol = simple.MSymbol;
            }
            else
            {
                simpleRendererSymbol = SymbolFactory.CreateSymbol(curLayer.FeatureType);
            }
            textSymbol = curLayer.MLabelRender.MTextSymbol;
            defaultSymbol = SymbolFactory.CreateSymbol(curLayer.FeatureType);
        }
        #endregion

        #region 事件

        //处理完成事件
        public delegate void FinishSettingLayerHandler(object sender);

        public event FinishSettingLayerHandler FinishSettingLayer;

        public delegate void FinishSettingLabelHandler(object sender);

        public event FinishSettingLabelHandler FinishSettingLabel;

        #endregion

        #region 事件处理
        //窗体生成事件
        private void LayerProperties_Load(object sender, EventArgs e)
        {
            //图层信息加载
            layerNameTbx.Text = curLayer.Name;
            layerVisibleChb.Checked = curLayer.Visible;
            layerDescriptTbx.Text = curLayer.Descript;

            RectangleD rectangleD = curLayer.GetExtent();
            upLbl.Text = rectangleD.MaxY.ToString();
            downLbl.Text = rectangleD.MinY.ToString();
            leftLbl.Text = rectangleD.MinX.ToString();
            rightLbl.Text = rectangleD.MaxX.ToString();

            datasourceTbx.Text += "数据源：" + curLayer.DataSource + "\r\n";
            datasourceTbx.Text += "几何数据类型：" + curLayer.FeatureTypeString + "\r\n";
            datasourceTbx.Text += "地理坐标系： WGS84" + "\r\n";
            datasourceTbx.Text += "投影坐标系： Equidistant Tangent Cylinder Projection" + "\r\n";
            
            //标注界面初始化
            for (int i = 0; i < curLayer.MRecords.fields.Count(); i++)
            {
                labelRendererValueCmb.Items.Add(curLayer.MRecords.fields.Item(i).name);
            }
            if(curLayer.MRecords.records.Count()!=0)
                labelRendererValueCmb.SelectedIndex = 0;
            fontSizeTbx.Text = textSymbol.FontSize.ToString();
            fontNameCmb.Text = textSymbol.FontName;

            //TODO:简单渲染按钮设计
            Bitmap symbolBitmap = new Bitmap(symbolBtn.Width, symbolBtn.Height);
            Graphics g = Graphics.FromImage(symbolBitmap);
            DrawSymbol.DrawAnySymbol(g, simpleRendererSymbol, g.VisibleClipBounds);
            symbolBtn.Image = symbolBitmap;
            symbolBtn.Refresh();

            //初始化值字段、色带
            //唯一值
            defaulySymbolBtn.Image = DrawSymbol.GetBitmapOfSymbol(defaultSymbol,
                new RectangleF(0,0, defaulySymbolBtn.Bounds.Width, defaulySymbolBtn.Bounds.Y));
            for (int i = 0; i < curLayer.MRecords.fields.Count(); i++)
            {
                uniqueValueCmb.Items.Add(curLayer.MRecords.fields.Item(i).name);
            }
            for(int i=0;i< randomRampColors.Length; i++)
            {
                uniqueValueColorCmb.Items.Add(randomRampColors[i]);
            }
            uniqueValueColorCmb.DrawItem += UniqueValueColorCmb_DrawItem;
            if (curLayer.MRecords.records.Count() != 0)
            {
                uniqueValueColorCmb.SelectedIndex = 0;
                uniqueValueCmb.SelectedIndex = 0;
            }

            //分级设色/大小
            for (int i = 0; i < curLayer.MRecords.fields.Count(); i++)
            {
                if (curLayer.MRecords.fields.Item(i).valueType != "double" &&
                    curLayer.MRecords.fields.Item(i).valueType != "float" &&
                    curLayer.MRecords.fields.Item(i).valueType != "int")
                    continue;

                classBreakRendererValueCmb.Items.Add(curLayer.MRecords.fields.Item(i).name);
                classBreakRendererSizeCmb.Items.Add(curLayer.MRecords.fields.Item(i).name);
            }
            for (int i = 0; i < rampColors.Length; i++)
            {
                classBreakRendererColorCmb.Items.Add(rampColors[i]);
            }
            classBreakRendererColorCmb.DrawItem += ClassBreakRendererColorCmb_DrawItem;
            if (curLayer.MRecords.records.Count() != 0)
                classBreakRendererColorCmb.SelectedIndex = 0;

            if(classBreakRendererValueCmb.Items.Count>0)
                classBreakRendererValueCmb.SelectedIndex = 0;
            if(classBreakRendererSizeCmb.Items.Count>0)
                classBreakRendererSizeCmb.SelectedIndex = 0;
        }

        //绘制唯一值随机色带
        private void UniqueValueColorCmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;
            RandomColorRampClass curRampColors = (RandomColorRampClass)uniqueValueColorCmb.Items[e.Index];
            curRampColors.DrawRamp(e.Graphics, e.Bounds);
        }

        //绘制分级渐变色带
        private void ClassBreakRendererColorCmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;
            ColorRampClass curRampColors = (ColorRampClass)classBreakRendererColorCmb.Items[e.Index];
            curRampColors.DrawRamp(e.Graphics, e.Bounds);
        }

        //获取唯一值按下事件
        private void GetUniqueValuesBtn_Click(object sender, EventArgs e)
        {
            string bindField;
            uniqueDgv.Rows.Clear();
            bindField = uniqueValueCmb.Text;

            //获取values
            List<object> values = curLayer.MRecords.GetValuesByField(bindField);

            //生成符号
            symbols.Clear();
            RandomColorRampClass curRamp = randomRampColors[uniqueValueColorCmb.SelectedIndex];
            curRamp.Reset();
            for (int i = 0; i < values.Count; i++)
            {
                Color curColor = curRamp.Next();
                symbols.Add(SymbolFactory.CreateSymbol(curLayer.FeatureType,curColor));
            }

            //绘制gridview
            uniqueRendererValues.Clear();
            fieldLabels.Clear();
            for(int i=0;i<values.Count;i++)
            {
                object value = values[i];
                Symbol curSymbol = symbols[i];
                string cValue = value.ToString();

                uniqueRendererValues.Add(cValue);
                fieldLabels.Add(cValue);

                DataGridViewRow curRow = new DataGridViewRow();
                //DataGridViewTextBoxCell symbolCell = new DataGridViewTextBoxCell();
                //symbolCell.Value = "符号样式设置窗体";

                //TODO:
                DataGridViewImageCell symbolCell = new DataGridViewImageCell();
                symbolCell.Value = DrawSymbol.GetBitmapOfSymbol(curSymbol,
                    new RectangleF(5,1,50,18));

                curRow.Cells.Add(symbolCell);
                DataGridViewTextBoxCell uniqueCell = new DataGridViewTextBoxCell();
                uniqueCell.Value = cValue;
                curRow.Cells.Add(uniqueCell);
                DataGridViewTextBoxCell labelCell = new DataGridViewTextBoxCell();
                labelCell.Value = cValue;
                curRow.Cells.Add(labelCell);
                uniqueDgv.Rows.Add(curRow);
            }
        }

        // 分级大小获取所有值按钮按下
        private void ClassBreakSizeBtn_Click(object sender, EventArgs e)
        {
            string bindField;
            sizeDgv.Rows.Clear();
            bindField = classBreakRendererSizeCmb.Text;

            //获取value
            //TODO:保证输入的都是可以转化为double类型的值
            List<double> values = new List<double>();
            int numOfRecords = curLayer.MRecords.records.Count();
            int indexOfRecord = curLayer.MRecords.fields.GetIndexOfField(bindField);
            for (int i = 0; i < numOfRecords; i++)
            {
                values.Add(Convert.ToDouble(curLayer.MRecords.records.Item(i).Value(indexOfRecord)));
            }

            // 分级,生成符号和区间
            symbols.Clear();
            classbreakRendererBreaks.Clear();
            double min = values.Min();
            double max = values.Max();
            int breakCount = Convert.ToInt32(classBreakRendererSizeCountTbx.Text);
            int maxSize = Convert.ToInt32(classBreakRendererSizeToTbx.Text);
            int minSize = Convert.ToInt32(classBreakRendererSizeFromTbx.Text);
            int cnt = 0;
            for(double i = min; i < max; i += (max - min) / breakCount)
            {
                symbols.Add(SymbolFactory.CreateSymbol(curLayer.FeatureType,
                    minSize+(int)cnt*(maxSize-minSize)/breakCount));
                classbreakRendererBreaks.Add(i);
                cnt += 1;
            }
            classbreakRendererBreaks.Add(max);

            //TODO:
            //绘制gridview
            for (int i = 0; i < breakCount; i++)
            {
                string frm = Math.Round(classbreakRendererBreaks[i], 3).ToString();
                string to = Math.Round(classbreakRendererBreaks[i + 1], 3).ToString();
                Symbol curSymbol = symbols[i];

                DataGridViewRow curRow = new DataGridViewRow();
                DataGridViewImageCell symbolCell = new DataGridViewImageCell();
                symbolCell.Value = DrawSymbol.GetBitmapOfSymbol(curSymbol,
                    new RectangleF(20, 1, 80, 18));
                curRow.Cells.Add(symbolCell);

                DataGridViewTextBoxCell uniqueCell = new DataGridViewTextBoxCell();
                uniqueCell.Value = frm + "-" + to;
                curRow.Cells.Add(uniqueCell);
                DataGridViewTextBoxCell labelCell = new DataGridViewTextBoxCell();
                labelCell.Value = frm + "-" + to;
                curRow.Cells.Add(labelCell);
                sizeDgv.Rows.Add(curRow);
            }
        }

        // 分级设色获取所有值按钮按下
        private void Button4_Click(object sender, EventArgs e)
        {
            string bindField;
            breakDgv.Rows.Clear();
            bindField = classBreakRendererValueCmb.Text;

            //获取value
            //TODO:保证输入的都是可以转化为double类型的值
            List<double> values = new List<double>();
            int numOfRecords = curLayer.MRecords.records.Count();
            int indexOfRecord = curLayer.MRecords.fields.GetIndexOfField(bindField);
            for (int i = 0; i < numOfRecords; i++)
            {
                values.Add(Convert.ToDouble(curLayer.MRecords.records.Item(i).Value(indexOfRecord)));
            }

            // 分级,生成符号和区间
            symbols.Clear();
            classbreakRendererBreaks.Clear();
            ColorRampClass curRamp = rampColors[classBreakRendererColorCmb.SelectedIndex];
            curRamp.Reset();
            curColorRamp = curRamp;
            double min = values.Min();
            double max = values.Max();
            int breakCount = Convert.ToInt32(classBreakRendererCountTbx.Text);

            if(breakCount>=1)
                curRamp.Pace = curRamp.Size / breakCount-1;

            for (double i = min; i < max; i += (max - min) / breakCount)
            {
                Color curColor = curRamp.Next();
                symbols.Add(SymbolFactory.CreateSymbol(curLayer.FeatureType, curColor));
                classbreakRendererBreaks.Add(i);
            }
            classbreakRendererBreaks.Add(max);

            //TODO:
            //绘制gridview
            for (int i = 0; i < breakCount; i++)
            {
                string frm = Math.Round(classbreakRendererBreaks[i],3).ToString();
                string to = Math.Round(classbreakRendererBreaks[i+1], 3).ToString();
                Symbol curSymbol = symbols[i];

                DataGridViewRow curRow = new DataGridViewRow();
                DataGridViewImageCell symbolCell = new DataGridViewImageCell();
                symbolCell.Value = DrawSymbol.GetBitmapOfSymbol(curSymbol,
                    new RectangleF(20, 1, 80, 18));
                curRow.Cells.Add(symbolCell);

                DataGridViewTextBoxCell uniqueCell = new DataGridViewTextBoxCell();
                uniqueCell.Value = frm + "-" +to;
                curRow.Cells.Add(uniqueCell);
                DataGridViewTextBoxCell labelCell = new DataGridViewTextBoxCell();
                labelCell.Value = frm + "-" + to;
                curRow.Cells.Add(labelCell);
                breakDgv.Rows.Add(curRow);
            }
        }

        //确认按钮按下
        private void Button1_Click(object sender, EventArgs e)
        {
            Process();
            FinishSettingLayer(this);
            this.Dispose();
        }

        //取消键按下
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //应用键按下
        private void Button3_Click(object sender, EventArgs e)
        {
            Process();
            FinishSettingLayer(this);
        }

        //在gridView中点击符号事件
        private void UniqueDgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            //TODO:弹出符号选择器，并设置事件相应函数
            if (column == 0 && row >= 0 && row < symbols.Count)
            {
                Symbol curSymbol = symbols[row];
                SymbolSelectorFrm s = new SymbolSelectorFrm(curSymbol);
                s.FinishSettingSymbol += SetUniqueRenderer;
                s.Show();
                rowToSet = row;
                columnToSet = column;
            }
        }

        private void BreakDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            //TODO:弹出符号选择器，并设置事件相应函数
            if (column == 0 && row >= 0 && row < symbols.Count)
            {
                Symbol curSymbol = symbols[row];
                SymbolSelectorFrm s = new SymbolSelectorFrm(curSymbol);
                s.FinishSettingSymbol += SetClassBreakRenderer;
                s.Show();
                rowToSet = row;
                columnToSet = column;
            }
        }
        private void SizeDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            //TODO:弹出符号选择器，并设置事件相应函数
            if (column == 0 && row >= 0 && row < symbols.Count)
            {
                Symbol curSymbol = symbols[row];
                SymbolSelectorFrm s = new SymbolSelectorFrm(curSymbol);
                s.FinishSettingSymbol += SetClassBreakSizeRenderer;
                s.Show();
                rowToSet = row;
                columnToSet = column;
            }
        }

        //简单符号渲染 符号按钮点击事件
        private void SymbolBtn_Click(object sender, EventArgs e)
        {
            GenerateSymbolSelecter(simpleRendererSymbol);
        }

        #endregion

        #region 方法
        //生成渲染器
        private void GenerateRenderer()
        {
            switch (classBreakRendererTab.SelectedIndex)
            {
                case 0:  //简单
                    SimpleRenderer r = RendererFactory.CreateSimpleRenderer(simpleRendererSymbol);
                    r.fieldLabel = labelStringTbx.Text;
                    curLayer.MRenderer = r;
                    break;
                case 1:  //唯一值
                    UniqueValueRenderer uniqueValueRenderer = new UniqueValueRenderer();
                    uniqueValueRenderer.Field = uniqueValueCmb.Text;
                    uniqueValueRenderer.symbols = symbols;
                    uniqueValueRenderer.values = uniqueRendererValues;
                    uniqueValueRenderer.FieldLabel = fieldLabels;
                    uniqueValueRenderer.DefaultSymbol = defaultSymbol;
                    curLayer.MRenderer = uniqueValueRenderer;
                    break;
                case 2:  //分级设色
                    ClassBreaksRenderer classBreaksRenderer = new ClassBreaksRenderer();
                    classBreaksRenderer.Field = classBreakRendererValueCmb.Text;
                    classBreaksRenderer.symbols = symbols;
                    classBreaksRenderer.breaks = classbreakRendererBreaks;
                    classBreaksRenderer.FieldLabel = fieldLabels;
                    classBreaksRenderer.colorRamp = curColorRamp;
                    curLayer.MRenderer = classBreaksRenderer;
                    break;
                case 3:  //分级大小
                    ClassBreaksRenderer classBreaksRenderer1 = new ClassBreaksRenderer();
                    classBreaksRenderer1.Field = classBreakRendererSizeCmb.Text;
                    classBreaksRenderer1.symbols = symbols;
                    classBreaksRenderer1.breaks = classbreakRendererBreaks;
                    classBreaksRenderer1.FieldLabel = fieldLabels;
                    curLayer.MRenderer = classBreaksRenderer1;
                    break;
            }
        }

        // 处理确认和应用按钮按下后图层属性变化
        private void Process()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:  //渲染
                    GenerateRenderer();
                    break;
            }
        }


        //生成符号选择器并绑定事件响应函数
        private void GenerateSymbolSelecter(Symbol symbol)
        {
            //TODO
            SymbolSelectorFrm s = new SymbolSelectorFrm(symbol);
            s.FinishSettingSymbol += SetSimpleRenderer;
            s.Show();
        }

        //符号生成响应函数
        private void SetSimpleRenderer(object sender, Symbol symbol)
        {
            simpleRendererSymbol = symbol.Clone();
            symbolToReset = symbol.Clone();
            Bitmap symbolBitmap = new Bitmap(symbolBtn.Width, symbolBtn.Height);
            Graphics g = Graphics.FromImage(symbolBitmap);
            DrawSymbol.DrawAnySymbol(g, symbol, g.VisibleClipBounds);
            symbolBtn.Image = symbolBitmap;
            symbolBtn.Refresh();
        }

        //唯一值渲染器相应函数
        private void SetUniqueRenderer(object sender, Symbol symbol)
        {
            symbolToReset = symbol.Clone();
            uniqueDgv.Rows[rowToSet].Cells[columnToSet].Value = DrawSymbol.GetBitmapOfSymbol(
                symbolToReset, new RectangleF(20, 1, 80, 18));
            symbols[rowToSet] = symbolToReset;
        }

        //
        private void SetClassBreakRenderer(object sender, Symbol symbol)
        {
            symbolToReset = symbol.Clone();
            breakDgv.Rows[rowToSet].Cells[columnToSet].Value = DrawSymbol.GetBitmapOfSymbol(
                symbolToReset, new RectangleF(20, 1, 80, 18));
            symbols[rowToSet] = symbolToReset;
        }

        //
        private void SetClassBreakSizeRenderer(object sender, Symbol symbol)
        {
            symbolToReset = symbol.Clone();
            sizeDgv.Rows[rowToSet].Cells[columnToSet].Value = DrawSymbol.GetBitmapOfSymbol(
                symbolToReset, new RectangleF(20, 1, 80, 18));
            symbols[rowToSet] = symbolToReset;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            curLayer.Name = layerNameTbx.Text;
            curLayer.Descript = layerDescriptTbx.Text;
            curLayer.Visible = layerVisibleChb.Checked;
            FinishSettingLayer(this);
            Dispose();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        //字体窗体设置
        private void LabelSettingBtn_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textSymbol.FontSize = (int)fontDialog1.Font.Size;
                textSymbol.FontName = fontDialog1.Font.Name;
                textSymbol.FontBold = fontDialog1.Font.Bold;
                textSymbol.FontItalic = fontDialog1.Font.Italic;
                textSymbol.FontUnderline = fontDialog1.Font.Underline;
                fontSizeTbx.Text = textSymbol.FontSize.ToString();
                fontNameCmb.Text = textSymbol.FontName;
                emampleStringPbx.Refresh();
            }
        }

        //颜色窗体设置
        private void Button4_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textSymbol.FontColor = colorDialog1.Color;
                emampleStringPbx.Refresh();
            }
        }

        //按钮颜色
        private void ColorBtn_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(textSymbol.FontColor),
                colorBtn.DisplayRectangle);
        }
        #endregion

        private void EmampleStringPbx_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(textSymbol.FontName, textSymbol.ToFont(),
                new SolidBrush(textSymbol.FontColor), new Point(10,10));

        }

        private void FontNameCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            textSymbol.FontName = (string)fontNameCmb.Items[fontNameCmb.SelectedIndex];
            emampleStringPbx.Refresh();
        }

        private void FontSizeTbx_TextChanged(object sender, EventArgs e)
        {
            textSymbol.FontSize = Convert.ToInt16(fontSizeTbx.Text);
            emampleStringPbx.Refresh();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void DefaulySymbolBtn_Click(object sender, EventArgs e)
        {
            SymbolSelectorFrm s = new SymbolSelectorFrm(defaultSymbol);
            s.FinishSettingSymbol += SetDefaultSymbol;
            s.Show();
        }

        private void SetDefaultSymbol(object sender, Symbol symbol)
        {
            defaultSymbol = symbol;
            defaulySymbolBtn.Image = DrawSymbol.GetBitmapOfSymbol(defaultSymbol,
    new RectangleF(0, 0, defaulySymbolBtn.Bounds.Width, defaulySymbolBtn.Bounds.Y));
            defaulySymbolBtn.Refresh();
        }

        //生成注记
        private void Button9_Click(object sender, EventArgs e)
        {
            if (labelValidBtn.Checked)
            {
                curLayer.MLabelRender.Used = true;
                curLayer.MLabelRender.MTextSymbol = textSymbol;
                curLayer.MLabelRender.Field = labelRendererValueCmb.Text;
                FinishSettingLabel(this);
            }
            else
            {
                curLayer.MLabelRender.Used = false;
            }
            Dispose();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }

}
