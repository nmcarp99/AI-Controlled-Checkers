using System;
using System.Collections.Generic;

class map {
	public const string blank = " ";
	public const string player1 = "X";
	public const string player2 = "O";
	public const ConsoleColor SelectedBackgroundColor = ConsoleColor.Green;
	public const ConsoleColor BackgroundColor1 = ConsoleColor.Red;
	public const ConsoleColor BackgroundColor2 = ConsoleColor.DarkGray;
	public const ConsoleColor ForegroundColor1 = ConsoleColor.Cyan;
	public const ConsoleColor ForegroundColor2 = ConsoleColor.White;
	private int[] selectedPosition = new int[] {0, 0};
	public List<piece> data = new List<piece> {
		new piece(player1, new int[] {0, 0}),
		new piece (player1, new int[] {2, 0}),
		new piece (player1, new int[] {4, 0}),
		new piece (player1, new int[] {6, 0}),
		new piece (player1, new int[] {1, 1}),
		new piece (player1, new int[] {3, 1}),
		new piece (player1, new int[] {5, 1}),
		new piece (player1, new int[] {7, 1}),
		new piece (player1, new int[] {0, 2}),
		new piece (player1, new int[] {2, 2}),
		new piece (player1, new int[] {4, 2}),
		new piece (player1, new int[] {6, 2}),
		new piece (player2, new int[] {1, 5}),
		new piece (player2, new int[] {3, 5}),
		new piece (player2, new int[] {5, 5}),
		new piece (player2, new int[] {7, 5}),
		new piece (player2, new int[] {0, 6}),
		new piece (player2, new int[] {2, 6}),
		new piece (player2, new int[] {4, 6}),
		new piece (player2, new int[] {6, 6}),
		new piece (player2, new int[] {1, 7}),
		new piece (player2, new int[] {3, 7}),
		new piece (player2, new int[] {5, 7}),
		new piece (player2, new int[] {7, 7}),
	};
	public piece findPiece(int[] index) {
		foreach (piece currentPiece in data) {
			if (currentPiece.position[0] == index[0] && currentPiece.position[1] == index[1]) {
				return currentPiece;
			}
		}
		return null;
	}
	public int[] getPos() {
		return selectedPosition;
	}
	public void move(int[] relativePosition) {
		if (selectedPosition[1] + relativePosition[0] < 8 && 
		selectedPosition[1] + relativePosition[0] > -1) {
			if (selectedPosition[0] + relativePosition[1] < 8 && 
			selectedPosition[0] + relativePosition[1] > -1) {
				selectedPosition[0] += relativePosition[1];
				selectedPosition[1] += relativePosition[0];
			}
		}
	}
	public map(map newMap = null) {
		if (newMap != null) {
			data = newMap.data;
		}
	}
}
class game
{
	public bool gameOver = false;
	public map gameMap = new map();
	public void draw() {
		bool offset = false;
		Console.Clear();
		Console.WriteLine("———————————————————");
		for (int i = 0; i < 8; i++) {
			Console.Write("| ");
			for (int j = 0; j < 8; j++) {
				offset = !offset;
				if (i == gameMap.getPos()[0] && j == gameMap.getPos()[1]) {
					Console.BackgroundColor = map.SelectedBackgroundColor;
				}
				else if (offset) {
					Console.BackgroundColor = map.BackgroundColor1;
				}
				else {
					Console.BackgroundColor = map.BackgroundColor2;
				}
				piece currentPiece = gameMap.findPiece(new int[] {j, i});
				if (currentPiece != null) {
					if (currentPiece.value == map.player1) {
						Console.ForegroundColor = map.ForegroundColor1;
					}
					else if (currentPiece.value == map.player2) {
						Console.ForegroundColor = map.ForegroundColor2;
					}
					Console.Write(currentPiece.value);
				}
				else {
					Console.Write(map.blank);
				}
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(" ");
			}
			Console.Write("|\n");
			offset = !offset;
		}
		Console.WriteLine("———————————————————");
	}
	public game() {
		
	}
}