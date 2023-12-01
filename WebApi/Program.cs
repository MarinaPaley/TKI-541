// <copyright file="Program.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace WebApi
{
    using System;
    using System.IO;
    using System.Reflection;
    using DataAccess.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Программа.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"> Аргументы. </param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc(
                        name: "v1",
                        info: new OpenApiInfo
                        {
                            Title = "Демонстрационный вариант WebAPI",
                            Description = "Это сделано специально, чтобы показать как хорошо",
                            Version = "v1",
                        });

                    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                });

            _ = builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());

            // @NOTE: Косое, но зато понятное применени user-secrets, "а то сидим как..."
            var connectionString = builder.Configuration.GetConnectionString("Default");
            connectionString += $"Password={builder.Configuration["DatabasePassword"]};";
            _ = builder.Services.AddDatabase(connectionString);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // UseCors must be placed after UseRouting and before UseAuthorization.
            app.UseCors(
                builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
