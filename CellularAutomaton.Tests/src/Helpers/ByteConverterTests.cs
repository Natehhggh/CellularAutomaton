using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CellularAutomaton.src.Helpers;

namespace CellularAutomaton.Tests.src.Helpers
{
	[TestClass]
	public class ByteConverterTests
	{
		[TestMethod]
		public void ConvertByteToStringTest()
		{
			const byte val = 100;
			const string expected = "01100100";
			string result = ByteConverter.ConvertByteToString(val);
			Assert.AreEqual(expected, result);

		}

		[TestMethod]
		public void ConvertStringToByteTest()
		{
			const int expected = 100;
			const string val = "01100100";

			int result = ByteConverter.ConvertBitString(val);
			Assert.AreEqual(expected, result);
		}




	}
}
