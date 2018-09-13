using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FateServer
{
    class MsgResolver
    {
        private DataManageUtil mDataManager;
        private Socket mSocket;
        private ClientsMgr mClientsMgr;

        public MsgResolver(DataManageUtil dataManager,Socket socket,ClientsMgr clientsMgr)
        {
            this.mDataManager = dataManager;
            this.mSocket = socket;
            this.mClientsMgr = clientsMgr;
        }

        public void resolveMsg(string msg)
        {
            if (msg.StartsWith(MyProtocol.head_queryStu))
                queryStu(msg.Substring(MyProtocol.head_queryStu.Length));
            else if (msg.StartsWith(MyProtocol.head_queryStuAll))
                queryStuAll();
            else if (msg.StartsWith(MyProtocol.head_login))
                login(msg.Substring(MyProtocol.head_login.Length));
            else if (msg.StartsWith(MyProtocol.head_insertStu))
                insertStu(msg.Substring(MyProtocol.head_insertStu.Length));
            else if (msg.StartsWith(MyProtocol.head_insertAdmin))
                insertAdmin(msg.Substring(MyProtocol.head_insertAdmin.Length));
            else if (msg.StartsWith(MyProtocol.head_deleteStu))
                deleteStu(msg.Substring(MyProtocol.head_deleteStu.Length));
            else if (msg.StartsWith(MyProtocol.head_deleteAdmin))
                deleteAdmin(msg.Substring(MyProtocol.head_deleteAdmin.Length));
            else if (msg.StartsWith(MyProtocol.head_updateAdminPw))
                updateAdminPw(msg.Substring(MyProtocol.head_updateAdminPw.Length));
            else if (msg.StartsWith(MyProtocol.head_request_offline))
                requestOffline(msg.Substring(MyProtocol.head_request_offline.Length));
            else if (msg.StartsWith(MyProtocol.head_queryAdminAll))
                queryAdminAll();
        }

        private bool isLegal(string ip)
        {
            Clients client = mClientsMgr.getClientByIP(ip);
            if (client == null || client.getLogin() == false)
                return false;
            return true;
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

        //处理学生查询命令
        private void queryStu(string msg)
        {
            //判断是否登录
            if (!isLegal(mSocket.RemoteEndPoint.ToString()))
            {
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_unlogin));
                return;
            }
            string[] args = msg.Split('#');
            List<StuInfo> resStu = null;
            //分类查询信息
            switch (int.Parse(args[0]))
            {
                case (int)StuInfo.type.sno:
                    resStu = mDataManager.queryStudents(StuInfo.type.sno, resumeSpecStr(args[1]));
                    break;
                case (int)StuInfo.type.sname:
                    resStu = mDataManager.queryStudents(StuInfo.type.sname, resumeSpecStr(args[1]));
                    break;
                case (int)StuInfo.type.ssex:
                    resStu = mDataManager.queryStudents(StuInfo.type.ssex, resumeSpecStr(args[1]));
                    break;
                case (int)StuInfo.type.sclass:
                    resStu = mDataManager.queryStudents(StuInfo.type.sclass, resumeSpecStr(args[1]));
                    break;
            }
            if (resStu == null)
                return;
            //向客户端返回数据
            string strTmp = "";
            for(int i=0;i<resStu.Count;i++)
            {
                strTmp += string.Format("{0},{1},{2},{3}/",
                    resolveSpecStr(resStu[i].getsno()),resolveSpecStr(resStu[i].getsname()),
                    resolveSpecStr(resStu[i].getssex()),resolveSpecStr(resStu[i].getsclass()));
            }
            string str = MyProtocol.head_queryStu + strTmp;
            mSocket.Send(Encoding.UTF8.GetBytes(str));
        }

        //处理学生查询全部学生命令
        private void queryStuAll()
        {
            //判断是否登录
            if (!isLegal(mSocket.RemoteEndPoint.ToString()))
            {
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_unlogin));
                return;
            }
            List<StuInfo> resStu = null;
            //获取所有数据
            resStu = mDataManager.queryAllStudents();
            if (resStu == null)
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_queryStuAll)); ;
            //向客户端返回数据
            string str = MyProtocol.head_queryStuAll;
            for (int i = 0; i < resStu.Count; i++)
            {
                str += string.Format("{0},{1},{2},{3}/",
                    resolveSpecStr(resStu[i].getsno()), resolveSpecStr(resStu[i].getsname()),
                    resolveSpecStr(resStu[i].getssex()), resolveSpecStr(resStu[i].getsclass()));
            }
            mSocket.Send(Encoding.UTF8.GetBytes(str));
        }

        //查询全部管理员
        private void queryAdminAll()
        {
            List<AdminInfo> resAdmin = null;
            //获取所有数据
            resAdmin = mDataManager.queryAllAdmin();
            if (resAdmin == null)
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_queryAdminAll));
            //向客户端返回数据
            string str = MyProtocol.head_queryAdminAll;
            for (int i = 0; i < resAdmin.Count; i++)
            {
                str += string.Format("{0},",
                    resolveSpecStr(resAdmin[i].getname()));
            }
            mSocket.Send(Encoding.UTF8.GetBytes(str));
        }

        //返回登录结果
        private void login(string msg)
        {
            //分析参数
            string[] args = msg.Split('#');
            args[0] = resumeSpecStr(args[0]);
            args[1] = resumeSpecStr(args[1]);
            //如果该帐号已在其他地方登录则下线之前的登录
            Clients client = mClientsMgr.getClientByID(args[0]);
            if (client != null && !client.getIP().Equals(mSocket.RemoteEndPoint.ToString()))
            {

                //获取之前登录的连接
                Socket socket = mClientsMgr.getSocketByIP(client.getIP());
                //如果socket为空，说明连接已失效，在客户端管理类中做出清理，并继续登录
                if (socket == null)
                    mClientsMgr.removeClientByID(args[0]);
                else //socket不为空，则下线之前登录
                {
                    //发送下线信息
                    socket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_new_login));

                    Console.WriteLine(socket.RemoteEndPoint.ToString() + " offline");

                    //关闭连接
                    mClientsMgr.closeSocketByIP(socket.RemoteEndPoint.ToString());
                    //从管理类移除客户端
                    mClientsMgr.removeClientByIP(client.getIP());
                }
            }
            //查询对应管理员
            List<AdminInfo> admin = mDataManager.queryAdmins(AdminInfo.type.name, args[0]);
            //比对信息并返回结果
            if (admin.Count <= 0 || !admin[0].getpw().Equals(args[1])) 
            {
                //登录失败
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_login + MyProtocol.body_false));
                Console.WriteLine(string.Format("{0}({1}) login denied",
                            mSocket.RemoteEndPoint.ToString(), args[0]));
                return;
            }
            //登录成功
            mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_login + MyProtocol.body_true));
            //添加到管理类
            mClientsMgr.addClient(new Clients(mSocket.RemoteEndPoint.ToString(),args[0],true));
            Console.WriteLine(string.Format("{0}({1}) login success",
                            mSocket.RemoteEndPoint.ToString(), args[0]));
        }

        //插入学生信息
        private void insertStu(string msg)
        {
            //判断是否登录
            if (!isLegal(mSocket.RemoteEndPoint.ToString()))
            {
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_unlogin));
                return;
            }
            string[] args = msg.Split('#');
            StuInfo stu = new StuInfo(resumeSpecStr(args[0]), resumeSpecStr(args[1]), 
                                        resumeSpecStr(args[2]), resumeSpecStr(args[3]));
            if(mDataManager.isSnoExists(stu.getsno()))
            {
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_insertStu + MyProtocol.body_exists));
                Console.WriteLine("insert denied(exist):" + stu.getsname());
                return;
            }
            //添加
            mDataManager.insertStuInfo(stu);
            //发送成功消息
            mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_insertStu + MyProtocol.body_success));
            Console.WriteLine("insert a student:" + stu.getsname());
        }

        //插入管理员信息
        private void insertAdmin(string msg)
        {
            string[] args = msg.Split('#');
            AdminInfo admin = new AdminInfo(resumeSpecStr(args[0]), resumeSpecStr(args[1]), false);
            //如果管理员已存在则返回已存在消息
            if(mDataManager.isAdminNameExists(resumeSpecStr(args[0])))
            {
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_insertAdmin + MyProtocol.body_exists));
                Console.WriteLine("insert denied(exist):" + admin.getname());
                return;
            }
            //插入
            mDataManager.insertAdminInfo(admin);
            //发送成功消息
            mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_insertAdmin + MyProtocol.body_success));
            Console.WriteLine("insert an administrator:" + admin.getname());
        }

        //删除学生信息
        private void deleteStu(string msg)
        {
            //判断是否登录
            if (!isLegal(mSocket.RemoteEndPoint.ToString()))
            {
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_unlogin));
                return;
            }
            string sno =  string.Copy(msg);
            //如果不存在，则返回相应信息
            if (!mDataManager.isSnoExists(resumeSpecStr(sno)))
            {
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_deleteStu + MyProtocol.body_notExists));
                Console.WriteLine("delete failed(not found):" + sno);
                return;
            }
            mDataManager.deleteStuInfo(resumeSpecStr(sno));
            //发送成功消息
            mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_deleteStu + MyProtocol.body_success));
            Console.WriteLine("delete a student:" + sno);
        }

        //删除管理员信息
        private void deleteAdmin(string msg)
        {
            string name = string.Copy(msg);
            //如果不存在，则返回相应信息
            if (!mDataManager.isAdminNameExists(resumeSpecStr(name)))
            {
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_deleteAdmin + MyProtocol.body_notExists));
                Console.WriteLine("delete failed(not found):" + name);
                return;
            }
            mDataManager.deleteAdminInfo(resumeSpecStr(name));
            //发送成功消息
            mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_deleteAdmin + MyProtocol.body_success));
            Console.WriteLine("delete an administrator:" + name);
        }

        //更新管理员密码
        private void updateAdminPw(string msg)
        {
            //分析参数
            string[] args = msg.Split('#');
            //查询对应管理员
            List<AdminInfo> admin = mDataManager.queryAdmins(AdminInfo.type.name, resumeSpecStr(args[0]));
            //比对信息并返回结果
            if (admin.Count <= 0 || !admin[0].getpw().Equals(resumeSpecStr(args[1])))
            {
                //失败
                mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_updateAdminPw + MyProtocol.body_denied));
                Console.WriteLine(string.Format("{0}({1}) update pw denied",
                            mSocket.RemoteEndPoint.ToString(), args[0]));
                return;
            }
            //成功
            mDataManager.updateAdminPw(resumeSpecStr(args[0]), resumeSpecStr(args[2]));
            mSocket.Send(Encoding.UTF8.GetBytes(MyProtocol.head_updateAdminPw + MyProtocol.body_success));
            Console.WriteLine(string.Format("{0}({1}) update pw success",
                            mSocket.RemoteEndPoint.ToString(), args[0]));
        }

        //要求客户端下线
        private void requestOffline(string msg)
        {
            Clients client = mClientsMgr.getClientByIP(mSocket.RemoteEndPoint.ToString());
            string ip = mSocket.RemoteEndPoint.ToString();
            //如果ip和帐号对应则做出下线操作
            if (client != null && client.getID().Equals(msg))
            {
                mClientsMgr.removeClientByID(msg);
                mClientsMgr.closeSocketByIP(ip);
                Console.WriteLine(string.Format("{0}({1}) is offline",ip,msg));
            }
            //ip和帐号不匹配则下线失败
            Console.WriteLine(string.Format("{0}({1}) offline failed", ip, msg));
        }
    }
}
