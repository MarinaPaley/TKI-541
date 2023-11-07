// <copyright file="Publishing.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Издательство.
    /// </summary>
    public sealed class Publishing : IEquatable<Publishing>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Publishing"/>.
        /// </summary>
        /// <param name="name"> Название издательства.</param>
        /// <param name="contact"> Контактные данные.</param>
        /// <exception cref="ArgumentNullException">Если название <see langword="null"/>. </exception>
        public Publishing(string name, string? contact = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
            this.Contact = contact;
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название издательства.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Контактные данные.
        /// </summary>
        public string? Contact { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object? other)
        {
            return other is Publishing publishing && this.Equals(publishing);
        }

        /// <inheritdoc/>
        public bool Equals(Publishing? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name.Equals(other.Name);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Id.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name;
    }
}
