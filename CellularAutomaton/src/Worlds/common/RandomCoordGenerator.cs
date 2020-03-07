﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton.src.Worlds.common
{
	static class RandomCoordGenerator
	{
		static public List<Coords> GetCoords(int Width, int Height, int NumCoords)
		{
			List<Coords> coords = new List<Coords>();
			Random random = new Random();

			while (coords.Count < NumCoords)
			{
				int x = random.Next(Width);
				int y = random.Next(Height);
				bool alreadyExists = false;
				foreach (Coords coord in coords)
				{
					if (coord.X == x && coord.Y == y)
					{
						alreadyExists = true;
					}
				}
				if (!alreadyExists)
				{
					coords.Add(new Coords(x, y));
				}

			}

			return coords;
		}

	}
}
