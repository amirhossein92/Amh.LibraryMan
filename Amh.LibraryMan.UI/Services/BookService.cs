using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amh.LibraryMan.UI.Models;

namespace Amh.LibraryMan.UI.Services
{
    public class BookService
    {
        public void AddBook(Book book)
        {
            using (var dbContext = new LibraryDbContext())
            {
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
            }
        }

        public Book GetBookById(int bookId)
        {
            var result = new Book();

            using (var dbContext = new LibraryDbContext())
            {
                result = dbContext.Books.Find(bookId);
            }

            return result;
        }

        public List<Book> GetBooks(string bookTitle = null, string author = null, string publisher = null)
        {
            var result = new List<Book>();

            using (var dbContext = new LibraryDbContext())
            {
                var books = dbContext.Books.AsQueryable();
                if (!string.IsNullOrEmpty(bookTitle))
                    books = books.Where(item => item.Title.ToLower().Contains(bookTitle.ToLower()));
                if (!string.IsNullOrEmpty(author))
                    books = books.Where(item => item.Author.FirstName.ToLower().Contains(author.ToLower()) ||
                                                item.Author.LastName.ToLower().Contains(author.ToLower()));
                if (!string.IsNullOrEmpty(publisher))
                    books = books.Where(item => item.Publisher.Name.ToLower().Contains(publisher.ToLower()));
                result.AddRange(books.ToList());
            }

            return result;
        }

        public void EditBook(Book book)
        {
            using (var dbContext = new LibraryDbContext())
            {
                var bookInDb = dbContext.Books.Find(book.Id);
                bookInDb.Title = book.Title;
                bookInDb.AuthorId = book.AuthorId;
                bookInDb.PublishDate = book.PublishDate;
                bookInDb.SerialNumber = book.SerialNumber;
                bookInDb.PublisherId = book.PublisherId;
                bookInDb.Edition = book.Edition;
                bookInDb.Price = book.Price;
                dbContext.SaveChanges();
            }
        }

        public void DeleteBookByIndex(int bookId)
        {
            using (var dbContext = new LibraryDbContext())
            {
                var book = dbContext.Books.Find(bookId);
                dbContext.Books.Remove(book);
                dbContext.SaveChanges();
            }
        }
    }
}
