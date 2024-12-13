using Godot;
using System;

public partial class SlingshotString : Node2D
{

    Node2D rightArmPoint;
    Node2D leftArmPoint;
    Node2D slingPoint;

    Node2D mouseCircle = new Node2D();
    Vector2[] stringCoords = new Vector2[3];

    bool isSlingPointTracking = false;

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

        if (isSlingPointTracking)
        {
            slingPoint.GlobalPosition = mouseCircle.GlobalPosition;
        }

        if (!Input.IsActionPressed("mouse1"))
        {
            isSlingPointTracking = false;
        }
        // Redraw the string, incase of movement
        QueueRedraw();
    }

    public override void _Draw()
    {
        Color white = Colors.White;
        DrawPolyline(stringCoords, white, 15.4f);
    }

    private void _on_area_2d_area_entered(Area2D area)
    {
        mouseCircle = area.GetParent<Node2D>();
        if (Input.IsActionPressed("mouse1"))
        {
            isSlingPointTracking = true;
        }
        
    }
}
