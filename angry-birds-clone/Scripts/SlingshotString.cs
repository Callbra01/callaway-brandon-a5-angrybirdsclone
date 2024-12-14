using Godot;
using System;

public partial class SlingshotString : Node2D
{
    // Get Slingshot ponts
    Node2D rightArmPoint;
    Node2D leftArmPoint;
    Node2D slingPoint;

    Node2D mouseCircle = new Node2D();
    Vector2[] stringCoords = new Vector2[3];
    Vector4 stringBox = new Vector4();
    Vector2 birdHolder = new Vector2();
    bool isSlingPointTracking = false;
    bool canFire = false;


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

        // Drag ball(bird) with slingshot band
        if (isSlingPointTracking)
        {
            canFire = true;
            birdHolder = slingPoint.Position;
            slingPoint.GlobalPosition = mouseCircle.GlobalPosition;
        }

        // If mouse1 is released, disable slingpoint tracking, and lerp band back to stationary
        if (!Input.IsActionPressed("mouse1"))
        {
            isSlingPointTracking = false;
            if (canFire)
            {
                slingPoint.GlobalPosition = slingPoint.GlobalPosition.Lerp(rightArmPoint.GlobalPosition, 0.4f);

            }
        }
        // Redraw the string, as PolyLine doesn't update every frame
        QueueRedraw();
    }

    // Draw slingshot band
    public override void _Draw()
    {
        Color white = Colors.White;
        DrawPolyline(stringCoords, white, 15.4f);
    }

    // If mousecursor is colliding with slingshot band, being band drawback
    private void _on_area_2d_area_entered(Area2D area)
    {
        mouseCircle = area.GetParent<Node2D>();
        if (Input.IsActionPressed("mouse1"))
        {
            isSlingPointTracking = true;
        }
    }
}
