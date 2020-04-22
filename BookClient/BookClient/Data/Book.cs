using System;
using System.Collections.Generic;
using System.Text;

namespace BookClient.Data
{
    public class Book
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public object[] Image { get; set; }
    }
}
