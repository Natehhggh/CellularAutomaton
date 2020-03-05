﻿using System;
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
			State = InitialState;
			PrevState = State;
		}

		public WolframCode(string RuleString, byte InitialState = 0)
		{
			this.RuleString = RuleString;
			PrevState = State;
		}

		public override void Update(string neighbors)
		{
			if (State == 0 )
			{
				int RuleIndex = ByteConverter.ConvertBitString(neighbors);
				
				int index = RuleString.Length - (RuleIndex + 1);
				State = Convert.ToByte(RuleString[index] - 48);
			}
			else
			{

			}

			if (State != 0)
			{

			}
		}

		public override byte GetState() 
		{
			return State;
		}



		
	}
}
