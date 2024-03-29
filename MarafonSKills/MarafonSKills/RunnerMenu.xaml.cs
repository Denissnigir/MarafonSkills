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
using MarafonSKills.Model;

namespace MarafonSKills
{
    /// <summary>
    /// Логика взаимодействия для RunnerMenu.xaml
    /// </summary>
    public partial class RunnerMenu : Page
    {
        private Runner curRunner;
        public RunnerMenu(MainMenu mainMenu, Runner runner)
        {
            InitializeComponent();
            curRunner = runner;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Information information = new Information();
            information.ShowDialog();
        }

        private void NavigateToEditProfile(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterRunner(curRunner));
        }
    }
}
