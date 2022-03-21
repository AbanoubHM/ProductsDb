using Microsoft.EntityFrameworkCore;
using ProductsDb.Models;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Configuration.AddUserSecrets<Program>();
var connectionString = builder.Configuration.GetConnectionString("DbConnection");

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder => {
                          builder.WithOrigins("http://localhost:4200",
                              "http://localhost:4321");
                      });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<AngularFinalDemoContext>(options => options.UseSqlServer(connectionString));

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
