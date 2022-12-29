using Godot;
using System;

public class Drone : KinematicBody2D
{
	public String path;
	public ConfigFile config;
	[Export] public int speed = 200; 
	public override void _Ready()
	{
		config = new ConfigFile();
		path = "res://save.cfg"; //res vagy user:
	}

	public override void _Process(float delta)
	{
		Vector2 moveVector = new Vector2(0, 0);
		moveVector.x -= 1;
		Position += moveVector*speed*delta;
	}
}
