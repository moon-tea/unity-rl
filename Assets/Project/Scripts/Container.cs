using System;

public class Container
{
    public Container(
        int x,
        int y,
        int width,
        int height,
        Map map,
        Player player
    )
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.map = map;
        this.player = player;
    }
        
    public int x;
    public int y;
    public int width;
    public int height;
    public int layer;
    public Map map;
    public Player player;

    public void update()
    {
        
    }

    public void render()
    {
        if (player != null)
        {
            player.render();
        }

        if (map != null)
        {
            map.render();
        }
    }
}
