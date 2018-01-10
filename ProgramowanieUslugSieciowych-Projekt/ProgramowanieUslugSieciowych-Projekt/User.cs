using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieUslugSieciowych_Projekt
{
    public class User
    {
        private int userId;
        private string login;
        private string password;
        private List<User> friends;

        public User(string login, string password)
        {
            string[] stringTab = login.Split('@');
            this.userId = Int32.Parse(stringTab[0]);
            this.login = stringTab[1];
            this.password = password;
            friends = new List<User>();
        }


    }
}
