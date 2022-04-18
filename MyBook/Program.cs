using Microsoft.EntityFrameworkCore;
using MyBook.DAL;
using MyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            //Book book = new Book { Name = "Alone" };
            using (AppDbContext sql = new AppDbContext())
            {
                //sql.Books.Add(book);
                //sql.SaveChanges();
                //Book b = sql.Books.Find(1);
                //Console.WriteLine($"{b.Id} {b.Name} {b.AuthorName}");
                //List<Book> books = sql.Books.ToList();
                //foreach (Book book1 in books)
                //{
                //    Console.WriteLine($"{book1.Id}. {book1.Name} {book1.AuthorName}");
                //}
                //List<Feature> features = sql.Features.ToList();
                //foreach (Feature feature in features)
                //{
                //    Console.WriteLine($"{feature.Id}. {feature.Genre} ~ {feature.Publishing}");
                //}
            }
            //Console.WriteLine("Menyuya baxmaq isterdiniz? Y/N");
            //if (Console.ReadLine().ToLower() == "y")
            //{
            //    Menu();
            //}
            GetBookFeature(1);
            //UpdateBook(2, "1984");
            //GetAllBooks();
        }
        public static void Menu()
        {
            GetAllBooks();
            Console.WriteLine("Hansi kitabi isteyirsiniz. NOmre daxil edin");
            int.TryParse(Console.ReadLine(), out int num);
            if (num > 0)
            {
                GetBookFeature(num);
            }
        }
        static void GetAllBooks()
        {
            using (AppDbContext sql = new AppDbContext())
            {

                List<Book> books = sql.Books.ToList();
                foreach (Book book1 in books)
                {
                    Console.WriteLine($"{book1.Id}. {book1.Name} {book1.AuthorName}");
                }
            }
        }
        static void GetBookFeature(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (sql.Books.Any(b => b.Id == id))
                {
                    Book book = sql.Books.Include(b => b.BookFeatures).ThenInclude(bf => bf.Feature).SingleOrDefault(b => b.Id == id);
                    string features = "";
                    foreach (BookFeature bf in book.BookFeatures)
                    {
                        features += bf.Feature.Genre + bf.Feature.Publishing + " , ";
                    }
                    if (features.Length > 2)
                    {
                        Console.WriteLine(book.Name + book.AuthorName + " - " + features.Substring(0, features.Length - 2));
                    }
                    else
                    {
                        Console.WriteLine(book.Name + book.AuthorName + " - " + features);
                    }

                }
                else
                {
                    Console.WriteLine("Bele kitab yoxdur");
                    Menu();
                }
            }
        }
        static void UpdateBook(int id, string name , string authorName)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.Books.Any(b => b.Id == id)) return;
                Book book = sql.Books.SingleOrDefault(b => b.Id == id);
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(authorName))
                {
                    book.Name = name;
                    book.AuthorName = authorName;
                }
                sql.SaveChanges();
            }
        }
        static void UpdateBookPrice(int id, int size, double prices)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.BookSizePrices.Any(b => b.Id == id)) return;
                BookSizePrice book = sql.BookSizePrices.SingleOrDefault(b => b.BookId == id && b.SizeId == size);
                book.Price = prices;
                sql.SaveChanges();
            }
        }
        static void RemoveBook(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.Books.Any(b => b.Id == id)) return;
                Book book = sql.Books.SingleOrDefault(b => b.Id == id);
                sql.Remove(book);
                sql.SaveChanges();
            }
        }
    
    }
}
