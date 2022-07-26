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
            try
            {
                SHA512 hashPassword = SHA512.Create();

                byte[] hashedPassword = hashPassword.ComputeHash(Encoding.UTF8.GetBytes(PasswordBox.Password));

                using(StreamWriter writePwToFile = new(file))
                {
                    writePwToFile.WriteLine(PasswordBox.Password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.Hide();
        }
    }
}
