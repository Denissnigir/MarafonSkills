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
using MarafonSKills.Windows;

namespace MarafonSKills
{
    /// <summary>
    /// Логика взаимодействия для RunnerValidate.xaml
    /// </summary>
    public partial class RunnerValidate : Page
    {
        private MainMenu curWin { get; }
        public RunnerValidate(MainMenu mainMenu)
        {
            InitializeComponent();
            curWin = mainMenu;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            curWin.MainFrame.Navigate(new AuthMenu(curWin));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            curWin.MainFrame.Navigate(new AuthMenu(curWin));
        }
    }
}