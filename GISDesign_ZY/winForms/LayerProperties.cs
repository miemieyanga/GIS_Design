using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
        #endregion

        #region 事件

        //处理完成事件
        public delegate void FinishSettingLayerHandler(object sender);

        public event FinishSettingLayerHandler FinishSettingLayer;

        #endregion

        #region 事件处理
        //窗体生成事件
        private void LayerProperties_Load(object sender, EventArgs e)
        {
            //图层信息加载
            layerNameTbx.Text = curLayer.Name;
            layerVisibleChb.Checked = curLayer.Visible;
            layerDescriptTbx.Text = curLayer.Descript;

            upLbl.Text = curLayer.MaxY.ToString();
            downLbl.Text = curLayer.MinY.ToString();
            leftLbl.Text = curLayer.MinX.ToString();
            rightLbl.Text = curLayer.MaxX.ToString();

            datasourceTbx.Text += "数据源：" + curLayer.DataSource + "\r\n";
            datasourceTbx.Text += "几何数据类型：" + curLayer.FeatureTypeString + "\r\n";
            datasourceTbx.Text += "地理坐标系： WGS84" + "\r\n";
            datasourceTbx.Text += "投影坐标系： Equidistant Tangent Cylinder Projection" + "\r\n";
            
            //标注界面初始化
            for (int i = 0; i < curLayer.MRecords.fields.Count(); i++)
            {
                labelRendererValueCmb.Items.Add(curLayer.MRecords.fields.Item(i).name);
            }
            labelRendererValueCmb.SelectedIndex = 0;
            fontSizeTbx.Text = textSymbol.FontSize.ToString();
            fontNameCmb.Text = textSymbol.FontName;

            //TODO:简单渲染按钮设计


            //初始化值字段、色带
            //唯一值
            for (int i = 0; i < curLayer.MRecords.fields.Count(); i++)
            {
                uniqueValueCmb.Items.Add(curLayer.MRecords.fields.Item(i).name);
            }
            for(int i=0;i< randomRampColors.Length; i++)
            {
                uniqueValueColorCmb.Items.Add(randomRampColors[i]);
            }
            uniqueValueColorCmb.DrawItem += UniqueValueColorCmb_DrawItem;
            uniqueValueColorCmb.SelectedIndex = 0;
            uniqueValueCmb.SelectedIndex = 0;

            //分级设色/大小
            for (int i = 0; i < curLayer.MRecords.fields.Count(); i++)
            {
                classBreakRendererValueCmb.Items.Add(curLayer.MRecords.fields.Item(i).name);
                classBreakRendererSizeCmb.Items.Add(curLayer.MRecords.fields.Item(i).name);
            }
            for (int i = 0; i < rampColors.Length; i++)
            {
                classBreakRendererColorCmb.Items.Add(rampColors[i]);
            }
            classBreakRendererColorCmb.DrawItem += ClassBreakRendererColorCmb_DrawItem;
            classBreakRendererColorCmb.SelectedIndex = 0;
            classBreakRendererValueCmb.SelectedIndex = 0;

            classBreakRendererSizeCmb.SelectedIndex = 0;
        }

        //绘制唯一值随机色带
        private void UniqueValueColorCmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            RandomColorRampClass curRampColors = (RandomColorRampClass)uniqueValueColorCmb.Items[e.Index];
            curRampColors.DrawRamp(e.Graphics, e.Bounds);
        }

        //绘制分级渐变色带
        private void ClassBreakRendererColorCmb_DrawItem(object sender, DrawItemEventArgs e)
        {
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
            foreach (var value in values)
            {
                string cValue = value.ToString();

                uniqueRendererValues.Add(cValue);
                fieldLabels.Add(cValue);

                DataGridViewRow curRow = new DataGridViewRow();
                DataGridViewTextBoxCell symbolCell = new DataGridViewTextBoxCell();
                symbolCell.Value = "符号样式设置窗体";

                //TODO:
                //DataGridViewImageCell symbolCell = new DataGridViewImageCell();
                //symbolCell.Value = ;  绘制样例

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
            for(double i = min; i < max; i += (max - min) / breakCount)
            {
                symbols.Add(SymbolFactory.CreateSymbol(curLayer.FeatureType,
                    minSize+(int)i*(maxSize-minSize)/breakCount));
                classbreakRendererBreaks.Add(i);
            }
            classbreakRendererBreaks.Add(max);

            //TODO:
            //绘制gridview
            foreach (var value in values)
            {
                DataGridViewRow curRow = new DataGridViewRow();
                DataGridViewTextBoxCell symbolCell = new DataGridViewTextBoxCell();
                symbolCell.Value = "符号样式设置窗体";
                //DataGridViewImageCell symbolCell = new DataGridViewImageCell();
                //symbolCell.Value = ;  绘制样例
                curRow.Cells.Add(symbolCell);
                DataGridViewTextBoxCell uniqueCell = new DataGridViewTextBoxCell();
                uniqueCell.Value = value.ToString();
                curRow.Cells.Add(uniqueCell);
                DataGridViewTextBoxCell labelCell = new DataGridViewTextBoxCell();
                labelCell.Value = value.ToString();
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
            double min = values.Min();
            double max = values.Max();
            int breakCount = Convert.ToInt32(classBreakRendererCountTbx.Text);
            for (double i = min; i < max; i += (max - min) / breakCount)
            {
                Color curColor = curRamp.Next();
                symbols.Add(SymbolFactory.CreateSymbol(curLayer.FeatureType, curColor));
                classbreakRendererBreaks.Add(i);
            }
            classbreakRendererBreaks.Add(max);

            //TODO:
            //绘制gridview
            foreach (var value in values)
            {
                DataGridViewRow curRow = new DataGridViewRow();
                DataGridViewTextBoxCell symbolCell = new DataGridViewTextBoxCell();
                symbolCell.Value = "符号样式设置窗体";
                //DataGridViewImageCell symbolCell = new DataGridViewImageCell();
                //symbolCell.Value = ;  绘制样例
                curRow.Cells.Add(symbolCell);
                DataGridViewTextBoxCell uniqueCell = new DataGridViewTextBoxCell();
                uniqueCell.Value = value.ToString();
                curRow.Cells.Add(uniqueCell);
                DataGridViewTextBoxCell labelCell = new DataGridViewTextBoxCell();
                labelCell.Value = value.ToString();
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
            GenerateSymbolSelecterInGdv(e.ColumnIndex, e.RowIndex);
        }
        private void BreakDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GenerateSymbolSelecterInGdv(e.ColumnIndex, e.RowIndex);
        }
        private void SizeDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GenerateSymbolSelecterInGdv(e.ColumnIndex, e.RowIndex);
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
                    uniqueValueRenderer.symbols = symbols;
                    uniqueValueRenderer.values = uniqueRendererValues;
                    uniqueValueRenderer.FieldLabel = fieldLabels;
                    curLayer.MRenderer = uniqueValueRenderer;
                    break;
                case 2:  //分级设色
                case 3:  //分级大小
                    ClassBreaksRenderer classBreaksRenderer = new ClassBreaksRenderer();
                    classBreaksRenderer.symbols = symbols;
                    classBreaksRenderer.breaks = classbreakRendererBreaks;
                    classBreaksRenderer.FieldLabel = fieldLabels;
                    curLayer.MRenderer = classBreaksRenderer;
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

        //在gridview中生成符号选择器并绑定事件响应函数
        private void GenerateSymbolSelecterInGdv(int column, int row)
        {
            //TODO:弹出符号选择器，并设置事件相应函数
            if (column == 0 && row >= 0 && row < symbols.Count)
            {
                Symbol curSymbol = symbols[row];
                GenerateSymbolSelecter(curSymbol);
            }
        }

        //生成符号选择器并绑定事件响应函数
        private void GenerateSymbolSelecter(Symbol symbol)
        {
            //TODO
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

        private void Button8_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }

}
