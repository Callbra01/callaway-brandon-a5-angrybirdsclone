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
	Node bird;

	[Export]
	public Camera2D camera;

	[Export]
	public Node2D birdParent;

	bool hasBirdBeenReleased = false;

	float powerDistance = 0f;
	bool canApplyForce;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Node mCircle = mouseCircle.Instantiate();
		Node sling = slingshot.Instantiate();
		bird = redBird.Instantiate();
		birdParent = GetNode<Node2D>("BirdParent");

        this.AddChild(mCircle);
		this.AddChild(sling);
        birdParent.AddChild(bird);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Node2D slingPos = GetNode<Node2D>("Slingshot");
		slingPos.GlobalPosition = GetNode<Node2D>("SlingshotSpawn").Position;
		Node2D slingPoint = slingPos.GetNode<Node2D>("SlingshotPoints/Pull Point");
        RigidBody2D birdPos = birdParent.GetNode<RigidBody2D>("RedBird");

		// Get distance from slingshot band to 25, where the slingshot is position
        var x1 = slingPoint.Position.X;
		var x2 = 25;
        var y1 = slingPoint.Position.Y;
		var y2 = slingPoint.Position.Y;
		if (Input.IsActionJustReleased("mouse1"))
		{
            powerDistance = ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        
		if (slingPoint.Position.X > 25)
		{
			hasBirdBeenReleased = true;
		}
		
		if (!hasBirdBeenReleased)
		{
			birdParent.GlobalPosition = slingPoint.GlobalPosition;
            birdPos.GlobalPosition = slingPoint.GlobalPosition;
			canApplyForce = true;
        }
		else
		{
			camera.Enabled = true;
			camera.Position = birdPos.GlobalPosition;
			if (canApplyForce)
			{
                birdPos.ApplyForce(new Vector2(powerDistance, 0));
				canApplyForce = false;
            }
		}
    }
	// For the life of me I can not figure out collision between tags when I can only get a node and not an RB from an RB object's signal
	private void _on_brick_body_entered(Node body)
	{
		if (body.Name == "Brick" || body.Name == "Brick2" || body.Name == "Brick3" || body.Name == "Brick4")
		{
			GD.Print("THUG");
		}
	}
}
