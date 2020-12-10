using System;

class piece {
	public int[] position = new int[] {0, 0};
	public string value = "";
	public void move(int[] relativePosition) {
		if (position[0] + relativePosition[0] < 8 && 
		position[0] + relativePosition[0] > -1) {
			if (position[1] + relativePosition[1] < 8 && 
			position[1] + relativePosition[1] > -1) {
				position[0] += relativePosition[0];
				position[1] += relativePosition[1];
			}
		}
	}
	public piece(string newValue, int[] newPosition) {
		position = newPosition;
		value = newValue;
	}
}