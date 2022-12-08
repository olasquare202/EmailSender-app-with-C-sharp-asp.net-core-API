using Microsoft.Extensions.Options;
using SendmailAPI.Interfaces;
using SendmailAPI.Models;
using SendmailAPI.services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<Appsetting>(configuration.GetSection(nameof(Appsetting)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMailServices, EmailServices>();
builder.Services.AddScoped<Appsetting>();
builder.Services.AddScoped<ITestClass, EmailSender > ();

builder.Services.AddScoped(v => v.GetRequiredService<IOptions<Appsetting>>().Value);

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
