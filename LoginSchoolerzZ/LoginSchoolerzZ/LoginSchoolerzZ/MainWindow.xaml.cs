﻿using System;
using System.Collections;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;

namespace LoginSchoolerzZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginManager manager;
        private ArrayList baseLogin = new();
        private ArrayList inputLogin = new();
        private Char[] letterOption = { 'S', 'P', 'T', 'A' };
        private String path = "../../../data/user_data.json";
        public MainWindow()
        {
            InitializeComponent();
            baseLogin.Add(UserTypeContainer);
            baseLogin.Add(ButtonNextContainer);

            inputLogin.Add(InputContainer);
            inputLogin.Add(ButtonLoginBackContainer);
            ReadData();
        }
        public void UserTypeSet(object sender, RoutedEventArgs e)
        {
            if (ComboboxUserType.SelectedItem is null)
            {
                MessageBox.Show("No puede estar vacío.");
                return;
            }
            foreach (StackPanel element in inputLogin)
            {
                element.Visibility = Visibility.Visible;
            }
            foreach (StackPanel element in baseLogin)
            {
                element.Visibility = Visibility.Collapsed;
            }
        }
        public void MakeLogin(object sender, RoutedEventArgs e)
        {
            String un = !String.IsNullOrEmpty(UserInput.Text.ToString()) ? UserInput.Text.ToString() : null;
            String pwd = !String.IsNullOrEmpty(PasswordInput.Password.ToString()) ? PasswordInput.Password.ToString() : null;
            if (un is null || pwd == null) return;
            remember(un, pwd);
            manager = new(letterOption[ComboboxUserType.SelectedIndex], un, GetMD5(pwd));
            if (manager.Login() == 0) MessageBox.Show("Dentro.");
            if (manager.Login() < 0) MessageBox.Show("Algo salió mal.");
        }
        public void Back(object sender, RoutedEventArgs e)
        {
            foreach (StackPanel element in baseLogin)
            {
                element.Visibility = Visibility.Visible;
            }
            foreach (StackPanel element in inputLogin)
            {
                element.Visibility = Visibility.Collapsed;
            }
        }
        public void EnterLogin(object sender, RoutedEventArgs e)
        {
            foreach (StackPanel element in baseLogin)
            {
                element.Visibility = Visibility.Visible;
            }

            StartContainer.Visibility = Visibility.Collapsed;
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ();
            byte[] stream = null;
            StringBuilder sb = new ();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public void remember(String username, String pwd)
        {
            using FileStream fs = File.Create(path);
            LivingPerson userdata = new LivingPerson { Username = username, Password = pwd, Recordar = (Boolean)RemembermeCheckbox.IsChecked, Role = ComboboxUserType.SelectedIndex };
            byte[] data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(userdata));
            fs.Write(data, 0, data.Length);
            fs.Close();
        }
        public void ReadData() 
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                LivingPerson data_recovered = Newtonsoft.Json.JsonConvert.DeserializeObject<LivingPerson>(json);
                try
                {
                    if (data_recovered.Recordar) 
                    {
                        UserInput.Text = data_recovered.Username;
                        PasswordInput.Password = data_recovered.Password;
                        RemembermeCheckbox.IsChecked = data_recovered.Recordar;
                        ComboboxUserType.SelectedIndex = data_recovered.Role;
                    }
                    r.Close();
                }
                catch (Exception e)
                {
                    r.Close();
                }
            }
        }
    }
}
