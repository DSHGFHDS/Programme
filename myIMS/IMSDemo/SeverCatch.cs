using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
namespace InSystem
{
    public class SeverCatch
    {
        public Socket mClient;
        public SeverCatch(Socket Client)
        {
            mClient = Client;
        }
        public bool IsMarched(string name, string pw)
        {
            AdminInfo admin = new AdminInfo(name, pw, true);
            string SendBuffer = MyProtocol.head_login + resolveSpecStr(name) + "#" + resolveSpecStr(admin.getpw());
            if (!SendMsgSafe(SendBuffer))
                return false;

            byte[] result = new byte[64];
            int len = mClient.Receive(result);

            string buffer = Encoding.UTF8.GetString(result, 0, len);

            if (buffer.StartsWith(MyProtocol.head_login) && buffer.Substring(MyProtocol.head_login.Length).Equals(MyProtocol.body_true))
                return true;

            return false;
        }

        public List<StuInfo> Search(int selectedIndex, string buffer)
        {
            string SendBuffer = MyProtocol.head_queryStu + (selectedIndex+1).ToString() + "#" + resolveSpecStr(buffer);
            if (!SendMsgSafe(SendBuffer))
                return null;

            byte[] result = new byte[2048];
            int len = mClient.Receive(result);

            if (len <= MyProtocol.head_queryStu.Length)
                return null;

            string mBuffer = Encoding.UTF8.GetString(result, 0, len).Substring(MyProtocol.head_queryStu.Length);

            List<StuInfo> stus = new List<StuInfo>();
            string[] str = mBuffer.Split('/');
            string[] strTmp;
            for (int i = 0; i < str.Length - 1;i++)
            {
                strTmp = str[i].Split(',');
                stus.Add(new StuInfo(resumeSpecStr(strTmp[0]), resumeSpecStr(strTmp[1]),
                                resumeSpecStr(strTmp[2]), resumeSpecStr(strTmp[3])));
            }

                return stus;
        }

        public bool Add(string sID, string sName, string sSex, string sClass)
        {
            string SendBuffer = MyProtocol.head_insertStu + resolveSpecStr(sID) + "#" +
                        resolveSpecStr(sName) + "#" + resolveSpecStr(sSex) + "#" + resolveSpecStr(sClass);
            if (!SendMsgSafe(SendBuffer))
                return false;

            byte[] result = new byte[256];
            int len = mClient.Receive(result);
            string buffer = Encoding.UTF8.GetString(result, 0, len);
            if (buffer.StartsWith(MyProtocol.head_insertStu) && buffer.Substring(MyProtocol.head_insertStu.Length).Equals(MyProtocol.body_success))
                return true;

            return false;
        }

        public bool Delete(string SID)
        {
            string SendBuffer = MyProtocol.head_deleteStu + resolveSpecStr(SID);
            if (!SendMsgSafe(SendBuffer))
                return false;

            byte[] result = new byte[64];
            int len = mClient.Receive(result);
            string buffer = Encoding.UTF8.GetString(result, 0, len);
            if (buffer.StartsWith(MyProtocol.head_deleteStu) && buffer.Substring(MyProtocol.head_deleteStu.Length).Equals(MyProtocol.body_success))
                return true;

            return false;
        }

        //查询所有学生
        public List<StuInfo> queryAllStu()
        {
            string SendBuffer = MyProtocol.head_queryStuAll;
            if (!SendMsgSafe(SendBuffer))
                return null;

            byte[] result = new byte[2048];
            int len = mClient.Receive(result);

            string mBuffer = Encoding.UTF8.GetString(result, 0, len);

            if (mBuffer.StartsWith(MyProtocol.head_unlogin))
                return null;
            if (mBuffer.Length <= MyProtocol.head_queryStu.Length)
                return null;

            mBuffer = mBuffer.Substring(MyProtocol.head_queryStuAll.Length);

            List<StuInfo> stus = new List<StuInfo>();
            string[] str = mBuffer.Split('/');
            string[] strTmp;
            for (int i = 0; i < str.Length - 1; i++)
            {
                strTmp = str[i].Split(',');
                stus.Add(new StuInfo(resumeSpecStr(strTmp[0]), resumeSpecStr(strTmp[1]),
                                resumeSpecStr(strTmp[2]), resumeSpecStr(strTmp[3])));
            }

            return stus;
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

        public bool SendMsgSafe(string buffer)
        {
            try
            {
                mClient.Send(Encoding.UTF8.GetBytes(buffer));
                return true;
            }
            catch
            {
                MessageBox.Show("网络已断开！", "连接失败");
                Application.Exit();
                //Environment.Exit(0);
                return false;
            }
        }
    }
}
