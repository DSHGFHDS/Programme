namespace InSystem
{
    partial class WinMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinMain));
            this.StuList = new System.Windows.Forms.DataGridView();
            this.ButtonDeleteStu = new System.Windows.Forms.Button();
            this.TextSearch = new System.Windows.Forms.TextBox();
            this.ButtonAddStu = new System.Windows.Forms.Button();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ComboSearch = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.StuList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StuList
            // 
            this.StuList.AllowUserToAddRows = false;
            this.StuList.AllowUserToDeleteRows = false;
            this.StuList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StuList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StuList.BackgroundColor = System.Drawing.Color.DarkGray;
            this.StuList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StuList.GridColor = System.Drawing.Color.DarkGray;
            this.StuList.Location = new System.Drawing.Point(2, 64);
            this.StuList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StuList.Name = "StuList";
            this.StuList.ReadOnly = true;
            this.StuList.RowTemplate.Height = 27;
            this.StuList.Size = new System.Drawing.Size(541, 255);
            this.StuList.TabIndex = 0;
            // 
            // ButtonDeleteStu
            // 
            this.ButtonDeleteStu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteStu.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonDeleteStu.Location = new System.Drawing.Point(424, 10);
            this.ButtonDeleteStu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonDeleteStu.Name = "ButtonDeleteStu";
            this.ButtonDeleteStu.Size = new System.Drawing.Size(118, 48);
            this.ButtonDeleteStu.TabIndex = 6;
            this.ButtonDeleteStu.Text = "删除信息";
            this.ButtonDeleteStu.UseVisualStyleBackColor = false;
            this.ButtonDeleteStu.Click += new System.EventHandler(this.DeleteStuButton_Click);
            // 
            // TextSearch
            // 
            this.TextSearch.BackColor = System.Drawing.Color.DarkGray;
            this.TextSearch.Location = new System.Drawing.Point(2, 39);
            this.TextSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextSearch.MaxLength = 20;
            this.TextSearch.Name = "TextSearch";
            this.TextSearch.Size = new System.Drawing.Size(167, 21);
            this.TextSearch.TabIndex = 2;
            this.TextSearch.TextChanged += new System.EventHandler(this.TextSearch_TextChanged);
            this.TextSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextSearch_KeyPress);
            // 
            // ButtonAddStu
            // 
            this.ButtonAddStu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddStu.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonAddStu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ButtonAddStu.Location = new System.Drawing.Point(302, 11);
            this.ButtonAddStu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonAddStu.Name = "ButtonAddStu";
            this.ButtonAddStu.Size = new System.Drawing.Size(118, 48);
            this.ButtonAddStu.TabIndex = 4;
            this.ButtonAddStu.Text = "添加信息";
            this.ButtonAddStu.UseVisualStyleBackColor = false;
            this.ButtonAddStu.Click += new System.EventHandler(this.AddStuButton_Click);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSearch.Location = new System.Drawing.Point(93, 10);
            this.ButtonSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 24);
            this.ButtonSearch.TabIndex = 3;
            this.ButtonSearch.Text = "所有学生";
            this.ButtonSearch.UseVisualStyleBackColor = false;
            this.ButtonSearch.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ComboSearch
            // 
            this.ComboSearch.BackColor = System.Drawing.Color.DarkGray;
            this.ComboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSearch.FormattingEnabled = true;
            this.ComboSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ComboSearch.ItemHeight = 12;
            this.ComboSearch.Items.AddRange(new object[] {
            "学号",
            "姓名",
            "性别",
            "班级"});
            this.ComboSearch.Location = new System.Drawing.Point(2, 14);
            this.ComboSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComboSearch.Name = "ComboSearch";
            this.ComboSearch.Size = new System.Drawing.Size(76, 20);
            this.ComboSearch.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.ComboSearch);
            this.panel1.Controls.Add(this.ButtonSearch);
            this.panel1.Controls.Add(this.ButtonAddStu);
            this.panel1.Controls.Add(this.TextSearch);
            this.panel1.Controls.Add(this.ButtonDeleteStu);
            this.panel1.Controls.Add(this.StuList);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 322);
            this.panel1.TabIndex = 6;
            // 
            // WinMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 346);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(582, 385);
            this.Name = "WinMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.WinMain_Activated);
            this.Load += new System.EventHandler(this.WinMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StuList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListSource SourceData;
        private System.Windows.Forms.DataGridView StuList;
        private System.Windows.Forms.Button ButtonDeleteStu;
        private System.Windows.Forms.TextBox TextSearch;
        private System.Windows.Forms.Button ButtonAddStu;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.ComboBox ComboSearch;
        private System.Windows.Forms.Panel panel1;
    }
}