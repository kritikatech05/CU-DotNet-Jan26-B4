using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.Data;
using NorthwindCatalog.Services.Interfaces;
using NorthwindCatalog.Services.Mapping;
using NorthwindCatalog.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("NorthwindConnection")));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();