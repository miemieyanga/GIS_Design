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
            this.cMSCompass = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除指北针ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblScale = new System.Windows.Forms.Label();
            this.cMSScale = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除比例尺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置字体样式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置字体颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cMSStaticNote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置注记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除注记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMSLabel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除标注ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picBCompass)).BeginInit();
            this.cMSCompass.SuspendLayout();
            this.cMSScale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.cMSStaticNote.SuspendLayout();
            this.cMSLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBCompass
            // 
            this.picBCompass.ContextMenuStrip = this.cMSCompass;
            this.picBCompass.Image = global::GISDesign_ZY.Properties.Resources.zhibeizhen;
            this.picBCompass.Location = new System.Drawing.Point(13, 21);
            this.picBCompass.Margin = new System.Windows.Forms.Padding(2);
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
            // cMSCompass
            // 
            this.cMSCompass.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cMSCompass.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除指北针ToolStripMenuItem});
            this.cMSCompass.Name = "cMSCompass";
            this.cMSCompass.Size = new System.Drawing.Size(137, 26);
            // 
            // 删除指北针ToolStripMenuItem
            // 
            this.删除指北针ToolStripMenuItem.Name = "删除指北针ToolStripMenuItem";
            this.删除指北针ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除指北针ToolStripMenuItem.Text = "删除指北针";
            this.删除指北针ToolStripMenuItem.Click += new System.EventHandler(this.删除指北针ToolStripMenuItem_Click);
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.ContextMenuStrip = this.cMSScale;
            this.lblScale.Location = new System.Drawing.Point(23, 59);
            this.lblScale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(41, 12);
            this.lblScale.TabIndex = 1;
            this.lblScale.Text = "label1";
            this.lblScale.Visible = false;
            this.lblScale.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblScale_MouseDown);
            this.lblScale.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblScale_MouseMove);
            this.lblScale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblScale_MouseUp);
            // 
            // cMSScale
            // 
            this.cMSScale.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cMSScale.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除比例尺ToolStripMenuItem,
            this.设置字体样式ToolStripMenuItem,
            this.设置字体颜色ToolStripMenuItem});
            this.cMSScale.Name = "cMSScale";
            this.cMSScale.Size = new System.Drawing.Size(149, 70);
            // 
            // 删除比例尺ToolStripMenuItem
            // 
            this.删除比例尺ToolStripMenuItem.Name = "删除比例尺ToolStripMenuItem";
            this.删除比例尺ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除比例尺ToolStripMenuItem.Text = "删除比例尺";
            this.删除比例尺ToolStripMenuItem.Click += new System.EventHandler(this.删除比例尺ToolStripMenuItem_Click);
            // 
            // 设置字体样式ToolStripMenuItem
            // 
            this.设置字体样式ToolStripMenuItem.Name = "设置字体样式ToolStripMenuItem";
            this.设置字体样式ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.设置字体样式ToolStripMenuItem.Text = "设置字体样式";
            this.设置字体样式ToolStripMenuItem.Click += new System.EventHandler(this.设置字体样式ToolStripMenuItem_Click);
            // 
            // 设置字体颜色ToolStripMenuItem
            // 
            this.设置字体颜色ToolStripMenuItem.Name = "设置字体颜色ToolStripMenuItem";
            this.设置字体颜色ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.设置字体颜色ToolStripMenuItem.Text = "设置字体颜色";
            this.设置字体颜色ToolStripMenuItem.Click += new System.EventHandler(this.设置字体颜色ToolStripMenuItem_Click);
            // 
            // cMSStaticNote
            // 
            this.cMSStaticNote.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cMSStaticNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置注记ToolStripMenuItem,
            this.删除注记ToolStripMenuItem});
            this.cMSStaticNote.Name = "cMSStaticNote";
            this.cMSStaticNote.Size = new System.Drawing.Size(125, 48);
            this.cMSStaticNote.Opening += new System.ComponentModel.CancelEventHandler(this.cMSStaticNote_Opening);
            // 
            // 设置注记ToolStripMenuItem
            // 
            this.设置注记ToolStripMenuItem.Name = "设置注记ToolStripMenuItem";
            this.设置注记ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设置注记ToolStripMenuItem.Text = "设置注记";
            this.设置注记ToolStripMenuItem.Click += new System.EventHandler(this.设置注记ToolStripMenuItem_Click);
            // 
            // 删除注记ToolStripMenuItem
            // 
            this.删除注记ToolStripMenuItem.Name = "删除注记ToolStripMenuItem";
            this.删除注记ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除注记ToolStripMenuItem.Text = "删除注记";
            this.删除注记ToolStripMenuItem.Click += new System.EventHandler(this.删除注记ToolStripMenuItem_Click);
            // 
            // cMSLabel
            // 
            this.cMSLabel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除标注ToolStripMenuItem});
            this.cMSLabel.Name = "cMSLabel";
            this.cMSLabel.Size = new System.Drawing.Size(181, 48);
            this.cMSLabel.Opening += new System.ComponentModel.CancelEventHandler(this.CMSLabel_Opening);
            // 
            // 删除标注ToolStripMenuItem
            // 
            this.删除标注ToolStripMenuItem.Name = "删除标注ToolStripMenuItem";
            this.删除标注ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除标注ToolStripMenuItem.Text = "删除标注";
            this.删除标注ToolStripMenuItem.Click += new System.EventHandler(this.删除标注ToolStripMenuItem_Click);
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.picBCompass);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(73, 73);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MapControl_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picBCompass)).EndInit();
            this.cMSCompass.ResumeLayout(false);
            this.cMSScale.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.cMSStaticNote.ResumeLayout(false);
            this.cMSLabel.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cMSStaticNote;
        private System.Windows.Forms.ToolStripMenuItem 设置注记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除注记ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cMSLabel;
        private System.Windows.Forms.ToolStripMenuItem 删除标注ToolStripMenuItem;
    }
}
