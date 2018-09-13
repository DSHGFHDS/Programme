using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSystem
{
    public class StuInfo
    {
        //学号
        private string sno;
        //姓名
        private string sname;
        //性别
        private string ssex;
        //班级
        private string sclass;

        //用于查找数据是表示参数传入的类型
        public enum type : int
        {
            sno = 1,
            sname = 2,
            ssex = 3,
            sclass = 4
        };

        public StuInfo()
        {
        }

        public StuInfo(String sno, string sname, string ssex, string sclass)
        {
            this.sno = sno;
            this.sname = sname;
            this.ssex = ssex;
            this.sclass = sclass;
        }

        public void setsno(string sno) { this.sno = sno; }
        public void setsname(string sname) { this.sname = sname; }
        public void setssex(string ssex) { this.ssex = ssex; }
        public void setsclass(string sclass) { this.sclass = sclass; }

        public string getsno() { return this.sno; }
        public string getsname() { return this.sname; }
        public string getssex() { return this.ssex; }
        public string getsclass() { return sclass; }
    }
}
