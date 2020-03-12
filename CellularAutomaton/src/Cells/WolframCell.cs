using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomaton.src.Rules;


namespace CellularAutomaton.src.Cells
{
	public class WolframCell : Cell
	{
		public WolframCell(Func<string> GetNeighbors, byte RuleNumber, byte InitialState = 0)
		{
			this.GetNeighbors = GetNeighbors;
			this.state = new WolframCode(RuleNumber, InitialState);
		}

		public WolframCell(Func<string> GetNeighbors, string RuleString, byte InitialState = 0)
		{
			this.GetNeighbors = GetNeighbors;
			this.state = new WolframCode(RuleString, InitialState);
		}

		public override byte GetState()
		{
			return state.GetState();
		}

		public override void Update()
		{
			string Neighbors = GetNeighbors();
			state.Update(Neighbors);
		}
	}
}
