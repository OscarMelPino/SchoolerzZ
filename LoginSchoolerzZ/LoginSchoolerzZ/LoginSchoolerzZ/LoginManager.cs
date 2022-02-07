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
    public class LoginManager : INotifyPropertyChanged
    {
        private DatabaseConnection schoolerz = new();

        public event PropertyChangedEventHandler PropertyChanged;

        private int ancho;
        private int alto;
        private String Username { get ; set;}
        private String Password { get; set; }
        public int Width
        {
            get => ancho;
            set
            {
                ancho = value;
                OnPropertyChanged("Width");
            }
        }
        public int Height { get => alto; set { alto = value;OnPropertyChanged("Height");}}
        public LoginManager()
        { 
            schoolerz = new();
            ancho = 1000;
            alto = 650;
        }
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
        public void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
