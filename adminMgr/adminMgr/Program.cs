using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace adminMgr
{
    class Program
    {
        private static Socket mSocket;

        static void Main(string[] args)
        {
            Program program = new Program();
            mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                mSocket.Connect(new IPEndPoint(IPAddress.Parse(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString()),6666));
            }catch(Exception e)
            {
                Console.WriteLine("连接失败，请检查网络");
                Console.ReadLine();
                Environment.Exit(0);
            }
            while(true)
            {
                Console.Write("已进入管理员后台，输入以下数字进行操作：\n" +
                            "1.添加管理员 \n2.查看所有管理员 \n3.修改管理员密码 \n4.删除管理员 \n");
                string tmp = Console.ReadLine();
                if(tmp.Length<=0)
                    continue;
                switch (int.Parse(tmp.Substring(0,1)))
                {
                    case 1: 
                        program.addAdmin();
                        break;
                    case 2:
                        program.queryAll();
                        break;
                    case 3:
                        program.changePw();
                        break;
                    case 4:
                        program.deleteAdmin();
                        break;
                }
            }
        }

        private void addAdmin()
        {
            input_name:
            Console.Write("输入管理员帐号：");
            string name = Console.ReadLine();
            if(name.Length <= 0)
            {
                Console.WriteLine("用户名不能为空");
                goto input_name;
            }

            input_pw:
            Console.Write("输入密码：");
            string pw1 = inputPw();
            Console.WriteLine();
            if (pw1.Length < 6)
            {
                Console.WriteLine("密码应该大于等于6位");
                goto input_pw;
            }

            Console.Write("确认密码：");
            string pw2 = inputPw();
            Console.WriteLine();

            
            if (!pw1.Equals(pw2))
            {
                Console.WriteLine("密码不一致，重新输入");
                goto input_pw;
            }
            AdminInfo admin = new AdminInfo(name,pw1,true);
            SendMsgSafe(MyProtocol.head_insertAdmin + resolveSpecStr(name) + "#" + resolveSpecStr(admin.getpw()));

            byte[] result = new byte[32];
            int len = mSocket.Receive(result);

            if (len <= MyProtocol.head_queryStuAll.Length)
                Console.WriteLine("未知结果");

            string mBuffer = Encoding.UTF8.GetString(result, 0, len).Substring(MyProtocol.head_insertAdmin.Length);
            if (mBuffer.Equals(MyProtocol.body_success))
                Console.WriteLine("添加成功");
            else if(mBuffer.Equals(MyProtocol.body_exists))
                Console.WriteLine("添加失败,该用户名已存在");
            Console.WriteLine("按回车键继续");
            Console.ReadLine();
            Console.Clear();
        }

        private void queryAll()
        {
            SendMsgSafe(MyProtocol.head_queryAdminAll);

            byte[] result = new byte[2048];
            int len = mSocket.Receive(result);

            if (len <= MyProtocol.head_queryStuAll.Length)
                Console.WriteLine("未知结果");

            string mBuffer = Encoding.UTF8.GetString(result, 0, len).Substring(MyProtocol.head_queryAdminAll.Length);
            
            string[] res = mBuffer.Split(',');
            Console.WriteLine("所有管理员帐号：");
            Console.WriteLine("-------------------------");
            for (int i = 0; i < res.Length-1; i++)
            {
                Console.WriteLine(res[i]);
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("按回车键继续");
            Console.ReadLine();
            Console.Clear();
        }

        private void changePw()
        {
            Console.Write("输入管理员帐号：");
            string name = Console.ReadLine();
            Console.Write("输入当前密码：");
            string pwo = inputPw();
            AdminInfo adminOld = new AdminInfo(name, pwo, true);
            Console.WriteLine();

        input_pw:
            Console.Write("输入新的密码：");
            string pw1 = inputPw();
            Console.WriteLine();
            if (pw1.Length < 6)
            {
                Console.WriteLine("密码应该大于等于6位");
                goto input_pw;
            }
            Console.Write("确认密码：");
            string pw2 = inputPw();
            Console.WriteLine();
            if (!pw1.Equals(pw2))
            {
                Console.WriteLine("密码不一致，重新输入");
                goto input_pw;
            }
            AdminInfo adminNew = new AdminInfo(name,pw1,true);
            string msg = MyProtocol.head_updateAdminPw + 
                            resolveSpecStr(name) + "#" + resolveSpecStr(adminOld.getpw()) +
                            "#" + resolveSpecStr(adminNew.getpw());
            SendMsgSafe(msg);

            byte[] result = new byte[32];
            int len = mSocket.Receive(result);

            if (len <= MyProtocol.head_queryStuAll.Length)
                Console.WriteLine("未知结果");

            string mBuffer = Encoding.UTF8.GetString(result, 0, len).Substring(MyProtocol.head_updateAdminPw.Length);
            if (mBuffer.Equals(MyProtocol.body_success))
                Console.WriteLine("修改密码成功");
            else if (mBuffer.Equals(MyProtocol.body_denied))
                Console.WriteLine("修改失败,密码错误");
            Console.WriteLine("按回车键继续");
            Console.ReadLine();
            Console.Clear();

        }

        private void deleteAdmin()
        {
            Console.Write("输入管理员帐号：");
            string name = Console.ReadLine();
            SendMsgSafe(MyProtocol.head_deleteAdmin + resolveSpecStr(name));

            byte[] result = new byte[32];
            int len = mSocket.Receive(result);

            if (len <= MyProtocol.head_queryStuAll.Length)
                Console.WriteLine("未知结果");

            string mBuffer = Encoding.UTF8.GetString(result, 0, len).Substring(MyProtocol.head_deleteAdmin.Length);
            if (mBuffer.Equals(MyProtocol.body_success))
                Console.WriteLine("删除成功");
            else if (mBuffer.Equals(MyProtocol.body_notExists))
                Console.WriteLine("删除失败,用户名不存在");
            Console.WriteLine("按回车键继续");
            Console.ReadLine();
            Console.Clear();
        }

        //还原经过处理的特殊符号
        private string resumeSpecStr(string str)
        {
            return str.Replace("\\00", "/").Replace("\\01", "#").Replace("\\02", ",");
        }

        //处理特殊符号
        private string resolveSpecStr(string str)
        {
            return str.Replace("/", "\\00").Replace("#", "\\01").Replace(",", "\\02");
        }

        //密码输入
        private string inputPw()
        {
            ConsoleKeyInfo cki;
            string pw = "";
            while (true)
            {
                cki = Console.ReadKey(true);
                int a = (int)cki.Key;
                //响应退格键
                if (a == 8 && pw.Length > 0)
                {
                    pw = pw.Substring(0, pw.Length - 1);
                    Console.Write("\b \b");
                }

                //限制输入类型
                if ((a < 32 || a > 126) && a != 13)
                        continue;
                //响应回车键
                if (cki.Key == ConsoleKey.Enter)
                    break;
                Console.Write("*");
                pw += cki.KeyChar.ToString();
            }
            return pw;
        }

        public void SendMsgSafe(string buffer)
        {
            try
            {
                mSocket.Send(Encoding.UTF8.GetBytes(buffer));
            }
            catch
            {
                Console.WriteLine("网络已断开！", "连接失败");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
