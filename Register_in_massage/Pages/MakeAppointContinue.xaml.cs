using Register_in_massage.Pages;
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
    public partial class MakeAppointContinue : ContentPage
    {
        public static BeautySaloon Saloon { get; set; }

        public static List<int> FreeTimes { get; set; }

        public static DateTime Date { get; set; }
        public MakeAppointContinue(BeautySaloon oldSaloon, DateTime oldDate)
        {
            InitializeComponent();

            Saloon = oldSaloon;
            Date = oldDate;
            
            
            List<int> Ftimes = new List<int>();
            for (int i = Convert.ToInt32(Saloon.TimeStart.Hours); i < Convert.ToInt32(Saloon.TimeEnd.Hours); i++)
            {
                Ftimes.Add(i);
            }

            var busyTimes = App.database.GetAllAppointments().Where(x => x.Time.Date == Date.Date).ToList();
            List<int> Btimes = new List<int>();
            for (int i = 0; i < busyTimes.Count; i++)
            {
                Btimes.Add(busyTimes[i].Time.Hour);
            }

            if (Btimes.Count != 0)
            {
                Ftimes = Ftimes.Except(Btimes).Union(Btimes.Except(Ftimes)).ToList();
            }


            FreeTimes = Ftimes;
            times_lv.ItemsSource = FreeTimes;


            title_txt.Text = "Записаться в салон " + Saloon.Name;
            this.BindingContext = FreeTimes;
        }

        private async void buttonAdd_Clicked(object sender, EventArgs e)
        {
            if (times_lv.SelectedItem == null)
            {
                await DisplayAlert("Ошибка", "Выберите время", "Ок");
                return;
            }

            var appointment = new Appointment();
            appointment.IdSaloon = Saloon.Id;
            appointment.IdUser = UserPage.CurrentUser.Id;
            appointment.Time = Date.Date.Add(new TimeSpan(Convert.ToInt32(times_lv.SelectedItem), 0, 0));

            App.database.SaveAppointment(appointment);

            User user = UserPage.CurrentUser;

            await DisplayAlert("Поздравляем","Вы успешно записались в салон " + Saloon.Name + " на " + appointment.Time, "Ок");
            await Navigation.PushAsync(new UserPage(user));
        }

        private async void Button_cancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
    public class TimesFree
    {
        public int time { get; set; }
    }
}