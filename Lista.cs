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
    public class Lista : ContentPage
    {
        private ListView _listview;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public Lista()
        {
            this.Title = "Zakupy";
            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();
            _listview = new ListView();
            _listview.ItemsSource = db.Table<Zakupy>().OrderBy(x => x.Name).ToList();
            stackLayout.Children.Add(_listview);

            Content = stackLayout;
        }
    }
}