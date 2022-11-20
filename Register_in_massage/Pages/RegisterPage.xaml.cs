using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Register_in_massage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }


        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(App.Database.GetUsers().Where(x => x.Number == txt_RegNum.Text).ToList().Count > 0)
                {
                    await DisplayAlert("Ошибка", "Пользователь с таким номером существует", "Ок");
                    return;
                }
                if (txt_RegName.Text != "" && txt_RegSecName.Text != "" && IsPhoneNumber(txt_RegNum.Text) == true && IsPassword(txt_RegPasw.Text) == true)
                {
                    var user = new User();
                    user.Name = txt_RegName.Text;
                    user.SecName = txt_RegSecName.Text;
                    user.Number = txt_RegNum.Text;
                    user.Password = txt_RegPasw.Text;

                    App.Database.SaveUser(user);


                    await this.Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Ошибка", "Что то неправильно", "Ок");
                }
            }
            catch 
            {
                await DisplayAlert("Ошибка", "Что то неправильно", "Ок");
            }
        }

        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{11})$").Success;
        }

        public static bool IsPassword(string temp)
        {
            if (temp.Length > 6)
            {
                return true;
            }
            return false;
        }
    }
}