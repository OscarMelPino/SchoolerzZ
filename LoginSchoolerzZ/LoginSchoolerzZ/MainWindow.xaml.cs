using System;
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
        public MainWindow()
        {
            InitializeComponent();
            baseLogin.Add(UserTypeContainer);
            baseLogin.Add(ButtonNextContainer);

            inputLogin.Add(InputContainer);
            inputLogin.Add(ButtonLoginBackContainer);
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
            if ((bool)RemembermeCheckbox.IsChecked) remember(un, pwd);
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
            var fileName = "user_data.json";
            var path = "/Users/admin-dam2b/Desktop/SchoolerzZ/LoginSchoolerzZ/LoginSchoolerzZ/" + fileName;
            LivingPerson userdata = new LivingPerson { Username = username, Password = pwd };
            var jsondata = JsonSerializer.Serialize(userdata);

            // PETA, DICE QUE NO SE PUEDE ACCEDER A LA RUTA: C\user_data.
            using FileStream fs = File.Create(path);
        }
    }
}

