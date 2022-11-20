using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Register_in_massage.Pages;

namespace Register_in_massage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSaloon : ContentPage
    {
        public static BeautySaloon CurrentSaloon { get; set; }
        public PageSaloon(BeautySaloon beautySaloon)
        {
            InitializeComponent();

            CurrentSaloon = beautySaloon;

            img_.Source = beautySaloon.Photo;

            this.BindingContext = CurrentSaloon;
        }

        private async void registry_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakeAppointment(CurrentSaloon));
        }

        
    }
}