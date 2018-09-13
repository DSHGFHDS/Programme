namespace InSystem
{
    partial class WinAddStu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinAddStu));
            this.AddSure = new System.Windows.Forms.Button();
            this.AddCancle = new System.Windows.Forms.Button();
            this.AddName = new System.Windows.Forms.TextBox();
            this.AddID = new System.Windows.Forms.TextBox();
            this.AddSex = new System.Windows.Forms.TextBox();
            this.AddClass = new System.Windows.Forms.TextBox();
            this.AIDTitle = new System.Windows.Forms.Label();
            this.ANameTitle = new System.Windows.Forms.Label();
            this.ASexTitle = new System.Windows.Forms.Label();
            this.AClassTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddSure
            // 
            this.AddSure.Location = new System.Drawing.Point(49, 142);
            this.AddSure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddSure.Name = "AddSure";
            this.AddSure.Size = new System.Drawing.Size(56, 28);
            this.AddSure.TabIndex = 5;
            this.AddSure.Text = "确定";
            this.AddSure.UseVisualStyleBackColor = true;
            this.AddSure.Click += new System.EventHandler(this.AddSure_Click);
            // 
            // AddCancle
            // 
            this.AddCancle.Location = new System.Drawing.Point(130, 142);
            this.AddCancle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddCancle.Name = "AddCancle";
            this.AddCancle.Size = new System.Drawing.Size(56, 28);
            this.AddCancle.TabIndex = 6;
            this.AddCancle.Text = "取消";
            this.AddCancle.UseVisualStyleBackColor = true;
            this.AddCancle.Click += new System.EventHandler(this.AddCancle_Click);
            // 
            // AddName
            // 
            this.AddName.Location = new System.Drawing.Point(86, 57);
            this.AddName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddName.MaxLength = 20;
            this.AddName.Name = "AddName";
            this.AddName.Size = new System.Drawing.Size(102, 21);
            this.AddName.TabIndex = 2;
            // 
            // AddID
            // 
            this.AddID.Location = new System.Drawing.Point(86, 32);
            this.AddID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddID.MaxLength = 15;
            this.AddID.Name = "AddID";
            this.AddID.Size = new System.Drawing.Size(102, 21);
            this.AddID.TabIndex = 1;
            // 
            // AddSex
            // 
            this.AddSex.Location = new System.Drawing.Point(86, 82);
            this.AddSex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddSex.MaxLength = 6;
            this.AddSex.Name = "AddSex";
            this.AddSex.Size = new System.Drawing.Size(102, 21);
            this.AddSex.TabIndex = 3;
            // 
            // AddClass
            // 
            this.AddClass.Location = new System.Drawing.Point(86, 106);
            this.AddClass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddClass.MaxLength = 50;
            this.AddClass.Name = "AddClass";
            this.AddClass.Size = new System.Drawing.Size(102, 21);
            this.AddClass.TabIndex = 4;
            // 
            // AIDTitle
            // 
            this.AIDTitle.AutoSize = true;
            this.AIDTitle.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AIDTitle.Location = new System.Drawing.Point(46, 33);
            this.AIDTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AIDTitle.Name = "AIDTitle";
            this.AIDTitle.Size = new System.Drawing.Size(37, 15);
            this.AIDTitle.TabIndex = 6;
            this.AIDTitle.Text = "学号";
            // 
            // ANameTitle
            // 
            this.ANameTitle.AutoSize = true;
            this.ANameTitle.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ANameTitle.Location = new System.Drawing.Point(46, 58);
            this.ANameTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ANameTitle.Name = "ANameTitle";
            this.ANameTitle.Size = new System.Drawing.Size(37, 15);
            this.ANameTitle.TabIndex = 7;
            this.ANameTitle.Text = "姓名";
            // 
            // ASexTitle
            // 
            this.ASexTitle.AutoSize = true;
            this.ASexTitle.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ASexTitle.Location = new System.Drawing.Point(46, 82);
            this.ASexTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ASexTitle.Name = "ASexTitle";
            this.ASexTitle.Size = new System.Drawing.Size(37, 15);
            this.ASexTitle.TabIndex = 8;
            this.ASexTitle.Text = "性别";
            // 
            // AClassTitle
            // 
            this.AClassTitle.AutoSize = true;
            this.AClassTitle.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AClassTitle.Location = new System.Drawing.Point(46, 107);
            this.AClassTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AClassTitle.Name = "AClassTitle";
            this.AClassTitle.Size = new System.Drawing.Size(37, 15);
            this.AClassTitle.TabIndex = 9;
            this.AClassTitle.Text = "班级";
            // 
            // WinAddStu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 194);
            this.Controls.Add(this.AClassTitle);
            this.Controls.Add(this.ASexTitle);
            this.Controls.Add(this.ANameTitle);
            this.Controls.Add(this.AIDTitle);
            this.Controls.Add(this.AddClass);
            this.Controls.Add(this.AddSex);
            this.Controls.Add(this.AddID);
            this.Controls.Add(this.AddName);
            this.Controls.Add(this.AddCancle);
            this.Controls.Add(this.AddSure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "WinAddStu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加学生信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddSure;
        private System.Windows.Forms.Button AddCancle;
        private System.Windows.Forms.TextBox AddName;
        private System.Windows.Forms.TextBox AddID;
        private System.Windows.Forms.TextBox AddSex;
        private System.Windows.Forms.TextBox AddClass;
        private System.Windows.Forms.Label AIDTitle;
        private System.Windows.Forms.Label ANameTitle;
        private System.Windows.Forms.Label ASexTitle;
        private System.Windows.Forms.Label AClassTitle;
    }
}