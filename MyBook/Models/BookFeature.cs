using System;
using System.Collections.Generic;
using System.Text;

namespace MyBook.Models
{
    class BookFeature
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int FeatureId { get; set; }
        public Book Book { get; set; }
        public Feature Feature { get; set; }
    }
}
