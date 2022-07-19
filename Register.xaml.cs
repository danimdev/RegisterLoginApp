using System;
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
using System.Windows.Shapes;

namespace RegisterLoginApp
{
    
    public partial class Register : Window
    {
        RegisterLoginManager rlm = new();

        public Register()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).registerWindow.Hide();
        }

        private void SubmitRegiserButton(object sender, RoutedEventArgs e)
        {
            if (!rlm.RegisterAndWriteToFile(UsernameTextbox.Text, PasswordBox.Password))
            {
                MessageBox.Show("Method didnt worked");
            }
            else
            {
                base.Hide();
                MessageBox.Show("It worked");
            }
        }
    }
}
