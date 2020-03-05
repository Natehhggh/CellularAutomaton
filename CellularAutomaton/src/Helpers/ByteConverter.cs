using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton.src.Helpers
{
	static class ByteConverter
	{

		public static string ConvertByteToString(byte value)
		{
			string ByteString = Convert.ToString(value, 2);

			while (ByteString.Length < 8)
			{
				ByteString = "0" + ByteString;
			}

			return ByteString;
		}

		public static int ConvertBitString(string bitString)
		{
			int val = 0;

			char[] bits = bitString.ToCharArray();

			bits = bits.Reverse().ToArray();

			for (int i = 0; i < bits.Length; i++)
			{
				val += (Convert.ToInt32(bits[i]) - 48) * (int)Math.Pow(2, i);
			}


			return val;
		}

	}
}
