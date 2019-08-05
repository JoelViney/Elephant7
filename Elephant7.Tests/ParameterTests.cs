using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Elephant7
{
    [TestClass]
    public class ParameterTests
    {
        [TestMethod]
        public void ParameterTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var rnd = mock.Object;

            // Act
            var value = rnd.NextParameter(7, 11);

            // Assert
            Assert.AreEqual(11, value);
        }

        [TestMethod]
        public void ParameterAlternateTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(0);
            var rnd = mock.Object;

            // Act
            var value = rnd.NextParameter(7, 11);

            // Assert
            Assert.AreEqual(7, value);
        }
    }
}
