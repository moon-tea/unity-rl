using System;
using UnityEngine;

public class TilePage
{
    public TilePage(int x, int y)
    {
        this.x = x;
        this.y = y;
        description = new Description(
            text: "Tiles keep info about rendering, but also have game world statistics and state.",
            x: 20,
            y: 0,
            layer: 1
        );
        /*tiles = new Map(
            x: 20,
            y: description.y + description.height + 1,
            layer: 1
        );*/
    }

    public int x;
    public int y;
    public Tile[] tiles;
    public Description description;

    public void render()
    {
        for (var i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                tiles[i].render();
            }
        }

        if (description != null)
        {
            description.render();
        }
    }
}
