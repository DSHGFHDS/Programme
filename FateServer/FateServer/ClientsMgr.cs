using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FateServer
{
    class ClientsMgr
    {
        private List<Clients> cList = new List<Clients>();
        private List<Socket> cSocket = new List<Socket>();

        public ClientsMgr() { }


        public void addClient(Clients client)
        {
            cList.Add(client);
        }

        public Clients getClientByIP(string ip)
        {
            for (int i = 0; i < cList.Count; i++)
            {
                if (cList[i].getIP().Equals(ip))
                    return cList[i];
            }
            return null;
        }

        public Clients getClientByID(string id)
        {
            for (int i = 0; i < cList.Count; i++)
            {
                if (cList[i].getID().Equals(id))
                    return cList[i];
            }
            return null;
        }

        public void removeClientByIP(string ip)
        {
            for (int i = 0; i < cList.Count; i++)
            {
                if (cList[i].getIP().Equals(ip))
                    cList.Remove(cList[i]);
            }
        }

        public void removeClientByID(string id)
        {
            for (int i = 0; i < cList.Count; i++)
            {
                if (cList[i].getID().Equals(id))
                    cList.Remove(cList[i]);
            }
        }

        public void addSocket(Socket socket)
        {
            this.cSocket.Add(socket);
        }

        //获取连接
        public Socket getSocketByIP(string ip)
        {
            for (int i = 0; i < cSocket.Count; i++)
            {
                if (cSocket[i].RemoteEndPoint.ToString().Equals(ip))
                {
                    return cSocket[i];
                }
            }
            return null;
        }

        //关闭连接
        public void closeSocketByIP(string ip)
        {
            for (int i = 0; i < cSocket.Count; i++)
            {
                if (cSocket[i].RemoteEndPoint.ToString().Equals(ip))
                {
                    cSocket[i].Close();
                    cSocket[i] = null;
                    cSocket.Remove(cSocket[i]);
                }
            }
        }
    }
}
