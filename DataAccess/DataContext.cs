// <copyright file="DataContext.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DataAccess
{
    using System.Reflection;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Контекст доступа к данным.
    /// </summary>
    public sealed class DataContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DataContext"/>.
        /// </summary>
        /// <param name="options"> Опции контекста доступа к данным. </param>
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Издательства.
        /// </summary>
        public DbSet<Publishing> Publishings { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
