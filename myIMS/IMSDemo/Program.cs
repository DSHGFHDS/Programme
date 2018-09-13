using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;

namespace InSystem
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Socket Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SeverCatch serverCatch = new SeverCatch(Client);
            LoginWindow Login = new LoginWindow(serverCatch);
            Login.ShowDialog();

            if (Login.DialogResult != DialogResult.OK)
                return;

            WinMain Accesster = new WinMain(serverCatch);
            Accesster.Text = "管理员:" + Login.IDInputer.Text;


            Login.Dispose();
            Application.Run(Accesster);
        }
    }

    
}
