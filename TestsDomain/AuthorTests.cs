// <copyright file="AuthorTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace TestsDomain
{
    using Domain;

    /// <summary>
    /// Класс тестов на <see cref="Author"/>.
    /// </summary>
    [TestFixture]
    public class AuthorTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            Assert.DoesNotThrow(
                () => _ = new Author(name: "Лев", familyName: "Толстой", surName: "Николаевич"));
        }
    }
}
