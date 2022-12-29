using Godot;
using System;

public class Planes : KinematicBody2D
{
	private AnimatedSprite plane;
	private KinematicBody2D drone;
	public String path;
	public ConfigFile config;
	[Export] public int speed = 200; 
	private float money;
	public override void _Ready()
	{
		path = "res://save.cfg"; //res vagy user:
		config = new ConfigFile();
		plane = GetNode("AnimatedSprite") as AnimatedSprite;
		drone = GetNode("/root/Game/Drone/KinematicBody2D") as KinematicBody2D;
	}

	public void _on_Planes_body_entered(object body){
		if(body == drone){
			GD.Print("A repulo felrobbantva");
			config.Load(path);
			money = Convert.ToSingle(config.GetValue("Upgrades", "Money", 0));
			money++;
			config.SetValue("Upgrades", "Money", money);
			config.Save(path);
			QueueFree();
			drone.QueueFree();
		}
	}
public override void _Process(float delta)
	{
	Vector2 moveVector = new Vector2(0, 0);
	moveVector.x += 2;
	Position += moveVector*speed*delta;    
	}
}
