using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Elephant7
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void DateTimeTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(123456789);
            var rnd = mock.Object;

            // Act
            var value = rnd.NextDateTime();

            // Assert
            Assert.AreEqual(new DateTime(235, 09, 25, 21, 9, 0), value);
        }

        [TestMethod]
        public void DateTimeRangeTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(8008);
            var rnd = mock.Object;

            // Act 
            var value = rnd.NextDateTime(new DateTime(2000, 01, 01), new DateTime(2001, 01, 01));

            // Assert
            Assert.AreEqual(new DateTime(2000, 01, 06, 13, 28, 0), value);
        }
    }
}
