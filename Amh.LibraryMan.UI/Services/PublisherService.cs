using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amh.LibraryMan.UI.Models;

namespace Amh.LibraryMan.UI.Services
{
    public class PublisherService
    {
        public List<Publisher> GetPublishers()
        {
            var result = new List<Publisher>();
            using (var dbContext = new LibraryDbContext())
            {
                result.AddRange(dbContext.Publishers.ToList());
            }

            return result;
        }

        public Publisher GetPublisherByIndex(int publisherId)
        {
            var result = new Publisher();

            using (var dbContext = new LibraryDbContext())
            {
                result = dbContext.Publishers.Find(publisherId);
            }

            return result;
        }

        public void EditPublihser(Publisher publisher)
        {
            using (var dbContext = new LibraryDbContext())
            {
                var publisherInDb = dbContext.Publishers.Find(publisher.Id);
                publisherInDb.Name = publisher.Name;
                publisherInDb.Address = publisher.Address;
                dbContext.SaveChanges();
            }
        }

        public void AddPublihsher(Publisher publisher)
        {
            using (var dbContext = new LibraryDbContext())
            {
                dbContext.Publishers.Add(publisher);
                dbContext.SaveChanges();
            }
        }

        public void DeleteByIndex(int publisherId)
        {
            using (var dbContext = new LibraryDbContext())
            {
                var publisher = dbContext.Publishers.Find(publisherId);
                dbContext.Publishers.Remove(publisher);
                dbContext.SaveChanges();
            }
        }
    }
}
