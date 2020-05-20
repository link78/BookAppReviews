using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAppCore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a title name")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a year date")]

        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter a price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a genre name")]
        public string Genre { get; set; }

        public string Publiser { get; set; }

        [Required(ErrorMessage = "Please enter an Author Id")]
        public int? AuthorID { get; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }

    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }


        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}