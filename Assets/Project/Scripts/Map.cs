using System;
using System.IO;
using UnityEngine;

[Serializable]
public class someStrings
{ 
    public String[] strings;
}

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
        //populateBasicRoom(width, height);
        loadMap();
    }

    public void populateBasicRoom(int width, int height)
    {
        tiles = new Tile[width, height];
        someStrings ss = new someStrings();
        ss.strings = new String[height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if(i == 0)
                {
                    ss.strings[j] = "";
                }
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
                    ss.strings[j] = ss.strings[j] + "#";
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
                    ss.strings[j] = ss.strings[j] + ".";
                }
            }
        }

        string myJson = JsonUtility.ToJson(ss);
        File.WriteAllText(Application.dataPath + mapData, myJson);
        //JsonConvert.SerializeObject(strings);
        //dumpMap(strings);
    }

    public void loadMap()
    {
        string filePath = Application.dataPath + mapData;

        someStrings myStrings;
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            myStrings = JsonUtility.FromJson<someStrings>(dataAsJson);
        }
        else
        {
            myStrings = new someStrings();
            //gameData = new GameData();
        }

        tiles = new Tile[myStrings.strings[0].Length, myStrings.strings.Length];
        Debug.Log(myStrings.strings[0].Length);
        Debug.Log(myStrings.strings.Length);
        for (int i = 0; i < myStrings.strings[0].Length; i++)
        {
            for (int j = 0; j < myStrings.strings.Length; j++)
            {
                if (myStrings.strings[j].Substring(i, 1) == "#") {
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

    public Tile tileAt(int _x, int _y)
    {
        Debug.Log(_x);
        Debug.Log(x);
        Debug.Log(_y);
        Debug.Log(y);
        return tiles[_x-x, _y-y];
    }

    public int x;
    public int y;
    public int width;
    public int height;
    public int layer;
    public Tile[,] tiles;
    private string mapData = "/mapData.json"; 

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
