using MovieWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebAppCore.Data
{
    public static class SeedingData
    {
        public static void Initializer(BookDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Authors.Any())
            {
                return;
            }

            var authors = new Author[]
            {
                new Author{ Name="Armistead Maupin", BooksCount=23},
                new Author{Name="David Talbot", BooksCount=5},
                new Author {Name="Nathanael West", BooksCount=22},
                new Author{Name="James Ellroy", BooksCount=5},
                new Author {Name="John Steinbeck", BooksCount=3}
            };

            foreach (var a in authors)
            {
                context.Authors.Add(a);
            }


            var books = new Book[]
            {
                new Book { AuthorID=1, Title="Tales of the City", Genre="Fictions", Price=9.99m, Year=1958, Publiser="Amazon"},
                new Book { AuthorID=1, Title="Of Mice and Men", Genre="Novella", Price=5.99m, Year=1978, Publiser="Atomic Drop Press"},
                new Book { AuthorID=1, Title="Where I Was From", Genre="Adventure", Price=19.99m, Year=2000, Publiser="Musa Publishing"},
                new Book { AuthorID=1, Title="We Tell Ourselves Stories in Order to Live", Genre="Essay", Price=12.99m, Year=2005, Publiser="Alfresco Press"},

                new Book { AuthorID=2, Title="Blue Nights", Genre="Memoire", Price=19.99m, Year=2011, Publiser="Barking Rain Press"},
                new Book { AuthorID=2, Title="Run, River", Genre="Fictions", Price=7.99m, Year=2012, Publiser="Arma Technologies"},
                new Book { AuthorID=2, Title="Run, River", Genre="Essay", Price=9.99m, Year=2001, Publiser="Chances Press, LLC"},
                new Book { AuthorID=2, Title="Get Out", Genre="Horror", Price=9.99m, Year=2012, Publiser="Kore Press"},

                new Book { AuthorID=3, Title="My Sister's Keeper", Genre="Thriller", Price=12.99m, Year=1998, Publiser="Kore Press"},
                new Book { AuthorID=3, Title="Gone Girl", Genre="Fictions", Price=9.99m, Year=2005, Publiser="Broadway Books"},
                new Book { AuthorID=3, Title="The Chronicles of Narnia", Genre="Fantastic", Price=9.99m, Year=2012, Publiser="HarperCollins"},
                new Book { AuthorID=3, Title="Assassin's Apprentice", Genre="Fantastic", Price=15.99m, Year=2008, Publiser="Robin Hobb"},

                new Book { AuthorID=4, Title="Ender's Game", Genre="Sci-Fi", Price=19.99m, Year=2000, Publiser="Tor"},
                new Book { AuthorID=4, Title="I, Robot", Genre="Sci-Fi", Price=9.99m, Year=2004, Publiser="Spectra"},
                new Book { AuthorID=4, Title="Slaughterhouse-Five", Genre="Fictions", Price=9.99m, Year=1999, Publiser="Dial Press"},
                new Book { AuthorID=4, Title="Pride and Prejudice", Genre="Crime-Dram", Price=9.99m, Year=1988, Publiser="Amazon"}

            };

            foreach (var b in books)
            {
                context.Books.Add(b);
            }


            var reviews = new Review[]
            {
                new Review{BookId=1, Rating=4, UserName="#GoForIt", Body="Best book i ever read"},
                new Review{BookId=1, Rating=5, UserName="#GoForIt", Body="Best book i ever read, i really recommend to anyone"},
                new Review{BookId=2, Rating=4, UserName="Jane", Body="It was very confusing and at the sane time interesting"},
                new Review{BookId=6, Rating=2, UserName="#LifeShort", Body="It was boring but i lked the characters in the book"},

                new Review{BookId=5, Rating=4, UserName="#ShootFirst", Body="I just loved ittttttt"},
                new Review{BookId=5, Rating=5, UserName="#fromHell", Body="I would like to see the movie!!!#MakeIt"},
                new Review{BookId=2, Rating=5, UserName="#Josh", Body="I wish it were short but i enjoyed it"},
                new Review{BookId=2, Rating=3, UserName="Fry", Body="This contains some information educative"},

                new Review{BookId=3, Rating=4, UserName="#GoForIt", Body="Best book i ever read"},
                new Review{BookId=3, Rating=4, UserName="Katrine", Body="Best book i ever read"},
                new Review{BookId=4, Rating=4, UserName="Aline", Body="I can read again. Liked it"},
                new Review{BookId=8, Rating=4, UserName="Kelly", Body="Good"}

            };

            foreach (var r in reviews) { context.Reviews.Add(r); }


            context.SaveChanges();
        }
    }
}