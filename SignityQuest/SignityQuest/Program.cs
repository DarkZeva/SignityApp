using Microsoft.EntityFrameworkCore;
using SignityQuest.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TasksDBContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(options =>
options.WithOrigins("http://localhost:3000")
.AllowAnyHeader()
.AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
