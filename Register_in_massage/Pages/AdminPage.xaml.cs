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
            await Navigation.PushAsync(new SaloonsPage(new User() {Number = "admin" }));
        }

        private async void addSaloon(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEditSaloon());
        }
    }
}