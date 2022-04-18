using System;
using System.Collections.Generic;
using System.Text;

namespace MyBook.Models
{
    class Size
    {
        public int Id { get; set; }
        public string PageCount { get; set; }
        public List<BookSizePrice> BookSizePrice { get; set; }
    }
}
