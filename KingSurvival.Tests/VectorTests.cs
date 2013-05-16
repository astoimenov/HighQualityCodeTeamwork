namespace KingSurvival.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void TestEqualsTwoEqualVectors()
        {
            Vector firstVector = new Vector(0, 0);
            Vector secondVector = new Vector(0, 0);

            bool actual = firstVector.Equals(secondVector);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestEqualsTwoUnequalVectors()
        {
            Vector firstVector = new Vector(7, 7);
            Vector secondVector = new Vector(6, 6);

            bool actual = firstVector.Equals(secondVector);

            Assert.IsFalse(actual);
        }
    }
}
