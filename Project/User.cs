using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string fullName;
        private int type;
        public User()
        {

        }
        public User(int id, string username, string fullName, int type)
        {
            this.Id = id;
            this.Username = username;
            this.FullName = fullName;
            this.Type = type;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int Type { get => type; set => type = value; }
    }
}