using Godot;
using System;

public class Menu : Node2D
{
    private Label fpslabel;
    public String path;
	public ConfigFile config;
    private bool fpsison;
    public override void _Ready()
    {
        path = "res://save.cfg"; // res vagy user:
        config = new ConfigFile();
        config.Load(path);
        fpsison = Convert.ToBoolean(Convert.ToSingle(config.GetValue("Options", "MenuFps", 0)));
        fpslabel = GetNode("FpsLabel") as Label;
        if(fpsison == true){
            switch (Convert.ToSingle(config.GetValue("Options", "FpsTarget", 0)))
            {
                case 30:
                    Engine.TargetFps = 30;
                    break;
                case 60:
                    Engine.TargetFps = 60;
                    break;
                case 90:
                    Engine.TargetFps = 90;
                    break;
                case 120:
                    Engine.TargetFps = 120;
                    break;
            }
        }
    }
    public void _on_Play_pressed(){
        GetTree().ChangeScene("res://scenes/Game.tscn");
    }
    public void _on_Options_pressed(){
        GetTree().ChangeScene("res://scenes/Options.tscn");
    }
    public void _on_Exit_pressed(){
        GetTree().Quit();
    }

    public override void _Process(float delta)
    {
        if(fpsison == true){fpslabel.Text = $"{Convert.ToInt32(1 / delta)} FPS";}    
    }
}
