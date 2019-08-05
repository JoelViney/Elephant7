using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Elephant7
{
    [TestClass]
    public class EnumTests
    {
        [TestMethod]
        public void EnumTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            var rnd = mock.Object;

            // Act
            var value = rnd.NextEnum<DayOfWeek>();

            // Assert
            Assert.AreEqual(DayOfWeek.Tuesday, value);
        }

        [TestMethod]
        public void EnumAlternateTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var rnd = mock.Object;

            // Act
            var value = rnd.NextEnum<DayOfWeek>();

            // Assert
            Assert.AreEqual(DayOfWeek.Monday, value);
        }
    }
}
