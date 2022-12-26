using Godot;
using System;

public class Move : KinematicBody2D
{
    [Export] public int speed = 200; 
    public override void _Ready()
    {
        
    }
    public override void _PhysicsProcess(float delta){
        Vector2 moveVector = new Vector2(0, 0);
        if(Input.IsActionPressed("left")){
            moveVector.x -= 1;
        }
        else if(Input.IsActionPressed("right")){
            moveVector.x += 1;
        }
        else if(Input.IsActionPressed("jump")){
            if(IsOnFloor()){
                moveVector.y -= 1;
            }
        }
        else{
            moveVector.y = 1f;
        }
        Position += moveVector*speed*delta;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
