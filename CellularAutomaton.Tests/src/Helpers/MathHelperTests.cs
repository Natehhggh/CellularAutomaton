using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CellularAutomaton.src.Helpers;

namespace CellularAutomaton.Tests.src.Helpers
{
	[TestClass]
	public class MathHelperTests
	{
		[TestMethod]
		public void ModNegative()
		{
			const int val = -12;
			const int mod = 3;

			const int expected = 0;

			int result = MathHelper.Mod(val, mod);

			Assert.AreEqual(result, expected);

		}

		[TestMethod]
		public void ModPositive()
		{
			const int val = 25;
			const int mod = 4;

			const int expected = 1;

			int result = MathHelper.Mod(val, mod);

			Assert.AreEqual(result, expected);

		}

		[TestMethod]
		public void ModZero()
		{
			const int val = 0;
			const int mod = 13;

			const int expected = 0;

			int result = MathHelper.Mod(val, mod);

			Assert.AreEqual(result, expected);

		}

	}
}
