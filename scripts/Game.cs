using Godot;
using System;

public class Game : Node2D
{
	private float armyLvL;
	private float airforceLvL;
	private float turretLvL;
	private float money;
	public Panel upgradepanel;
	private Label armylvllabel;
	private Label airforcelvllabel;
	private Label turretlvllabel;
	private Label moneylabel;

	public String path;
	public ConfigFile config;
	[Export] public PackedScene psarmy;
	[Export] public PackedScene psplane;

	
    private AnimatedSprite turret;
	private AnimatedSprite plane;
	public override void _Ready()
	{
		path = "res://save.cfg"; // res vagy user:
		config = new ConfigFile();
		config.Load(path);
		armyLvL = Convert.ToSingle(config.GetValue("Upgrades", "ArmyLvL", 0));
		airforceLvL = Convert.ToSingle(config.GetValue("Upgrades", "AirForceLvL", 0));
		turretLvL = Convert.ToSingle(config.GetValue("Upgrades", "TurretLvL", 0));

		plane = GetNode("/root/Game/Planes/KinematicBody2D/AnimatedSprite") as AnimatedSprite;
		turret = GetNode("/root/Game/Turret/StaticBody2D/Shot") as AnimatedSprite;
		upgradepanel = GetNode("Upgrade") as Panel;
		armylvllabel = GetNode("Upgrade/Army/ArmyLvL") as Label;
		airforcelvllabel = GetNode("Upgrade/AirForce/AirForceLvL") as Label;
		turretlvllabel = GetNode("Upgrade/Turret/TurretLvL") as Label;
		moneylabel = GetNode("MoneyLabel") as Label;
		turret.Play("Shot");
		plane.Play("Plane");
        GetTree().Paused = false;
	}

	public void _on_ArmyAdd_pressed(){
		Node2D army = (Node2D)psarmy.Instance();
		army.Position = new Vector2(-83, 437);
		AddChild(army);
	}
	public void _on_PlanesAdd_pressed(){
		Node2D planeinstance = (Node2D)psplane.Instance();
		planeinstance.Position = new Vector2(-80, 92);
		AddChild(planeinstance);
	}

	public void _on_Upgrades_pressed(){
		upgradepanel.Visible = true;
	}
	public void _on_ExitButton_pressed(){
		upgradepanel.Visible = false;
	}
	public void _on_ArmyUpgradeButton_pressed(){
		armyLvL++;
		config.SetValue("Upgrades", "ArmyLvL", armyLvL);
		config.Save(path);
	}

	public void _on_AirForceUpgradeButton_pressed(){
		airforceLvL++;
		config.SetValue("Upgrades", "AirForceLvL", airforceLvL);
		config.Save(path);
	}
	public void _on_TurretUpgradeButton_pressed(){
		turretLvL++;
		config.SetValue("Upgrades", "TurretLvL", turretLvL);
		config.Save(path);
	}
	public override void _Process(float delta)
	{  
		config.Load(path);
		moneylabel.Text = $"Your money: ${Convert.ToSingle(config.GetValue("Upgrades", "Money", 0))}";
		armylvllabel.Text = $"LvL.: {armyLvL}";
		airforcelvllabel.Text = $"LvL.: {airforceLvL}";
		turretlvllabel.Text = $"LvL.: {turretLvL}";
	}
}
