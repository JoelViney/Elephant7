using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Elephant7
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void ListTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var rnd = mock.Object;

            // Act
            var list = new string[] { "John", "Jack", "Billy", "Kevin" };
            var item = rnd.NextListItem<string>(list);

            // Assert
            Assert.AreEqual("Jack", item);
        }

        [TestMethod]
        public void ListAlternateTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            var rnd = mock.Object;

            // Act
            var list = new string[] { "John", "Jack", "Billy", "Kevin" };
            var item = rnd.NextListItem<string>(list);

            // Assert
            Assert.AreEqual("Billy", item);
        }

        [TestMethod]
        public void EmptyListTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            var rnd = mock.Object;

            // Act
            var list = new string[] {  };
            var item = rnd.NextListItem<string>(list);

            // Assert
            Assert.IsNull(item);
        }
    }
}
