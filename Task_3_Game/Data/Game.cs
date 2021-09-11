using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Task_3_Game.Data
{
	public class Game
	{
		private int _idUserMove = 0;
		private int _idPcMove = 0;
		private Dictionary<string, string> _menu = new Dictionary<string, string>();
		private List<string> _movesList = new List<string>();

		public void InputMoves()
		{
			Console.Write("Enter moves:");
			string inputMoves = Console.ReadLine().Trim();
			string[] moves = inputMoves.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			bool isUnique = true;
			do
			{
				while(moves.Length < 3 || moves.Length % 2 == 0 || !isUnique)
				{					
					PrintErrorMessages();
					Console.Write("Enter moves:");
					inputMoves = Console.ReadLine().Trim();
					moves = inputMoves.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					isUnique = true;
				}
				foreach (var m in moves)
				{
					if (_movesList.Contains(m))
					{
						_movesList.Clear();
						isUnique = false;
						break;
					}
					_movesList.Add(m);
				}
			}
			while (!isUnique);
			SetMenu(_movesList);
		}

		private void SetMenu(IEnumerable<string> moves)
		{
			int _starKey = 1;
			foreach (var m in moves)
			{
				_menu.Add(_starKey.ToString(), m);
				++_starKey;
			}
			_menu.Add("0", "exit");
			_menu.Add("?", "help");
		}

		public void SetUserMove()
		{
			Console.Write("Enter your move:");
			string inputUserMove = Console.ReadLine();
			while (!_menu.ContainsKey(inputUserMove))
			{
				Console.WriteLine("You entered incorrect move. Try agan");
				Console.WriteLine("Enter your move");
				inputUserMove = Console.ReadLine();
			}
			ExecuteUserChoice(inputUserMove);
		}

		private void ExecuteUserChoice(string inputUserMove)
		{
			switch (inputUserMove)
			{
				case "?":
					Table table = new Table(_movesList);
					table.PrintHelpTable();
					SetUserMove();
					break;
				case "0":
					Environment.Exit(0);
					break;
				default:					
					_idUserMove = int.Parse(inputUserMove) - 1;
					Console.WriteLine("Your move: " + ShowMove(_idUserMove));
					Console.WriteLine("Computer move:" + ShowMove(_idPcMove));
					break;
			}
		}

		public string GetResultGame()
		{
			return "You:" + Rule.GetResultMove(_idUserMove, _idPcMove, _movesList.Count).ToLower();
		}

		public void CreateRandomMovePc()
		{
			_idPcMove = RandomNumberGenerator.GetInt32(0, _movesList.Count);
		}

		public int GetMovePc()
		{
			return _idPcMove;
		}

		public string ShowMove(int numMove)
		{
			return _movesList[numMove];
		}

		public void PrintMenu()
		{
			Console.WriteLine("Available moves:");
			foreach (var menu in _menu)
			{
				Console.WriteLine(menu.Key + " - " + menu.Value);
			}
		}

		private void PrintErrorMessages()
		{
			Console.WriteLine("Error. The number of entered moves must be at least 3, odd and unique");
			Console.WriteLine("For example: Rock Scissors Paper or Rock Scissors Paper Lizard Spock or 1 2 3 4 5 6 7 8 9");
			Console.WriteLine();
		}
	}
}
