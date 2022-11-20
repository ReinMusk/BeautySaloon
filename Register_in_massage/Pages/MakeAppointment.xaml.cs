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
    public partial class MakeAppointment : ContentPage
    {
        public static BeautySaloon Saloon { get; set; }

        public static List<TimesFree> FreeTimes { get; set; }
        public MakeAppointment(BeautySaloon oldSaloon)
        {
            InitializeComponent();

            Saloon = oldSaloon;

            List<TimesFree> times = new List<TimesFree>();
            var timeLenght = Convert.ToInt32((Saloon.TimeEnd - Saloon.TimeStart).Hours);
            for (int i = Convert.ToInt32(Saloon.TimeStart.Hours); i < timeLenght; i++)
            {
                times.Add(new TimesFree() { time = i});
            }
            FreeTimes = times;

            times_lv.ItemsSource = FreeTimes;


            title_txt.Text = "Записаться в салон " + Saloon.Name;

            this.BindingContext = FreeTimes;
        }

        private void buttonAdd_Clicked(object sender, EventArgs e)
        {

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