using System;
using Dmitriy_Vysotskyy.Tasks;
using NUnit.Framework;

namespace Dmitriy_Vysotskyy.Tests
{
	public class Test4
	{
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestA()
        {
            Assert.AreEqual(Task4.GetTargetPair((new int[] { 1, 3, 6, 2, 2, 0, 4, 5 }), 5), 4);
        }
    }
}

