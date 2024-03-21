using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

           // LibraryContainer context = new LibraryContainer();
            /*context.authors.Add(new author()
            {
                author_name="Steve",
                author_surname="Petrov",
                age=20
            });
            context.authors.Add(new author()
            {
                author_name = "Robin",
                author_surname = "Hud",
                age = 30
            });*/
            /*
                        context.countries.Add(new countrie()
                        { 
                            country="Uk"
                        });
                        context.countries.Add(new countrie()
                        {
                            country = "Germany"
                        });*/
            /* context.languages.Add(new language()
             {
                 language_name= "en",
                 countrie_country_id=1
             });
             context.languages.Add(new language()
             {
                 language_name = "ger",
                 countrie_country_id=2
             });*/



            /*   context.books.Add(new book() { book_name = "ABC", author_author_id = 1, language_language_id = 1, pages_count = 100 });
               context.books.Add(new book() { book_name = "Main Kamf", author_author_id = 2, language_language_id = 2, pages_count = 500 });
               context.SaveChanges();*/
            using (LibraryContainer context = new LibraryContainer())
            {
                var books1 = context.books.Where(b => b.pages_count > 100);

                var books2 = context.books.Where(b => b.book_name.StartsWith("A") || b.book_name.StartsWith("a"));

                var books3 = context.books.Where(b => b.author.author_name == "William" && b.author.author_surname == "Shakespeare");

                var books4 = context.books.Where(b => b.language.language_name == "ukr");

                var books5 = context.books.Where(b => b.book_name.Length < 10);

                var maxPages = context.books.Where(b => b.language.language_name == "eng").Max(b => b.pages_count);
                var books6 = context.books.Where(b => b.pages_count == maxPages && b.language.language_name == "eng");

                var authorWithMinBooks = context.authors.OrderBy(a => a.books.Count).FirstOrDefault();

                var authorNames = context.authors.Where(a => a.books.Any(b => b.language.language_name != "eng")).OrderBy(a => a.author_name).Select(a => a.author_name);

                var countryWithMostBooks = context.countries.OrderByDescending(c => c.books.Count).FirstOrDefault();

                var authorsWithMultipleLanguages = context.authors.Where(a => a.books.Select(b => b.language_language_id).Distinct().Count() > 1).OrderBy(a => a.books.Select(b => b.language_language_id).Distinct().Count());
            }
        }
    }
}
