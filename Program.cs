using Microsoft.EntityFrameworkCore;
using ProductsDb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AngularFinalDemoContext>(options => options.UseSqlServer("Data Source=tcp:productsdbdbserver.database.windows.net,1433;Initial Catalog=ProductsDb_db;User Id=handmade@productsdbdbserver;Password=H@ndmade"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
