using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amh.LibraryMan.UI.Models;
using Amh.LibraryMan.UI.Models.Config;

namespace Amh.LibraryMan.UI.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("LibraryDbContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AuthorConfig());
            modelBuilder.Configurations.Add(new PublisherConfig());
            modelBuilder.Configurations.Add(new BookConfig());
        }
    }
}
