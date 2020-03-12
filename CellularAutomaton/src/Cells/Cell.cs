using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomaton.src.Rules;

namespace CellularAutomaton.src.Cells
{
	public abstract class Cell
	{
		protected RuleStates state;
		protected Func<string> GetNeighbors;
		

		public abstract void Update();
		public abstract byte GetState();
	}
}
