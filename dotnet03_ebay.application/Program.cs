using dotnet03_ebay.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("connectionStringEbay");
builder.Services.AddDbContext<EbayContext>(options =>
    options.UseSqlServer(connectionString));


//DI các repository để dùng trong các lớp service
// builder.Services.AddScoped<IRepository, Repository>();







var app = builder.Build();

app.Run();

