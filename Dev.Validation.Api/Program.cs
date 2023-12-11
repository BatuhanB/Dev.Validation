using Dev.Validation.Api.Extensions.Handler;
using Dev.Validation.Api.Filters;
using Dev.Validation.Extensions;
using Dev.Validation.Validator;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandling>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
