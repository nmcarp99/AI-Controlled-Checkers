using System;

class main {
	static void Main(string[] Args) {
		game currentGame = new game();
		ConsoleKeyInfo currentKey = new ConsoleKeyInfo();
		while (!currentGame.gameOver) {
			currentGame.draw();
			currentKey = Console.ReadKey();
			switch (currentKey.Key) {
				case ConsoleKey.LeftArrow:
				currentGame.gameMap.move(new int[] {-1, 0});
				break;
				case ConsoleKey.RightArrow:
				currentGame.gameMap.move(new int[] {1, 0});
				break;
				case ConsoleKey.UpArrow:
				currentGame.gameMap.move(new int[] {0, -1});
				break;
				case ConsoleKey.DownArrow:
				currentGame.gameMap.move(new int[] {0, 1});
				break;
			}
		}
	}
}