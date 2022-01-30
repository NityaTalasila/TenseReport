using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace TenseReport
{
    public partial class App : Application
    {
        public static string pFilePath;
        public static string tFilePath;
        public static int currID;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public App(string pfilePath, string tfilePath)
        {
            InitializeComponent();
            currID = 0;
            MainPage = new MainPage();
            pFilePath = pfilePath;
            tFilePath = tfilePath;
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
