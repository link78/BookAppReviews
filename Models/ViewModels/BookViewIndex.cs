using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAppCore.Models.ViewModels
{
    public class BookViewIndex
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }

        public string Publisher { get; set; }
        public int ReviewCount { get; set; }
        public string Name { get; set; }
        public int BooksCount { get; set; }


    }
}