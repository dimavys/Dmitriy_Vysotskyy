using System;
using Dmitriy_Vysotskyy.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dmitriy_Vysotskyy.Tests
{
	public class Test5
    {
		[SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestA()
        {
            string input = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill;";
            string output = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";

            Assert.AreEqual(Task5.GetSortedString(input), output);
        }
    }
}

