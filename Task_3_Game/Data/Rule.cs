using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3_Game.Data
{
	public static class Rule
	{
		public static string GetResultMove(int idUserMove, int idPcMove, int movesCount)
		{
			if (idUserMove == idPcMove)
			{
				return "Draw"; 
			}
			if (idUserMove < idPcMove)
			{
				if (idPcMove - idUserMove <= movesCount / 2)
				{
					return "Win";
				}
				return "Lose";
			}
			else
			{
				if (idUserMove - idPcMove <= movesCount / 2)
				{
					return "Lose";
				}
				return "Win";
			}
		}
	}
}
