using Godot;
using System;

public class Planes : KinematicBody2D
{
    private Sprite plane;
    [Export] public int speed = 200; 
    public override void _Ready()
    {
        plane = GetNode("Plane") as Sprite;
    }

public override void _Process(float delta)
    {
    Vector2 moveVector = new Vector2(0, 0);
    moveVector.x += 1;
    Position += moveVector*speed*delta;    
    }
}
