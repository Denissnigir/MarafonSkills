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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MarafonSKills.Windows;
using MarafonSKills.Model;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace MarafonSKills
{
    /// <summary>
    /// Логика взаимодействия для RegisterRunner.xaml
    /// </summary> 
    public partial class RegisterRunner : Page
    {
        private MainMenu curWin { get; }

        private string filePath = null;
        private string fileName = null;

        User userData;

        public RegisterRunner()
        {
            InitializeComponent();

            userData = new User();
            MainGrid.DataContext = userData;
            this.DataContext = userData;

            GenderCB.ItemsSource = Context._con.Gender.ToList();
            CountryCB.ItemsSource = Context._con.Country.ToList();
        }

        public RegisterRunner(Runner runner)
        {
            InitializeComponent();

            userData = new User();
            MainGrid.DataContext = userData;
            this.DataContext = userData;

            GenderCB.ItemsSource = Context._con.Gender.ToList();
            CountryCB.ItemsSource = Context._con.Country.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if ((bool)openFileDialog.ShowDialog())
            {
                filePath = openFileDialog.FileName;
                fileName = filePath.Split('\\').Last();
                ProfilePhoto.Source = new BitmapImage(new Uri(filePath));
                ChoosePhotoTB.Text = fileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[a-z0-9].*[a-z0-9]@[a-z]+[.][a-z]+");
            if (!string.IsNullOrWhiteSpace(filePath) && !string.IsNullOrWhiteSpace(EmailTB.Text) && !string.IsNullOrWhiteSpace(PasswordTB.Text) && !string.IsNullOrWhiteSpace(RepeatPasswordTB.Text) &&
                !string.IsNullOrWhiteSpace(NameTB.Text) && !string.IsNullOrWhiteSpace(SurnameTB.Text) && GenderCB.SelectedIndex >= 0 && BirthdateTB.SelectedDate != null && CountryCB.SelectedIndex >= 0)
            {
                if(BirthdateTB.SelectedDate >= new DateTime(2010, 01, 01))
                {
                    MessageBox.Show("Выберите корректную дату!");
                }
                else
                {
                    if(PasswordTB.Text == RepeatPasswordTB.Text)
                    {

                        if (Regex.IsMatch(EmailTB.Text, Convert.ToString(regex), RegexOptions.IgnoreCase))
                        {
                            try
                            {
                                File.Copy(filePath, $@"..\..\{fileName}");
                            }
                            catch
                            {

                            }

                            userData.Email = EmailTB.Text;
                            userData.Password = PasswordTB.Text;
                            userData.FirstName = NameTB.Text;
                            userData.LastName = SurnameTB.Text;
                            userData.RoleId = "R";

                            Context._con.User.Add(userData);
                            Context._con.SaveChanges();

                            Runner runnerData = new Runner();
                            runnerData.Email = userData.Email;
                            runnerData.Gender = GenderCB.Text;
                            runnerData.DateOfBirth = (DateTime)BirthdateTB.SelectedDate;
                            runnerData.CountryCode = CountryCB.Text;
                            runnerData.Photo = fileName;

                            Context._con.Runner.Add(runnerData);
                            Context._con.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Введите корректную почту!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают!");
                    }
                }

                
            }
            else
            {
                MessageBox.Show("Заполните все поля!!");
            }
            
        }
    }
}
