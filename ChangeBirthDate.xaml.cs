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
    /// Logika interakcji dla klasy ChangeBirthDate.xaml
    /// </summary>
    public partial class ChangeBirthDate : Window
    {
        User currentlyLoggedUser;
        string state;
        Profile profile;
        public ChangeBirthDate(User user, string state, Profile profile)
        {
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            this.profile = profile;
        }

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            bool canBeChanged = Validate.BirthDate(dp_birthday, lb_errorInfo);

            if (canBeChanged)
            {
                Confirm c = new Confirm(currentlyLoggedUser, state, dp_birthday.ToString(), profile);
                c.Show();
                this.Close();
            }
        }
    }
}
