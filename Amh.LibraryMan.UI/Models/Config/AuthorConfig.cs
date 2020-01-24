using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.LibraryMan.UI.Models.Config
{
    public class AuthorConfig : EntityTypeConfiguration<Author>
    {
        public AuthorConfig()
        {
            this.Property(item => item.FirstName)
                .HasMaxLength(128)
                .IsRequired();
            this.Property(item => item.LastName)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
