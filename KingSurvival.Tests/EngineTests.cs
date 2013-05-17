using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;
using System.IO;

namespace KingSurvival.Tests
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void EngineTestKingWins()
        {
            StreamReader input = new StreamReader(@"EngineTests/input1.txt");
            StreamWriter output = new StreamWriter(@"EngineTests/output1.txt");
            Console.SetIn(input);
            Console.SetOut(output);

            Engine game = new Engine();

            using (input)
            {
                using (output)
                {
                    game.Start();
                }
            }

            string actual = File.ReadAllText(@"EngineTests/output1.txt");
            string expected = File.ReadAllText(@"EngineTests/result1.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EngineTestCommands()
        {
            StreamReader input = new StreamReader(@"EngineTests/input2.txt");
            StreamWriter output = new StreamWriter(@"EngineTests/output2.txt");
            Console.SetIn(input);
            Console.SetOut(output);

            Engine game = new Engine();

            using (input)
            {
                using (output)
                {
                    game.Start();
                }
            }

            string actual = File.ReadAllText(@"EngineTests/output2.txt");
            string expected = File.ReadAllText(@"EngineTests/result2.txt");

            Assert.AreEqual(expected, actual);
        }
    }
}
