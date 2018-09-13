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
    public partial class WinDeleteStu : Form
    {
        private SeverCatch sqlCatch;
        public WinDeleteStu(SeverCatch SqlSent)
        {
            sqlCatch = SqlSent;
            InitializeComponent();
        }

        private void DeleteSure_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(DeleteBox.Text))
            {
                MessageBox.Show("信息不能为空!");
                return;
            }

            if (!sqlCatch.Delete(DeleteBox.Text))
            {
                MessageBox.Show("不存在该学号!", "删除失败");
                return;
            }

            MessageBox.Show("删除成功!");

            this.Close();
        }

        private void DeleteCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
