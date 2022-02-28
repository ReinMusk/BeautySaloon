using System;
using System.Collections.Generic;
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


            await Navigation.PushAsync(new MasseursPage());
        }
    }
}