using Godot;
using System;

public partial class LevelOne : Node2D
{
	[Export]
	public PackedScene mouseCircle;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Node mCircle = mouseCircle.Instantiate();
		this.AddChild(mCircle);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
