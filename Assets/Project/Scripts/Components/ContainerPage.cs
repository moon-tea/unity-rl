using System;
using UnityEngine;

public class ContainerPage
{
    public ContainerPage(int x, int y)
    {
        this.x = x;
        this.y = y;
        description = new Description(
            text: "Containers hold the whole game, players, maps, items, AIs, console logs, and UI!",
            x: 20,
            y: 0,
            layer: 1,
            width: 40
        );
        container = new Container(
            x: 20,
            y: description.y + description.height + 1,
            width: 20,
            height: 10,
            player: new Player(
                layer: 2,
                x: 25,
                y: description.y + description.height + 5
            ),
            map: new Map(
                x: 20,
                y: description.y + description.height + 1,
                width: 20,
                height: 10,
                layer: 1
            )
        );
        container.player.addMapData(container.map);
    }

    public int x;
    public int y;
    public Container container;
    public Description description;

    public void render()
    {
        if (description != null)
        {
            description.render();
        }

        if (container != null)
        {
            container.render();
        }
    }
}
