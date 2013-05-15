using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;
using System.Collections.Generic;

[TestClass]
public class PawnTests
{
    [TestMethod]
    public void TestCanMoveValidInitialMoveFirstPawnDownRight()
    {
        Vector fromPosition = new Vector(0, 0);
        Vector toPosition = new Vector(1, 1);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveSecondPawnDownRight()
    {
        Vector fromPosition = new Vector(2, 0);
        Vector toPosition = new Vector(3, 1);

        Pawn pawn = new Pawn('B');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveSecondPawnDownLeft()
    {
        Vector fromPosition = new Vector(2, 0);
        Vector toPosition = new Vector(1, 1);

        Pawn pawn = new Pawn('B');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveThirdPawnDownRight()
    {
        Vector fromPosition = new Vector(4, 0);
        Vector toPosition = new Vector(5, 1);

        Pawn pawn = new Pawn('C');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveThirdPawnDownLeft()
    {
        Vector fromPosition = new Vector(4, 0);
        Vector toPosition = new Vector(3, 1);

        Pawn pawn = new Pawn('C');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveForthPawnDownRight()
    {
        Vector fromPosition = new Vector(6, 0);
        Vector toPosition = new Vector(7, 1);

        Pawn pawn = new Pawn('D');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidMoveDownLeft()
    {
        Vector fromPosition = new Vector(4, 4);
        Vector toPosition = new Vector(3, 5);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidMoveDownRight()
    {
        Vector fromPosition = new Vector(4, 4);
        Vector toPosition = new Vector(5, 5);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidLastMoveDownRight()
    {
        Vector fromPosition = new Vector(2, 6);
        Vector toPosition = new Vector(1, 7);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidMoveUpRight()
    {
        Vector fromPosition = new Vector(5, 5);
        Vector toPosition = new Vector(6, 4);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidMoveUpLeft()
    {
        Vector fromPosition = new Vector(5, 5);
        Vector toPosition = new Vector(4, 4);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidInitialMoveStraightDown()
    {
        Vector fromPosition = new Vector(0, 0);
        Vector toPosition = new Vector(0, 1);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void TestCanMoveAttackingUp1()
    {
        Vector fromPosition = new Vector(1, 1);
        Vector toPosition = new Vector(2, 2);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void TestCanMoveAttackingUp2()
    {
        Vector fromPosition = new Vector(2, 2);
        Vector toPosition = new Vector(1, 1);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveAttackingDown1()
    {
        Vector fromPosition = new Vector(1, 1);
        Vector toPosition = new Vector(1, 2);

        Pawn pawn = new Pawn('A');
        bool actual = pawn.CanMove(fromPosition, toPosition, false);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void TestGetPossibleNewPositionsValidPositions()
    {
        Vector initialPosition = new Vector(4, 6);

        Pawn pawn = new Pawn('A');
        List<Vector> actual = pawn.GetPossibleNewPositions(initialPosition);
        List<Vector> expected = new List<Vector>() 
        { 
            new Vector(5, 5),
            new Vector(3, 5),
        };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestGetPossibleNewPositionsAttackingDown()
    {
        Vector initialPosition = new Vector(7, 3);

        Pawn pawn = new Pawn('A');
        List<Vector> actual = pawn.GetPossibleNewPositions(initialPosition, false);
        List<Vector> expected = new List<Vector>() 
        { 
            new Vector(8, 4),
            new Vector(6, 4),
        };

        CollectionAssert.AreEqual(expected, actual);
    }
}
