using Godot;
using System;
using MySql.Data.MySqlClient;

public class Login : Node2D
{
    public LineEdit username;
    public LineEdit password;
    public string constring;
    public MySqlConnection conn;
    
    public override void _Ready()
    {
        username = GetNode("Username") as LineEdit;
        password = GetNode("Password") as LineEdit;

    }

    public void _on_LoginButton_pressed()
    {
            string server = "localhost";
            string database = "wildem";
            string usernamee = "root";
            string passwordd = "";
            constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" +
                               "UID=" + usernamee + ";" + "PASSWORD=" + passwordd + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
            string query = $"SELECT * FROM login WHERE username='{username}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                GD.Print(reader["password"]);
                if (!(username.Text == "" && password.Text == ""))
                {
                    if (password.Text == Convert.ToString(reader["password"]))
                    {
                        GD.Print("Sikeres bejelentkezés");
                        reader.Close();
                    }
                }
                else
                {
                    GD.Print("Ne hagyd uresen");
                }
                conn.Close();
            }
        else
        {
            GD.Print("Nem csatlakozik");
        }
        
    }
    
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
/*
            string server = "87.229.85.107";
            string database = "wildem_reglog";
            string usernamee = "wpuser";
            string passwordd = "password";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" +
                "UID=" + usernamee + ";" + "PASSWORD=" + passwordd + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
            string query = $"SELECT * FROM reglog WHERE username='{usernametext}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            if (passwordtext == Convert.ToString(reader["password"]))
            {
*/