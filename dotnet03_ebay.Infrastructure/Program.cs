using dotnet03_ebay.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// service EF
var connectionString = builder.Configuration.GetConnectionString("connectionStringEbay");
builder.Services.AddDbContext<EbayContext>(options =>
    options.UseSqlServer(connectionString));



var app = builder.Build();


app.Run();
