using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
    
    public partial class Register : Window
    {
        string file = "data.enc";

        public Register()
        {
            InitializeComponent();
        }

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    base.OnClosing(e);
        //    e.Cancel = true;
        //    this.Hide();
        //}

        private void SubmitRegiserButton(object sender, RoutedEventArgs e)
        {
            HashPasswordAndWriteToFile("data.enc");
            HashUsernameAndWriteToFile("data.enc");

            base.Close();
        }

        void HashUsernameAndWriteToFile(string fileName)
        {
            try
            {
                string usernameString = UsernameTextbox.Text;

                SHA512 hashUsername = SHA512.Create();

                byte[] hashedUsername = hashUsername.ComputeHash(Encoding.UTF8.GetBytes(usernameString));
                
                using(StreamWriter writeUsernameToFile = new(fileName,true))
                {
                    writeUsernameToFile.WriteLine("");
                    
                    for(int i = 0; i < hashedUsername.Length ; i++)
                    {
                        writeUsernameToFile.Write(hashedUsername.GetValue(i));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void HashPasswordAndWriteToFile(string fileName)
        {
            try
            {
                string passwordString = PasswordBox.Password;

                SHA512 hashPassword = SHA512.Create();

                byte[] hashedPassword = hashPassword.ComputeHash(Encoding.UTF8.GetBytes(passwordString));

                using (StreamWriter writePwToFile = new(file))
                {
                    for (int i = 0; i < hashedPassword.Length; i++)
                    {
                        writePwToFile.Write(hashedPassword.GetValue(i));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
