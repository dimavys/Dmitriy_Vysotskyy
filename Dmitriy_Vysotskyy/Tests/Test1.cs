using System;
using System.Collections.Generic;
using Dmitriy_Vysotskyy.Tasks;
using NUnit.Framework;

namespace Dmitriy_Vysotskyy.Tests
{
	public class Test1
	{
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestA()
        {
            Assert.AreEqual(Task1.GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b' }), new List<object>() {1, 2});
        }

        [Test]
        public void TestB()
        {
            Assert.AreEqual(Task1.GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b', 0, 15 }), new List<object>() { 1, 2, 0, 15 });
        }

        [Test]
        public void TestC()
        {
            Assert.AreEqual(Task1.GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b', "aasf", '1', "123", 231 }), new List<object>() { 1, 2, 231 });
        }

    }
}

