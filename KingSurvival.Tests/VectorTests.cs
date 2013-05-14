using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;

[TestClass]
public class VactorTests
{
    [TestMethod]
    public void TestEqualsTwoEqualVectors()
    {
        Vector firstVector = new Vector(0, 0);
        Vector secondVector = new Vector(0, 0);

        bool actual = firstVector.Equals(secondVector);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestEqualsTwoUnequalVectors()
    {
        Vector firstVector = new Vector(7, 7);
        Vector secondVector = new Vector(6, 6);

        bool actual = firstVector.Equals(secondVector);
        bool expected = false;

        Assert.AreEqual(expected, actual);
    }
}
