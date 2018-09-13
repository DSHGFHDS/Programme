using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InSystem
{
    public partial class WinAddStu : Form
    {
        private SeverCatch sqlCatch;
        public WinAddStu(SeverCatch sqlSent)
        {
            sqlCatch = sqlSent;
            InitializeComponent();
        }

        private void AddSure_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(AddID.Text) || String.IsNullOrWhiteSpace(AddName.Text) || String.IsNullOrWhiteSpace(AddSex.Text) || String.IsNullOrWhiteSpace(AddClass.Text))
            {
                MessageBox.Show("信息不能为空!", "添加失败");
                return;
            }

            if (!sqlCatch.Add(AddID.Text, AddName.Text, AddSex.Text, AddClass.Text))
            { 
                MessageBox.Show("该学生信息已存在!", "添加失败");
                return;
            }

            MessageBox.Show("添加成功!");
            this.Close();
        }

        private void AddCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
