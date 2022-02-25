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
        }
    }
}