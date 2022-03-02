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
    public partial class UserAppointments : ContentPage
    {
        public UserAppointments()
        {
            InitializeComponent();

            projectList.ItemsSource = App.Database.GetUserAppointments(UserPage.CurrentUser);
            this.BindingContext = this;
            //base.OnAppearing();
        }
    }

    //private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    //{
    //    Appointment selected = (Appointment)e.SelectedItem;
    //    await Navigation.PushAsync(projectPage);
    //}
}