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
using System.Windows.Threading;

namespace MarafonSKills.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public MainMenu()
        {
            InitializeComponent();
            MainFrame.Navigate(new RunnerSponsor());

            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += tick;
            dispatcherTimer.Start();
        }

        private void tick(object sender, EventArgs e)
        {
            DateTime curDate = DateTime.Now;
            TimeSpan remaningTIme = MainWindow.dateOfEvent - curDate;
            EventTB.Text = string.Format("{0} days, {1} hours and {2} minutes {3} seconds until marathin starts!", remaningTIme.Days, remaningTIme.Hours, remaningTIme.Minutes, remaningTIme.Seconds); 
        }
    }
}
