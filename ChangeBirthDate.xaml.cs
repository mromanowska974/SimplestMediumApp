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
    public partial class ChangeBirthDate : Page
    {
        User currentlyLoggedUser;
        string state;
        int counter;
        Frame rootFrame;
        Window rootWindow;
        Window parentWindow;
        public ChangeBirthDate(User user, string state, Frame frame, Window window, Window window2)
        {
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            counter = currentlyLoggedUser.BirthDateChangesCounter;
            rootFrame = frame;
            rootWindow = window;
            parentWindow = window2;

            if (counter == 3) lb_errorInfo.Content = "Przekroczono dopuszczalną ilość zmiany daty urodzenia.";
            else
            {
                lb_errorInfo.Foreground = Brushes.Black;
                lb_errorInfo.Content = $"Pozostało {3 - counter} możliwych zmian daty urodzenia.";
            }

        }

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            bool canBeChanged = Validate.BirthDate(dp_birthday, lb_errorInfo) && counter < 3;

            if (counter == 3) lb_errorInfo.Content = "Przekroczono dopuszczalną ilość zmiany daty urodzenia.";

            if (canBeChanged)
            {
                rootFrame.Content = new ConfirmPage(currentlyLoggedUser, state, dp_birthday.ToString(), rootWindow, parentWindow);
            }
        }
    }
}
