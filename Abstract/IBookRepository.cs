using MovieWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAppCore.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
        void SaveMovie(Book newAdded);
        Book getBook(int id);
        Book DeleteMovie(int id);

    }


    public class BookRepository : IBookRepository
    {

        private BookDbContext contex;

        public BookRepository(BookDbContext _context) { contex = _context; }


        /// <summary>
        /// 
        /// </summary>
        public IQueryable<Book> Books => contex.Books;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book DeleteMovie(int id)
        {
            var q = contex.Books.FirstOrDefault(b => b.Id == id);
            if (q != null)
            {
                contex.Books.Remove(q);
                contex.SaveChanges();
            }

            return q;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Book getBook(int id)
        {
            return Books.Where(b => b.Id == id).FirstOrDefault();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="newAdded"></param>
        public void SaveMovie(Book newAdded)
        {
            if (newAdded.Id == 0)
            {
                contex.Books.Add(newAdded);
            }
            else
            {
                var entry = contex.Books.FirstOrDefault(b => b.Id == newAdded.Id);

                if (entry != null)
                {
                    entry.Title = newAdded.Title;
                    entry.Genre = newAdded.Genre;
                    entry.Price = newAdded.Price;
                    entry.Publiser = newAdded.Publiser;
                    entry.Year = newAdded.Year;
                    entry.AuthorID = newAdded.AuthorID;

                }

            }

            contex.SaveChanges();
        }
    }
}