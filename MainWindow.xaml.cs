﻿using System;
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

namespace RegisterLoginApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Register registerWindow = new();

        public MainWindow()
        {
            InitializeComponent();
            this.Closed += CloseWindows;
        }

        private void CloseWindows(object? sender, EventArgs e)
        {
            registerWindow.Close();
        }

        private void RegisterButton(object sender, RoutedEventArgs e)
        {
            registerWindow.Show();
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
