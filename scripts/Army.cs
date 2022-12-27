using Godot;
using System;

public class Army : KinematicBody2D
{
    private AnimatedSprite army;
    [Export] public int speed = 200; 
    [Export] public PackedScene psarmy;
    public override void _Ready()
    {
        army = GetNode("Army") as AnimatedSprite;
    }

    public override void _Process(float delta)
    {
        Vector2 moveVector = new Vector2(0, 0);
        army.Play("Walk");
        moveVector.x += 1;
        Position += moveVector*speed*delta;
    }
}
