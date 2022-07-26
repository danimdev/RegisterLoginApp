using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegisterLoginApp
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        void SubmitAndCheckPassword(object sender, RoutedEventArgs e)
        {
            string passwordString = LoginPasswordBox.Password;

            SHA512 hashPassword = SHA512.Create();

            byte[] hashedPassword = hashPassword.ComputeHash(Encoding.UTF8.GetBytes(passwordString));

            using (StreamReader readPasswordFromFile = new("data.enc"))
            {
                string hashedPasswordFromFile = readPasswordFromFile.ReadLine();


                string loginPasswordToCheck = "";
                for (int i = 0; i < hashedPassword.Length; i++)
                {
                    loginPasswordToCheck += hashedPassword.GetValue(i).ToString();
                }

                if(string.Equals(loginPasswordToCheck,hashedPasswordFromFile))
                {
                    MessageBox.Show("Login Successfull");
                }
            }
        }
    }
}
