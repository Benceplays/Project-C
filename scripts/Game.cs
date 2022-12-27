using Godot;
using System;

public class Game : Node2D
{
    public Panel upgradepanel;
    [Export] public PackedScene psarmy;
    public override void _Ready()
    {
        upgradepanel = GetNode("Upgrade") as Panel;
        Random rnd = new Random(); 
        for (int i = 0; i < 5; i++)
        {
            Vector2 rand = new Vector2(rnd.Next(0, 200), rnd.Next(1, 300));
            Node2D army = (Node2D)psarmy.Instance();
            army.Position = rand;
            AddChild(army);
        }
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
