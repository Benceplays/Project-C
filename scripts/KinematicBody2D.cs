using Godot;
using System;

public class KinematicBody2D : Godot.KinematicBody2D
{
    private AnimatedSprite zombie;
    [Export] public int speed = 200; 
    public override void _Ready()
    {
        zombie = GetNode("Zombie") as AnimatedSprite;
    }

    public override void _Process(float delta)
    {
        Vector2 moveVector = new Vector2(0, 0);
        zombie.Play("Walk");
        moveVector.x -= 1;
        Position += moveVector*speed*delta;
    }
}
