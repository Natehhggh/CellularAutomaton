using CellularAutomaton.src.Cells;
using CellularAutomaton.src.Helpers;

namespace CellularAutomaton.src.CellGrids
{
	public abstract class CellGrid
	{
		protected int Height;
		protected int Width;
		protected Cell[][] Cells;


		public CellGrid(int Width, int Height)
		{
			this.Width = Width;
			this.Height = Height;
		}

		

		public abstract string GetNeighborStates();
		public abstract void Update();

		public byte GetState(int x, int y) { return this.Cells[x][y].GetState(); }
		public int GetHeight() { return this.Height; }
		public int GetWidth() { return this.Width; }

		protected abstract void InstanciateCells();

		protected int ModWorldWidth(int x)
		{
			return MathHelper.Mod(x, Width);
		}

		protected int ModWorldWHeight(int y)
		{
			return MathHelper.Mod(y, Height);
		}

	}
}
