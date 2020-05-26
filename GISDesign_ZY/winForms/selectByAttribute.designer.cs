namespace GISFinal
{
    partial class selectByAttribute
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
            this.condition = new System.Windows.Forms.Label();
            this.uniqueValue = new System.Windows.Forms.Label();
            this.field = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uniqueValueSelect = new System.Windows.Forms.ComboBox();
            this.conditionSelect = new System.Windows.Forms.ComboBox();
            this.fieldSelect = new System.Windows.Forms.ComboBox();
            this.layerSelect = new System.Windows.Forms.ComboBox();
            this.layer = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // condition
            // 
            this.condition.AutoSize = true;
            this.condition.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.condition.Location = new System.Drawing.Point(20, 85);
            this.condition.Name = "condition";
            this.condition.Size = new System.Drawing.Size(37, 20);
            this.condition.TabIndex = 1;
            this.condition.Text = "条件";
            this.condition.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // uniqueValue
            // 
            this.uniqueValue.AutoSize = true;
            this.uniqueValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uniqueValue.Location = new System.Drawing.Point(13, 115);
            this.uniqueValue.Name = "uniqueValue";
            this.uniqueValue.Size = new System.Drawing.Size(51, 20);
            this.uniqueValue.TabIndex = 2;
            this.uniqueValue.Text = "唯一值";
            // 
            // field
            // 
            this.field.AutoSize = true;
            this.field.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.field.Location = new System.Drawing.Point(20, 55);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(37, 20);
            this.field.TabIndex = 0;
            this.field.Text = "字段";
            this.field.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uniqueValueSelect);
            this.groupBox1.Controls.Add(this.conditionSelect);
            this.groupBox1.Controls.Add(this.fieldSelect);
            this.groupBox1.Controls.Add(this.layerSelect);
            this.groupBox1.Controls.Add(this.layer);
            this.groupBox1.Controls.Add(this.field);
            this.groupBox1.Controls.Add(this.uniqueValue);
            this.groupBox1.Controls.Add(this.condition);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 165);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // uniqueValueSelect
            // 
            this.uniqueValueSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uniqueValueSelect.FormattingEnabled = true;
            this.uniqueValueSelect.Location = new System.Drawing.Point(89, 113);
            this.uniqueValueSelect.Name = "uniqueValueSelect";
            this.uniqueValueSelect.Size = new System.Drawing.Size(136, 25);
            this.uniqueValueSelect.TabIndex = 11;
            // 
            // conditionSelect
            // 
            this.conditionSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conditionSelect.FormattingEnabled = true;
            this.conditionSelect.Location = new System.Drawing.Point(89, 83);
            this.conditionSelect.Name = "conditionSelect";
            this.conditionSelect.Size = new System.Drawing.Size(136, 25);
            this.conditionSelect.TabIndex = 10;
            // 
            // fieldSelect
            // 
            this.fieldSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fieldSelect.FormattingEnabled = true;
            this.fieldSelect.Location = new System.Drawing.Point(89, 54);
            this.fieldSelect.Name = "fieldSelect";
            this.fieldSelect.Size = new System.Drawing.Size(136, 25);
            this.fieldSelect.TabIndex = 9;
            // 
            // layerSelect
            // 
            this.layerSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layerSelect.FormattingEnabled = true;
            this.layerSelect.Location = new System.Drawing.Point(89, 25);
            this.layerSelect.Name = "layerSelect";
            this.layerSelect.Size = new System.Drawing.Size(136, 25);
            this.layerSelect.TabIndex = 8;
            // 
            // layer
            // 
            this.layer.AutoSize = true;
            this.layer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layer.Location = new System.Drawing.Point(20, 25);
            this.layer.Name = "layer";
            this.layer.Size = new System.Drawing.Size(37, 20);
            this.layer.TabIndex = 3;
            this.layer.Text = "图层";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(52, 197);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 5;
            this.OK.Text = "确认";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(178, 197);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // selectByAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 242);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.groupBox1);
            this.Name = "selectByAttribute";
            this.Text = "按属性选择";
            this.Load += new System.EventHandler(this.selectByAttribute_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label condition;
        private System.Windows.Forms.Label uniqueValue;
        private System.Windows.Forms.Label field;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox uniqueValueSelect;
        private System.Windows.Forms.ComboBox conditionSelect;
        private System.Windows.Forms.ComboBox fieldSelect;
        private System.Windows.Forms.ComboBox layerSelect;
        private System.Windows.Forms.Label layer;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
    }
}