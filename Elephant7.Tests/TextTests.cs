using Elephant7.Texts;
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

            // Act
            var result = RandomTextExtensions.NextWord(mock.Object);

            // Assert
            Assert.AreEqual("A&P", result);
        }
    }
}
