using System;
using System.IO;
using DPS_926___App_2.Services;
using Xamarin.Forms;

namespace DPS_926___App_2
{
    public partial class App : Application
    {
        private static DataStore database;

        public static DataStore Database
        {
            get
            {
                if (database == null)
                    database = new DataStore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SavedRecipes.db3"));
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<DataStore>();

            MainPage = new AppShell();
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
