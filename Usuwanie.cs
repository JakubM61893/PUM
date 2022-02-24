using projektt.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace projektt.Views
{
    public class Usuwanie : ContentPage
    {
        private ListView _listView;
        private Button _button;

        Zakupy _zakupy = new Zakupy();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public Usuwanie()
        {
            this.Title = "Usuń produkt z listy";

            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Zakupy>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Usuń";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _zakupy = (Zakupy)e.SelectedItem;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Zakupy>().Delete(x => x.Id == _zakupy.Id);
            await Navigation.PopAsync();
        }
    }
}