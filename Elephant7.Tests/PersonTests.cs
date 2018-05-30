using Elephant7.People;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elephant7
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void NumberTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(3);
            
            // Act
            var result = RandomPersonExtensions.NextPerson(mock.Object);

            // Assert
            Assert.AreEqual(3, result);
        }
    }
}
