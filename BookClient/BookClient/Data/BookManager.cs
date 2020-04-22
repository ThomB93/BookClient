using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace BookClient.Data
{
    public class BookManager
    {

        public string strAuthorizationKey { get; set; } =
            "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MSwiaWF0IjoxNTg3NTM5NjE2LCJleHAiOjE1OTAxMzE2MTZ9.My595cpwl5umZhShXsglgguWqQgTyrVtUe0ZZI1YupY";
        public string Url { get; set; } = "https://shrouded-waters-99136.herokuapp.com/";
        public HttpClient Client { get; set; }


        public BookManager()
        {
            Client = GetClient();
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            string requestURI = Url + "Books";
            var jsonString = await Client.GetStringAsync(requestURI);
            var bookObjects = DeserializeJsonBooks(jsonString);

            return bookObjects;
        }

        public async void Add(Book book)
        {
            string json = SerializeJson(book);
            HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
            await Client.PostAsync(Url + "books", c);
        }

        public async void Update(Book book)
        {
            string json = SerializeJson(book);
            HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
            var b = await Client.PutAsync(Url + "books/"+ book.id.ToString(), c);
        }

        public async void Delete(Book book)
        {
            await Client.DeleteAsync(Url + "books/" + book.id.ToString());
        }

        //SERIALIZE & DESERIALIZE METHODS
        private Book DeserializeJsonBook(string json)
        {
            return JsonConvert.DeserializeObject<Book>(json);
        }
        private IEnumerable<Book> DeserializeJsonBooks(string json)
        {
            return JsonConvert.DeserializeObject<List<Book>>(json);
        }
        private string SerializeJson(Book book)
        {
            return JsonConvert.SerializeObject(book, Formatting.Indented);
        }

    }

    
}
