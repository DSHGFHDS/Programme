using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace FateServer
{
    class DataManageUtil
    {
        //数据库名字
        private string DB_NAME = "myIMS.db";

        private SQLiteConnection dbConnection;

        public DataManageUtil()
        {
            autoCreateDB();
            connectToDatabase();
            createTable();
        }

        //获取数据库名字
        public string getDBName() { return DB_NAME; }

        //自动创建一个空数据库（如果不存在的话）
        void autoCreateDB()
        {
            if (!File.Exists(DB_NAME))
                SQLiteConnection.CreateFile(DB_NAME);
        }

        //创建一个连接到指定数据库
        void connectToDatabase()
        {
            dbConnection = new SQLiteConnection("Data Source=" + DB_NAME + ";Version=3;");
            dbConnection.Open();
        }

        public void close()
        {
            //关闭数据库
            if (dbConnection != null)
                dbConnection.Close();
        }

        //在指定数据库中创学生和管理员table
        void createTable()
        {
            string sql_a = "create table if not exists admins(name varchar(20),pw varchar(20))";
            string sql_s = "create table if not exists students(sno varchar(15),sname varchar(20),ssex varchar(6)," +
                "sclass varchar(50))";
            SQLiteCommand command = new SQLiteCommand(sql_a, dbConnection);
            try
            {
                command.ExecuteNonQuery();
                command = new SQLiteCommand(sql_s, dbConnection);
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("数据库错误，删除数据库后重试");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        //查找学生信息
        public List<StuInfo> queryStudents(StuInfo.type type, string param)
        {
            string sql = "";
            //根据不同的类型编辑sql语句
            switch (type)
            {
                case StuInfo.type.sno:
                    sql = "select * from students where sno='" + param + "'";
                    break;
                case StuInfo.type.sname:
                    sql = "select * from students where sname='" + param + "'";
                    break;
                case StuInfo.type.ssex:
                    sql = "select * from students where ssex='" + param + "'";
                    break;
                case StuInfo.type.sclass:
                    sql = "select * from students where sclass='" + param + "'";
                    break;
            }

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            //装载结果的List
            List<StuInfo> stus = new List<StuInfo>();
            //读取所有结果
            while (reader.Read())
            {
                StuInfo stu = new StuInfo(reader["sno"].ToString(), reader["sname"].ToString(),
                    reader["ssex"].ToString(), reader["sclass"].ToString());
                stus.Add(stu);
            }
            return stus;
        }

        //按照id查找管理员信息
        public List<AdminInfo> queryAdmins(AdminInfo.type type, string param)
        {
            string sql = "";
            //根据不同的类型编辑sql语句
            switch (type)
            {
                case AdminInfo.type.name:
                    sql = "select * from admins where name='" + param + "'";
                    break;
                case AdminInfo.type.pw:
                    sql = "select * from admins where pw='" + param + "'";
                    break;
            }
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            //装载加结果的List
            List<AdminInfo> admins = new List<AdminInfo>();
            //读取所有结果
            while (reader.Read())
            {
                AdminInfo admin = new AdminInfo(reader["name"].ToString(), reader["pw"].ToString(), false);
                admins.Add(admin);
            }
            return admins;
        }

        //查询所有学生数据
        public List<StuInfo> queryAllStudents()
        {
            List<StuInfo> stus = new List<StuInfo>();
            string sql = "select * from students order by sno";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StuInfo stu = new StuInfo(reader["sno"].ToString(), reader["sname"].ToString(),
                    reader["ssex"].ToString(), reader["sclass"].ToString());
                stus.Add(stu);
            }
            return stus;
        }

        //查询所有管理员数据
        public List<AdminInfo> queryAllAdmin()
        {
            List<AdminInfo> admins = new List<AdminInfo>();
            string sql = "select * from admins order by name";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AdminInfo admin = new AdminInfo(reader["name"].ToString(), reader["pw"].ToString(), false);
                admins.Add(admin);
            }
            return admins;
        }

        //插入学生数据
        public void insertStuInfo(StuInfo stu)
        {
            String sql = "insert into students values('" + stu.getsno() + "','" + stu.getsname() + "','" +
                stu.getssex() + "','" + stu.getsclass() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        //插入管理员数据
        public void insertAdminInfo(AdminInfo admin)
        {
            string sql = "insert into admins values('" + admin.getname() + "','" + admin.getpw() + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        //按学号删除学生
        public void deleteStuInfo(string sno)
        {
            string sql = "delete from students where sno='" + sno + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        //按name删除管理员
        public void deleteAdminInfo(string name)
        {
            string sql = "delete from admins where name='" + name + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        //更新管理员密码(传过来的新密码为密文)
        public void updateAdminPw(string name, string newPw)
        {
            AdminInfo admin = new AdminInfo(name, newPw, false);
            string sql = "update admins set pw='" + admin.getpw() + "' where name='" + admin.getname() + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        //判断学号是否存在
        public bool isSnoExists(string sno)
        {
            string sql = "select sno from students where sno='" + sno + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            //如果可以读取到数据，说明已存在，返回true
            if (reader.Read())
                return true;
            //读取不到说明不存在，返回false
            return false;
        }

        //判断管理员名称是否已存在
        public bool isAdminNameExists(string name)
        {
            string sql = "select name from admins where name='" + name + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            //如果可以读取到数据，说明已存在，返回true
            if (reader.Read())
                return true;
            //读取不到说明不存在，返回false
            return false;
        }

        //判断是否有任何管理员
        public bool hasAdmin()
        {
            string sql = "select name from admins";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return true;
            return false;
        }
    }
}
