namespace GISFinal
{
    partial class selByAttriInMainForm
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
            this.cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.conditionSelect = new System.Windows.Forms.ComboBox();
            this.fieldSelect = new System.Windows.Forms.ComboBox();
            this.layerSelect = new System.Windows.Forms.ComboBox();
            this.layer = new System.Windows.Forms.Label();
            this.field = new System.Windows.Forms.Label();
            this.uniqueValue = new System.Windows.Forms.Label();
            this.condition = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(387, 422);
            this.cancel.Margin = new System.Windows.Forms.Padding(6);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(150, 46);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(108, 422);
            this.OK.Margin = new System.Windows.Forms.Padding(6);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(150, 46);
            this.OK.TabIndex = 8;
            this.OK.Text = "确认";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.conditionSelect);
            this.groupBox1.Controls.Add(this.fieldSelect);
            this.groupBox1.Controls.Add(this.layerSelect);
            this.groupBox1.Controls.Add(this.layer);
            this.groupBox1.Controls.Add(this.field);
            this.groupBox1.Controls.Add(this.uniqueValue);
            this.groupBox1.Controls.Add(this.condition);
            this.groupBox1.Location = new System.Drawing.Point(62, 45);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(512, 330);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(178, 235);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(272, 35);
            this.textBox1.TabIndex = 11;
            // 
            // conditionSelect
            // 
            this.conditionSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conditionSelect.FormattingEnabled = true;
            this.conditionSelect.Items.AddRange(new object[] {
            ">",
            "<",
            "="});
            this.conditionSelect.Location = new System.Drawing.Point(178, 166);
            this.conditionSelect.Margin = new System.Windows.Forms.Padding(6);
            this.conditionSelect.Name = "conditionSelect";
            this.conditionSelect.Size = new System.Drawing.Size(268, 39);
            this.conditionSelect.TabIndex = 10;
            // 
            // fieldSelect
            // 
            this.fieldSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fieldSelect.FormattingEnabled = true;
            this.fieldSelect.Location = new System.Drawing.Point(178, 108);
            this.fieldSelect.Margin = new System.Windows.Forms.Padding(6);
            this.fieldSelect.Name = "fieldSelect";
            this.fieldSelect.Size = new System.Drawing.Size(268, 39);
            this.fieldSelect.TabIndex = 9;
            // 
            // layerSelect
            // 
            this.layerSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layerSelect.FormattingEnabled = true;
            this.layerSelect.Location = new System.Drawing.Point(178, 50);
            this.layerSelect.Margin = new System.Windows.Forms.Padding(6);
            this.layerSelect.Name = "layerSelect";
            this.layerSelect.Size = new System.Drawing.Size(268, 39);
            this.layerSelect.TabIndex = 8;
            this.layerSelect.SelectedIndexChanged += new System.EventHandler(this.layerSelect_SelectedIndexChanged);
            // 
            // layer
            // 
            this.layer.AutoSize = true;
            this.layer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layer.Location = new System.Drawing.Point(40, 50);
            this.layer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.layer.Name = "layer";
            this.layer.Size = new System.Drawing.Size(71, 36);
            this.layer.TabIndex = 3;
            this.layer.Text = "图层";
            // 
            // field
            // 
            this.field.AutoSize = true;
            this.field.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.field.Location = new System.Drawing.Point(40, 110);
            this.field.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(71, 36);
            this.field.TabIndex = 0;
            this.field.Text = "字段";
            // 
            // uniqueValue
            // 
            this.uniqueValue.AutoSize = true;
            this.uniqueValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uniqueValue.Location = new System.Drawing.Point(26, 230);
            this.uniqueValue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.uniqueValue.Name = "uniqueValue";
            this.uniqueValue.Size = new System.Drawing.Size(99, 36);
            this.uniqueValue.TabIndex = 2;
            this.uniqueValue.Text = "唯一值";
            // 
            // condition
            // 
            this.condition.AutoSize = true;
            this.condition.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.condition.Location = new System.Drawing.Point(40, 170);
            this.condition.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.condition.Name = "condition";
            this.condition.Size = new System.Drawing.Size(71, 36);
            this.condition.TabIndex = 1;
            this.condition.Text = "条件";
            // 
            // selByAttriInMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 532);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.groupBox1);
            this.Name = "selByAttriInMainForm";
            this.Text = "selByAttriInMainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox conditionSelect;
        private System.Windows.Forms.ComboBox fieldSelect;
        private System.Windows.Forms.ComboBox layerSelect;
        private System.Windows.Forms.Label layer;
        private System.Windows.Forms.Label field;
        private System.Windows.Forms.Label uniqueValue;
        private System.Windows.Forms.Label condition;
    }
}