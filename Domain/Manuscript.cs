﻿// <copyright file="Manuscript.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;

    /// <summary>
    /// Класс рукопись.
    /// </summary>
    public sealed class Manuscript : IEquatable<Manuscript>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Manuscript"/>.
        /// </summary>
        /// <param name="title"> Название.</param>
        /// <param name="authors">Авторы.</param>
        /// <exception cref="ArgumentNullException"> Если название <see langword="null"/>.</exception>
        public Manuscript(string title, ISet<Author>? authors = null)
        {
            this.Id = Guid.NewGuid();
            this.Title = string.IsNullOrEmpty(title?.Trim()) ?? throw new ArgumentNullException(nameof(title));
            if (authors != null)
            {
                foreach (var author in authors)
                {
                    this.Authors.Add(author);
                    author.AddBook(this);
                }
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Manuscript"/>.
        /// </summary>
        /// <param name="title"> Название.</param>
        /// <param name="authors">Авторы.</param>
        /// <exception cref="ArgumentNullException"> Если название <see langword="null"/>.</exception>
        public Manuscript(string title, params Author[] authors)
            : this(title, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Список авторов.
        /// </summary>
        public ISet<Author> Authors { get; init; } = new HashSet<Author>();

        /// <inheritdoc/>
        public bool Equals(Manuscript? other)
        {
            if (ReferenceEquals(null, other) && other is null)
            {
                return false;
            }

            return this.Title.Equals(other.Title)
                && this.Authors.SetEquals(other.Authors);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) =>
            this.Equals(obj as Manuscript);

        /// <inheritdoc/>
        public override int GetHashCode() =>
            this.Title.GetHashCode() * this.Authors.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() =>
            $"{this.Title} {string.Join(",", this.Authors)}";
    }
}
