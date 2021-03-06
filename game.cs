using System;
using System.Collections.Generic;

class map {
	public bool player1Turn = true;
	public const string blank = "   ";
	public const string player1 = " ⛀ ";
	public const string player1King = " ⛁ ";
	public const string player2 = " ⛂ ";
	public const string player2King = " ⛃ ";
	public const ConsoleColor SelectedBackgroundColor = ConsoleColor.Yellow;
	public const ConsoleColor BackgroundColor1 = ConsoleColor.Red;
	public const ConsoleColor BackgroundColor2 = ConsoleColor.Black;
	public const ConsoleColor ForegroundColor1 = ConsoleColor.White;
	public const ConsoleColor ForegroundColor2 = ConsoleColor.Red;
	private int[] selectedPosition = new int[] {0, 0};
	public List<piece> data = new List<piece> {
		new piece(player1, new int[] {1, 0}),
		new piece (player1, new int[] {3, 0}),
		new piece (player1, new int[] {5, 0}),
		new piece (player1, new int[] {7, 0}),
		new piece (player1, new int[] {0, 1}),
		new piece (player1, new int[] {2, 1}),
		new piece (player1, new int[] {4, 1}),
		new piece (player1, new int[] {6, 1}),
		new piece (player1, new int[] {1, 2}),
		new piece (player1, new int[] {3, 2}),
		new piece (player1, new int[] {5, 2}),
		new piece (player1, new int[] {7, 2}),
		new piece (player2, new int[] {0, 5}),
		new piece (player2, new int[] {2, 5}),
		new piece (player2, new int[] {4, 5}),
		new piece (player2, new int[] {6, 5}),
		new piece (player2, new int[] {1, 6}),
		new piece (player2, new int[] {3, 6}),
		new piece (player2, new int[] {5, 6}),
		new piece (player2, new int[] {7, 6}),
		new piece (player2, new int[] {0, 7}),
		new piece (player2, new int[] {2, 7}),
		new piece (player2, new int[] {4, 7}),
		new piece (player2, new int[] {6, 7}),
	};
	public piece findPiece(int[] index) {
		foreach (piece currentPiece in data) {
			if (currentPiece.position[0] == index[0] && currentPiece.position[1] == index[1] && !currentPiece.dead) {
				return currentPiece;
			}
		}
		return null;
	}
	public bool isThereAJump() {
		bool turnIsOver = true;
		foreach (piece currentPiece in data) {
			if ((currentPiece.value == player1) == player1Turn && !currentPiece.dead) {
				// down and right
				if (currentPiece.position[0] + 2 < 8 && currentPiece.position[1] + 2 < 8) {
					if (currentPiece.king != player1Turn) {
						piece killingPiece = findPiece(new int[] {currentPiece.position[0] + 1, currentPiece.position[1] + 1});
						if (killingPiece != null && !killingPiece.dead) {
							if ((killingPiece.value != player1) == player1Turn) {
								if (findPiece(new int[] {currentPiece.position[0] + 2, currentPiece.position[1] + 2}) == null) {
									turnIsOver = false;
									break;
								}
							}
						}
					}
				}
				if (currentPiece.position[0] - 2 >= 0 && currentPiece.position[1] + 2 < 8) { // down and left
					if (currentPiece.king != player1Turn) {
						piece killingPiece = findPiece(new int[] {currentPiece.position[0] - 1, currentPiece.position[1] + 1});
						if (killingPiece != null && !killingPiece.dead) {
							if ((killingPiece.value != player1) == player1Turn) {
								if (findPiece(new int[] {currentPiece.position[0] - 2, currentPiece.position[1] + 2}) == null) {
									turnIsOver = false;
									break;
								}
							}
						}
					}
				}
				if (currentPiece.position[0] + 2 < 8 && currentPiece.position[1] - 2 >= 0) { // up and right
					if (currentPiece.king == player1Turn) {
						piece killingPiece = findPiece(new int[] {currentPiece.position[0] + 1, currentPiece.position[1] - 1});
						if (killingPiece != null && !killingPiece.dead) {
							if ((killingPiece.value != player1) == player1Turn) {
								if (findPiece(new int[] {currentPiece.position[0] + 2, currentPiece.position[1] - 2}) == null) {
									turnIsOver = false;
									break;
								}
							}
						}
					}
				}
				if (currentPiece.position[0] - 2 >= 0 && currentPiece.position[1] - 2 >= 0) { // up and left
					if (currentPiece.king == player1Turn) {
						piece killingPiece = findPiece(new int[] {currentPiece.position[0] - 1, currentPiece.position[1] - 1});
						if (killingPiece != null && !killingPiece.dead) {
							if ((killingPiece.value != player1) == player1Turn) {
								if (findPiece(new int[] {currentPiece.position[0] - 2, currentPiece.position[1] - 2}) == null) {
									turnIsOver = false;
									break;
								}
							}
						}
					}
				}
			}
		}
		return !turnIsOver;
	}
	public bool checkTurnOver(piece currentPiece) {
		bool turnIsOver = true;
		if (!currentPiece.dead) {
			// down and right
			if (currentPiece.position[0] + 2 < 8 && currentPiece.position[1] + 2 < 8) {
				if (currentPiece.king != player1Turn) {
					piece killingPiece = findPiece(new int[] {currentPiece.position[0] + 1, currentPiece.position[1] + 1});
					if (killingPiece != null && !killingPiece.dead) {
						if ((killingPiece.value != player1) == player1Turn) {
							if (findPiece(new int[] {currentPiece.position[0] + 2, currentPiece.position[1] + 2}) == null) {
								turnIsOver = false;
							}
						}
					}
				}
			}
			if (currentPiece.position[0] - 2 >= 0 && currentPiece.position[1] + 2 < 8) { // down and left
				if (currentPiece.king != player1Turn) {
					piece killingPiece = findPiece(new int[] {currentPiece.position[0] - 1, currentPiece.position[1] + 1});
					if (killingPiece != null && !killingPiece.dead) {
						if ((killingPiece.value != player1) == player1Turn) {
							if (findPiece(new int[] {currentPiece.position[0] - 2, currentPiece.position[1] + 2}) == null) {
								turnIsOver = false;
							}
						}
					}
				}
			}
			if (currentPiece.position[0] + 2 < 8 && currentPiece.position[1] - 2 >= 0) { // up and right
				if (currentPiece.king == player1Turn) {
					piece killingPiece = findPiece(new int[] {currentPiece.position[0] + 1, currentPiece.position[1] - 1});
					if (killingPiece != null && !killingPiece.dead) {
						if ((killingPiece.value != player1) == player1Turn) {
							if (findPiece(new int[] {currentPiece.position[0] + 2, currentPiece.position[1] - 2}) == null) {
								turnIsOver = false;
							}
						}
					}
				}
			}
			if (currentPiece.position[0] - 2 >= 0 && currentPiece.position[1] - 2 >= 0) { // up and left
				if (currentPiece.king == player1Turn) {
					piece killingPiece = findPiece(new int[] {currentPiece.position[0] - 1, currentPiece.position[1] - 1});
					if (killingPiece != null && !killingPiece.dead) {
						if ((killingPiece.value != player1) == player1Turn) {
							if (findPiece(new int[] {currentPiece.position[0] - 2, currentPiece.position[1] - 2}) == null) {
								turnIsOver = false;
							}
						}
					}
				}
			}
		}
		return turnIsOver;
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
	public void moveDown(ref piece selectedPiece, ref ConsoleKey currentAltitudeKey, ref game currentGame) {
		if (selectedPiece != null) {
			currentAltitudeKey = ConsoleKey.DownArrow;
		}
		else {
			currentGame.gameMap.move(new int[] {0, 1});
		}
	}
	public void moveUp(ref piece selectedPiece, ref ConsoleKey currentAltitudeKey, ref game currentGame) {
		if (selectedPiece != null) {
			currentAltitudeKey = ConsoleKey.UpArrow;
		}
		else {
			currentGame.gameMap.move(new int[] {0, -1});
		}
	}
	public void moveRight(ref piece selectedPiece, ref ConsoleKey currentAltitudeKey, ref game currentGame) {
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
	}
	public void moveLeft(ref piece selectedPiece, ref ConsoleKey currentAltitudeKey, ref game currentGame) {
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
		Console.BackgroundColor = ConsoleColor.White;
		Console.ForegroundColor = ConsoleColor.Black;
		Console.Clear();
		Console.BackgroundColor = ConsoleColor.Black;
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine("╔═════════════════════════════════╗");
		for (int i = 0; i < 8; i++) {
			Console.Write("║ ");
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
					if (currentPiece.king && currentPiece.value == map.player1) {
						Console.Write(map.player1King);
					}
					else if (currentPiece.king && currentPiece.value == map.player2) {
						Console.Write(map.player2King);
					}
					else {
						Console.Write(currentPiece.value);
					}
				}
				else {
					Console.Write(map.blank);
				}
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(" ");
			}
			Console.Write("║\n");
			offset = !offset;
		}
		Console.WriteLine("╚═════════════════════════════════╝");
	}
	public game() {
		
	}
}