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
            var random = new RandomEx(mock.Object);

            // Act
            var result = random.Boolean();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
