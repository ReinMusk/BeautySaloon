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
    public partial class CurrentAppointment : ContentPage
    {
        public Appointment newAppointment { get; set; }
        public CurrentAppointment(Appointment oldAppointment)
        {
            InitializeComponent();
            newAppointment = oldAppointment;

            datetimeL.Text = "На время: " + newAppointment.Time.ToString();
            adressL.Text = "Адрес: " + App.database.GetBeautySaloon(newAppointment.IdSaloon).Adress;
            nameL.Text = "Название салона: " + App.database.GetBeautySaloon(newAppointment.IdSaloon).Name;
        }

        private async void Button_cancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void buttonDel_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Предупреждение", "Вы точно хотите удалить запись?","Да","Нет");

            if (result == true)
            {
                App.database.DeleteAppointment(newAppointment.Id);
                await Navigation.PushAsync(new UserPage(UserPage.CurrentUser));
            }
        }
    }
}