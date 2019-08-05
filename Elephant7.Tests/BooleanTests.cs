using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
            var rnd = mock.Object;

            // Act
            var result = rnd.NextBoolean();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BooleanAlternateTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(0);
            var rnd = mock.Object;

            // Act
            var result = rnd.NextBoolean();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
