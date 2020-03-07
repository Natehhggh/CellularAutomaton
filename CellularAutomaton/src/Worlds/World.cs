using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomaton.src.Cells;
using CellularAutomaton.src.Worlds.common;

namespace CellularAutomaton.src.Worlds
{
	abstract class World
	{
		protected int XUpdatePos;
		protected int YUpdatePos;

		protected int Height;
		protected int Width;

		protected Cell[][] CellGrid;

		public World(int Width, int Height)
		{
			this.Width = Width;
			this.Height = Height;
		}

		public abstract string GetNeighborStates();
		protected abstract void InitializeGrid(byte Rule, int seedPos);
		protected abstract void InitializeGrid(byte Rule, IList<Coords> InitialSeeds);
		protected abstract Cell[][] CreateCellGrid();
		public abstract void Update();
		public abstract void PrintCellStates();

	}
}
