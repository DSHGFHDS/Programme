using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace adminMgr
{
    class AdminInfo
    {
        //用户名
        private string name;
        //密码
        private string pw;

        //用于查找数据是表示参数传入的类型
        public enum type : int
        {
            name = 1,
            pw = 2
        };

        public AdminInfo()
        {
        }

        public AdminInfo(string name, string pw, bool isCryptic)
        {
            this.name = name;
            //是否加密
            if (isCryptic)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(pw);
                string tmp = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(bytes));
                tmp = name + tmp;
                bytes = System.Text.Encoding.UTF8.GetBytes(tmp);
                tmp = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(bytes));
                this.pw = tmp;
            }
            else
                this.pw = pw;

        }

        public void setname(string name) { this.name = name; }
        public void setpw(string pw) { this.pw = pw; }

        public string getname() { return this.name; }
        public string getpw() { return this.pw; }
    }
}
