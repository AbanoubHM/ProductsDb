using Microsoft.EntityFrameworkCore;
using ProductsDb.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder => {
                          builder.WithOrigins("https://abanoubhm.github.io");
                      });
});
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
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
