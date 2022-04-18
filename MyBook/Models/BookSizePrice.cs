using System;
using System.Collections.Generic;
using System.Text;

namespace MyBook.Models
{
    class BookSizePrice
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int SizeId { get; set; }
        public double Price { get; set; }
        public Book Book { get; set; }
        public Size Size { get; set; }
    }
}
