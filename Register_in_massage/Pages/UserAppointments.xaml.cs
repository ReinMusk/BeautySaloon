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
        public static List<Appointment> newAppointments { get; set; }

        public static List<Appointment> oldAppointments { get; set; }

        public static User user { get; set; }

        public UserAppointments(User oldUser)
        {
            InitializeComponent();

            user = oldUser;

            newAppointments = App.Database.GetUserAppointments(user).Where(x => x.Time > DateTime.Now).ToList();
            oldAppointments = App.Database.GetUserAppointments(user).Where(x => x.Time < DateTime.Now).ToList();

            projectList1.ItemsSource = newAppointments;
            projectList2.ItemsSource = oldAppointments;

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