// <copyright file="BookTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Класс тестов на <see cref="Author"/>.
    /// </summary>
    [TestFixture]
    public sealed class BookTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            // Arrange
            var publishing = new Publishing("Тестовое издательство");
            var author = new Author(name: "Лев", familyName: "Толстой", surName: "Николаевич");
            var manuscript = new Manuscript("Тестовая рукопись 1", new DateOnly(1899, 01, 01), author);
            Assert.DoesNotThrow(
                () => _ = new Book(title: "Война и мир", publishing, 500, manuscript));
        }
    }
}
