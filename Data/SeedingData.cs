using MovieWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MovieWebAppCore.Data
{
    public static class SeedingData
    {
        public static void Initializer(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
        
             {
               SeedData(serviceScope.ServiceProvider.GetService<BookDbContext>());
              }

        }


        public static void SeedData(BookDbContext context)
        {
            System.Console.WriteLine("Applying Migrations......");

          //  context.Database.Migrate();

            context.Database.EnsureCreated();

        }
    }
}