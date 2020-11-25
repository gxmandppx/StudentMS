namespace StudentCS
{
    partial class FormLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.User_ID = new System.Windows.Forms.TextBox();
            this.User_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.denglu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // User_ID
            // 
            this.User_ID.Location = new System.Drawing.Point(152, 45);
            this.User_ID.Name = "User_ID";
            this.User_ID.Size = new System.Drawing.Size(73, 21);
            this.User_ID.TabIndex = 1;
            this.User_ID.Text = "hb";
            // 
            // User_Password
            // 
            this.User_Password.Location = new System.Drawing.Point(152, 114);
            this.User_Password.Name = "User_Password";
            this.User_Password.PasswordChar = '*';
            this.User_Password.Size = new System.Drawing.Size(73, 21);
            this.User_Password.TabIndex = 3;
            this.User_Password.Text = "hb";
            this.User_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User_Password_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码";
            // 
            // denglu
            // 
            this.denglu.Location = new System.Drawing.Point(100, 175);
            this.denglu.Name = "denglu";
            this.denglu.Size = new System.Drawing.Size(72, 36);
            this.denglu.TabIndex = 4;
            this.denglu.Text = "登录";
            this.denglu.UseVisualStyleBackColor = true;
            this.denglu.Click += new System.EventHandler(this.denglu_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.denglu);
            this.Controls.Add(this.User_Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.User_ID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox User_ID;
        private System.Windows.Forms.TextBox User_Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button denglu;
    }
}