namespace GISFinal
{
    partial class attributeList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.selectNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.添加字段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.完成修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(12, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(776, 395);
            this.dataGridView1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectNum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // selectNum
            // 
            this.selectNum.AutoSize = false;
            this.selectNum.Name = "selectNum";
            this.selectNum.Size = new System.Drawing.Size(100, 17);
            this.selectNum.Text = "已选择：0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加字段ToolStripMenuItem,
            this.属性查询ToolStripMenuItem,
            this.完成修改ToolStripMenuItem,
            this.取消修改ToolStripMenuItem,
            this.撤销修改ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 添加字段ToolStripMenuItem
            // 
            this.添加字段ToolStripMenuItem.Name = "添加字段ToolStripMenuItem";
            this.添加字段ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.添加字段ToolStripMenuItem.Text = "添加字段";
            // 
            // 属性查询ToolStripMenuItem
            // 
            this.属性查询ToolStripMenuItem.Name = "属性查询ToolStripMenuItem";
            this.属性查询ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.属性查询ToolStripMenuItem.Text = "属性查询";
            // 
            // 完成修改ToolStripMenuItem
            // 
            this.完成修改ToolStripMenuItem.Name = "完成修改ToolStripMenuItem";
            this.完成修改ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.完成修改ToolStripMenuItem.Text = "显示所有记录";
            // 
            // 取消修改ToolStripMenuItem
            // 
            this.取消修改ToolStripMenuItem.Name = "取消修改ToolStripMenuItem";
            this.取消修改ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.取消修改ToolStripMenuItem.Text = "显示已选择记录";
            // 
            // 撤销修改ToolStripMenuItem
            // 
            this.撤销修改ToolStripMenuItem.Name = "撤销修改ToolStripMenuItem";
            this.撤销修改ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.撤销修改ToolStripMenuItem.Text = "撤销修改";
            // 
            // attributeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "attributeList";
            this.Text = "属性表";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel selectNum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加字段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 完成修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤销修改ToolStripMenuItem;
    }
}