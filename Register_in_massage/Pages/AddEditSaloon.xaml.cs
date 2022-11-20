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
using System.IO;

namespace Register_in_massage 
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditSaloon : ContentPage
    {
        public static BeautySaloon Saloon { get; set; }
        public AddEditSaloon()
        {
            InitializeComponent();

            title_txt.Text = "Добавить салон красоты";
            this.BindingContext = this;
        }

        public AddEditSaloon(BeautySaloon oldSaloon)
        {
            InitializeComponent();

            title_txt.Text = "Изменить салон красоты";
            buttonAdd.Text = "Изменить";
            Saloon = oldSaloon;

            img_box.Source = Saloon.Photo;
            img_box.IsVisible = true;
            buttonDel.IsVisible = true;

            this.BindingContext = Saloon;
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txt_AddName.Text != "" &&
                txt_AddNum.Text != "" &&
                txt_AddDesc.Text != "" &&
                txt_AddAdress.Text != "")
                {
                    Saloon.Name = txt_AddName.Text;
                    Saloon.Description = txt_AddDesc.Text;
                    Saloon.Adress = txt_AddAdress.Text;
                    Saloon.Number = txt_AddNum.Text;
                    Saloon.TimeStart = txt_AddTimeStart.Time;
                    Saloon.TimeEnd = txt_AddTimeEnd.Time;
                    App.Database.SaveBeautySaloon(Saloon);
                    await this.Navigation.PopAsync();
                }
            }
            catch
            {
                await DisplayAlert("Сообщение об ошибке", "Ошибка", "OK");
            }
            
        }

        private async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                Saloon.Photo = photo.FullPath;
                img_box.Source = Saloon.Photo;
                img_box.IsVisible = true;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private async void buttonDel_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Предупреждение", "Вы точно хотите удалить этот салон?", "Да", "Нет");
            if (result)
            {
                App.Database.DeleteBeautySaloon(Saloon.Id);

                await this.Navigation.PopAsync();
            }
        }
    }
}