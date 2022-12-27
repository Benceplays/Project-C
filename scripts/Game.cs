using Godot;
using System;

public class Game : Node2D
{
    public Panel upgradepanel;
    public override void _Ready()
    {
        upgradepanel = GetNode("Upgrade") as Panel;
    }
    public void _on_Upgrades_pressed(){
        upgradepanel.Visible = true;
    }
    public void _on_ExitButton_pressed(){
        upgradepanel.Visible = false;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
