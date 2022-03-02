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
    public partial class PageMasseur : ContentPage
    {
        public PageMasseur(Masseur masseur)
        {
            InitializeComponent();

            txt_name.Text = masseur.Name + " " + masseur.SecName;
            txt_num.Text = masseur.Number;

            if (masseur.Email == null)
                mail_frame.IsVisible = false;
            txt_mail.Text = masseur.Email;
            

        }

        private void registry_Clicked(object sender, EventArgs e)
        {

        }
    }
}