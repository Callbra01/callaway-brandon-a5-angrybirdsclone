using Godot;
using System;

public partial class MouseCircle : Node2D
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Get mouse position
		Position = GetViewport().GetMousePosition();

		// If mouse1 is pressed, scale the size of the mouse orb
		if (Input.IsActionPressed("mouse1"))
		{
			this.Scale = new Vector2(1, 1);
		}
		else
		{
			this.Scale = new Vector2 (2, 2);
		}

	}
}
