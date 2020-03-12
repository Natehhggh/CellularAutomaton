using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton.src.Helpers
{
	public static class MathHelper
	{
		public static int Mod(int x, int m)
		{
			return (x % m + m) % m;
		}
	}
}
