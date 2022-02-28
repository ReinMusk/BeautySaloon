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
    public partial class MasseursPage : ContentPage
    {
        public MasseursPage()
        {
            InitializeComponent();

            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            projectList.ItemsSource = App.Database.GetMasseurs();
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Masseur selected = (Masseur)e.SelectedItem;
            PageMasseur projectPage = new PageMasseur(selected);
            await Navigation.PushAsync(projectPage);
        }
    }
}