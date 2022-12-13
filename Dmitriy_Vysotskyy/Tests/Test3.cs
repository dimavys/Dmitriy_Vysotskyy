using System;
using Dmitriy_Vysotskyy.Tasks;
using NUnit.Framework;

namespace Dmitriy_Vysotskyy.Tests
{
	public class Test3
	{
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestA()
        {
            Assert.AreEqual(Task3.GetDigitalRoot(16), 7);
        }

        [Test]
        public void TestB()
        {
            Assert.AreEqual(Task3.GetDigitalRoot(942), 6);
        }

        [Test]
        public void TestC()
        {
            Assert.AreEqual(Task3.GetDigitalRoot(132189), 6);
        }

        [Test]
        public void TestD()
        {
            Assert.AreEqual(Task3.GetDigitalRoot(493193), 2);
        }
    }
}

