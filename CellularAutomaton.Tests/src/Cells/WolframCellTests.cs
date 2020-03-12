using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CellularAutomaton.src.Cells;
namespace CellularAutomaton.Tests.src.Cells
{
	[TestClass]
	public class WolframCellTests
	{
		string GetNeighbors()
		{
			return "111";
		}


		[TestMethod]
		public void InstantiationByteTest()
		{
			const byte rule = 90;
			const byte initialState = 1;
			const byte Expected = initialState;

			WolframCell cell = new WolframCell(GetNeighbors, rule, initialState);

			byte result = cell.GetState();

			Assert.AreEqual(Expected, result);

		}

		[TestMethod]
		public void InstantiationStringTest()
		{
			const string rule = "10101010";
			const byte initialState = 1;
			const byte Expected = initialState;

			WolframCell cell = new WolframCell(GetNeighbors, rule, initialState);

			byte result = cell.GetState();

			Assert.AreEqual(Expected, result);
		}

		[TestMethod]
		public void RuleTest()
		{
			const string rule = "10000000";
			const byte initialState = 0;

			const byte expected = 1;

			WolframCell cell = new WolframCell(GetNeighbors, rule, initialState);
			cell.Update();
			byte result = cell.GetState();
			Assert.AreEqual(expected, result);
			
		}




		

	}
}
