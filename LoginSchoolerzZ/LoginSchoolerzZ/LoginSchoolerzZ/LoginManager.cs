using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginSchoolerzZ
{
    public class LoginManager 
    {
        private DatabaseConnection schoolerz = new();

        private String Username { get ; set;}
        private String Password { get; set; }
        public LoginManager(){ schoolerz = new(); }
        public LoginManager(char userType, String username, String pwd )
        {
            Username = userType + username;
            Password = pwd;
            schoolerz = new();
        }
        public int Login()
        {
            return schoolerz.TryLogin(Username, Password);
        }
    }
}
