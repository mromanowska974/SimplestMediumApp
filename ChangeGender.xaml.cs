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
    public partial class ChangeGender : Page
    {
        User currentlyLoggedUser;
        string state;
        Frame rootFrame;
        Window rootWindow;
        Window parentWindow;
        public ChangeGender(User user, string state, Frame frame, Window window, Window window2)
        {
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            rootFrame = frame;
            rootWindow = window;
            parentWindow = window2;
        }

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            RadioButton[] rb = {
                radio_female,
                radio_male,
                radio_other
            };
            bool canBeChanged = Validate.Gender(rb, lb_errorInfo);

            if (canBeChanged)
            {
                string newData = "";

                if (radio_female.IsChecked == true) newData = "Female";
                else if (radio_male.IsChecked == true) newData = "Male";
                else if (radio_other.IsChecked == true) newData = "Other/Not mentioned";

                rootFrame.Content = new ConfirmPage(currentlyLoggedUser, state, newData, rootWindow, parentWindow);
            }
        }
    }
}
