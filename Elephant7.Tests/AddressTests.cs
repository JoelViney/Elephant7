using Elephant7.Australia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Elephant7
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void AddressTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(123456789);
            var rnd = mock.Object;

            // Act
            var value = rnd.NextAddress();

            // Assert
            Assert.AreEqual("1000 Redoubt Slope", value.Street1);
        }

    }
}
