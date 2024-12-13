using Godot;
using System;

public partial class SlingshotString : Node2D
{

    Node2D rightArmPoint;
    Node2D leftArmPoint;
    Node2D slingPoint;

    Vector2[] stringCoords = new Vector2[3];

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Get arm points
        rightArmPoint = GetNode<Node2D>("Right Arm");
        leftArmPoint = GetNode<Node2D>("Left Arm");
        slingPoint = GetNode<Node2D>("Pull Point");

        // Set arm point positions to vector2 array
        stringCoords[0] = rightArmPoint.Position;
        stringCoords[1] = slingPoint.Position;
        stringCoords[2] = leftArmPoint.Position;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        // Update string coord points
        stringCoords[0] = rightArmPoint.Position;
        stringCoords[1] = slingPoint.Position;
        stringCoords[2] = leftArmPoint.Position;

        // Redraw the string, incase of movement
        QueueRedraw();
    }

    public override void _Draw()
    {
        Color white = Colors.White;
        DrawPolyline(stringCoords, white, 15.4f);
    }
}
