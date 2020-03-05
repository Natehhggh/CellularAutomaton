﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomaton.src.Cells;

namespace CellularAutomaton.src.Worlds
{
	abstract class World
	{
		protected int XUpdatePos;
		protected int YUpdatePos;
		protected Cell[][] CellGrid;


		public abstract string GetNeighborStates();
		protected abstract void  InitializeGrid(byte Rule, int seedPos);
		protected abstract Cell[][] CreateCellGrid(int width, int height);
		public abstract void Update();
		public abstract void PrintCellStates();

	}
}