using System;

class piece {
	public int[] position = new int[] {0, 0};
	public bool dead = false;
	public bool king = false;
	public string value = "";
	public void move(int[] relativePosition, map gameMap) {
		if (position[0] + relativePosition[0] < 8 && 
		position[0] + relativePosition[0] > -1) {
			if (position[1] + relativePosition[1] < 8 && 
			position[1] + relativePosition[1] > -1) {
				if (gameMap.findPiece(new int[] {position[0] + relativePosition[0], position[1] + relativePosition[1]}) == null) {
					position[0] += relativePosition[0];
					position[1] += relativePosition[1];
					gameMap.player1Turn = !gameMap.player1Turn;
				}
				else if (gameMap.findPiece(new int[] {position[0] + (relativePosition[0] * 2), position[1] + (relativePosition[1] * 2)}) == null && 
				position[0] + (relativePosition[0] * 2) < 8 && 
				position[0] + (relativePosition[0] * 2) > -1) {
					if (position[1] + (relativePosition[1] * 2) < 8 && 
					position[1] + (relativePosition[1] * 2) > -1 && gameMap.findPiece(new int[] {position[0] + relativePosition[0], position[1] + relativePosition[1]}).value != value) {
						gameMap.findPiece(new int[] {position[0] + relativePosition[0], position[1] + relativePosition[1]}).dead = true;
						position[0] += relativePosition[0] * 2;
						position[1] += relativePosition[1] * 2;
						if (gameMap.checkTurnOver()) {
							gameMap.player1Turn = !gameMap.player1Turn;
						}
					}
				}
			}
		}
		if ((position[1] == 7 && value == map.player1) ||
		(position[1] == 0 && value == map.player2)) {
			king = true;
		}
	}
	public piece(string newValue, int[] newPosition) {
		position = newPosition;
		value = newValue;
	}
}