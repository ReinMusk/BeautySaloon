using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Register_in_massage
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "RegMassage.db";
        public static LocalRepository database;
        public static LocalRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new LocalRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
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
