using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.LibraryMan.UI.Models.Config
{
    public class BookConfig : EntityTypeConfiguration<Book>
    {
        public BookConfig()
        {
            this.Property(item => item.Title)
                .HasMaxLength(256)
                .IsRequired();
            this.Property(item => item.SerialNumber)
                .HasMaxLength(16)
                .IsRequired();
        }
    }
}
