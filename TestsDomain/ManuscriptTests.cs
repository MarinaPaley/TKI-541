// <copyright file="ManuscriptTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace TestsDomain
{
    using System;
    using Domain;
    using NUnit.Framework;

    [TestFixture]
    [Ignore("Логика пока не реализована.")]
    public class ManuscriptTests
    {
        [Test]
        public void Ctor_Valid_Success()
        {
            // arrange
            var date = DateOnly.FromDateTime(DateTime.Today);

            // act & assert
            Assert.DoesNotThrow(
                () => { _ = new Manuscript("Тестовое название", date); });
        }

        [Test]
        public void Ctor_TitleNull_ThrowException()
        {
            // arrange
            var date = DateOnly.FromDateTime(DateTime.Today);

            // act & assert
            Assert.Throws<ArgumentNullException>(
                () => { _ = new Manuscript(null!, date); });
        }

        [Test]
        public void Ctor_TitleEmpty_ThrowException()
        {
            // arrange
            var date = DateOnly.FromDateTime(DateTime.Today);

            // act & assert
            Assert.Throws<ArgumentNullException>(
                () => { _ = new Manuscript(string.Empty, date); });
        }
    }
}
