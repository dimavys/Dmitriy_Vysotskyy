using System;
using Dmitriy_Vysotskyy.Tasks;
using NUnit.Framework;

namespace Dmitriy_Vysotskyy.Tests
{
	public class Test2
	{
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestA()
        {
            Assert.AreEqual(Task2.GetFirstNonRepeatingLetter("stress"), "t");
        }

        [Test]
        public void TestB()
        {
            Assert.AreEqual(Task2.GetFirstNonRepeatingLetter("sTreSS"), "T");
        }
    }
}

