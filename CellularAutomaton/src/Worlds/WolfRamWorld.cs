using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomaton.src.Cells;
using CellularAutomaton.src.Helpers;
using System.Diagnostics;


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

			for (int x = -1; x <= 1; x++)
			{
				int xPos = ModWorldWidth(XUpdatePos + x);
				neighbors += CellGrid[xPos][YUpdatePos - 1].GetState().ToString();
			}

			return neighbors;
		}

		int ModWorldWidth(int x)
		{
			return MathHelper.mod(x, CellGrid.Length - 1);
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

		public override void Update()
		{
			for (YUpdatePos = 1; YUpdatePos < CellGrid[XUpdatePos].Length; YUpdatePos++)
			{
				for (XUpdatePos = 0; XUpdatePos < CellGrid.Length; XUpdatePos++)
				{ 
					CellGrid[XUpdatePos][YUpdatePos].Update();
				}
				XUpdatePos = 0;
			}
		}

		public override void PrintCellStates()
		{
			XUpdatePos = 0;
			for (YUpdatePos = 0; YUpdatePos < CellGrid[XUpdatePos].Length; YUpdatePos++)
			{
				for (XUpdatePos = 0; XUpdatePos < CellGrid.Length; XUpdatePos++)
				{
					byte state = CellGrid[XUpdatePos][YUpdatePos].GetState();

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
				Debug.WriteLine("");
				XUpdatePos = 0;
			}
		}
	}
}
