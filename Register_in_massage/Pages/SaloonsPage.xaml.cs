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
    public partial class SaloonsPage : ContentPage
    {
        public static List<BeautySaloon> Saloons { get; set; }

        public static User user { get; set; }
        public SaloonsPage(User oldUser)
        {
            InitializeComponent();
            user = oldUser;
            Saloons = App.database.GetSaloons();
            saloons_lv.ItemsSource = Saloons;

            this.BindingContext = this;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (user.Number == "admin")
            {
                await Navigation.PushAsync(new AddEditSaloon(saloons_lv.SelectedItem as BeautySaloon));
            }
            else
            {
                await Navigation.PushAsync(new PageSaloon(saloons_lv.SelectedItem as BeautySaloon));
            }
        }

        private async void Refresh_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(200);
            saloons_lv.ItemsSource = null;
            saloons_lv.ItemsSource = App.database.GetSaloons();

            Refresh.IsRefreshing = false;
        }
    }
}