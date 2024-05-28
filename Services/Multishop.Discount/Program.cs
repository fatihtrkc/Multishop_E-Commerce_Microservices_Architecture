using FluentValidation;
using FluentValidation.AspNetCore;
using Multishop.Discount.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddFluentValidation
//                (b => { b.RegisterValidatorsFromAssemblyContaining<Program>().DisableDataAnnotationsValidation = true; });

builder.Services.AddControllers();
builder.Services.AddDiscountDataAccess(builder.Configuration);
builder.Services.AddDiscountRepositories();
builder.Services.AddDiscountServices();
builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
