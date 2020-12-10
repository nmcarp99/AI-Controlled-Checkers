using System;

class piece {
	public int[] position = new int[] {0, 0};
	public string value = "";

	public piece(string newValue, int[] newPosition) {
		position = newPosition;
		value = newValue;
	}
}