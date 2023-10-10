// <copyright file="ManuscriptTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace TestsDomain
{
    using Domain;

    [TestFixture]
    public class ManuscriptTests
    {
        [Test]
        public void Ctor_Valid_Success()
        {
            Assert.DoesNotThrow(
                () => { _ = new Manuscript("Тестовое название"); });
        }

        [Test]
        public void Ctor_TitleNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(
                () => { _ = new Manuscript(null!); });
        }

        [Test]
        public void Ctor_TitleEmpty_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(
                () => { _ = new Manuscript(string.Empty); });
        }
    }
}
