using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Register_in_massage.Pages;

namespace Register_in_massage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMasseur : ContentPage
    {
        public Masseur CurrentMasseur { get; set; }
        public PageMasseur(Masseur masseur)
        {
            InitializeComponent();

            CurrentMasseur = masseur;

            txt_name.Text = masseur.Name + " " + masseur.SecName;
            txt_num.Text = masseur.Number;

            //if (masseur.Email == null)
            //    mail_frame.IsVisible = false;
            txt_mail.Text = masseur.Email;
            img = new Image { Source = masseur.pathName };
            this.BindingContext = this;
        }

        private void registry_Clicked(object sender, EventArgs e)
        {
            var appointment = new Appointment();
            appointment.IdMasseur = CurrentMasseur.Id;
            appointment.IdUser = UserPage.CurrentUser.Id;
            appointment.Time = datepicker.Date;

            App.database.SaveAppointment(appointment);
        }
    }
}