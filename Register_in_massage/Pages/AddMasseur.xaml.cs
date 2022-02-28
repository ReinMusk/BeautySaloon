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
    public partial class AddMasseur : ContentPage
    {
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
            Masseur ms = (Masseur)BindingContext;
            if (!String.IsNullOrEmpty(ms.Name))
            {
                App.Database.SaveMasseur(ms);
            }
            this.Navigation.PopAsync();
        }
    }
}