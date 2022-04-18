using System;
using System.Collections.Generic;
using System.Text;

namespace MyBook.Models
{
    class Feature
    {
        public int Id { get; set; }
        public string Genre{ get; set; }
        public string Publishing { get; set; }
        public List<BookFeature> BookFeatures { get; set; }
    }
}
