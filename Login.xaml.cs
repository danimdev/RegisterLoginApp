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
            if(CheckLoginUsername("data.enc") && HashLoginPasswordAndCheckForRightOne("data.enc"))
            {
                MessageBox.Show("Login Successfull");
            }
            base.Close();
        }

        bool CheckLoginUsername(string fileName)
        {
            try
            {
                string usernameString = LoginUsernameTextBox.Text;

                SHA512 hashUsername = SHA512.Create();

                byte[] hashedUsername = hashUsername.ComputeHash(Encoding.UTF8.GetBytes(usernameString));

                using (StreamReader CheckForUsernameInFile = new(fileName))
                {
                    string HashedUsernameFromFile = File.ReadLines(fileName).Skip(1).Take(1).First();

                    string loginUsernameToCheck = "";

                    for (int i = 0; i< hashedUsername.Length; i++)
                    {

                        loginUsernameToCheck += hashedUsername.GetValue(i).ToString();
                    }

                    if(string.Equals(HashedUsernameFromFile,loginUsernameToCheck))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return false;
        }

        bool HashLoginPasswordAndCheckForRightOne(string fileName)
        {
            string passwordString = LoginPasswordBox.Password;

            SHA512 hashPassword = SHA512.Create();

            byte[] hashedPassword = hashPassword.ComputeHash(Encoding.UTF8.GetBytes(passwordString));

            using (StreamReader readPasswordFromFile = new(fileName))
            {
                string hashedPasswordFromFile = readPasswordFromFile.ReadLine();


                string loginPasswordToCheck = "";
                for (int i = 0; i < hashedPassword.Length; i++)
                {
                    loginPasswordToCheck += hashedPassword.GetValue(i).ToString();
                }

                if (string.Equals(loginPasswordToCheck, hashedPasswordFromFile))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
