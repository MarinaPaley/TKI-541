// <copyright file="PublishingTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace TestsDomain
{
    using Domain;

    /// <summary>
    /// Класс тестов на <see cref="Publishing"/>.
    /// </summary>
    [TestFixture]
    public class PublishingTests
    {
        [Test]
        public void Ctor_ValdData_Success()
        {
            Assert.DoesNotThrow(() => _ = new Publishing("Лань"));
        }

        [Test]
        public void Ctor_NullName_ThrowException()
        {
            Assert.Throws<NullReferenceException>(() => _ = new Publishing(null!));
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
            Assert.That(expected!.Equals(actual), Is.True);
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
            Assert.IsFalse(actual);
        }
    }
}