using MovieWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAppCore.Abstract
{
   public interface IAuthorRepository
    {
        IQueryable<Author> Authors { get; }
        void SaveAuthor(Author newAdded);
        Author getAuthor(int id);
        Author DeleteAuthor(int id);

    }


    public class AuthorRepository : IAuthorRepository
    {

        private BookDbContext contex;

        public AuthorRepository(BookDbContext _context) { contex = _context; }


        /// <summary>
        /// 
        /// </summary>
        public IQueryable<Author> Authors => contex.Authors;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Author DeleteAuthor(int id)
        {
            var q = contex.Authors.FirstOrDefault(b => b.Id == id);
            if (q != null)
            {
                contex.Authors.Remove(q);
                contex.SaveChanges();
            }

            return q;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Author getAuthor(int id)
        {
            return Authors.Where(b => b.Id == id).FirstOrDefault();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="newAdded"></param>
        public void SaveAuthor(Author newAdded)
        {
            if (newAdded.Id == 0)
            {
                contex.Authors.Add(newAdded);
            }
            else
            {
                var entry = contex.Authors.FirstOrDefault(b => b.Id == newAdded.Id);

                if (entry != null)
                {
                    entry.Id = newAdded.Id;
                    entry.Name = newAdded.Name;
                    entry.BooksCount = newAdded.BooksCount;
                    

                }

            }

            contex.SaveChanges();
        }
    }
}