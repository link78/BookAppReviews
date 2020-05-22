using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieWebAppCore.Abstract;
using MovieWebAppCore.Models;
using MovieWebAppCore.Data;

namespace MovieWebAppCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DBServer"] ?? "sqlServer";
            var port   = Configuration["DBPort"] ?? "1433";
            var user   = Configuration["DBUser"] ?? "SA";
            var password= Configuration["DBPassword"] ?? "Marine7815@@";
            var db     = Configuration["DBDatabase"] ?? "MovieWebDB";


            services.AddDbContext<BookDbContext>(options => 
                options.UseSqlServer($"Server={server},{port};Initial Catalog={db};User ID={user};Password={password}"));
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

           //SeedingData.Initializer(app);
        }
    }
}
