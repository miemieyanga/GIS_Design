namespace GISFinal
{
    partial class newAntMap
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
            this.mapName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.coordinate = new System.Windows.Forms.Label();
            this.comment = new System.Windows.Forms.Label();
            this.coordinateSelect = new System.Windows.Forms.ComboBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.commentInput = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapName
            // 
            this.mapName.AutoSize = true;
            this.mapName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mapName.Location = new System.Drawing.Point(19, 29);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(65, 20);
            this.mapName.TabIndex = 0;
            this.mapName.Text = "地图名称";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.commentInput);
            this.groupBox1.Controls.Add(this.nameInput);
            this.groupBox1.Controls.Add(this.coordinateSelect);
            this.groupBox1.Controls.Add(this.comment);
            this.groupBox1.Controls.Add(this.coordinate);
            this.groupBox1.Controls.Add(this.mapName);
            this.groupBox1.Location = new System.Drawing.Point(22, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // coordinate
            // 
            this.coordinate.AutoSize = true;
            this.coordinate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.coordinate.Location = new System.Drawing.Point(12, 60);
            this.coordinate.Name = "coordinate";
            this.coordinate.Size = new System.Drawing.Size(79, 20);
            this.coordinate.TabIndex = 1;
            this.coordinate.Text = "地理坐标系";
            // 
            // comment
            // 
            this.comment.AutoSize = true;
            this.comment.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comment.Location = new System.Drawing.Point(32, 91);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(37, 20);
            this.comment.TabIndex = 3;
            this.comment.Text = "备注";
            // 
            // coordinateSelect
            // 
            this.coordinateSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.coordinateSelect.FormattingEnabled = true;
            this.coordinateSelect.Location = new System.Drawing.Point(118, 58);
            this.coordinateSelect.Name = "coordinateSelect";
            this.coordinateSelect.Size = new System.Drawing.Size(198, 25);
            this.coordinateSelect.TabIndex = 4;
            // 
            // nameInput
            // 
            this.nameInput.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameInput.Location = new System.Drawing.Point(118, 28);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(198, 23);
            this.nameInput.TabIndex = 5;
            this.nameInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // commentInput
            // 
            this.commentInput.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.commentInput.ForeColor = System.Drawing.Color.Gray;
            this.commentInput.Location = new System.Drawing.Point(118, 90);
            this.commentInput.Name = "commentInput";
            this.commentInput.Size = new System.Drawing.Size(198, 23);
            this.commentInput.TabIndex = 7;
            this.commentInput.Text = "（可填）";
            this.commentInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(73, 174);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "确认";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(225, 174);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // newAntMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 225);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.groupBox1);
            this.Name = "newAntMap";
            this.Text = "新建地图";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label mapName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.ComboBox coordinateSelect;
        private System.Windows.Forms.Label comment;
        private System.Windows.Forms.Label coordinate;
        private System.Windows.Forms.TextBox commentInput;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
    }
}