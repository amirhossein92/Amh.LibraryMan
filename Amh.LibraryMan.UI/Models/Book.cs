using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.LibraryMan.UI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int Edition { get; set; }
        public int PublishDate { get; set; }
        public string SerialNumber { get; set; }

        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
