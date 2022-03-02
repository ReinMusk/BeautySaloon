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
        public User CurrentUser{ get; set; }
        public UserPage(User user)
        {
            InitializeComponent();

            CurrentUser= user;

            label_title.Text = "Добро пожаловать, " + user.Name;
        }

        private async void openListBtn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MasseursPage());
        }
    }
}