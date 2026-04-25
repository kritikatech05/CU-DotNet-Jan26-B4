using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.Data;
using NorthwindCatalog.Services.Interfaces;
using NorthwindCatalog.Services.Mapping;
using NorthwindCatalog.Services.Repositories;

namespace NorthwindCatalog.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();

            // Database connection
            builder.Services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("NorthwindConnection")));

            // Repository Dependency Injection
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddHttpClient("NorthwindApi", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7106/");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
     name: "default",
     pattern: "{controller=Categories}/{action=Index}/{id?}");

            app.Run();
        }
    }
}