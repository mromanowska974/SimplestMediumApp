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
    /// Logika interakcji dla klasy ChangeGender.xaml
    /// </summary>
    public partial class ChangeGender : Window
    {
        User currentlyLoggedUser;
        string state;
        Profile profile;
        public ChangeGender(User user, string state, Profile profile)
        {
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            this.profile = profile;
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

                Confirm c = new Confirm(currentlyLoggedUser, state, newData, profile);
                c.Show();
                this.Close();
            }
        }
    }
}
