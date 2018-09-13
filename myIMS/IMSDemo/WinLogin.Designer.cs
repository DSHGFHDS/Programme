namespace InSystem
{
    partial class LoginWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindow));
            this.Lab1 = new System.Windows.Forms.Label();
            this.IDInputer = new System.Windows.Forms.TextBox();
            this.TextPw = new System.Windows.Forms.TextBox();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.LabID = new System.Windows.Forms.Label();
            this.LabPw = new System.Windows.Forms.Label();
            this.pbBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.SuspendLayout();
            // 
            // Lab1
            // 
            this.Lab1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lab1.AutoSize = true;
            this.Lab1.BackColor = System.Drawing.Color.Transparent;
            this.Lab1.CausesValidation = false;
            this.Lab1.Font = new System.Drawing.Font("幼圆", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab1.ForeColor = System.Drawing.Color.DimGray;
            this.Lab1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Lab1.Location = new System.Drawing.Point(91, 53);
            this.Lab1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lab1.Name = "Lab1";
            this.Lab1.Size = new System.Drawing.Size(412, 48);
            this.Lab1.TabIndex = 0;
            this.Lab1.Text = "学生管理信息系统";
            // 
            // IDInputer
            // 
            this.IDInputer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IDInputer.BackColor = System.Drawing.SystemColors.Menu;
            this.IDInputer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IDInputer.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.IDInputer.Location = new System.Drawing.Point(237, 136);
            this.IDInputer.Margin = new System.Windows.Forms.Padding(2);
            this.IDInputer.MaxLength = 20;
            this.IDInputer.Name = "IDInputer";
            this.IDInputer.ShortcutsEnabled = false;
            this.IDInputer.Size = new System.Drawing.Size(131, 23);
            this.IDInputer.TabIndex = 1;
            this.IDInputer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextPw_Press);
            // 
            // TextPw
            // 
            this.TextPw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextPw.BackColor = System.Drawing.SystemColors.Menu;
            this.TextPw.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TextPw.Location = new System.Drawing.Point(237, 176);
            this.TextPw.Margin = new System.Windows.Forms.Padding(2);
            this.TextPw.MaxLength = 20;
            this.TextPw.Name = "TextPw";
            this.TextPw.PasswordChar = '*';
            this.TextPw.ShortcutsEnabled = false;
            this.TextPw.Size = new System.Drawing.Size(131, 21);
            this.TextPw.TabIndex = 2;
            this.TextPw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextPw_Press);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ButtonLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonLogin.ForeColor = System.Drawing.Color.Gray;
            this.ButtonLogin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ButtonLogin.Location = new System.Drawing.Point(251, 225);
            this.ButtonLogin.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(106, 33);
            this.ButtonLogin.TabIndex = 3;
            this.ButtonLogin.Text = "登录";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LabID
            // 
            this.LabID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabID.AutoSize = true;
            this.LabID.BackColor = System.Drawing.Color.Transparent;
            this.LabID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabID.ForeColor = System.Drawing.Color.Gray;
            this.LabID.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.LabID.Location = new System.Drawing.Point(191, 137);
            this.LabID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabID.Name = "LabID";
            this.LabID.Size = new System.Drawing.Size(42, 22);
            this.LabID.TabIndex = 5;
            this.LabID.Text = "帐号";
            // 
            // LabPw
            // 
            this.LabPw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabPw.AutoSize = true;
            this.LabPw.BackColor = System.Drawing.Color.Transparent;
            this.LabPw.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabPw.ForeColor = System.Drawing.Color.Gray;
            this.LabPw.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LabPw.Location = new System.Drawing.Point(191, 176);
            this.LabPw.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabPw.Name = "LabPw";
            this.LabPw.Size = new System.Drawing.Size(42, 22);
            this.LabPw.TabIndex = 6;
            this.LabPw.Text = "密码";
            // 
            // pbBack
            // 
            this.pbBack.BackColor = System.Drawing.Color.Black;
            this.pbBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBack.Location = new System.Drawing.Point(0, 0);
            this.pbBack.Margin = new System.Windows.Forms.Padding(2);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(566, 346);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 7;
            this.pbBack.TabStop = false;
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(566, 346);
            this.Controls.Add(this.LabPw);
            this.Controls.Add(this.LabID);
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.TextPw);
            this.Controls.Add(this.IDInputer);
            this.Controls.Add(this.Lab1);
            this.Controls.Add(this.pbBack);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(582, 385);
            this.MinimumSize = new System.Drawing.Size(582, 385);
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理信息系统设计作业";
            this.Load += new System.EventHandler(this.LoginWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lab1;
        public System.Windows.Forms.TextBox IDInputer;
        private System.Windows.Forms.TextBox TextPw;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.Label LabID;
        private System.Windows.Forms.Label LabPw;
        private System.Windows.Forms.PictureBox pbBack;
    }
}

