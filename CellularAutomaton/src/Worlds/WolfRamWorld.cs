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

		public WolframWorld(int Width, int Height,Byte Rule , int SeedPosition = -1 )
		{
			CellGrid = CreateCellGrid(Width, Height);

			if (SeedPosition == -1)
			{
				SeedPosition = Width / 2;
			}

			InitializeGrid(Rule, SeedPosition);

		}

		public WolframWorld(int Width, int Height, Byte Rule, IList<Coords> InitialSeeds)
		{
			CellGrid = CreateCellGrid(Width, Height);

			InitializeGrid(Rule, InitialSeeds);

		}


		public override string GetNeighborStates()
		{
			return GetWolframNeighbors();
		}

		protected override void InitializeGrid(byte Rule, int seedPos)
		{
			for (YUpdatePos = 0; YUpdatePos < CellGrid[XUpdatePos].Length; YUpdatePos++)
			{
				for (XUpdatePos = 0; XUpdatePos < CellGrid.Length; XUpdatePos++)
				{
					
					CellGrid[XUpdatePos][YUpdatePos] = new WolframCell(GetNeighborStates,Rule, GetCellStartingState(seedPos));
				}
				XUpdatePos = 0;
			}
			YUpdatePos = 0;
		}

		protected override void InitializeGrid(byte Rule, IList<Coords> InitialSeeds)
		{
			for (YUpdatePos = 0; YUpdatePos < CellGrid[XUpdatePos].Length; YUpdatePos++)
			{
				for (XUpdatePos = 0; XUpdatePos < CellGrid.Length; XUpdatePos++)
				{
					CellGrid[XUpdatePos][YUpdatePos] = new WolframCell(GetNeighborStates, Rule, GetCellStartingState(InitialSeeds));
				}
				XUpdatePos = 0;
				
			}
			YUpdatePos = 0;
		}


		protected override Cell[][] CreateCellGrid(int width, int height)
		{
			Cell[][] grid = new Cell[width][];
			for (int i = 0; i < width; i++)
			{
				grid[i] = new Cell[height];
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
			return MathHelper.mod(x, CellGrid.Length);
		}

		int ModWorldWHeight(int y)
		{
			return MathHelper.mod(y, CellGrid[0].Length);
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
#if UpdateOneRow
			for (XUpdatePos = 0; XUpdatePos < CellGrid.Length; XUpdatePos++)
			{ 
				CellGrid[XUpdatePos][YUpdatePos].Update();
			}
			XUpdatePos = 0;
			YUpdatePos = ModWorldWHeight(YUpdatePos + 1);
#else
			for (YUpdatePos = 0; YUpdatePos < CellGrid[XUpdatePos].Length; YUpdatePos++)
			{
				for (XUpdatePos = 0; XUpdatePos < CellGrid.Length; XUpdatePos++)
				{ 
					CellGrid[XUpdatePos][YUpdatePos].Update();
				}
				XUpdatePos = 0;
			}
#endif
		}

		public override void PrintCellStates()
		{
			int x = 0;
			for (int y = 0; y < CellGrid[x].Length; y++)
			{
				for (x = 0; x < CellGrid.Length; x++)
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
