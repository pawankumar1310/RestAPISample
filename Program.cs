using Microsoft.EntityFrameworkCore;
using RestAPISample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
     options.SwaggerDoc("v1",
    new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title="Tech Avant-Garde",
        Description="WEB API",
        Version="v1"
    });
});

//Configuring and adding a database context to the dependency injection container
builder.Services.AddDbContext<StudentDbDemoContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
