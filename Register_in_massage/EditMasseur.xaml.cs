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
    public partial class EditMasseur : ContentPage
    {
        Masseur masseur;
        public EditMasseur(Masseur newMass)
        {
            InitializeComponent();
            masseur = newMass;

            txt_EditMsName.Text = masseur.Name;
            txt_EditMsSecName.Text = masseur.SecName;
            txt_EditMsWork.Text = masseur.WorkExperience.ToString();
            txt_EditMsNum.Text = masseur.Number;
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            Masseur mas = new Masseur
            {
                Id = masseur.Id,
                Name = txt_EditMsName.Text,
                SecName = txt_EditMsSecName.Text,
                WorkExperience = int.Parse(txt_EditMsWork.Text),
                Number = txt_EditMsNum.Text
            };

            bool result = await DisplayAlert("Подтвердить действие", $"Вы точно хотите изменить \n{mas.Name}?", "Да", "Нет");

            if (result == true)
            {
                try
                {
                    if (!String.IsNullOrEmpty(mas.Name))
                    {
                        App.Database.SaveMasseur(mas);
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
            bool result = await DisplayAlert("Подтвердить действие", $"Вы точно хотите удалить \n{masseur.Name}?", "Да", "Нет");

            if (result == true)
            {
                App.database.DeleteUser(masseur.Id);
                //ProjectsPage projectsPage = new ProjectsPage();
                //await Navigation.PushAsync(projectsPage);
            }
        }
    }
}