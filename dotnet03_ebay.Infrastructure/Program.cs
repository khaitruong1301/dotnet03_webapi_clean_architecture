using dotnet03_ebay.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//EF framework
//ef-service

var app = builder.Build();

app.Run();

