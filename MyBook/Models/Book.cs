using System;
using System.Collections.Generic;
using System.Text;

namespace MyBook.Models
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public List<BookFeature> BookFeatures { get; set; }
        public List<BookSizePrice> BookSizePrices { get; set; }
    }
}
