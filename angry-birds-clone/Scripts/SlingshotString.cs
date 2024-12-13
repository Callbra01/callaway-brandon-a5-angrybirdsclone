using Godot;
using System;

public partial class SlingshotString : Node2D
{

    Node2D rightArmPoint;
    Node2D leftArmPoint;
    Node2D slingPoint;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        rightArmPoint = GetNode<Node2D>("Right Arm");
        leftArmPoint = GetNode<Node2D>("Left Arm");
        slingPoint = GetNode<Node2D>("Pull Point");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
