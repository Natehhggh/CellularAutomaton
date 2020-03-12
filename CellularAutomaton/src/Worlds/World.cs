using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomaton.src.Cells;
using CellularAutomaton.src.Worlds.common;

namespace CellularAutomaton.src.Worlds
{
	public abstract class World
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

		
		protected abstract void InitializeGrid(byte Rule, int seedPos);
		protected abstract void InitializeGrid(byte Rule, IList<Coords> InitialSeeds);
		protected abstract Cell[][] CreateCellGrid();

		//TODO: test if this can be private or protected
		public abstract string GetNeighborStates();

		public abstract void Update();
		public abstract void PrintCellStates();
		public byte GetState(int x, int y) { return this.CellGrid[x][y].GetState(); }
		public int GetHeight() { return this.Height; }
		public int GetWidth() { return this.Width; }

	}
}
