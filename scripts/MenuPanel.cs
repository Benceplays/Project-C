using Godot;
using System;

public class MenuPanel : Panel
{
    private Panel menupanel;
    public override void _Ready()
    {
        menupanel = GetNode(".") as Panel;
    }
    public void _on_MenuButton_pressed(){
        menupanel.Visible = true;
        GetTree().Paused = true;
    }
    public void _on_ReturnButton_pressed(){
        menupanel.Visible = false;
        GetTree().Paused = false;
    }
    public void _on_BackButton_pressed(){
        GetTree().ChangeScene("res://scenes/Menu.tscn");
        GetTree().Paused = false;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
