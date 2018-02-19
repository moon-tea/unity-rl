using System;
using UnityEngine;

public class MapPage
{
    public MapPage(int x, int y)
    {
        this.x = x;
        this.y = y;
        description = new Description(
            text: "Maps can be loaded and are a 2d arrays of chars to be interpretted as Tiles.",
            x: 20,
            y: 0,
            layer: 1
        );
        map = new Map(
            x: 20,
            y: description.y + description.height + 1,
            width: 20,
            height: 10,
            layer: 1
        );
    }

    public int x;
    public int y;
    public Map map;
    public Description description;

    public void render()
    {
        if (map != null)
        {
            map.render();
        }

        if (description != null)
        {
            description.render();
        }
    }
}
