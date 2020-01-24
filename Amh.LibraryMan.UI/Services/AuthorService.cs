using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amh.LibraryMan.UI.Data;
using Amh.LibraryMan.UI.Models;

namespace Amh.LibraryMan.UI.Services
{
    public class AuthorService
    {
        public List<Author> GetAuthors()
        {
            var result = new List<Author>();

            using (var dbContext = new LibraryDbContext())
            {
                result.AddRange(dbContext.Authors.ToList());
            }

            return result;
        }

        public Author GetAuthorById(int authorId)
        {
            using (var dbContext = new LibraryDbContext())
            {
                var author = dbContext.Authors.Find(authorId);
                return author;
            }
        }

        public void EditAuthor(Author editedAuthor)
        {
            using (var dbContext = new LibraryDbContext())
            {
                var author = dbContext.Authors.Find(editedAuthor.Id);
                author.FirstName = editedAuthor.FirstName;
                author.LastName = editedAuthor.LastName;

                dbContext.SaveChanges();
            }
        }

        public void AddAuthor(Author author)
        {
            using (var dbContext = new LibraryDbContext())
            {
                dbContext.Authors.Add(author);
                dbContext.SaveChanges();
            }
        }

        public void DeleteAuthorById(int authorId)
        {
            using (var dbContext = new LibraryDbContext())
            {
                var author = dbContext.Authors.Find(authorId);
                dbContext.Authors.Remove(author);
                dbContext.SaveChanges();
            }
        }
    }
}
