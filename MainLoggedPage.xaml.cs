using MyLoginPanel.DB;
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

namespace MyLoginPanel
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainLoggedPage : Window
    {
        User currentlyLoggedUser;
        string welcomeMessage;
        bool isMenuHidden = false;
        public MainLoggedPage(User user)
        {
            InitializeComponent();
            welcomeMessage = $"Witaj {user.Login}. Wkrótce SimplestMedium otworzy przed tobą swoje możliwości.";
            Main.Content = new HomePage(welcomeMessage);
            currentlyLoggedUser = user;
        }
        /*
        public MainLoggedPage()
        {
            InitializeComponent();
            Main.Content = new HomePage();
        }
        */
        private void logOut(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void goToSettings(object sender, RoutedEventArgs e)
        {
            Main.Content = new SettingsPage(currentlyLoggedUser, this);
        }

        private void goToHomePage(object sender, RoutedEventArgs e)
        {
            Main.Content = new HomePage(); //w wersji testowej jest uruchamiany bezparametrowy konstruktor
        }

        private void hideUnhideMenu(object sender, RoutedEventArgs e)
        {
            if (isMenuHidden)
            {
                (sender as Button).Content = "X";
                MenuRow.Width = new GridLength(Left, GridUnitType.Auto);
            }
            else
            {
                (sender as Button).Content = "->";
                MenuRow.Width = new GridLength(0);
            }
            isMenuHidden = !isMenuHidden;
        }
    }
}
