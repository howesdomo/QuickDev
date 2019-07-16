using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuickDev.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            this.btnStartScan.Clicked += BtnStartScan_Clicked;
        }

        private void BtnStartScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.MyBluetooth.StartScan();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.GetFullInfo());
            }
        }
    }
}