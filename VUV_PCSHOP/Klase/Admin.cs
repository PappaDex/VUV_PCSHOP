using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_PCSHOP
{
     class Admin
    {
        protected string username;
        protected string password;
       public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        Admin()
        {
        }
         public string Username
        {
            get { return username; }
        }
        public string Password
        {
            get { return password; }
        }
    }
}
