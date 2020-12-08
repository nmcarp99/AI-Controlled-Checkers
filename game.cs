using System;
using System.Collections.Generic;

class map {
	const string blank = " ";
	const string player1 = "X";
	const string player2 = "O";
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
	map gameMap = new map();
	public void draw() {
		bool offset = false;
		Console.Clear();
		Console.WriteLine("———————————————————");
		foreach (List<string> row in gameMap.data) {
			Console.Write("| ");
			Console.ForegroundColor = ConsoleColor.Black;
			foreach (string cell in row) {
				offset = !offset;
				if (offset) {
					Console.BackgroundColor = ConsoleColor.Blue;
				}
				else {
					Console.BackgroundColor = ConsoleColor.White;
				}
				Console.Write(cell);
				Console.BackgroundColor = ConsoleColor.Black;
				Console.Write(" ");
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("|\n");
			offset = !offset;
		}
		Console.WriteLine("———————————————————");
	}
	public game() {
		
	}
}