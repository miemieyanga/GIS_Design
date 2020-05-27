using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GISDesign_ZY;

namespace GIS_Design
{
    public partial class SymbolSelectorFrm : Form
    {
        //事件
        public delegate void FinishSettingSymbolHandler(object sender, Symbol symbol);
        public event FinishSettingSymbolHandler FinishSettingSymbol;


        public Symbol curSymbol;
        public SymbolSelectorFrm(Symbol symbol)
        {
            InitializeComponent();
            curSymbol = symbol.Clone();
        }

        //根据符号类型设置各控件的可见性
        private void SymbolSelectorFrm_Load(object sender, EventArgs e)
        {
            switch (curSymbol.Type)
            {
                case SymbolType.SimpleMarkerSymbol:
                    SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
                    lblSize.Visible = true;
                    nudSize.Visible = true;
                    lblAngle.Visible = true;
                    nudAngle.Visible = true;
                    lblColor.Visible = true;
                    btnColor.Visible = true;
                    btnColor.BackColor = curSymbol1.MColor;
                    nudSize.Value = (decimal)curSymbol1.Size;
                    nudAngle.Value = (decimal)curSymbol1.Angle;
                    iconLbx.Items.AddRange(SymbolFactory.CreateAllSymbols(SymbolType.SimpleMarkerSymbol));
                    break;
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol curSymbol2 = (SimpleLineSymbol)curSymbol;
                    lblWidth.Visible = true;
                    nudWidth.Visible = true;
                    lblOColor.Visible = true;
                    btnOColor.Visible = true;
                    btnOColor.BackColor = curSymbol2.MColor;
                    nudWidth.Value = (decimal)curSymbol2.Width;
                    iconLbx.Items.AddRange(SymbolFactory.CreateAllSymbols(SymbolType.SimpleLineSymbol));
                    break;
                case SymbolType.SimpleFillSymbol:
                    SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
                    lblWidth.Visible = true;
                    nudWidth.Visible = true;
                    lblOColor.Visible = true;
                    btnOColor.Visible = true;
                    lblColor.Visible = true;
                    btnColor.Visible = true;
                    nudWidth.Value = (decimal)curSymbol3.OutlineWidth;
                    btnColor.BackColor = curSymbol3.FillColor;
                    btnOColor.BackColor = curSymbol3.OutlineColor;
                    iconLbx.Items.AddRange(SymbolFactory.CreateAllSymbols(SymbolType.SimpleFillSymbol));
                    iconLbx.Items.AddRange(SymbolFactory.CreateAllSymbols(SymbolType.HatchFillSymbol));
                    break;
                case SymbolType.HatchFillSymbol:
                    HatchFillSymbol curSymbol4 = (HatchFillSymbol)curSymbol;
                    lblWidth.Visible = true;
                    nudWidth.Visible = true;
                    lblHLColor.Visible = true;
                    btnHLColor.Visible = true;
                    lblOColor.Visible = true;
                    btnOColor.Visible = true;
                    lblColor.Visible = true;
                    btnColor.Visible = true;
                    nudWidth.Value = (decimal)curSymbol4.OutlineWidth;
                    btnColor.BackColor = curSymbol4.BackColor;
                    btnHLColor.BackColor = curSymbol4.HatchColor;
                    btnOColor.BackColor = curSymbol4.OutlineColor;
                    iconLbx.Items.AddRange(SymbolFactory.CreateAllSymbols(SymbolType.SimpleFillSymbol));
                    iconLbx.Items.AddRange(SymbolFactory.CreateAllSymbols(SymbolType.HatchFillSymbol));
                    break;
                default:
                    break;
            }
        }

        private void plPreview_Paint(object sender, PaintEventArgs e)
        {
            
        }

        #region 双击选择点符号样式
        private void btnCircle_Click(object sender, EventArgs e)
        {
            SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
            curSymbol1.Style = MarkerStyleConstant.MCircle;
            prePbx.Refresh();
        }

        private void btnSolidCircle_Click(object sender, EventArgs e)
        {
            SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
            curSymbol1.Style = MarkerStyleConstant.MSolidCircle;
            prePbx.Refresh();
        }

        private void butRectengle_Click(object sender, EventArgs e)
        {
            SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
            curSymbol1.Style = MarkerStyleConstant.MRectengle;
            prePbx.Refresh();
        }

        private void btnSolidRectengle_Click(object sender, EventArgs e)
        {
            SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
            curSymbol1.Style = MarkerStyleConstant.MSolidRectengle;
            prePbx.Refresh();
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
            curSymbol1.Style = MarkerStyleConstant.MTriangle;
            prePbx.Refresh();
        }

        private void btnSolidTriangle_Click(object sender, EventArgs e)
        {
            SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
            curSymbol1.Style = MarkerStyleConstant.MSolidTriangle;
            prePbx.Refresh();
        }

        private void btnDotCircle_Click(object sender, EventArgs e)
        {
            SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
            curSymbol1.Style = MarkerStyleConstant.MDotCircle;
            prePbx.Refresh();
        }

        private void btnDoubleCircle_Click(object sender, EventArgs e)
        {
            SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
            curSymbol1.Style = MarkerStyleConstant.MDoubleCircle;
            prePbx.Refresh();
        }
        #endregion

        #region 双击选择线符号样式
        private void btnSolidLine_Click(object sender, EventArgs e)
        {
            //判断符号类型
            switch (curSymbol.Type)
            {
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol curSymbol2 = (SimpleLineSymbol)curSymbol;
                    curSymbol2.Style = LineStyleConstant.LSolid;
                    break;
                case SymbolType.SimpleFillSymbol:
                case SymbolType.HatchFillSymbol:
                    SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
                    curSymbol3.OutlineStyle = LineStyleConstant.LSolid;
                    break;               
                default:
                    break;               
            }
            prePbx.Refresh();
        }

        private void btnDotLine_Click(object sender, EventArgs e)
        {
            //判断符号类型
            switch (curSymbol.Type)
            {
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol curSymbol2 = (SimpleLineSymbol)curSymbol;
                    curSymbol2.Style = LineStyleConstant.LDot;
                    break;
                case SymbolType.SimpleFillSymbol:
                case SymbolType.HatchFillSymbol:
                    SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
                    curSymbol3.OutlineStyle = LineStyleConstant.LDot;
                    break;
                default:
                    break;
            }
            prePbx.Refresh();
        }

        private void btnDashLine_Click(object sender, EventArgs e)
        {
            //判断符号类型
            switch (curSymbol.Type)
            {
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol curSymbol2 = (SimpleLineSymbol)curSymbol;
                    curSymbol2.Style = LineStyleConstant.LDash;
                    break;
                case SymbolType.SimpleFillSymbol:
                case SymbolType.HatchFillSymbol:
                    SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
                    curSymbol3.OutlineStyle = LineStyleConstant.LDash;
                    break;
                default:
                    break;
            }
            prePbx.Refresh();
        }

        private void btnDotDash_Click(object sender, EventArgs e)
        {
            switch (curSymbol.Type)
            {
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol curSymbol2 = (SimpleLineSymbol)curSymbol;
                    curSymbol2.Style = LineStyleConstant.LDashDot;
                    break;
                case SymbolType.SimpleFillSymbol:
                case SymbolType.HatchFillSymbol:
                    SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
                    curSymbol3.OutlineStyle = LineStyleConstant.LDashDot;
                    break;
                default:
                    break;
            }
            prePbx.Refresh();
        }

        private void btnDashDotDash_Click(object sender, EventArgs e)
        {
            switch (curSymbol.Type)
            {
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol curSymbol2 = (SimpleLineSymbol)curSymbol;
                    curSymbol2.Style = LineStyleConstant.LDashDotDash;
                    break;
                case SymbolType.SimpleFillSymbol:
                case SymbolType.HatchFillSymbol:
                    SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
                    curSymbol3.OutlineStyle = LineStyleConstant.LDashDotDash;
                    break;
                default:
                    break;
            }
            prePbx.Refresh();
        }
        #endregion

        #region 双击选择面符号样式
        private void btnFill_Click(object sender, EventArgs e)
        {
            SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
            curSymbol3.FillStyle = FillStyleConstant.FColor;
            prePbx.Refresh();
        }

        private void btnTransparent_Click(object sender, EventArgs e)
        {
            SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
            curSymbol3.FillStyle = FillStyleConstant.FTransparent;
            prePbx.Refresh();
        }
        #endregion

        #region 双击选择阴影符号样式
        private void btnHLine_Click(object sender, EventArgs e)
        {
            HatchFillSymbol curSymbol4 = (HatchFillSymbol)curSymbol;
            curSymbol4.HatchStyle = HatchStyleConstant.HLine;
            prePbx.Refresh();
        }

        private void btnHDot_Click(object sender, EventArgs e)
        {
            HatchFillSymbol curSymbol4 = (HatchFillSymbol)curSymbol;
            curSymbol4.HatchStyle = HatchStyleConstant.HDot;
            prePbx.Refresh();
        }

        private void btnHCross_Click(object sender, EventArgs e)
        {
            HatchFillSymbol curSymbol4 = (HatchFillSymbol)curSymbol;
            curSymbol4.HatchStyle = HatchStyleConstant.HCrossLine;
            prePbx.Refresh();
        }

        #endregion

        #region 其他设置更改后        

        //选择阴影线条颜色
        private void btnHLColor_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
            {
                btnHLColor.BackColor = colorDialog3.Color;
                HatchFillSymbol curSymbol4 = (HatchFillSymbol)curSymbol;
                curSymbol4.HatchColor = colorDialog3.Color;
                prePbx.Refresh();
            }
        }

        //选择轮廓颜色
        private void btnOColor_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                btnOColor.BackColor = colorDialog2.Color;
                switch (curSymbol.Type)
                {
                    case SymbolType.SimpleLineSymbol:
                        SimpleLineSymbol curSymbol1 = (SimpleLineSymbol)curSymbol;
                        curSymbol1.MColor = colorDialog2.Color;
                        break;
                    case SymbolType.SimpleFillSymbol:
                        SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
                        curSymbol3.OutlineColor = colorDialog2.Color;
                        break;
                    case SymbolType.HatchFillSymbol:
                        HatchFillSymbol curSymbol4 = (HatchFillSymbol)curSymbol;
                        curSymbol4.OutlineColor = colorDialog2.Color;
                        break;
                        break;
                    default:
                        break;
                }
                prePbx.Refresh();
            }
        }

        //选择填充颜色
        private void ChooseColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
                switch (curSymbol.Type)
                {
                    case SymbolType.SimpleMarkerSymbol:
                        SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
                        curSymbol1.MColor = colorDialog1.Color;
                        break;
                    case SymbolType.SimpleFillSymbol:
                        SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
                        curSymbol3.FillColor = colorDialog1.Color;
                        break;
                    case SymbolType.HatchFillSymbol:
                        HatchFillSymbol curSymbol4 = (HatchFillSymbol)curSymbol;
                        curSymbol4.BackColor = colorDialog1.Color;
                        break;
                    default:
                        break;
                }
                prePbx.Refresh();
            }
        }

        //调整大小
        private void nudSize_ValueChanged(object sender, EventArgs e)
        {
            SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
            curSymbol1.Size = (double)nudSize.Value;
            prePbx.Refresh();
        }

        //调整宽度
        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            switch (curSymbol.Type)
            {
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol curSymbol2 = (SimpleLineSymbol)curSymbol;
                    curSymbol2.Width = (double)nudWidth.Value;
                    break;
                case SymbolType.SimpleFillSymbol:
                    SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
                    curSymbol3.OutlineWidth = (double)nudWidth.Value;
                    break;
                case SymbolType.HatchFillSymbol:
                    HatchFillSymbol curSymbol4 = (HatchFillSymbol)curSymbol;
                    curSymbol4.OutlineWidth = (double)nudWidth.Value;
                    break;
                default:
                    break;
            }
            prePbx.Refresh();
        }

        //调整角度
        private void nudAngle_ValueChanged(object sender, EventArgs e)
        {
            SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol;
            curSymbol1.Angle = (double)nudAngle.Value;
            prePbx.Refresh();
        }
        #endregion

        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Symbol symbol = (Symbol)iconLbx.Items[e.Index];
            switch (symbol.Type)
            {
                case SymbolType.SimpleMarkerSymbol:
                    SimpleMarkerSymbol cSymbol = (SimpleMarkerSymbol)iconLbx.Items[e.Index];
                    DrawSymbol.DrawMarkerSymbol(e.Graphics, cSymbol, 
                        new Point(e.Bounds.X + e.Bounds.Width/2, e.Bounds.Y + e.Bounds.Height / 2));
                    break;
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol curSymbol2 = (SimpleLineSymbol)iconLbx.Items[e.Index];
                    DrawSymbol.DrawLineSymbol(e.Graphics, curSymbol2, 
                        new RectangleF(e.Bounds.X + 10, e.Bounds.Y + 10,30,30));
                    break;
                case SymbolType.SimpleFillSymbol:
                    btnHLColor.Visible = false;
                    btnHLColor.Enabled = false;
                    lblHLColor.Visible = false ;
                    lblHLColor.Enabled = false;
                    SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)iconLbx.Items[e.Index];
                    DrawSymbol.DrawFillSymbol(e.Graphics, curSymbol3,
                        new RectangleF(e.Bounds.X + 10, e.Bounds.Y + 10, 30, 30));
                    break;
                case SymbolType.HatchFillSymbol:
                    btnHLColor.Visible = true;
                    btnHLColor.Enabled = true ;
                    lblHLColor.Visible = true;
                    lblHLColor.Enabled = true;
                    HatchFillSymbol curSymbol4 = (HatchFillSymbol)iconLbx.Items[e.Index];
                    DrawSymbol.DrawHatchSymbol(e.Graphics, curSymbol4,
                        new RectangleF(e.Bounds.X + 10, e.Bounds.Y + 10, 30, 30));
                    break;
            }
        }

        private void PrePbx_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            switch (curSymbol.Type)
            {
                case SymbolType.SimpleMarkerSymbol:
                    SimpleMarkerSymbol curSymbol1 = (SimpleMarkerSymbol)curSymbol.Clone();
                    PointF showPoint = new PointF(g.VisibleClipBounds.X+ g.VisibleClipBounds.Width/2,
                        g.VisibleClipBounds.Y + g.VisibleClipBounds.Height / 2);
                    DrawSymbol.DrawMarkerSymbol(g, curSymbol1, showPoint);
                    break;
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol curSymbol2 = (SimpleLineSymbol)curSymbol;
                    DrawSymbol.DrawLineSymbol(g, curSymbol2,
                         new RectangleF(g.VisibleClipBounds.X + 20, g.VisibleClipBounds.Y + 10,
                        g.VisibleClipBounds.Width - 40, g.VisibleClipBounds.Height - 20));
                    break;
                case SymbolType.SimpleFillSymbol:
                    SimpleFillSymbol curSymbol3 = (SimpleFillSymbol)curSymbol;
                    DrawSymbol.DrawFillSymbol(g, curSymbol3, 
                        new RectangleF(g.VisibleClipBounds.X+20, g.VisibleClipBounds.Y+10, 
                        g.VisibleClipBounds.Width-40, g.VisibleClipBounds.Height-20));
                    break;
                case SymbolType.HatchFillSymbol:
                    HatchFillSymbol curSymbol4 = (HatchFillSymbol)curSymbol;
                    DrawSymbol.DrawHatchSymbol(g, curSymbol4,
                         new RectangleF(g.VisibleClipBounds.X + 20, g.VisibleClipBounds.Y + 10,
                        g.VisibleClipBounds.Width - 40, g.VisibleClipBounds.Height - 20));
                    break;
            }
        }

        //单击图标样式
        private void IconLbx_Click(object sender, EventArgs e)
        {
            
        }

        private void IconLbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iconLbx.SelectedIndex < 0 || iconLbx.SelectedIndex > iconLbx.Items.Count)
                return;
            Symbol c = (Symbol)iconLbx.Items[iconLbx.SelectedIndex];
            curSymbol = c.Clone();
            //TODO:大小、颜色
            switch (curSymbol.Type)
            {
                case SymbolType.SimpleMarkerSymbol:
                    SimpleMarkerSymbol s = (SimpleMarkerSymbol)curSymbol;
                    s.Size = (double)nudSize.Value;
                    s.MColor = btnColor.BackColor;
                    s.Angle = (double)nudAngle.Value;
                    break;
                case SymbolType.SimpleLineSymbol:
                    SimpleLineSymbol s1 = (SimpleLineSymbol)curSymbol;
                    s1.Width = (double)nudWidth.Value;
                    s1.MColor = btnOColor.BackColor;
                    break;
                case SymbolType.SimpleFillSymbol:
                    SimpleFillSymbol s2 = (SimpleFillSymbol)curSymbol;
                    btnColor.BackColor= s2.FillColor;
                    btnOColor.BackColor= s2.OutlineColor;
                    nudWidth.Value= (decimal)s2.OutlineWidth;
                    break;
                case SymbolType.HatchFillSymbol:
                    HatchFillSymbol s3 = (HatchFillSymbol)curSymbol;
                    s3.OutlineWidth = (double)nudWidth.Value;
                    s3.OutlineColor = btnOColor.BackColor;
                    s3.BackColor = btnColor.BackColor;
                    s3.HatchColor = btnHLColor.BackColor;
                    break;
            }

            prePbx.Refresh();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            FinishSettingSymbol(this,curSymbol);
            Dispose();
        }
    }
}
