using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elephant7
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public void WordTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var random = new RandomEx(mock.Object);

            // Act
            var result = random.Text.Word();

            // Assert
            Assert.AreEqual("Wiggle", result);
        }
    }
}
