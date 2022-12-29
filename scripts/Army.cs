using Godot;
using System;

public class Army : KinematicBody2D
{
    private AnimatedSprite army;
    private KinematicBody2D enemy;
    [Export] public int speed = 200; 
    [Export] public PackedScene psarmy;
    private float money;
    public String path;
    public ConfigFile config;
    public override void _Ready()
    {
        army = GetNode("Army") as AnimatedSprite;
        enemy = GetNode("/root/Game/Enemy/KinematicBody2D") as KinematicBody2D;
        path = "res://save.cfg"; //res vagy user:
        config = new ConfigFile();
    }
    public void _on_Army2_body_entered(object body){
        if(body == enemy){
            GD.Print("A katona feláldozta magát");
            config.Load(path);
            money = Convert.ToSingle(config.GetValue("Upgrades", "Money", 0));
            money++;
            config.SetValue("Upgrades", "Money", money);
            config.Save(path);
            this.QueueFree();
        }
    }

    public override void _Process(float delta)
    {
        Vector2 moveVector = new Vector2(0, 0);
        army.Play("Walk");
        moveVector.x += 1;
        Position += moveVector*speed*delta;
    }
}
