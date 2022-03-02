using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Register_in_massage.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private async void showList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MasseursPage());
        }

        private async void addMasseur(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMasseur());
        }
    }
}