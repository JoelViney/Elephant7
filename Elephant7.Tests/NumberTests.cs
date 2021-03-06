﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Elephant7
{
    [TestClass]
    public class NumberTests
    {
        [TestMethod]
        public void NumberTest()
        {
            // Arrange
            var mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(3);
            var rnd = mock.Object;

            // Act
            var result = rnd.Number(1, 10);

            // Assert
            Assert.AreEqual(3, result);
        }
    }
}
