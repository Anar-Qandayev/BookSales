using Microsoft.EntityFrameworkCore;
using MyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBook.DAL
{
    class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-R60C9I5\SQLEXPRESS;Database=MyLibraff;Trusted_Connection=True;");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<BookFeature> BookFeatures { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<BookSizePrice> BookSizePrices { get; set; }
    }
}
