using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace RegisterLoginApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Register? registerWindow;
        public Login? loginWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton(object sender, RoutedEventArgs e)
        {
            if(registerWindow == null)
            {
                registerWindow = new Register();
                registerWindow.Closed += RegisterwindowClosed;
                registerWindow.Show();
            }
            else
            {
                registerWindow.Activate();
            }
        }

        private void RegisterwindowClosed(object? sender, EventArgs e)
        {
            registerWindow = null;
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            if (loginWindow == null)
            {
                loginWindow = new Login();
                loginWindow.Closed += LoginWindowClosed; ;
                loginWindow.Show();
            }
            else
            {
                loginWindow.Activate();
            }
        }

        private void LoginWindowClosed(object? sender, EventArgs e)
        {
            loginWindow = null;
        }
    }
}
