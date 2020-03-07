using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomaton.src.Helpers;
using CellularAutomaton.src.Worlds;

namespace CellularAutomaton.src.Rules
{
	class WolframCode : RuleStates
	{
		private readonly string RuleString;

		public WolframCode(byte RuleNumber, byte InitialState = 0)
		{

			RuleString = ByteConverter.ConvertByteToString(RuleNumber);
			NextState = InitialState;
			SetCurrentState();
		}

		public WolframCode(string RuleString, byte InitialState = 0)
		{
			this.RuleString = RuleString;
			NextState = InitialState;
			SetCurrentState();
		}

		public override void Update(string neighbors)
		{ 
			SetCurrentState();
			int RuleIndex = ByteConverter.ConvertBitString(neighbors);
			int index = RuleString.Length - (RuleIndex + 1);
			NextState = Convert.ToByte(RuleString[index] - 48);
			SetCurrentState();
		}

		public override byte GetState() 
		{
			return State;
		}


		protected override void SetCurrentState()
		{
			State = NextState;
		}

		
	}
}
