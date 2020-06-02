namespace GISFinal
{
    partial class addField
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
            this.nameInput = new System.Windows.Forms.TextBox();
            this.valueInput = new System.Windows.Forms.TextBox();
            this.typeSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldType = new System.Windows.Forms.Label();
            this.fieldName = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nameInput);
            this.groupBox1.Controls.Add(this.valueInput);
            this.groupBox1.Controls.Add(this.typeSelect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fieldType);
            this.groupBox1.Controls.Add(this.fieldName);
            this.groupBox1.Location = new System.Drawing.Point(56, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(528, 268);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // nameInput
            // 
            this.nameInput.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameInput.Location = new System.Drawing.Point(206, 50);
            this.nameInput.Margin = new System.Windows.Forms.Padding(6);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(266, 39);
            this.nameInput.TabIndex = 5;
            // 
            // valueInput
            // 
            this.valueInput.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.valueInput.ForeColor = System.Drawing.Color.Gray;
            this.valueInput.Location = new System.Drawing.Point(206, 172);
            this.valueInput.Margin = new System.Windows.Forms.Padding(6);
            this.valueInput.Name = "valueInput";
            this.valueInput.Size = new System.Drawing.Size(266, 39);
            this.valueInput.TabIndex = 4;
            this.valueInput.Text = "默认值";
            this.valueInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // typeSelect
            // 
            this.typeSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.typeSelect.FormattingEnabled = true;
            this.typeSelect.Items.AddRange(new object[] {
            "int",
            "double",
            "string"});
            this.typeSelect.Location = new System.Drawing.Point(206, 108);
            this.typeSelect.Margin = new System.Windows.Forms.Padding(6);
            this.typeSelect.Name = "typeSelect";
            this.typeSelect.Size = new System.Drawing.Size(266, 39);
            this.typeSelect.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(52, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "默认值";
            // 
            // fieldType
            // 
            this.fieldType.AutoSize = true;
            this.fieldType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fieldType.Location = new System.Drawing.Point(38, 112);
            this.fieldType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.fieldType.Name = "fieldType";
            this.fieldType.Size = new System.Drawing.Size(127, 36);
            this.fieldType.TabIndex = 1;
            this.fieldType.Text = "字段类型";
            // 
            // fieldName
            // 
            this.fieldName.AutoSize = true;
            this.fieldName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fieldName.Location = new System.Drawing.Point(38, 52);
            this.fieldName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(127, 36);
            this.fieldName.TabIndex = 0;
            this.fieldName.Text = "字段名称";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(102, 364);
            this.OK.Margin = new System.Windows.Forms.Padding(6);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(150, 46);
            this.OK.TabIndex = 1;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(382, 364);
            this.Cancel.Margin = new System.Windows.Forms.Padding(6);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(150, 46);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // addField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 474);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "addField";
            this.Text = "添加字段";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fieldType;
        private System.Windows.Forms.Label fieldName;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox valueInput;
        private System.Windows.Forms.ComboBox typeSelect;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}