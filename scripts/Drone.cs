using Godot;
using System;

public class Drone : KinematicBody2D
{
    private Sprite drone;
    private Label moneylabel;
    [Export] public int speed = 200; 
    public override void _Ready()
    {
        drone = GetNode("Drone") as Sprite;
        moneylabel = GetNode("/root/Game/MoneyLabel") as Label;
    }

    public override void _Process(float delta)
    {
        Vector2 moveVector = new Vector2(0, 0);
        moveVector.x -= 1;
        Position += moveVector*speed*delta;
    }
    public override void _Input(InputEvent @event)
    {   
        if(Input.IsActionJustPressed("mouse_click")){
            moneylabel.Text = "Your Money: $300";
        }
    }
}
