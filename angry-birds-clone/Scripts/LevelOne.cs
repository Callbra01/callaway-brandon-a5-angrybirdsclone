using Godot;
using System;

public partial class LevelOne : Node2D
{
	[Export]
	public PackedScene mouseCircle;

	[Export]
	public PackedScene slingshot;

	[Export]
	public PackedScene redBird;

	bool hasBirdBeenReleased = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Node mCircle = mouseCircle.Instantiate();
		Node sling = slingshot.Instantiate();
		Node bird = redBird.Instantiate();

		this.AddChild(mCircle);
		this.AddChild(sling);
		this.AddChild(bird);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Node2D slingPos = GetNode<Node2D>("Slingshot");
		slingPos.GlobalPosition = GetNode<Node2D>("SlingshotSpawn").Position;
		Node2D slingPoint = slingPos.GetNode<Node2D>("SlingshotPoints/Pull Point");


        RigidBody2D birdPos = GetNode<RigidBody2D>("RedBird");
		if (!hasBirdBeenReleased)
		{
            //birdPos.GlobalPosition = slingPoint.GlobalPosition;
        }
		else
		{
			//birdPos.ApplyForce(new Vector2(1000, 0));
		}


    }
}
