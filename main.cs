using System;

class main {
	static void Main(string[] Args) {
		game currentGame = new game();
		ConsoleKeyInfo currentKey = new ConsoleKeyInfo();
		ConsoleKey currentAltitudeKey = new ConsoleKey();
		piece selectedPiece = null;
		while (!currentGame.gameOver) {
			currentGame.draw();
			currentKey = Console.ReadKey();
			switch (currentKey.Key) {
				case ConsoleKey.LeftArrow:
				if (selectedPiece != null) {
					if (selectedPiece.king) {
						if (currentAltitudeKey == ConsoleKey.UpArrow) {
							selectedPiece.move(new int[] {-1, -1}, currentGame.gameMap);
						}
						else if (currentAltitudeKey == ConsoleKey.DownArrow) {
							selectedPiece.move(new int[] {-1, 1}, currentGame.gameMap);
						}
						currentAltitudeKey = new ConsoleKey();
					}
					else {
						if (selectedPiece.value == map.player1) {
							selectedPiece.move(new int[] {-1, 1}, currentGame.gameMap);
						}
						else if (selectedPiece.value == map.player2) {
							selectedPiece.move(new int[] {-1, -1}, currentGame.gameMap);
						}
					}
					selectedPiece = null;
				}
				else {
					currentGame.gameMap.move(new int[] {-1, 0});
				}
				break;
				case ConsoleKey.RightArrow:
				if (selectedPiece != null) {
					if (selectedPiece.king) {
						if (currentAltitudeKey == ConsoleKey.UpArrow) {
							selectedPiece.move(new int[] {1, -1}, currentGame.gameMap);
						}
						else if (currentAltitudeKey == ConsoleKey.DownArrow) {
							selectedPiece.move(new int[] {1, 1}, currentGame.gameMap);
						}
						currentAltitudeKey = new ConsoleKey();
					}
					else {
						if (selectedPiece.value == map.player1) {
							selectedPiece.move(new int[] {1, 1}, currentGame.gameMap);
						}
						else if (selectedPiece.value == map.player2) {
							selectedPiece.move(new int[] {1, -1}, currentGame.gameMap);
						}
					}
					selectedPiece = null;
				}
				else {
					currentGame.gameMap.move(new int[] {1, 0});
				}
				break;
				case ConsoleKey.UpArrow:
				if (selectedPiece != null) {
					currentAltitudeKey = ConsoleKey.UpArrow;
				}
				else {
					currentGame.gameMap.move(new int[] {0, -1});
				}
				break;
				case ConsoleKey.DownArrow:
				if (selectedPiece != null) {
					currentAltitudeKey = ConsoleKey.DownArrow;
				}
				else {
					currentGame.gameMap.move(new int[] {0, 1});
				}
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
				break;
			}
		}
		Console.BackgroundColor = ConsoleColor.Black;
		Console.Clear();
	}
}