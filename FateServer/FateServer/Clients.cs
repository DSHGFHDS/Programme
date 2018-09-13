using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateServer
{
    class Clients
    {
        private bool isLogin = false;
        private string ip = "";
        private string id = "";

        public Clients() { }

        public Clients(string ip, string id,bool isLogin)
        {
            this.ip = ip;
            this.id = id;
            this.isLogin = isLogin;
        }

        public void setIP(string ip)
        {
            this.ip = ip;
        }

        public void setID(string id)
        {
            this.id = id;
        }

        public string getIP()
        {
            return this.ip;
        }

        public string getID()
        {
            return this.id;
        }

        public void setLogin(bool isLogin)
        {
            this.isLogin = isLogin;
        }

        public bool getLogin()
        {
            return this.isLogin;
        }
    }
}
