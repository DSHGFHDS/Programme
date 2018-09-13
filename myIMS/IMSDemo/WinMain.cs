using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;

namespace InSystem
{
    public partial class WinMain : Form
    {
        private SeverCatch serverCatch;

        public WinMain(SeverCatch serverCatch)
        {
            InitializeComponent();
            this.serverCatch = serverCatch;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            showOrSearch();
        }


        private void AddStuButton_Click(object sender, EventArgs e)
        {
            WinAddStu Awindow = new WinAddStu(serverCatch);
            Awindow.ShowDialog();
            Awindow.Dispose();
            ShowAll();
        }


        private void DeleteStuButton_Click(object sender, EventArgs e)
        {
            WinDeleteStu Dwindow = new WinDeleteStu(serverCatch);
            Dwindow.ShowDialog();
            Dwindow.Dispose();
            ShowAll();
        }


        private void TextSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按下回车进行搜索
            if((int)e.KeyChar == 13)
            {
                showOrSearch();
            }
        }


        private void WinMain_Activated(object sender, EventArgs e)
        {
            //自动为搜索框设置焦点
            TextSearch.Focus();
        }


        private void WinMain_Load(object sender, EventArgs e)
        {
            //设置combobox的初始选项
            ComboSearch.SelectedIndex = 0;
            //初始化数据显示框
            SourceData = new ListSource(StuList);
            ShowAll();
        }


        //根据搜索框有无内容自动执行查询或显示全部
        private void showOrSearch()
        {
            if (TextSearch.Text.Length <= 0)
            {
                ShowAll();
                MessageBox.Show("已显示所有学生信息");
            }
            else
                search();
        }


        //查询
        private void search()
        {
            List<StuInfo> sList = serverCatch.Search(ComboSearch.SelectedIndex, TextSearch.Text);

            if (sList == null || sList.Count <= 0)
            {
                ShowAll();
                MessageBox.Show("没有符合该信息的学生!", "查询失败!");
                return;
            }

            SourceData.Clear();

            int i = 0;
            foreach (StuInfo Info in sList)
            {
                SourceData.Add(Info.getsno(), Info.getsname(), Info.getssex(), Info.getsclass());
                StuList.Rows[i++].Cells[ComboSearch.SelectedIndex].Selected = true;
            }
            StuList.Rows[0].Cells[0].Selected = false;

            MessageBox.Show("查找完成");
        }

        //显示全部信息
        private void ShowAll()
        {
            SourceData.Clear();
            List<StuInfo> stus = serverCatch.queryAllStu();
            if (stus == null || stus.Count <= 0)
                return;
            foreach (StuInfo stu in stus)
                SourceData.Add(stu.getsno(), stu.getsname(), stu.getssex(), stu.getsclass());
        }


        //监控搜索框变化，动态改变按钮文本
        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            if (TextSearch.Text.Length <= 0)
                ButtonSearch.Text = "所有学生";
            else
                ButtonSearch.Text = "查找";
        }
    }
}
