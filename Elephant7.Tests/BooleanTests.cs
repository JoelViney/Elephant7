using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elephant7
{
    [TestClass]
    public class BooleanTests
    {
        [TestMethod]
        public void RandomBoolean()
        {
            // Arrange
            RandomEx.Random = new Random(0);

            // Act
            var result = RandomEx.Boolean();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
