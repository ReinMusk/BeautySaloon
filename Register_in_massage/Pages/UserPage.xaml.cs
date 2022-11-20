using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Register_in_massage;

namespace Register_in_massage.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public static User CurrentUser{ get; set; }
        public UserPage(User user)
        {
            InitializeComponent();

            CurrentUser = user;

            label_title.Text = "Добро пожаловать, " + user.Name + user.SecName;
        }

        private async void myApps_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserAppointments(CurrentUser));
        }

        private async void openListBtn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SaloonsPage(CurrentUser));
        }

        private async void profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(CurrentUser));
        }
    }
}