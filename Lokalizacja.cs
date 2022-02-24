using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace projektt.Views
{
    public class Lokalizacja : ContentPage
    {
        private Button _button;
        private Label _result;
        public Lokalizacja()
        {
            this.Title = "Pobierz swoją lokalizację";

            StackLayout stackLayout = new StackLayout();

            _button = new Button();
            _button.Text = "Lokal";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);


            Content = stackLayout;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var result = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
            _result.Text = $"lat: {result.Latitude}, lng: {result.Longitude}";
        }
        
    }
}