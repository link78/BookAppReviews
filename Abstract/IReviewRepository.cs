using MovieWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAppCore.Abstract
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        void SaveMovie(Review newAdded);
        Review getReview(int id);
        Review DeleteMovie(int id);

    }


    public class ReviewRepository : IReviewRepository
    {

        private BookDbContext contex;

        public ReviewRepository(BookDbContext _context) { contex = _context; }


        /// <summary>
        /// 
        /// </summary>
        public IQueryable<Review> Reviews => contex.Reviews;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Review DeleteMovie(int id)
        {
            var q = contex.Reviews.FirstOrDefault(b => b.Id == id);
            if (q != null)
            {
                contex.Reviews.Remove(q);
                contex.SaveChanges();
            }

            return q;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Review getReview(int id)
        {
            return Reviews.Where(b => b.Id == id).FirstOrDefault();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="newAdded"></param>
        public void SaveMovie(Review newAdded)
        {
            if (newAdded.Id == 0)
            {
                contex.Reviews.Add(newAdded);
            }
            else
            {
                var entry = contex.Reviews.FirstOrDefault(b => b.Id == newAdded.Id);
                // contex.Entry(newAdded).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                if (entry != null)
                {
                    entry.Body = newAdded.Body;
                    entry.Rating = newAdded.Rating;
                    entry.UserName = newAdded.UserName;


                }

            }

            contex.SaveChanges();
        }
    }
}
