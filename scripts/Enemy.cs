using Godot;
using System;

public class Enemy : KinematicBody2D
{
	private AnimatedSprite zombie;
	private KinematicBody2D army;
	[Export] public int speed = 200; 
	public override void _Ready()
	{
		zombie = GetNode("Zombie") as AnimatedSprite;
		army = GetNode("/root/Game/Army/KinematicBody2D") as KinematicBody2D;
	}

	public void _on_Enemy_body_entered(object body){
		if(body == army){
			GD.Print("Zombie meghalt");
			this.QueueFree();
		}
	}

	public override void _Process(float delta)
	{
		Vector2 moveVector = new Vector2(0, 0);
		zombie.Play("Walk");
		moveVector.x -= 1;
		Position += moveVector*speed*delta;
	}
}
