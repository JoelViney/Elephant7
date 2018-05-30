using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Elephant7
{
    [TestClass]
    public class BooleanTests
    {
        [TestMethod]
        public void BooleanTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);

            // Act
            var result = RandomExtensions.NextBoolean(mock.Object);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BooleanAlternateTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(0);

            // Act
            var result = RandomExtensions.NextBoolean(mock.Object);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
