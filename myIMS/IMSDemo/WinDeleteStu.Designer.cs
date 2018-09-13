namespace InSystem
{
    partial class WinDeleteStu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinDeleteStu));
            this.DeleteBox = new System.Windows.Forms.TextBox();
            this.DeleteInfo = new System.Windows.Forms.Label();
            this.DeleteSure = new System.Windows.Forms.Button();
            this.DeleteCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeleteBox
            // 
            this.DeleteBox.Location = new System.Drawing.Point(68, 16);
            this.DeleteBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteBox.Name = "DeleteBox";
            this.DeleteBox.Size = new System.Drawing.Size(168, 21);
            this.DeleteBox.TabIndex = 0;
            // 
            // DeleteInfo
            // 
            this.DeleteInfo.AutoSize = true;
            this.DeleteInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeleteInfo.Location = new System.Drawing.Point(25, 14);
            this.DeleteInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DeleteInfo.Name = "DeleteInfo";
            this.DeleteInfo.Size = new System.Drawing.Size(42, 21);
            this.DeleteInfo.TabIndex = 1;
            this.DeleteInfo.Text = "学号";
            // 
            // DeleteSure
            // 
            this.DeleteSure.Location = new System.Drawing.Point(28, 55);
            this.DeleteSure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteSure.Name = "DeleteSure";
            this.DeleteSure.Size = new System.Drawing.Size(94, 30);
            this.DeleteSure.TabIndex = 2;
            this.DeleteSure.Text = "删除";
            this.DeleteSure.UseVisualStyleBackColor = true;
            this.DeleteSure.Click += new System.EventHandler(this.DeleteSure_Click);
            // 
            // DeleteCancle
            // 
            this.DeleteCancle.Location = new System.Drawing.Point(140, 55);
            this.DeleteCancle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteCancle.Name = "DeleteCancle";
            this.DeleteCancle.Size = new System.Drawing.Size(94, 30);
            this.DeleteCancle.TabIndex = 3;
            this.DeleteCancle.Text = "取消";
            this.DeleteCancle.UseVisualStyleBackColor = true;
            this.DeleteCancle.Click += new System.EventHandler(this.DeleteCancle_Click);
            // 
            // WinDeleteStu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 95);
            this.Controls.Add(this.DeleteCancle);
            this.Controls.Add(this.DeleteSure);
            this.Controls.Add(this.DeleteInfo);
            this.Controls.Add(this.DeleteBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "WinDeleteStu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "删除学生信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DeleteBox;
        private System.Windows.Forms.Label DeleteInfo;
        private System.Windows.Forms.Button DeleteSure;
        private System.Windows.Forms.Button DeleteCancle;
    }
}