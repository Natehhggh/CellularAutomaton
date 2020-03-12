using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton.src.Worlds.common
{
	public struct Coords
	{
		public Coords(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }

	}
}
