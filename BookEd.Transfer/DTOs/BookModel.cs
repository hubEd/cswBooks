using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEd.Transfer.DTOs
{
    public class BookModel
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }   
        public int CategoryId { get; set; }
        public AuthorModel Author { get; set; }
        public CategoryModel Category { get; set; }

        public string Name { get; set; }
        public int Pages { get; set; }
    }
}
