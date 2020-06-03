using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GISDesign_ZY.winForms
{
    public partial class StaticNoteFrm : Form
    {
        public StaticNoteFrm()
        {
            InitializeComponent();
        }

        #region 字段

        private Font _font;
        private Color _color;
        private Color _BackColor;

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置注记内容
        /// </summary>
        public string GetText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        /// <summary>
        /// 获取或设置字体样式
        /// </summary>
        public Font font
        {
            get { return _font; }
            set { _font = value; }
        }

        /// <summary>
        /// 获取或设置字体颜色
        /// </summary>
        public Color color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// 获取或设置背景颜色
        /// </summary>
        public Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        #endregion

        #region 窗体和控件事件处理

        //设置字体样式按钮
        private void btnSetFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                _font = fd.Font;
                ShowFont();
                ShowView();
            }
            fd.Dispose();
        }

        //设置字体颜色按钮
        private void btnSetColor_Click(object sender, EventArgs e)
        {
            ColorDialog sDialog = new ColorDialog();
            sDialog.Color = _color;
            if (sDialog.ShowDialog(this) == DialogResult.OK)
            {
                _color = sDialog.Color;
                ShowColor();
                ShowView();
            }
            sDialog.Dispose();
        }

        //设置背景颜色按钮
        private void btnSetBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog sDialog = new ColorDialog();
            sDialog.Color = _color;
            if (sDialog.ShowDialog(this) == DialogResult.OK)
            {
                _BackColor = sDialog.Color;
                ShowBackColor();
                ShowView();
            }
            sDialog.Dispose();
        }

        //确认按钮
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //取消按钮
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //注记内容改变
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ShowView();
        }

        //装载窗体
        private void StaticNoteFrm_Load(object sender, EventArgs e)
        {
            ShowView();
            ShowFont();
            ShowColor();
            ShowBackColor();
        }

        #endregion

        #region 私有函数

        //显示样例
        private void ShowView()
        {
            lblEG.Text = textBox1.Text;
            lblEG.Font = _font;
            lblEG.ForeColor = _color;
            lblEG.BackColor = _BackColor;
        }

        //显示字体样式
        private void ShowFont()
        {
            string sfont = _font.Name + ", " + _font.Size.ToString() + "pt";
            lblFont.Text = sfont;
        }

        //显示字体颜色
        private void ShowColor()
        {
            pictureBox1.BackColor = _color;
        }

        //显示背景颜色
        private void ShowBackColor()
        {
            pBBackColor.BackColor = _BackColor;
        }

        #endregion


    }
}
