// <copyright file="ServiceCollectionExtensions.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DataAccess.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Класс коллекция методов расширения для <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Регистрирует контекст доступа к данным, связанный с конкретной БД.
        /// </summary>
        /// <param name="services"> Коллекция сервисов. </param>
        /// <param name="connectionString"> Строка подключения к БД. </param>
        /// <returns> Изменённая коллекция сервисов. </returns>
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            string? connectionString)
        {
            return services.AddDbContext<DataContext>(
                optionsBuilder =>
                    optionsBuilder.UseNpgsql(connectionString)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors());
        }
    }
}
