using System;

public class Map
{
	public Map(
        int x,
        int y,
        int width,
        int height,
        int layer
    )
	{
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.layer = layer;
        populateBasicRoom(width, height);
    }

    public void populateBasicRoom(int width, int height)
    {
        tiles = new Tile[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i < 1 || j < 1 || i > width - 2 || j > height - 2)
                {
                    tiles[i, j] = new Tile(
                        ch: "#",
                        x: i,
                        y: j,
                        obstructsEverything: true,
                        fgColor: Tile.WallfgColor,
                        bgColor: Tile.WallbgColor
                    );
                }
                else
                {
                    tiles[i, j] = new Tile(
                        ch: ".",
                        x: i,
                        y: j,
                        fgColor: Tile.FloorfgColor,
                        bgColor: Tile.FloorbgColor
                    );
                }
            }
        }
    }

    public int x;
    public int y;
    public int width;
    public int height;
    public int layer;
    public Tile[,] tiles;

    public void render()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Cell cell = Display.CellAt(layer, x + i, y + j);
                if(cell != null) {
                    cell.SetContent(tiles[i, j].ch, tiles[i, j].bgColor, tiles[i, j].fgColor);
                }
            }
        }
    }    
}
