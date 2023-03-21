using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MongoDbExample.Commands;
using MongoDbExample.Handlers;
using MongoDbExample.Models;
using MediatR;
//using MongoDbExample.Services;


var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<ProductStoreSetting>(
            builder.Configuration.GetSection("ProductsDatabase"));

//builder.Services.AddSingleton<ProductsService>();

    builder.Services.AddMediatR(typeof(Program).Assembly);

    builder.Services.AddControllers()
            .AddJsonOptions(
                options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddCors(options => { options.AddPolicy("AllowAllOrigins", builder => { builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod(); }); });

var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

        app.MapControllers();

        app.Run();
    