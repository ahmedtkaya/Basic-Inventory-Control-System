﻿using InventoryControl.Models;
using InventoryControl.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<InventoryControlDatabaseSettings>(
    builder.Configuration.GetSection("InventoryControlDatabase"));

//Important point!!!
builder.Services.AddSingleton<ProductsService>();
builder.Services.AddSingleton<CategoryService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

