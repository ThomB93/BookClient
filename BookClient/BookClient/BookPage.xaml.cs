using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookClient.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        BookManager bm; 
        public BookPage()
        {
            InitializeComponent();
            bm = new BookManager();
        }

        private void CreateBook(object sender, EventArgs e)
        {
            Book b = new Book()
            {
                Title = titleText.Text,
                ISBN = isbnText.Text,
                Description = descText.Text
            };
            bm.Add(b);
        }
    }
}