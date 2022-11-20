using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Register_in_massage.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public static User user { get; set; }

        public ProfilePage(User oldUser)
        {
            InitializeComponent();

            user = oldUser;

            this.BindingContext = user;
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txt_AddPas.Text.Length > 7)
                {
                    if (txt_AddNum.Text.Length == 11)
                    {
                        if (txt_AddPas == txt_AddPas1)
                        {
                            if (txt_AddName.Text != "" &&
                            txt_AddSecName.Text != "")
                            {
                                user.Number = txt_AddNum.Text;
                                user.SecName = txt_AddSecName.Text;
                                user.Name = txt_AddName.Text;
                                user.Password = txt_AddPas.Text;

                                App.Database.SaveUser(user);
                                await Navigation.PopAsync();
                            }
                        }
                        else
                        {
                            await DisplayAlert("Ошибка", "пароли не совпадают", "Ок");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Ошибка", "неправильный номер телефона", "Ок");
                    }

                }
                else
                {
                    await DisplayAlert("Ошибка", "пароль меньше 7 символов", "Ок");
                }
            }
            catch
            {
                await DisplayAlert("Ошибка", "Что то неправильно", "Ок");
            }
            
            
        }
    }
}