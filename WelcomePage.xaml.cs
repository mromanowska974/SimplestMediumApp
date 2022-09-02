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

namespace MyLoginPanel
{
    /// <summary>
    /// Logika interakcji dla klasy Welcome.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        Frame rootFrame;
        Window rootWindow;
        public WelcomePage(Frame frame, Window window)
        {
            InitializeComponent();
            rootFrame = frame;
            rootWindow = window;
        }

        private void goToLoginWindow(object sender, RoutedEventArgs e)
        {
            rootFrame.Content = new LoginPage("Witamy ponownie drogi użytkowniku. \nZaloguj się w serwisie SimplestMedium.", rootWindow);
        }

        private void goToRegisterWindow(object sender, RoutedEventArgs e)
        {
            rootFrame.Content = new RegisterPage(rootFrame, rootWindow);
        }
    }
}
