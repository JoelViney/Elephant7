using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elephant7
{
    [TestClass]
    public class EitherTests
    {
        [TestMethod]
        public void EitherTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var random = new RandomEx(mock.Object);

            // Act
            var value = random.Either(7, 11);

            // Assert
            Assert.AreEqual(11, value);
        }

        [TestMethod]
        public void EitherAlternateTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(0);
            var random = new RandomEx(mock.Object);

            // Act
            var value = random.Either(7, 11);

            // Assert
            Assert.AreEqual(7, value);
        }
    }
}
