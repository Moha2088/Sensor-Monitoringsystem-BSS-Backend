using BSS_Backend_Opgave.API.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BSS_Backend_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BSS_Backend_SQLSERVER") ??
                         throw new InvalidOperationException("Connection string 'BSS_Backend_SQLSERVER' not found.")));

// Add services to the container.

builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<EventHub>("/event");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
