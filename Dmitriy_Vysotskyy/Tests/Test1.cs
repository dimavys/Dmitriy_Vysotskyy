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
        public void Test()
        {
            
            Assert.AreEqual(Task1.GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b' }), new List<object>() {1, 2});
        }

    }
}

