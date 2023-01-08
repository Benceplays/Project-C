using Godot;
using System;

public class Game : Node2D
{
	private float armyLvL;
	private float airforceLvL;
	private float turretLvL;
	private float money;
	private float armynumbers;
	private float planenumbers;

	private bool gamefps;
	public Panel upgradepanel;
	private Label armylvllabel;
	private Label airforcelvllabel;
	private Label turretlvllabel;
	private Label moneylabel;

	public String path;
	public ConfigFile config;
	private Timer zombietimer;
	private Timer dronetimer;
	private Label fpslabel;
    private AnimatedSprite turret;
	private Label armyslabel;
	private Label planeslabel;

	private Button armyprize;
	private Button airforceprize;
	private Button turretprize;

	[Export] public PackedScene psarmy;
	[Export] public PackedScene psplane;
	[Export] public PackedScene psdrone;
	[Export] public PackedScene pszombie;

	
	public override void _Ready()
	{
		path = "user://save.cfg"; // res vagy user:
		config = new ConfigFile();
		config.Load(path);
		armyLvL = Convert.ToSingle(config.GetValue("Upgrades", "ArmyLvL", 0));
		airforceLvL = Convert.ToSingle(config.GetValue("Upgrades", "AirForceLvL", 0));
		turretLvL = Convert.ToSingle(config.GetValue("Upgrades", "TurretLvL", 0));
		gamefps = Convert.ToBoolean(Convert.ToSingle(config.GetValue("Options", "GameFps", 0)));
		armynumbers = Convert.ToSingle(config.GetValue("Player", "Army", 0));
		planenumbers = Convert.ToSingle(config.GetValue("Player", "Plane", 0));

		turret = GetNode("/root/Game/Turret/StaticBody2D/Shot") as AnimatedSprite;
		upgradepanel = GetNode("Upgrade") as Panel;
		armylvllabel = GetNode("Upgrade/Army/ArmyLvL") as Label;
		airforcelvllabel = GetNode("Upgrade/AirForce/AirForceLvL") as Label;
		turretlvllabel = GetNode("Upgrade/Turret/TurretLvL") as Label;
		moneylabel = GetNode("MoneyLabel") as Label;
		zombietimer = GetNode("ZombieTimer") as Timer;
		dronetimer = GetNode("DroneTimer") as Timer;
		fpslabel = GetNode("FpsLabel") as Label;
		armyslabel = GetNode("HUD/Armys") as Label;
		planeslabel = GetNode("HUD/Planes") as Label;
		armyprize = GetNode("Upgrade/Army/Button") as Button;
		airforceprize = GetNode("Upgrade/AirForce/Button") as Button;
		turretprize = GetNode("Upgrade/Turret/Button") as Button;


		turret.Play("Shot");
        GetTree().Paused = false;
	}

	public void _on_ArmyAdd_pressed(){
		float armynumbersforadd = Convert.ToSingle(config.GetValue("Player", "Army", 0));
		if (armynumbersforadd != 0){
			Node2D army = (Node2D)psarmy.Instance();
			army.Position = new Vector2(-83, 432);
			AddChild(army);
			armynumbersforadd--;
			config.SetValue("Player", "Army", armynumbersforadd);
			config.Save(path);
		}
	}
	public void _on_PlanesAdd_pressed(){
		float planenumbersforadd = Convert.ToSingle(config.GetValue("Player", "Plane", 0));
		if(planenumbersforadd != 0){
			Node2D planeinstance = (Node2D)psplane.Instance();
			planeinstance.Position = new Vector2(-80, 92);
			AddChild(planeinstance);
			planenumbersforadd--;
			config.SetValue("Player", "Plane", planenumbersforadd);
			config.Save(path);
		}
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
	public void _on_ZombieTimer_timeout(){
		Node2D zombieinstance = (Node2D)pszombie.Instance();
		zombieinstance.Position = new Vector2(1330, 484);
		AddChild(zombieinstance);
	}
	public void _on_DroneTimer_timeout(){
		Node2D droneinstance = (Node2D)psdrone.Instance();
		droneinstance.Position = new Vector2(1109, 95);
		AddChild(droneinstance);
	}
	public void _on_ArmyTimer_timeout(){
		float armynumbersforadd = Convert.ToSingle(config.GetValue("Player", "Army", 0));
		armynumbersforadd++;
		config.SetValue("Player", "Army", armynumbersforadd);
		config.Save(path);
	}
	public void _on_PlaneTimer_timeout(){
		float planenumbersforadd = Convert.ToSingle(config.GetValue("Player", "Plane", 0));
		planenumbersforadd++;
		config.SetValue("Player", "Plane", planenumbersforadd);
		config.Save(path);
	}
	public override void _Process(float delta)
	{  
		config.Load(path);
		moneylabel.Text = $"${Convert.ToSingle(config.GetValue("Upgrades", "Money", 0))}";
		armyslabel.Text = $"{Convert.ToSingle(config.GetValue("Player", "Army", 0))}";
		planeslabel.Text = $"{Convert.ToSingle(config.GetValue("Player", "Plane", 0))}";
		if (gamefps == true){
			fpslabel.Text = $"{Convert.ToInt32(1 / delta)} FPS";
		}
		armylvllabel.Text = $"LvL.: {armyLvL}";
		airforcelvllabel.Text = $"LvL.: {airforceLvL}";
		turretlvllabel.Text = $"LvL.: {turretLvL}";
		armyprize.Text = $"$50";
		airforceprize.Text = $"$70";
		turretprize.Text = $"$100";
	}
}
