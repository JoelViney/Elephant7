using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Elephant7
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void PersonTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(123456789);
            var rnd = mock.Object;

            // Act
            var value = rnd.NextPerson();

            // Assert
            Assert.AreEqual("Sir Ahmed Ahmed Reagan", value.FullName);
        }
    }
}
