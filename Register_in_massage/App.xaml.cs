using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Register_in_massage
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "RegMassage.db";
        public static UserRepository database;
        public static UserRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public static MasseurRepository database1;
        public static MasseurRepository Database1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new MasseurRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database1;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
