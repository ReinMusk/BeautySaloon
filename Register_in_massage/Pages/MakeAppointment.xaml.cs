using Register_in_massage.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Register_in_massage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeAppointment : ContentPage
    {
        public static BeautySaloon Saloon { get; set; }
        public MakeAppointment(BeautySaloon oldSaloon)
        {
            InitializeComponent();

            Saloon = oldSaloon;

            date_dp.MinimumDate = DateTime.Now.AddDays(1);

            title_txt.Text = "Записаться в салон " + Saloon.Name;
        }

        private async void buttonAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakeAppointContinue(Saloon, date_dp.Date));
        }

        private async void Button_cancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

}