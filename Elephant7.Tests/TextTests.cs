using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
            var rnd = mock.Object;

            // Act
            var result = rnd.NextWord();

            // Assert
            Assert.AreEqual("A&P", result);
        }
    }
}
