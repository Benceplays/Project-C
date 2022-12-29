using Godot;
using System;

public class Menu : Node2D
{
    private AudioStreamPlayer2D music;
    public override void _Ready()
    {
        music = GetNode("Music") as AudioStreamPlayer2D;
        //music.Play();
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

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
