// <copyright file="Book.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Класс рукопись.
    /// </summary>
    public sealed class Book : IEquatable<Book>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="title">Название книги. </param>
        /// <param name="publishing">Издательство. </param>
        /// <param name="manuscripts"> Рукопись. </param>
        /// <param name="pageCount">Количество страниц. </param>
        public Book(string title, Publishing publishing, int pageCount, ISet<Manuscript> manuscripts)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Publishing = publishing;
            this.Manuscripts = manuscripts;
            this.PageCount = pageCount;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="title">Название книги. </param>
        /// <param name="publishing">Издательство. </param>
        /// <param name="pageCount">Рукопись. </param>
        /// <param name="manuscripts">Количество страниц. </param>
        public Book(string title, Publishing publishing, int pageCount, params Manuscript[] manuscripts)
            : this(title, publishing, pageCount, new HashSet<Manuscript>(manuscripts))
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
        /// Издательство.
        /// </summary>
        public Publishing Publishing { get; init; }

        /// <summary>
        /// Рукопись.
        /// </summary>
        public ISet<Manuscript> Manuscripts { get; init; } = new HashSet<Manuscript>();

        /// <summary>
        /// Количество страниц.
        /// </summary>
        public int PageCount { get; init; }

        /// <inheritdoc/>
        public bool Equals(Book? other)
        {
            return other is not null
                && this.Title.Equals(other.Title)
                && this.Manuscripts.SetEquals(other.Manuscripts);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) =>
            this.Equals(obj as Book);

        /// <inheritdoc/>
        public override int GetHashCode() =>
            this.Title.GetHashCode() * this.Manuscripts.GetHashCode();
    }
}