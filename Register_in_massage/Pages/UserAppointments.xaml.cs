using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public List<Appointment> newAppointments { get; set; }
        public List<Appointment> oldAppointments { get; set; }

        public static User user { get; set; }

        public UserAppointments(User oldUser)
        {
            InitializeComponent();

            user = oldUser;

            newAppointments = App.Database.GetAllAppointments().Where(x => x.IdUser == user.Id && x.Time > DateTime.Now).ToList();
            oldAppointments = App.Database.GetAllAppointments().Where(x => x.IdUser == user.Id && x.Time < DateTime.Now).ToList();

            times_lv1.ItemsSource = newAppointments;
            times_lv2.ItemsSource = oldAppointments;

            this.BindingContext = this;
            //base.OnAppearing();
        }

        private async void times_lv1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushAsync(new CurrentAppointment(times_lv1.SelectedItem as Appointment));
        }

        private async void times_lv2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushAsync(new CurrentAppointment(times_lv2.SelectedItem as Appointment));
        }
    }

    //private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    //{
    //    Appointment selected = (Appointment)e.SelectedItem;
    //    await Navigation.PushAsync(projectPage);
    //}
}