using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Threading;

namespace RegisterLoginApp
{

    public partial class MainWindow : Window
    {

        public static bool loginSuccess = false;

        public Register? registerWindow;
        public Login? loginWindow;

        //timer
        DispatcherTimer timer = new();

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("data.enc"))
            {
                RegisterButtonVar.IsEnabled = false;
            }

            InitializeTimer();
        }

        void InitializeTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(0.1f);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if(loginSuccess == true)
            {
                MainFrame.Background = Brushes.Blue;
                timer.Stop();
                LoginButtonVar.IsEnabled = false;
                LoginStatus.Content = "Login Successfull!!";
            }
        }

        private void RegisterButton(object sender, RoutedEventArgs e)
        {
            if (registerWindow == null)
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
