using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.IO;
using System.Text.Json;

namespace LoginSchoolerzZ
{
    //Title="MainWindow" Width="{Binding Width, Mode=TwoWay}" Height="{Binding Height, Mode=TwoWay}">
    //Title="MainWindow" Width="1000" Height="650">
    public class LoginManager : INotifyPropertyChanged
    {
        private DatabaseConnection schoolerz = new();

        public event PropertyChangedEventHandler PropertyChanged;

        private MediaPlayer mpSFX = new();
        private string[] SFX = { "Media/Sounds/StandardClick.wav", "Media/Sounds/OptionalClick1.wav", "Media/Sounds/OptionalClick2.wav" };
        private int ancho;
        private int alto;
        private int volumen;
        private int track;
        public int Volume { get => volumen; set { volumen = value; OnPropertyChanged("Volume");}}
        public int Track { get => track; set { track = value; OnPropertyChanged("Track");}}
        private String Username { get ; set; } 
        private String Password { get; set; }
        public int Width { get => ancho; set { ancho = value; OnPropertyChanged("Width");}}
        public int Height { get => alto; set { alto = value; OnPropertyChanged("Height");}}
        public LoginManager()
        { 
            schoolerz = new();
            Track = int.Parse(ConfigurationManager.AppSettings["track"]) - 1;
            Volume = int.Parse(ConfigurationManager.AppSettings["master_volume"]);
            mpSFX.Open(new Uri(SFX[Track], UriKind.Relative));
            ChangeVolume();
        }
        public LoginManager(char userType, String username, String pwd, int track )
        {
            Username = userType + username;
            Password = pwd;
            schoolerz = new();
            Track = track;
            Track = int.Parse(ConfigurationManager.AppSettings["track"]) - 1 ;
            Volume = int.Parse(ConfigurationManager.AppSettings["master_volume"]);
            mpSFX.Open(new Uri(SFX[Track], UriKind.Relative));
            ChangeVolume();
            ConfigurationManager.AppSettings["track"] = "1";
        }
        public int Login()
        {
            return schoolerz.TryLogin(Username, Password);
        }
        public void Play()
        {
            mpSFX.Stop();
            ChangeVolume();
            mpSFX.Play();
        }
        public void ChangeSFX(int option)
        {
            if (option > 3 || option < 0) return;
            if (option == 1)
            {
                Track = option - 1 ;
                mpSFX.Open(new Uri(SFX[Track], UriKind.Relative));
                return;
            }
            if (option == 2)
            {
                Track = option - 1;
                mpSFX.Open(new Uri(SFX[Track], UriKind.Relative));
                return;
            }
            Track = option - 1;
            mpSFX.Open(new Uri(SFX[Track], UriKind.Relative));
        }

        public void ChangeVolume()
        {
            switch (Volume)
            {
                case 10:
                    mpSFX.Volume = 1;
                    break;
                case 9:
                    mpSFX.Volume = 0.9;
                    break;
                case 8:
                    mpSFX.Volume = 0.8;
                    break;
                case 7:
                    mpSFX.Volume = 0.7;
                    break;
                case 6:
                    mpSFX.Volume = 0.6;
                    break;
                case 5:
                    mpSFX.Volume = 0.5;
                    break;
                case 4:
                    mpSFX.Volume = 0.4;
                    break;
                case 3:
                    mpSFX.Volume = 0.3;
                    break;
                case 2:
                    mpSFX.Volume = 0.2;
                    break;
                case 1:
                    mpSFX.Volume = 0.1;
                    break;
                case 0:
                    mpSFX.Volume = 0;
                    break;
                default:
                    mpSFX.Volume = 0;
                    break;
            }
        }

        public void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void UpdateConfig()
        {
            using FileStream fs = File.Create("../../../config.json");
            Config user_config = new Config { MasterVolume = Volume, LastTrack = Track, HeighResolution = Height, WidthResolution = Width};
            byte[] data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(user_config));
            fs.Write(data, 0, data.Length);
            fs.Close();
        }
    }
}
