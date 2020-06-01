namespace GIS_Design
{
    partial class SymbolSelectorFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prePbx = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHLColor = new System.Windows.Forms.Button();
            this.lblHLColor = new System.Windows.Forms.Label();
            this.btnOColor = new System.Windows.Forms.Button();
            this.lblOColor = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lblWidth = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.nudAngle = new System.Windows.Forms.NumericUpDown();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.lblAngle = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.iconLbx = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prePbx)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.prePbx);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(436, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(312, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // prePbx
            // 
            this.prePbx.Location = new System.Drawing.Point(20, 38);
            this.prePbx.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.prePbx.Name = "prePbx";
            this.prePbx.Size = new System.Drawing.Size(282, 188);
            this.prePbx.TabIndex = 0;
            this.prePbx.TabStop = false;
            this.prePbx.Paint += new System.Windows.Forms.PaintEventHandler(this.PrePbx_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHLColor);
            this.groupBox2.Controls.Add(this.lblHLColor);
            this.groupBox2.Controls.Add(this.btnOColor);
            this.groupBox2.Controls.Add(this.lblOColor);
            this.groupBox2.Controls.Add(this.nudWidth);
            this.groupBox2.Controls.Add(this.lblWidth);
            this.groupBox2.Controls.Add(this.btnColor);
            this.groupBox2.Controls.Add(this.nudAngle);
            this.groupBox2.Controls.Add(this.nudSize);
            this.groupBox2.Controls.Add(this.lblAngle);
            this.groupBox2.Controls.Add(this.lblSize);
            this.groupBox2.Controls.Add(this.lblColor);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(436, 278);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(312, 316);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置";
            // 
            // btnHLColor
            // 
            this.btnHLColor.Location = new System.Drawing.Point(252, 28);
            this.btnHLColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHLColor.Name = "btnHLColor";
            this.btnHLColor.Size = new System.Drawing.Size(36, 36);
            this.btnHLColor.TabIndex = 12;
            this.btnHLColor.UseVisualStyleBackColor = true;
            this.btnHLColor.Visible = false;
            this.btnHLColor.Click += new System.EventHandler(this.btnHLColor_Click);
            // 
            // lblHLColor
            // 
            this.lblHLColor.AutoSize = true;
            this.lblHLColor.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblHLColor.Location = new System.Drawing.Point(16, 32);
            this.lblHLColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHLColor.Name = "lblHLColor";
            this.lblHLColor.Size = new System.Drawing.Size(214, 24);
            this.lblHLColor.TabIndex = 11;
            this.lblHLColor.Text = "阴影线条色(HLC)：";
            this.lblHLColor.Visible = false;
            // 
            // btnOColor
            // 
            this.btnOColor.Location = new System.Drawing.Point(252, 74);
            this.btnOColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOColor.Name = "btnOColor";
            this.btnOColor.Size = new System.Drawing.Size(36, 36);
            this.btnOColor.TabIndex = 10;
            this.btnOColor.UseVisualStyleBackColor = true;
            this.btnOColor.Visible = false;
            this.btnOColor.Click += new System.EventHandler(this.btnOColor_Click);
            // 
            // lblOColor
            // 
            this.lblOColor.AutoSize = true;
            this.lblOColor.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblOColor.Location = new System.Drawing.Point(52, 76);
            this.lblOColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOColor.Name = "lblOColor";
            this.lblOColor.Size = new System.Drawing.Size(178, 24);
            this.lblOColor.TabIndex = 9;
            this.lblOColor.Text = "轮廓颜色(OC)：";
            this.lblOColor.Visible = false;
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(188, 216);
            this.nudWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(100, 35);
            this.nudWidth.TabIndex = 8;
            this.nudWidth.Visible = false;
            this.nudWidth.ValueChanged += new System.EventHandler(this.nudWidth_ValueChanged);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblWidth.Location = new System.Drawing.Point(64, 216);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(118, 24);
            this.lblWidth.TabIndex = 7;
            this.lblWidth.Text = "宽度(W)：";
            this.lblWidth.Visible = false;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(252, 120);
            this.btnColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(36, 36);
            this.btnColor.TabIndex = 6;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Visible = false;
            this.btnColor.Click += new System.EventHandler(this.ChooseColor_Click);
            // 
            // nudAngle
            // 
            this.nudAngle.Location = new System.Drawing.Point(188, 264);
            this.nudAngle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngle.Name = "nudAngle";
            this.nudAngle.Size = new System.Drawing.Size(100, 35);
            this.nudAngle.TabIndex = 5;
            this.nudAngle.Visible = false;
            this.nudAngle.ValueChanged += new System.EventHandler(this.nudAngle_ValueChanged);
            // 
            // nudSize
            // 
            this.nudSize.Location = new System.Drawing.Point(188, 168);
            this.nudSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(100, 35);
            this.nudSize.TabIndex = 4;
            this.nudSize.Visible = false;
            this.nudSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblAngle.Location = new System.Drawing.Point(64, 268);
            this.lblAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(118, 24);
            this.lblAngle.TabIndex = 2;
            this.lblAngle.Text = "角度(A)：";
            this.lblAngle.Visible = false;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblSize.Location = new System.Drawing.Point(64, 170);
            this.lblSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(118, 24);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "大小(S)：";
            this.lblSize.Visible = false;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblColor.Location = new System.Drawing.Point(52, 126);
            this.lblColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(178, 24);
            this.lblColor.TabIndex = 0;
            this.lblColor.Text = "填充颜色(FC)：";
            this.lblColor.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Menu;
            this.btnOK.Location = new System.Drawing.Point(436, 608);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(146, 46);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Menu;
            this.btnCancel.Location = new System.Drawing.Point(606, 608);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 46);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // iconLbx
            // 
            this.iconLbx.ColumnWidth = 50;
            this.iconLbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.iconLbx.FormattingEnabled = true;
            this.iconLbx.ItemHeight = 50;
            this.iconLbx.Location = new System.Drawing.Point(24, 56);
            this.iconLbx.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.iconLbx.MultiColumn = true;
            this.iconLbx.Name = "iconLbx";
            this.iconLbx.Size = new System.Drawing.Size(398, 504);
            this.iconLbx.TabIndex = 4;
            this.iconLbx.Click += new System.EventHandler(this.IconLbx_Click);
            this.iconLbx.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1_DrawItem);
            this.iconLbx.SelectedIndexChanged += new System.EventHandler(this.IconLbx_SelectedIndexChanged);
            // 
            // SymbolSelectorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 670);
            this.Controls.Add(this.iconLbx);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SymbolSelectorFrm";
            this.Text = "符号选择";
            this.Load += new System.EventHandler(this.SymbolSelectorFrm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prePbx)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.NumericUpDown nudAngle;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Button btnOColor;
        private System.Windows.Forms.Label lblOColor;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Button btnHLColor;
        private System.Windows.Forms.Label lblHLColor;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.ListBox iconLbx;
        private System.Windows.Forms.PictureBox prePbx;
    }
}