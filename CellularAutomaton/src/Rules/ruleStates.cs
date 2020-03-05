using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton.src.Rules
{
	abstract class RuleStates
	{
		protected byte State;
		protected byte PrevState;

		public abstract void Update(string neighbors);

		public abstract byte GetState();

	}
}
