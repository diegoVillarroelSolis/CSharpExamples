using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ef_webapi_books_example.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}