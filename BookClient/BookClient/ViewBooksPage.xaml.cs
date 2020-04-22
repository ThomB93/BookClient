using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClient.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewBooksPage : ContentPage
    {
        private BookManager bm;
        public ViewBooksPage()
        {
            InitializeComponent();
            bm = new BookManager();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await bm.GetAllBooks();
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EditBookPage
                {
                    BindingContext = e.SelectedItem as Book
                });
            }
        }
    }
}