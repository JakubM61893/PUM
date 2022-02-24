using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace projektt.Views
{
    public class StronaGłówna : ContentPage
    {
        public StronaGłówna()
        {
            this.Title = "Witaj!";


            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Dodaj do listy";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Lista";
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Usuń";
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Lokalizacja";
            button.Clicked += Button_Geo_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DodajDoListy());
        }

        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista());
        }
        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Usuwanie());
        }
        private async void Button_Geo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lokalizacja());
        }
    }
}