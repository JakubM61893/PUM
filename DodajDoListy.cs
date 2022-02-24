using projektt.Models;
using projektt.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace projektt.Views
{
    public class DodajDoListy : ContentPage
    {
        private Entry _nameEntry;
        private Entry _amountEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public DodajDoListy()
        {
            this.Title = "Dodaj produkt";
            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Nazwa produktu";
            stackLayout.Children.Add(_nameEntry);

            _amountEntry = new Entry();
            _amountEntry.Keyboard = Keyboard.Text;
            _amountEntry.Placeholder = "Ilość";
            stackLayout.Children.Add(_amountEntry);

            _saveButton = new Button();
            _saveButton.Text = "Dodaj";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }
        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Zakupy>();

            var maxPk = db.Table<Zakupy>().OrderByDescending(c => c.Id).FirstOrDefault();

            Zakupy zakupy = new Zakupy()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Name = _nameEntry.Text,
                Amount = _amountEntry.Text
            };
            db.Insert(zakupy);
            await DisplayAlert(null, zakupy.Name + " x" + zakupy.Amount + " Zapisano", "Ok");
            await Navigation.PopAsync();
        }
    }
}