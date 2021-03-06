using System;

class main {
	static void Main(string[] Args) {
		game currentGame = new game();
		ConsoleKeyInfo currentKey = new ConsoleKeyInfo();
		ConsoleKey currentAltitudeKey = new ConsoleKey();
		piece selectedPiece = null;
		while (!currentGame.gameOver) {
			currentGame.draw();
			Console.WriteLine(currentGame.gameMap.player1Turn ? "White's Turn" : "Red's Turn");
			currentKey = Console.ReadKey();
			switch (currentKey.Key) {
				case ConsoleKey.LeftArrow:
				currentGame.gameMap.moveLeft(ref selectedPiece, ref currentAltitudeKey, ref currentGame);
				break;
				case ConsoleKey.RightArrow:
				currentGame.gameMap.moveRight(ref selectedPiece, ref currentAltitudeKey, ref currentGame);
				break;
				case ConsoleKey.UpArrow:
				currentGame.gameMap.moveUp(ref selectedPiece, ref currentAltitudeKey, ref currentGame);
				break;
				case ConsoleKey.DownArrow:
				currentGame.gameMap.moveDown(ref selectedPiece, ref currentAltitudeKey, ref currentGame);
				break;
				case ConsoleKey.Escape:
				if (selectedPiece != null) {
					selectedPiece = null;
				}
				else {
					currentGame.gameOver = true;
				}
				break;
				case ConsoleKey.Spacebar:
				selectedPiece = currentGame.gameMap.findPiece(new int[] {currentGame.gameMap.getPos()[1], currentGame.gameMap.getPos()[0]});
				if (selectedPiece != null) {
					if ((selectedPiece.value != map.player1) == currentGame.gameMap.player1Turn) {
						selectedPiece = null;
					}
				}
				break;
			}
		}
		Console.BackgroundColor = ConsoleColor.Black;
		Console.Clear();
	}
}