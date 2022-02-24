using projektt.Services;
using projektt.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projektt
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StronaGłówna());
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
