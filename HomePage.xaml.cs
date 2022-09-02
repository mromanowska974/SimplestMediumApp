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
    /// Logika interakcji dla klasy HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage(string welcomeMessage)
        {
            InitializeComponent();
            lb_welcomeMessage.Content = welcomeMessage;
        }

        public HomePage()
        {
            InitializeComponent();
            lb_welcomeMessage.Content = $"Wersja testowa dla mnie. Tu testuję moje widoki.";
        }
    }
}
