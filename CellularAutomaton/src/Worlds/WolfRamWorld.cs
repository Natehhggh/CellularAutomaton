//#define UpdateOneRow

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomaton.src.Cells;
using CellularAutomaton.src.Helpers;
using System.Diagnostics;
using CellularAutomaton.src.Worlds.common;

namespace CellularAutomaton.src.Worlds
{
	class WolframWorld : World
	{

		private Byte Rule;

		public WolframWorld(int Width, int Height,Byte Rule , int SeedPosition = -1 ) : base(Width,Height)
		{
			this.Rule = Rule;
			CellGrid = CreateCellGrid();

			if (SeedPosition == -1)
			{
				SeedPosition = Width / 2;
			}

			InitializeGrid(Rule, SeedPosition);
			InitialUpdate();
		}

		public WolframWorld(int Width, int Height, Byte Rule, IList<Coords> InitialSeeds) : base(Width, Height)
		{
			this.Rule = Rule;
			CellGrid = CreateCellGrid();

			InitializeGrid(Rule, InitialSeeds);
			InitialUpdate();

		}


		public override string GetNeighborStates()
		{
			return GetWolframNeighbors();
		}

		protected override void InitializeGrid(byte Rule, int seedPos)
		{
			for (YUpdatePos = 0; YUpdatePos < Height; YUpdatePos++)
			{
				for (XUpdatePos = 0; XUpdatePos < Width; XUpdatePos++)
				{
					CellGrid[XUpdatePos][YUpdatePos] = new WolframCell(GetNeighborStates,Rule, GetCellStartingState(seedPos));
				}
				XUpdatePos = 0;
			}
			YUpdatePos = 0;
		}

		protected override void InitializeGrid(byte Rule, IList<Coords> InitialSeeds)
		{
			for (YUpdatePos = 0; YUpdatePos < Height; YUpdatePos++)
			{
				for (XUpdatePos = 0; XUpdatePos < Width; XUpdatePos++)
				{
					CellGrid[XUpdatePos][YUpdatePos] = new WolframCell(GetNeighborStates, Rule, GetCellStartingState(InitialSeeds));
				}
				XUpdatePos = 0;
				
			}
			YUpdatePos = 0;
		}


		protected override Cell[][] CreateCellGrid()
		{
			Cell[][] grid = new Cell[Width][];
			for (int i = 0; i < Width; i++)
			{
				grid[i] = new Cell[Height];
			}
			return grid;
		}

		string GetWolframNeighbors()
		{
			string neighbors = string.Empty;

			int yPos = ModWorldWHeight(YUpdatePos - 1);

			for (int x = -1; x <= 1; x++)
			{
				int xPos = ModWorldWidth(XUpdatePos + x);
				neighbors += CellGrid[xPos][yPos].GetState().ToString();
			}


			return neighbors;
		}

		int ModWorldWidth(int x)
		{
			return MathHelper.mod(x, Width);
		}

		int ModWorldWHeight(int y)
		{
			return MathHelper.mod(y, Height);
		}

		byte GetCellStartingState(int seedPos)
		{
			byte state = 0;
			if (XUpdatePos == seedPos && YUpdatePos == 0)
			{
				state = 1;
			}
			return state;
		}

		byte GetCellStartingState(IList<Coords> initialSeeds)
		{
			byte state = 0;
			for (int i = 0; i < initialSeeds.Count; i++)
			{
				if (XUpdatePos == initialSeeds[i].X && YUpdatePos == initialSeeds[i].Y)
				{
					//I dont like the list being edited here, but I take it as planting the seed, for performance.
					initialSeeds.RemoveAt(i);
					state = 1;
					break;
				}

			}
			return state;
		}


		public override void Update()
		{

			for (int x = 0; x < Width; x++)
			{
				Cell newCell = CellGrid[x][0];
				for (int y = 0; y < Height - 1; y++)
				{
					CellGrid[x][y] = CellGrid[x][y + 1];
				}
				CellGrid[x][Height - 1] = newCell;
			}
			UpdateRow(Height- 1);

		}

		private void UpdateRow(int y)
		{
			YUpdatePos = y;
			for (XUpdatePos = 0; XUpdatePos < Width; XUpdatePos++)
			{
				CellGrid[XUpdatePos][YUpdatePos].Update();
			}
			XUpdatePos = 0;
		}

		protected void InitialUpdate()
		{
			for (YUpdatePos = 1; YUpdatePos < Height; YUpdatePos++)
			{
				for (XUpdatePos = 0; XUpdatePos < Width; XUpdatePos++)
				{
					CellGrid[XUpdatePos][YUpdatePos].Update();
				}
				XUpdatePos = 0;
			}
		}


		public override void PrintCellStates()
		{
			int x = 0;
			for (int y = 0; y < Height; y++)
			{
				for (x = 0; x < Width; x++)
				{
					byte state = CellGrid[x][y].GetState();

					string stateString;
					if (state == 1)
					{
						stateString = "\u25A0";
					}
					else
					{
						stateString = "\u25A1";
					}


					Debug.Write(stateString);
				}
				x = 0;
				Debug.WriteLine("");
			}
			Debug.WriteLine("");
			Debug.WriteLine("");
			Debug.WriteLine("");
		}

		
	}
}
