using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LoginSchoolerzZ
{
    public class LoginManager 
    {
        public String Username { get ; set;}
        public String Password { get; set; }
        public LoginManager(){ }
        public LoginManager(char userType, String username, String pwd )
        {
            Username = userType + username;
            Password = pwd;
        }
    }
}
