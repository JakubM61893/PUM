using projektt.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace projektt.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}