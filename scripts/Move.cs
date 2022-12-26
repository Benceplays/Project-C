using Godot;
using System;

public class Move : KinematicBody2D
{
    [Export] public int speed = 5; 
    public override void _Ready()
    {
        
    }
    public override void _PhysicsProcess(float delta){
        Vector2 moveVector = new Vector2(0, 0);
        if(Input.IsActionPressed("left")){
            moveVector.x -= 1;
        }
        if(Input.IsActionPressed("right")){
            moveVector.x += 1;
        }
        if(Input.IsActionPressed("jump")){
            moveVector.y -= 1;
        }
        Position += moveVector*speed*delta;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
