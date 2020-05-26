namespace GISFinal
{
    partial class render
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.color1 = new System.Windows.Forms.Label();
            this.size1 = new System.Windows.Forms.TextBox();
            this.type1 = new System.Windows.Forms.ComboBox();
            this.type2 = new System.Windows.Forms.ComboBox();
            this.size2 = new System.Windows.Forms.TextBox();
            this.color2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.type3 = new System.Windows.Forms.ComboBox();
            this.size3 = new System.Windows.Forms.TextBox();
            this.color3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.field2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.field3 = new System.Windows.Forms.ComboBox();
            this.classNum = new System.Windows.Forms.TextBox();
            this.begin = new System.Windows.Forms.TextBox();
            this.end = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(29, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "渲染方式";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(29, 31);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "单一符号渲染";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(134, 31);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "唯一值渲染";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(229, 31);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(71, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "分级渲染";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.type1);
            this.groupBox2.Controls.Add(this.size1);
            this.groupBox2.Controls.Add(this.color1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(29, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 91);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "单一符号渲染";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.field2);
            this.groupBox3.Controls.Add(this.type2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.size2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.color2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(29, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 129);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "唯一值渲染";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.end);
            this.groupBox4.Controls.Add(this.begin);
            this.groupBox4.Controls.Add(this.classNum);
            this.groupBox4.Controls.Add(this.field3);
            this.groupBox4.Controls.Add(this.type3);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.size3);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.color3);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(29, 343);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(329, 188);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "分级渲染";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "符号颜色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "符号大小";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "关联字段";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "关联字段";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "符号样式";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "分级数";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // color1
            // 
            this.color1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.color1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.color1.Location = new System.Drawing.Point(85, 24);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(74, 21);
            this.color1.TabIndex = 5;
            // 
            // size1
            // 
            this.size1.Location = new System.Drawing.Point(85, 52);
            this.size1.Name = "size1";
            this.size1.Size = new System.Drawing.Size(74, 21);
            this.size1.TabIndex = 6;
            // 
            // type1
            // 
            this.type1.FormattingEnabled = true;
            this.type1.Location = new System.Drawing.Point(226, 53);
            this.type1.Name = "type1";
            this.type1.Size = new System.Drawing.Size(74, 20);
            this.type1.TabIndex = 7;
            // 
            // type2
            // 
            this.type2.FormattingEnabled = true;
            this.type2.Location = new System.Drawing.Point(226, 89);
            this.type2.Name = "type2";
            this.type2.Size = new System.Drawing.Size(74, 20);
            this.type2.TabIndex = 13;
            // 
            // size2
            // 
            this.size2.Location = new System.Drawing.Point(85, 88);
            this.size2.Name = "size2";
            this.size2.Size = new System.Drawing.Size(74, 21);
            this.size2.TabIndex = 12;
            // 
            // color2
            // 
            this.color2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.color2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.color2.Location = new System.Drawing.Point(85, 60);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(74, 21);
            this.color2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "符号样式";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "符号大小";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "符号颜色";
            // 
            // type3
            // 
            this.type3.FormattingEnabled = true;
            this.type3.Location = new System.Drawing.Point(226, 148);
            this.type3.Name = "type3";
            this.type3.Size = new System.Drawing.Size(74, 20);
            this.type3.TabIndex = 19;
            // 
            // size3
            // 
            this.size3.Location = new System.Drawing.Point(85, 147);
            this.size3.Name = "size3";
            this.size3.Size = new System.Drawing.Size(74, 21);
            this.size3.TabIndex = 18;
            // 
            // color3
            // 
            this.color3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.color3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.color3.Location = new System.Drawing.Point(85, 119);
            this.color3.Name = "color3";
            this.color3.Size = new System.Drawing.Size(74, 21);
            this.color3.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "符号样式";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 151);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 15;
            this.label15.Text = "符号大小";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "符号颜色";
            // 
            // field2
            // 
            this.field2.FormattingEnabled = true;
            this.field2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.field2.Location = new System.Drawing.Point(85, 32);
            this.field2.Name = "field2";
            this.field2.Size = new System.Drawing.Size(206, 20);
            this.field2.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(169, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "结束大小";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "起始大小";
            // 
            // field3
            // 
            this.field3.FormattingEnabled = true;
            this.field3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.field3.Location = new System.Drawing.Point(85, 32);
            this.field3.Name = "field3";
            this.field3.Size = new System.Drawing.Size(206, 20);
            this.field3.TabIndex = 15;
            // 
            // classNum
            // 
            this.classNum.Location = new System.Drawing.Point(85, 60);
            this.classNum.Name = "classNum";
            this.classNum.Size = new System.Drawing.Size(74, 21);
            this.classNum.TabIndex = 20;
            // 
            // begin
            // 
            this.begin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.begin.ForeColor = System.Drawing.Color.Gray;
            this.begin.Location = new System.Drawing.Point(85, 87);
            this.begin.Name = "begin";
            this.begin.Size = new System.Drawing.Size(74, 23);
            this.begin.TabIndex = 21;
            this.begin.Text = "（最小值）";
            this.begin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // end
            // 
            this.end.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.end.ForeColor = System.Drawing.Color.Gray;
            this.end.Location = new System.Drawing.Point(226, 87);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(74, 23);
            this.end.TabIndex = 22;
            this.end.Text = "（最大值）";
            this.end.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(78, 551);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 6;
            this.OK.Text = "确认";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(221, 551);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // render
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 598);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "render";
            this.Text = "渲染设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label color1;
        private System.Windows.Forms.ComboBox type1;
        private System.Windows.Forms.TextBox size1;
        private System.Windows.Forms.ComboBox type2;
        private System.Windows.Forms.TextBox size2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label color2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox type3;
        private System.Windows.Forms.TextBox size3;
        private System.Windows.Forms.Label color3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox field2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox end;
        private System.Windows.Forms.TextBox begin;
        private System.Windows.Forms.TextBox classNum;
        private System.Windows.Forms.ComboBox field3;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button cancel;
    }
}