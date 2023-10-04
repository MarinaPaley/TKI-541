// <copyright file="Manuscript.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;

    public class Manuscript : IEquatable<Manuscript>
    {
        public Guid Id { get; }
        public string Title { get; init; }
        public Author Author { get; init; }
        public bool Equals(Manuscript? other)
        {
            throw new NotImplementedException();
        }
    }
}
