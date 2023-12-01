// <copyright file="AuthorTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Класс тестов на <see cref="Author"/>.
    /// </summary>
    [TestFixture]
    public sealed class AuthorTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            Assert.DoesNotThrow(
                () => _ = new Author(name: "Лев", familyName: "Толстой", surName: "Николаевич"));
        }

        [Test]
        public void Ctor_NullSurNameData_Success()
        {
            Assert.DoesNotThrow(
                () => _ = new Author(name: "Лев", familyName: "Толстой"));
        }

        [TestCase(null, "Толстой")]
        [TestCase("Лев", null)]
        [TestCase(null, null)]
        public void Ctor_WrongData_ThrowException(string? firstName, string? familyName)
        {
            Assert.Throws<ArgumentNullException>(
                () => _ = new Author(name: firstName!, familyName: familyName!));
        }

        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var author = new Author(name: "Лев", familyName: "Толстой", surName: "Николаевич");
            var expected = "Лев Николаевич Толстой";

            // Act
            var actual = author.ToString();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("Николаевич", "Николаевич")]
        [TestCase(null, "Николаевич")]
        [TestCase("Николаевич", null)]
        public void Equals_SameData_Equal(string? surName1, string? surName2)
        {
            // Arrange
            var author1 = new Author(name: "Лев", familyName: "Толстой", surName: surName1);
            var author2 = new Author(name: "Лев", familyName: "Толстой", surName: surName2);

            // Act & Assert
            Assert.That(author1, Is.EqualTo(author2));
        }
    }
}
