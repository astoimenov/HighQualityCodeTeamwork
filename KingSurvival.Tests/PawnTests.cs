using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;

[TestClass]
public class PawnTests
{
    [TestMethod]
    public void TestCanMoveValidInitialMoveFirstPawnDownRight()
    {
        Vector fromPosition = new Vector(0, 0);
        Vector toPosition = new Vector(1, 1);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveSecondPawnDownRight()
    {
        Vector fromPosition = new Vector(2, 0);
        Vector toPosition = new Vector(3, 1);

        Pawn pawn = new Pawn('B');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveSecondPawnDownLeft()
    {
        Vector fromPosition = new Vector(2, 0);
        Vector toPosition = new Vector(1, 1);

        Pawn pawn = new Pawn('B');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveThirdPawnDownRight()
    {
        Vector fromPosition = new Vector(4, 0);
        Vector toPosition = new Vector(5, 1);

        Pawn pawn = new Pawn('C');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveThirdPawnDownLeft()
    {
        Vector fromPosition = new Vector(4, 0);
        Vector toPosition = new Vector(3, 1);

        Pawn pawn = new Pawn('C');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveForthPawnDownRight()
    {
        Vector fromPosition = new Vector(6, 0);
        Vector toPosition = new Vector(7, 1);

        Pawn pawn = new Pawn('D');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveValidMoveDownLeft()
    {
        Vector fromPosition = new Vector(4, 4);
        Vector toPosition = new Vector(3, 5);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveValidMoveDownRight()
    {
        Vector fromPosition = new Vector(4, 4);
        Vector toPosition = new Vector(5, 5);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveValidLastMoveDownRight()
    {
        Vector fromPosition = new Vector(2, 6);
        Vector toPosition = new Vector(1, 7);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidMoveUpRight()
    {
        Vector fromPosition = new Vector(5, 5);
        Vector toPosition = new Vector(6, 4);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = false;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidMoveUpLeft()
    {
        Vector fromPosition = new Vector(5, 5);
        Vector toPosition = new Vector(4, 4);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = false;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidInitialMoveStraightDown()
    {
        Vector fromPosition = new Vector(0, 0);
        Vector toPosition = new Vector(0, 1);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition);
        bool expected = false;

        Assert.AreEqual(expected, actual);
    }
}
