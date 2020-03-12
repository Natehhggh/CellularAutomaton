using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CellularAutomaton.src.Rules;

namespace CellularAutomaton.Tests.src.Rules

{
	[TestClass]
	public class WolframCodeTests
	{
		[TestMethod]
		public void InstantiationByteTest()
		{
			const byte rule = 90;
			const byte initialState = 1;
			const byte Expected = initialState;

			WolframCode code = new WolframCode(rule, initialState);

			byte result = code.GetState();

			Assert.AreEqual(Expected, result);

		}

		[TestMethod]
		public void InstantiationStringTest()
		{
			const string rule = "10101010";
			const byte initialState = 1;
			const byte Expected = initialState;

			WolframCode code = new WolframCode(rule, initialState);

			byte result = code.GetState();

			Assert.AreEqual(Expected, result);
		}

		[TestMethod]
		public void RuleTest()
		{
			const string rule = "10101010";
			string[] neighbors = new string[] {"111", "110", "101", "100", "011", "010", "001", "000", };
			const byte initialState = 0;

			WolframCode code = new WolframCode(rule, initialState);
			for (int i = 0; i < neighbors.Length; i++)
			{
				code.Update(neighbors[i]);
				byte result = code.GetState();
				Assert.AreEqual(int.Parse(new string (rule[i], 1)), result);
			}
		}
	}
}
