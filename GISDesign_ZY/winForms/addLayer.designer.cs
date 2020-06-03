namespace GISFinal
{
    partial class addLayer
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
            this.typeSelect = new System.Windows.Forms.ComboBox();
            this.commentInput = new System.Windows.Forms.TextBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.comment = new System.Windows.Forms.Label();
            this.layerType = new System.Windows.Forms.Label();
            this.layerName = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.typeSelect);
            this.groupBox1.Controls.Add(this.commentInput);
            this.groupBox1.Controls.Add(this.nameInput);
            this.groupBox1.Controls.Add(this.comment);
            this.groupBox1.Controls.Add(this.layerType);
            this.groupBox1.Controls.Add(this.layerName);
            this.groupBox1.Location = new System.Drawing.Point(54, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(626, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // typeSelect
            // 
            this.typeSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.typeSelect.FormattingEnabled = true;
            this.typeSelect.Items.AddRange(new object[] {
            "PointD",
            "Polyline",
            "Polygon",
            "MultiPolyline",
            "MultiPolygon"});
            this.typeSelect.Location = new System.Drawing.Point(222, 118);
            this.typeSelect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.typeSelect.Name = "typeSelect";
            this.typeSelect.Size = new System.Drawing.Size(340, 39);
            this.typeSelect.TabIndex = 5;
            this.typeSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // commentInput
            // 
            this.commentInput.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.commentInput.ForeColor = System.Drawing.Color.Gray;
            this.commentInput.Location = new System.Drawing.Point(222, 180);
            this.commentInput.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.commentInput.Name = "commentInput";
            this.commentInput.Size = new System.Drawing.Size(340, 39);
            this.commentInput.TabIndex = 4;
            this.commentInput.Text = "（可填）";
            this.commentInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nameInput
            // 
            this.nameInput.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameInput.Location = new System.Drawing.Point(222, 60);
            this.nameInput.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(340, 39);
            this.nameInput.TabIndex = 3;
            // 
            // comment
            // 
            this.comment.AutoSize = true;
            this.comment.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comment.Location = new System.Drawing.Point(70, 180);
            this.comment.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(71, 36);
            this.comment.TabIndex = 2;
            this.comment.Text = "备注";
            // 
            // layerType
            // 
            this.layerType.AutoSize = true;
            this.layerType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layerType.Location = new System.Drawing.Point(46, 118);
            this.layerType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.layerType.Name = "layerType";
            this.layerType.Size = new System.Drawing.Size(127, 36);
            this.layerType.TabIndex = 1;
            this.layerType.Text = "要素类型";
            // 
            // layerName
            // 
            this.layerName.AutoSize = true;
            this.layerName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layerName.Location = new System.Drawing.Point(46, 60);
            this.layerName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.layerName.Name = "layerName";
            this.layerName.Size = new System.Drawing.Size(127, 36);
            this.layerName.TabIndex = 0;
            this.layerName.Text = "图层名称";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(152, 350);
            this.OK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(150, 46);
            this.OK.TabIndex = 1;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(408, 350);
            this.cancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(150, 46);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // addLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 440);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "addLayer";
            this.Text = "添加图层";
            this.Load += new System.EventHandler(this.addLayer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox typeSelect;
        private System.Windows.Forms.TextBox commentInput;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label comment;
        private System.Windows.Forms.Label layerType;
        private System.Windows.Forms.Label layerName;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
    }
}