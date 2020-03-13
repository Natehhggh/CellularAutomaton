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
using CellularAutomaton.src.CellGrids;

namespace CellularAutomaton.src.Worlds
{
	public class WolframWorld : World
	{

		private Byte Rule;

		public WolframWorld(int Width, int Height,Byte Rule , int SeedPosition = -1 )
		{
			this.Rule = Rule;
			

			if (SeedPosition == -1)
			{
				SeedPosition = Width / 2;
			}

			Cells = new WolframGrid(Width, Height, Rule, SeedPosition);
		}

		public WolframWorld(int Width, int Height, Byte Rule, IList<Coords> InitialSeeds)
		{
			this.Rule = Rule;
			Cells = new WolframGrid(Width, Height, Rule, InitialSeeds);


		}






		public override void Update()
		{
			Cells.Update();
		}


		
	}
}
