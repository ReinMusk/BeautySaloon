using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Diagnostics;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Register_in_massage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMasseur : ContentPage
    {
        public string pathName;
        public AddMasseur()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            //Masseur ms = (Masseur)BindingContext;
            //if (!String.IsNullOrEmpty(ms.Name))
            //{
            //    App.Database.SaveMasseur(ms);
            //}
            //this.Navigation.PopAsync();

            Masseur ms = new Masseur();
            ms.Name = txt_AddName.Text;
            ms.SecName = txt_AddSecName.Text;
            ms.WorkExperience = Convert.ToInt32(txt_AddWork.Text);
            ms.Number = txt_AddNum.Text;
            ms.pathName = pathName;
            App.Database.SaveMasseur(ms);
            this.Navigation.PopAsync();
        }

        private async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                pathName = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
    }
}