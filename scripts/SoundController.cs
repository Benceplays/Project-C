using Godot;
using System;

public class SoundController : Node2D
{
    private AudioStreamPlayer2D music;

    public String path;
    public ConfigFile config;
    public override void _Ready()
    {
        music = GetNode("Music") as AudioStreamPlayer2D;

        path = "res://save.cfg"; //res vagy user:
        config = new ConfigFile();
        config.Load(path);
        music.VolumeDb = Convert.ToSingle(config.GetValue("Options", "MusicVolume", 0));
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
