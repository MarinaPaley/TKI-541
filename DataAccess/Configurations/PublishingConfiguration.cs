// <copyright file="PublishingConfiguration.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DataAccess.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Правила отображения для сущности <see cref="Publishing"/>.
    /// </summary>
    internal sealed class PublishingConfiguration : IEntityTypeConfiguration<Publishing>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Publishing> builder)
        {
            _ = builder.Property(x => x.Id)
                .IsRequired()
                .HasComment("Идентификатор");

            _ = builder.HasKey(x => x.Id);

            _ = builder.Property(x => x.Name)
                .IsRequired()
                .HasComment("Название");

            _ = builder.Property(x => x.Contact)
                .IsRequired(false)
                .HasComment("Контактные данные издательства");
        }
    }
}
