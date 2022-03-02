using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Register_in_massage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorPage : ContentPage
    {
        public AuthorPage()
        {
            InitializeComponent();
        }

        private async void Button_Registr_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
        private async void Button_Login_Clicked(object sender, EventArgs e)
        {
            //var user = new User();
            //user.Number = author_txt_number.Text;
            //user.Password = author_txt_password.Text;

            var user = App.Database.GetUser(author_txt_number.Text);
            try
            {
                if (author_txt_number.Text == "admin" && author_txt_password.Text == "admin")
                    await Navigation.PushAsync(new Pages.AdminPage());
                else if (App.Database.UserIsCorrect(user))
                    await Navigation.PushAsync(new Pages.UserPage(user));
            }
            catch
            {
                await DisplayAlert("Error", "Что то неправильно", "Ок");
            }
        }
    }
}