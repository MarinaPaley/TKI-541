// <copyright file="Book.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using Staff.Extensions;

    /// <summary>
    /// Класс рукопись.
    /// </summary>
    public sealed class Book : IEquatable<Book>
    {
        public Book(string title, Publishing publishing, ISet<Manuscript> manuscripts, int pageCount)
        {
            this.Id = Guid.NewGuid();
            Title = title;
            Publishing = publishing;
            Manuscripts = manuscripts;
            PageCount = pageCount;
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public Publishing Publishing { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public ISet<Manuscript> Manuscripts { get; init; } = new HashSet<Manuscript>();

        /// <summary>
        /// 
        /// </summary>
        public int PageCount { get; init; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Equals(Book? other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Book);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}