using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using PetsApi.Repositories;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);

builder.Services.AddDbContext<VeterinariaContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSQLServer"));
   //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
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
