using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomaton.src.Worlds.common;
using CellularAutomaton.src.Cells;


namespace CellularAutomaton.src.CellGrids
{
	class WolframGrid : CellGrid
	{
		Coords UpdatePosition;

		public WolframGrid(int Width, int Height, Byte Rule, int SeedPosition = -1) : base(Width, Height)
		{
			UpdatePosition = new Coords(0, 0);
			InstanciateCells();

			if (SeedPosition == -1)
			{
				SeedPosition = Width / 2;
			}

			InitializeGrid(Rule, SeedPosition);
			InitialUpdate();
		}

		public WolframGrid(int Width, int Height, Byte Rule, IList<Coords> InitialSeeds) : base(Width, Height)
		{
			UpdatePosition = new Coords(0, 0);
			InstanciateCells();

			InitializeGrid(Rule, InitialSeeds);
			InitialUpdate();

		}

		protected void InitializeGrid(byte Rule, IList<Coords> InitialSeeds)
		{
			Coords pos = new Coords(0, 0);
			for (int y = 0; y< Height; y++)
			{
				pos.Y = y;
				for (int x = 0; x < Width; x++)
				{
					pos.X = x;
					Cells[x][y] = new WolframCell(GetNeighborStates, Rule, GetCellStartingState(InitialSeeds, pos));
				}

			}
		}

		protected void InitialUpdate()
		{
			for (int y = 1; y < Height; y++)
			{
				UpdateRow(y);
			}
		}


		public override void Update()
		{
			ShiftCellsUp();
			UpdateRow(Height - 1);
		}


		private void UpdateRow(int y)
		{
			UpdatePosition.Y = y;
			for (int x = 0; x < Width; x++)
			{
				UpdatePosition.X = x;
				Cells[x][y].Update();
			}

		}

		protected void ShiftCellsUp()
		{
			for (int x = 0; x < Width; x++)
			{
				Cell newCell = Cells[x][0];
				for (int y = 0; y < Height - 1; y++)
				{
					Cells[x][y] = Cells[x][y + 1];
				}
				Cells[x][Height - 1] = newCell;
			}
		}


		protected byte GetCellStartingState(int seedPos, Coords pos)
		{
			byte state = 0;
			if (pos.Y == seedPos && pos.Y == 0)
			{
				state = 1;
			}
			return state;
		}

		protected byte GetCellStartingState(IList<Coords> initialSeeds, Coords pos)
		{
			byte state = 0;
			for (int i = 0; i < initialSeeds.Count; i++)
			{
				if (pos == initialSeeds[i])
				{
					initialSeeds.RemoveAt(i);
					state = 1;
					break;
				}

			}
			return state;
		}

		public override string GetNeighborStates()
		{
			string neighbors = string.Empty;

			int y = ModWorldWHeight(UpdatePosition.Y - 1);

			for (int offset = -1; offset <= 1; offset++)
			{
				int x = ModWorldWidth(UpdatePosition.X + offset);
				neighbors += Cells[x][y].GetState().ToString();
			}

			return neighbors;
		}

		protected void InitializeGrid(byte Rule, int seedPos)
		{
			Coords pos = new Coords(0, 0);
			for (int y = 0; y < Height; y++)
			{
				pos.Y = y;
				for (int x = 0; x < Width; x++)
				{
					pos.X = x;
					Cells[x][y] = new WolframCell(GetNeighborStates, Rule, GetCellStartingState(seedPos, pos));
				}
			}
		}

		protected override void InstanciateCells()
		{
			Cells = new Cell[Width][];
			for (int i = 0; i < Width; i++)
			{
				Cells[i] = new Cell[Height];
			}
		}

		

	}
}
