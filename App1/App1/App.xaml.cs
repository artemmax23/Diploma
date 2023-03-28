using App1.Services;
using App1.Views;
using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {

        public const string DATABASE_NAME = "friends.db";
        public static MyBookRepository database;
        public static MyBookRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new MyBookRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
