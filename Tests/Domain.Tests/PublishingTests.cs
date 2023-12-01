// <copyright file="PublishingTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Класс тестов на <see cref="Publishing"/>.
    /// </summary>
    [TestFixture]
    public sealed class PublishingTests
    {
        [Test]
        public void Ctor_ValdData_Success()
        {
            Assert.DoesNotThrow(() => _ = new Publishing("Лань"));
        }

        [Test]
        public void Ctor_NullName_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new Publishing(null!));
        }

        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var publishing = new Publishing("Лань");

            var expected = "Лань";

            // Act
            var actual = publishing.ToString();

            // Assert
            Assert.That(expected, Is.Not.Null);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Equals_SameData_Equal()
        {
            // Arrange
            var publishing = new Publishing("Лань");

            var other = new Publishing("Не Лань");

            // Act
            var actual = publishing.Equals(other);

            // Assert
            Assert.That(actual, Is.False);
        }
    }
}
