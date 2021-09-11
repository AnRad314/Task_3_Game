using ConsoleTables;
using System.Collections.Generic;

namespace Task_3_Game.Data
{
	class Table
	{
        private string[] _moves;

        public Table(List<string> moves)
        {
            _moves = new string[moves.Count + 1];
            _moves[0] = "PC\\User";
            for (int i = 1; i <= moves.Count; ++i)
            {
                _moves[i] = moves[i - 1];
            }
        }
        public void PrintHelpTable()
        {
            var table = new ConsoleTable(_moves);
            for (int player1 = 1; player1 < _moves.Length; ++player1)
            {
                string[] resultMoves = new string[_moves.Length];
                resultMoves[0] = _moves[player1];
                for (int player2 = 1; player2 < _moves.Length; ++player2)
                {
                    resultMoves.SetValue(Rule.GetResultMove(player1, player2, _moves.Length - 1), player2);
                }
                table.AddRow(resultMoves);
            }
            table.Write(Format.Alternative);
        }
    }
}
