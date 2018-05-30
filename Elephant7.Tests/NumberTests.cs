﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

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

            // Act
            var result = RandomExtensions.Number(mock.Object, 1, 10);

            // Assert
            Assert.AreEqual(3, result);
        }
    }
}
