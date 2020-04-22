using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClient.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBookPage : ContentPage
    {
        private BookManager bm;
        public EditBookPage()
        {
            InitializeComponent();
            bm = new BookManager();
        }

        private async void Update_Book(object sender, EventArgs e)
        {
            var book = (Book)BindingContext;
            bm.Update(book);
            await Navigation.PopAsync();
        }

        private async void Delete_Book(object sender, EventArgs e)
        {
            var book = (Book)BindingContext;
            bm.Delete(book);
            await Navigation.PopAsync();
        }
    }
}