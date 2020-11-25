namespace StudentCS
{
    partial class FormTJ
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
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avg1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CName,
            this.member,
            this.max1,
            this.avg1,
            this.min1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(444, 380);
            this.dataGridView1.TabIndex = 1;
            // 
            // CName
            // 
            this.CName.DataPropertyName = "CName";
            this.CName.HeaderText = "课程名";
            this.CName.Name = "CName";
            // 
            // member
            // 
            this.member.DataPropertyName = "member";
            this.member.HeaderText = "选课人数";
            this.member.Name = "member";
            this.member.Width = 80;
            // 
            // max1
            // 
            this.max1.DataPropertyName = "max1";
            this.max1.HeaderText = "最高分";
            this.max1.Name = "max1";
            this.max1.Width = 75;
            // 
            // avg1
            // 
            this.avg1.DataPropertyName = "avg1";
            this.avg1.HeaderText = "平均分";
            this.avg1.Name = "avg1";
            this.avg1.Width = 75;
            // 
            // min1
            // 
            this.min1.DataPropertyName = "min1";
            this.min1.HeaderText = "最低分";
            this.min1.Name = "min1";
            this.min1.Width = 75;
            // 
            // FormTJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 380);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormTJ";
            this.Text = "统计分析";
            this.Load += new System.EventHandler(this.FormTJ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn member;
        private System.Windows.Forms.DataGridViewTextBoxColumn max1;
        private System.Windows.Forms.DataGridViewTextBoxColumn avg1;
        private System.Windows.Forms.DataGridViewTextBoxColumn min1;
    }
}