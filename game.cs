using System;
using System.Collections.Generic;

class map {
	public const string blank = " ";
	public const string player1 = "X";
	public const string player2 = "O";
	private int[] selectedPosition = new int[] {0, 0};
	public List<List<string>> data = new List<List<string>> {
		new List<string> { blank, player2, blank, player2, blank, player2, blank, player2 },
		new List<string> { player2, blank, player2, blank, player2, blank, player2, blank },
		new List<string> { blank, player2, blank, player2, blank, player2, blank, player2 },
		new List<string> { blank, blank, blank, blank, blank, blank, blank, blank },
		new List<string> { blank, blank, blank, blank, blank, blank, blank, blank },
		new List<string> { player1, blank, player1, blank, player1, blank, player1, blank },
		new List<string> { blank, player1, blank, player1, blank, player1, blank, player1 },
		new List<string> { player1, blank, player1, blank, player1, blank, player1, blank }
	};
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
	public string getCell(int x, int y) {
		return data[y][x];
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
		for (int i = 0; i < gameMap.data.Count; i++) {
			Console.Write("| ");
			for (int j = 0; j < gameMap.data[i].Count; j++) {
				offset = !offset;
				if (i == gameMap.getPos()[0] && j == gameMap.getPos()[1]) {
					if (offset) {
						Console.BackgroundColor = ConsoleColor.Magenta;
					}
					else {
						Console.BackgroundColor = ConsoleColor.Green;
					}
				}
				else if (offset) {
					Console.BackgroundColor = ConsoleColor.Red;
				}
				else {
					Console.BackgroundColor = ConsoleColor.DarkGray;
				}
				if (gameMap.data[i][j] == map.player1) {
					Console.ForegroundColor = ConsoleColor.Cyan;
				}
				else if (gameMap.data[i][j] == map.player2) {
					Console.ForegroundColor = ConsoleColor.White;
				}
				Console.Write(gameMap.data[i][j]);
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