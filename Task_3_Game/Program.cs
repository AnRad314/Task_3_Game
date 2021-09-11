using System;
using Task_3_Game.Data;

namespace Task_3_Game
{
	class Program
	{
		static void Main(string[] args)
		{
			Game game = new Game();
			game.InputMoves(args);
			while (true)
			{
				game.CreateRandomMovePc();
				int numMovePc = game.GetMovePc();
				var movePC = game.ShowMove(numMovePc);
				Encryptor coder = new Encryptor();
				coder.CreatreHmac(movePC);
				Console.WriteLine("HMAC: " + coder.GetHmacHash());
				game.PrintMenu();
				game.SetUserMove();
				string resultGame = game.GetResultGame();
				Console.WriteLine(resultGame);
				string hmacKey = coder.GetHmacKey();
				Console.WriteLine("HMAC key: " + hmacKey);
				Console.WriteLine("========NEXT GAME? Press Enter===============");
				Console.WriteLine("========Press Esc for exit===================");
				ConsoleKeyInfo pressKey = Console.ReadKey(true);
				if (pressKey.Key == ConsoleKey.Escape)
				{
					Environment.Exit(0);
				}
				while (pressKey.Key != ConsoleKey.Enter) { }
				
			}
		}
	}
}
