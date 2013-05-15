using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;
using System.Collections.Generic;

[TestClass]
public class KingTests
{
    [TestMethod]
    public void TestCanMoveValidInitialMoveKingUpRight()
    {
        Vector fromPosition = new Vector(3, 7);
        Vector toPosition = new Vector(4, 6);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidInitialMoveKingUpLeft()
    {
        Vector fromPosition = new Vector(3, 7);
        Vector toPosition = new Vector(2, 6);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidInitialMoveKingStraightUp()
    {
        Vector fromPosition = new Vector(3, 7);
        Vector toPosition = new Vector(3, 6);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void TestCanMoveValidMoveKingUpLeft()
    {
        Vector fromPosition = new Vector(4, 4);
        Vector toPosition = new Vector(3, 3);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidMoveKingUpRight()
    {
        Vector fromPosition = new Vector(4, 4);
        Vector toPosition = new Vector(5, 5);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidMoveKingDownLeft()
    {
        Vector fromPosition = new Vector(4, 4);
        Vector toPosition = new Vector(3, 5);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveValidMoveKingDownRight()
    {
        Vector fromPosition = new Vector(3, 1);
        Vector toPosition = new Vector(4, 2);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidMoveKingStraightDown()
    {
        Vector fromPosition = new Vector(3, 3);
        Vector toPosition = new Vector(3, 4);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidMoveKingStraightUp()
    {
        Vector fromPosition = new Vector(3, 5);
        Vector toPosition = new Vector(3, 4);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidMoveKingLeft()
    {
        Vector fromPosition = new Vector(0, 4);
        Vector toPosition = new Vector(1, 4);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void TestCanMoveInvalidMoveKingRight()
    {
        Vector fromPosition = new Vector(7, 3);
        Vector toPosition = new Vector(6, 3);

        King king = new King('K');
        bool actual = king.CanMove(fromPosition, toPosition);

        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void TestGetPossibleNewPositionsValidPositions()
    {
        Vector initialPosition = new Vector(4, 6);
        
        King king = new King('K');
        List<Vector> actual = king.GetPossibleNewPositions(initialPosition, true);
        List<Vector> expected = new List<Vector>() 
        { 
            new Vector(5, 7),
            new Vector(5, 5),
            new Vector(3, 7),
            new Vector(3, 5)
        };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestGetPossibleNewPositionsValidPositionsLimitRight()
    {
        Vector initialPosition = new Vector(7, 3);

        King king = new King('K');
        List<Vector> actual = king.GetPossibleNewPositions(initialPosition, true);
        List<Vector> expected = new List<Vector>() 
        { 
            new Vector(8, 4),
            new Vector(8, 2),
            new Vector(6, 4),
            new Vector(6, 2)
        };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestGetPossibleNewPositionsValidPositionsLimitLeft()
    {
        Vector initialPosition = new Vector(0, 2);

        King king = new King('K');
        List<Vector> actual = king.GetPossibleNewPositions(initialPosition, true);
        List<Vector> expected = new List<Vector>() 
        { 
            new Vector(1, 3),
            new Vector(1, 1),
            new Vector(-1, 3),
            new Vector(-1, 1)
        };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestGetPossibleNewPositionsValidPositionsBottomRightEdge()
    {
        Vector initialPosition = new Vector(7, 7);

        King king = new King('K');
        List<Vector> actual = king.GetPossibleNewPositions(initialPosition, true);
        List<Vector> expected = new List<Vector>() 
        { 
            new Vector(8, 8),
            new Vector(8, 6),
            new Vector(6, 8),
            new Vector(6, 6)
        };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestGetPossibleNewPositionsValidPositionsTopRightEdge()
    {
        Vector initialPosition = new Vector(0, 0);

        King king = new King('K');
        List<Vector> actual = king.GetPossibleNewPositions(initialPosition, true);
        List<Vector> expected = new List<Vector>() 
        { 
            new Vector(1, 1),
            new Vector(1, -1),
            new Vector(-1, 1),
            new Vector(-1, -1)
        };

        CollectionAssert.AreEqual(expected, actual);
    }
}
