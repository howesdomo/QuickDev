using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace QuickDev.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() =>
            {
                // Device.OpenUri(new Uri("https://xamarin.com/platform");
                throw new Exception("test ios catch exception");
            });


        }

        public ICommand OpenWebCommand { get; }
    }
}