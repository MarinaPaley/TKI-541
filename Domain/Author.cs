// <copyright file="Authors.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;

    /// <summary>
    /// Автор.
    /// </summary>
    public sealed class Author : IEquatable<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="familyName">Фамилия.</param>
        /// <param name="surName">Отчество.</param>
        /// <exception cref="ArgumentNullException">Если имя или фамилия не определены <see langword="null"/>.</exception>
        public Author(string name, string familyName, string? surName = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
            this.FamilyName = familyName?.Trim() ?? throw new ArgumentNullException(nameof(familyName));
            this.SurName = string.IsNullOrEmpty(surName) ? null : surName;
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FamilyName { get; init; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? SurName { get; init; }

        /// <summary>
        /// Рукописи.
        /// </summary>
        public ISet<Manuscript> Manuscripts { get; set; } = new HashSet<Manuscript>();

        /// <summary>
        /// Добавляем рукопись.
        /// </summary>
        /// <param name="manuscript">Рукопись.</param>
        /// <returns><see langword="true"/> если книга была добавлена.</returns>
        public bool AddBook(Manuscript manuscript)
        {
            if (manuscript is null)
            {
                throw new ArgumentNullException(nameof(manuscript));
            }

            return this.Manuscripts.Add(manuscript);
        }

        /// <inheritdoc/>
        public bool Equals(Author? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name!.Equals(other.Name!)
                && this.FamilyName!.Equals(other.FamilyName!)
                && (this.SurName is null || other.SurName is null || this.SurName!.Equals(other.SurName!));
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => this.Equals(obj as Author);

        /// <inheritdoc/>
        public override int GetHashCode() => this.Id.GetHashCode();

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.SurName is not null
                ? $"{this.Name} {this.SurName} {this.FamilyName}"
                : $"{this.Name} {this.FamilyName}";
        }
    }
}
