namespace StudentCS
{
    partial class FormStudentEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SDept = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SAge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SBirthday = new System.Windows.Forms.DateTimePicker();
            this.radioButtonGirl = new System.Windows.Forms.RadioButton();
            this.radioButtonBoy = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 87);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(311, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.SDept);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.SAge);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.SBirthday);
            this.panel2.Controls.Add(this.radioButtonGirl);
            this.panel2.Controls.Add(this.radioButtonBoy);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.SName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.SNO);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 310);
            this.panel2.TabIndex = 1;
            // 
            // SDept
            // 
            this.SDept.FormattingEnabled = true;
            this.SDept.Location = new System.Drawing.Point(206, 260);
            this.SDept.Name = "SDept";
            this.SDept.Size = new System.Drawing.Size(121, 20);
            this.SDept.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "院系";
            // 
            // SAge
            // 
            this.SAge.Location = new System.Drawing.Point(206, 214);
            this.SAge.Name = "SAge";
            this.SAge.Size = new System.Drawing.Size(140, 21);
            this.SAge.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "年龄";
            // 
            // SBirthday
            // 
            this.SBirthday.Location = new System.Drawing.Point(206, 170);
            this.SBirthday.Name = "SBirthday";
            this.SBirthday.Size = new System.Drawing.Size(200, 21);
            this.SBirthday.TabIndex = 10;
            // 
            // radioButtonGirl
            // 
            this.radioButtonGirl.AutoSize = true;
            this.radioButtonGirl.Location = new System.Drawing.Point(311, 126);
            this.radioButtonGirl.Name = "radioButtonGirl";
            this.radioButtonGirl.Size = new System.Drawing.Size(35, 16);
            this.radioButtonGirl.TabIndex = 9;
            this.radioButtonGirl.Text = "女";
            this.radioButtonGirl.UseVisualStyleBackColor = true;
            // 
            // radioButtonBoy
            // 
            this.radioButtonBoy.AutoSize = true;
            this.radioButtonBoy.Checked = true;
            this.radioButtonBoy.Location = new System.Drawing.Point(206, 126);
            this.radioButtonBoy.Name = "radioButtonBoy";
            this.radioButtonBoy.Size = new System.Drawing.Size(35, 16);
            this.radioButtonBoy.TabIndex = 8;
            this.radioButtonBoy.TabStop = true;
            this.radioButtonBoy.Text = "男";
            this.radioButtonBoy.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "出生日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "性别";
            // 
            // SName
            // 
            this.SName.Location = new System.Drawing.Point(206, 77);
            this.SName.Name = "SName";
            this.SName.Size = new System.Drawing.Size(140, 21);
            this.SName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名";
            // 
            // SNO
            // 
            this.SNO.Location = new System.Drawing.Point(206, 26);
            this.SNO.Name = "SNO";
            this.SNO.Size = new System.Drawing.Size(140, 21);
            this.SNO.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "学号";
            // 
            // FormStudentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 403);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStudentEdit";
            this.Text = "FormStudentEdit";
            this.Load += new System.EventHandler(this.FormStudentEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker SBirthday;
        private System.Windows.Forms.RadioButton radioButtonGirl;
        private System.Windows.Forms.RadioButton radioButtonBoy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SAge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SDept;
    }
}