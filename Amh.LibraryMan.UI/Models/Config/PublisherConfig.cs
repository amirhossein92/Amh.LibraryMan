using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.LibraryMan.UI.Models.Config
{
    public class PublisherConfig : EntityTypeConfiguration<Publisher>
    {
        public PublisherConfig()
        {
            this.Property(item => item.Name)
                .HasMaxLength(128)
                .IsRequired();
            this.Property(item => item.Address)
                .HasMaxLength(512);
        }
    }
}
