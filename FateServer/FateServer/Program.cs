using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FateServer
{
    class Program
    {
        private static Socket fateServer;
        private static int prot = 6666;
        private static string ipAdd = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        private DataManageUtil dataManager = new DataManageUtil();
        private ClientsMgr clientMgr = new ClientsMgr();


        static void Main(string[] args)
        {
            Program program = new Program();
            IPAddress ip = IPAddress.Parse(ipAdd);
            fateServer = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            fateServer.Bind(new IPEndPoint(ip,prot));
            fateServer.Listen(10);
            Thread myThread = new Thread(program.ClientListener);
            myThread.Start();
            Console.WriteLine(String.Format("server launched ip:{0}  prot:{1}", ipAdd, prot));
        }

        //监听客户端的连接
        private void ClientListener()
        {
            while (true)
            {
                Socket clientSocket = fateServer.Accept();
                //clientSocket.Send(Encoding.UTF8.GetBytes("#connected"));
                Console.WriteLine("find a client:" + clientSocket.RemoteEndPoint.ToString());
                //添加到客户端管理类的socket列表
                clientMgr.addSocket(clientSocket);
                //新建命令监听线程
                Thread receiveThread = new Thread(ReceiveMsg);
                receiveThread.Start(clientSocket);
            }
        }

        //接收消息
        private void ReceiveMsg(object clientSocket)
        {
            Socket mSocket = (Socket)clientSocket;
            MsgResolver msgResolver = new MsgResolver(dataManager, mSocket,clientMgr);
            string clientIP = mSocket.RemoteEndPoint.ToString();
            while (true)
            {
                try
                {
                    byte[] result = new byte[1024];
                    int receiveNumber = mSocket.Receive(result);
                    string msg = Encoding.UTF8.GetString(result,0,receiveNumber);
                    if (msg.Length <= 0)
                        throw new Exception("客户端异常中止");
                    msg = msg.Substring(msg.IndexOf('#'));
                    Console.WriteLine(String.Format("client:{0} command:{1}",clientIP,msg));
                    //将命令交给消息处理类进行处理
                    msgResolver.resolveMsg(msg);
                }
                catch(Exception e)
                {
                    clientMgr.removeClientByIP(clientIP);
                    Console.WriteLine(string.Format("{0} closed ({1})", clientIP, e.Message));
                    break;
                }
            }
        }
    }
}
