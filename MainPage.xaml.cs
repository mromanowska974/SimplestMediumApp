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
    public partial class MainPage : Window
    {
        User currentlyLoggedUser;
        public MainPage(User user)
        {
            InitializeComponent();
            lb_welcomeMessage.Content = $"Witaj {user.Login}. Wkrótce SimplestMedium otworzy przed tobą swoje możliwości.";
            currentlyLoggedUser = user;
        }

        private void logOut(object sender, RoutedEventArgs e)
        {
            currentlyLoggedUser = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void goToProfile(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(currentlyLoggedUser);
            profile.Show();
            this.Close();
        }
    }
}
