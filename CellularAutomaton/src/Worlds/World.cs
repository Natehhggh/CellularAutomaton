using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomaton.src.Cells;
using CellularAutomaton.src.Worlds.common;
using CellularAutomaton.src.CellGrids;

namespace CellularAutomaton.src.Worlds
{
	public abstract class World
	{
		protected CellGrid Cells;
		


		public abstract void Update();
		public byte GetState(int x, int y) { return this.Cells.GetState(x,y); }
		public int GetHeight() { return Cells.GetHeight(); }
		public int GetWidth() { return Cells.GetWidth(); }

	}
}
