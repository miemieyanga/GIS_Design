namespace GISDesign_ZY
{
    partial class MapControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picBCompass = new System.Windows.Forms.PictureBox();
            this.lblScale = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cMSCompass = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除指北针ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMSScale = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除比例尺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置字体样式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置字体颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picBCompass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.cMSCompass.SuspendLayout();
            this.cMSScale.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBCompass
            // 
            this.picBCompass.ContextMenuStrip = this.cMSCompass;
            this.picBCompass.Image = global::GISDesign_ZY.Properties.Resources.zhibeizhen;
            this.picBCompass.Location = new System.Drawing.Point(26, 42);
            this.picBCompass.Name = "picBCompass";
            this.picBCompass.Size = new System.Drawing.Size(48, 48);
            this.picBCompass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBCompass.TabIndex = 0;
            this.picBCompass.TabStop = false;
            this.picBCompass.Visible = false;
            this.picBCompass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBCompass_MouseDown);
            this.picBCompass.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBCompass_MouseMove);
            this.picBCompass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBCompass_MouseUp);
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.ContextMenuStrip = this.cMSScale;
            this.lblScale.Location = new System.Drawing.Point(46, 118);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(82, 24);
            this.lblScale.TabIndex = 1;
            this.lblScale.Text = "label1";
            this.lblScale.Visible = false;
            this.lblScale.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblScale_MouseDown);
            this.lblScale.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblScale_MouseMove);
            this.lblScale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblScale_MouseUp);
            // 
            // cMSCompass
            // 
            this.cMSCompass.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cMSCompass.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除指北针ToolStripMenuItem});
            this.cMSCompass.Name = "cMSCompass";
            this.cMSCompass.Size = new System.Drawing.Size(209, 42);
            // 
            // 删除指北针ToolStripMenuItem
            // 
            this.删除指北针ToolStripMenuItem.Name = "删除指北针ToolStripMenuItem";
            this.删除指北针ToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.删除指北针ToolStripMenuItem.Text = "删除指北针";
            this.删除指北针ToolStripMenuItem.Click += new System.EventHandler(this.删除指北针ToolStripMenuItem_Click);
            // 
            // cMSScale
            // 
            this.cMSScale.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cMSScale.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除比例尺ToolStripMenuItem,
            this.设置字体样式ToolStripMenuItem,
            this.设置字体颜色ToolStripMenuItem});
            this.cMSScale.Name = "cMSScale";
            this.cMSScale.Size = new System.Drawing.Size(233, 118);
            // 
            // 删除比例尺ToolStripMenuItem
            // 
            this.删除比例尺ToolStripMenuItem.Name = "删除比例尺ToolStripMenuItem";
            this.删除比例尺ToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.删除比例尺ToolStripMenuItem.Text = "删除比例尺";
            this.删除比例尺ToolStripMenuItem.Click += new System.EventHandler(this.删除比例尺ToolStripMenuItem_Click);
            // 
            // 设置字体样式ToolStripMenuItem
            // 
            this.设置字体样式ToolStripMenuItem.Name = "设置字体样式ToolStripMenuItem";
            this.设置字体样式ToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.设置字体样式ToolStripMenuItem.Text = "设置字体样式";
            this.设置字体样式ToolStripMenuItem.Click += new System.EventHandler(this.设置字体样式ToolStripMenuItem_Click);
            // 
            // 设置字体颜色ToolStripMenuItem
            // 
            this.设置字体颜色ToolStripMenuItem.Name = "设置字体颜色ToolStripMenuItem";
            this.设置字体颜色ToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.设置字体颜色ToolStripMenuItem.Text = "设置字体颜色";
            this.设置字体颜色ToolStripMenuItem.Click += new System.EventHandler(this.设置字体颜色ToolStripMenuItem_Click);
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.picBCompass);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(146, 146);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MapControl_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picBCompass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.cMSCompass.ResumeLayout(false);
            this.cMSScale.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBCompass;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ContextMenuStrip cMSCompass;
        private System.Windows.Forms.ToolStripMenuItem 删除指北针ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cMSScale;
        private System.Windows.Forms.ToolStripMenuItem 删除比例尺ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置字体样式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置字体颜色ToolStripMenuItem;
    }
}
