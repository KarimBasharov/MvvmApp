using MvvmApp.Models;
using MvvmApp.Views;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "friends2.db";
        public static FriendsAsyncRepository database;
        public static FriendsAsyncRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new FriendsAsyncRepository(
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
