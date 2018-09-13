using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace InSystem
{
    public partial class LoginWindow : Form
    {
        private ConnectCaller CC;
        private SeverCatch serverCatch;

        public LoginWindow(SeverCatch serverCatch)
        {
            InitializeComponent();
            this.serverCatch = serverCatch;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            login();
        }

        //登录
        private void login()
        {
            if (String.IsNullOrWhiteSpace(IDInputer.Text) || String.IsNullOrWhiteSpace(TextPw.Text))
            {
                MessageBox.Show("姓名或密码不能为空!", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IAsyncResult NetResult = CC.BeginInvoke(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(), 6666, null, null);

            if (!CC.EndInvoke(NetResult))
            {
                MessageBox.Show("无法连接网络！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!serverCatch.IsMarched(IDInputer.Text, TextPw.Text))
            {
                MessageBox.Show("登录错误!", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TextPw_Press(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                login();
            else if(e.KeyChar == ' ')
                e.Handled = true;
            else e.Handled = false;
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            CC = new ConnectCaller(ConnectToServer);

            //使各个标签在picturebox上透明
            Lab1.Parent = pbBack;
            LabID.Parent = pbBack;
            LabPw.Parent = pbBack;
        }

        private delegate bool ConnectCaller(string ip, int prot);
        private bool ConnectToServer(string ip, int prot)
        {
            if (serverCatch.mClient.Connected)
                return true;

            try
            {
                serverCatch.mClient.Connect(new IPEndPoint(IPAddress.Parse(ip), prot));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}