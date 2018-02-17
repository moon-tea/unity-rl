using System;
using UnityEngine;

public class PlayerPage
{
    public PlayerPage(int x, int y)
    {
        this.x = x;
        this.y = y;
        description = new Description(
            text: "There can be only one player. Players can move around the map.",
            x: 20,
            y: 0,
            layer: 1
        );
        player = new Player(
            x: 20,
            y: description.y + description.height + 1,
            layer: 1
        );
    }

    public int x;
    public int y;
    public Player player;
    public Description description;

    public void render()
    {
        if (player != null)
        {
            player.render();
        }
     
        if (description != null)
        {
            description.render();
        }
    }
}
