using Godot;
using System;

public class Options : Node2D
{
    private CheckBox gamefpscheck;
    private CheckBox menufpscheck;
    private HSlider fpstarget;
    private Button reset;
    private HSlider mainvolume;
    private HSlider musicvolume;
    private HSlider soundeffectvolume;
    private AudioStreamPlayer2D music;
    private Label fpstargetlabel;

    public String path;
	public ConfigFile config;

    public override void _Ready(){
        gamefpscheck = GetNode("Display/GameFps") as CheckBox;
        menufpscheck = GetNode("Display/MenuFps") as CheckBox;
        fpstarget = GetNode("Display/FpsTarget") as HSlider;
        mainvolume = GetNode("Audio/MainVolume") as HSlider;
        musicvolume = GetNode("Audio/MusicVolume") as HSlider;
        soundeffectvolume = GetNode("Audio/SoundEffectVolume") as HSlider;
        music = GetNode("/root/SoundController/Music") as AudioStreamPlayer2D;
        fpstargetlabel = GetNode("Display/FpsTarget/FpsTarget") as Label;

        path = "user://save.cfg"; // res vagy user:
		config = new ConfigFile();
		config.Load(path);
		gamefpscheck.Pressed = Convert.ToBoolean(Convert.ToSingle(config.GetValue("Options", "GameFps", 0)));
		menufpscheck.Pressed = Convert.ToBoolean(Convert.ToSingle(config.GetValue("Options", "MenuFps", 0)));
		fpstarget.Value = Convert.ToSingle(config.GetValue("Options", "FpsTarget", 0));
		mainvolume.Value = Convert.ToSingle(config.GetValue("Options", "MainVolume", 0));
		musicvolume.Value = Convert.ToSingle(config.GetValue("Options", "MusicVolume", 0));
		soundeffectvolume.Value = Convert.ToSingle(config.GetValue("Options", "SoundEffectVolume", 0));
    }
    public void _on_BackButton_pressed(){
        GetTree().ChangeScene("res://scenes/Menu.tscn");
    }
    public void _on_ResetButton_pressed(){
        gamefpscheck.Pressed = false;
		menufpscheck.Pressed = false;
		fpstarget.Value = 0;
		mainvolume.Value = 0;
		musicvolume.Value = 0;
		soundeffectvolume.Value = 0;
        config.SetValue("Options", "GameFps", false);
        config.SetValue("Options", "MenuFps", false);
        config.SetValue("Options", "FpsTarget", 0);
        config.SetValue("Options", "MainVolume", 0);
        config.SetValue("Options", "MusicVolume", 0);
        config.SetValue("Options", "SoundEffectVolume", 0);
		config.Save(path);
    }

    public void _on_SaveButton_pressed(){
        config.SetValue("Options", "GameFps", gamefpscheck.Pressed);
        config.SetValue("Options", "MenuFps", menufpscheck.Pressed);
        config.SetValue("Options", "FpsTarget", fpstarget.Value);
        config.SetValue("Options", "MainVolume", mainvolume.Value);
        config.SetValue("Options", "MusicVolume", musicvolume.Value);
        config.SetValue("Options", "SoundEffectVolume", soundeffectvolume.Value);
		config.Save(path);
        config.Load(path);
        music.VolumeDb = Convert.ToSingle(config.GetValue("Options", "MusicVolume", 0));
    }
    public override void _Process(float delta)
    {
        fpstargetlabel.Text = $"{fpstarget.Value}";
        if(gamefpscheck.Pressed){gamefpscheck.Text = "ON";} else{ gamefpscheck.Text = "OFF";}
        if(menufpscheck.Pressed){menufpscheck.Text = "ON";} else{ menufpscheck.Text = "OFF";}
    }
}
