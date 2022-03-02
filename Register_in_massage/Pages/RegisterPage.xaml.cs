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
            //var usr = (User)BindingContext;
            //if (!String.IsNullOrEmpty(usr.Name) && !String.IsNullOrEmpty(usr.Number))
            //{
            //    App.Database.SaveUser(usr);
            //}

            var user = new User();
            user.Name = txt_RegName.Text;
            user.SecName = txt_RegSecName.Text;
            user.Year = txt_RegYear.Text;
            user.Email = txt_RegEmail.Text; 
            user.Number = txt_RegNum.Text;
            user.Password = txt_RegPasw.Text;

            App.Database.SaveUser(user);


            await this.Navigation.PopAsync();
        }
    }
}