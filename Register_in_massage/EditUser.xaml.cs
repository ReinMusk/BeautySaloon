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
    public partial class EditUser : ContentPage
    {
        User user;
        public EditUser(User newUsr)
        {
            InitializeComponent();
            user = newUsr;

            txt_EditUsName.Text = user.Name;
            txt_EditUsSecName.Text = user.SecName;
            txt_EditUsYear.Text = user.Year;
            txt_EditUsPas.Text = user.Password;
            txt_EdirUsEmail.Text = user.Email;
            txt_EditUsNum.Text = user.Number;
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            User usr = new User
            {
                Id = user.Id,
                Password = txt_EditUsNum.Text,
                Year = txt_EditUsYear.Text,
                Name = txt_EditUsName.Text,
                SecName = txt_EditUsSecName.Text,
                Number = txt_EditUsNum.Text,
                Email = txt_EdirUsEmail.Text
            };

            bool result = await DisplayAlert("Подтвердить действие", $"Вы точно хотите изменить \n{user.Name}?", "Да", "Нет");

            if (result == true)
            {
                try
                {
                    if (!String.IsNullOrEmpty(usr.Name))
                    {
                        App.Database.SaveUser(usr);
                    }
                    //ProjectsPage projectsPage = new ProjectsPage();
                    //await Navigation.PushAsync(projectsPage);
                }
                catch (Exception)
                {
                    _ = DisplayAlert("Подтвердить действие", "Укажите имя", "Ок");
                }
            }
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", $"Вы точно хотите удалить \n{user.Name}?", "Да", "Нет");

            if (result == true)
            {
                App.database.DeleteUser(user.Id);
                //ProjectsPage projectsPage = new ProjectsPage();
                //await Navigation.PushAsync(projectsPage);
            }
        }
    }
}