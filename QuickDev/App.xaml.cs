using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QuickDev.Services;
using QuickDev.Views;

namespace QuickDev
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

#if DEBUG
            HotReloader.Current.Run(app: this, config: new HotReloader.Configuration()
            {
                ExtensionIpAddress = System.Net.IPAddress.Parse("192.168.1.219"),
                DeviceUrlPort = 15000
            });
#endif

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
