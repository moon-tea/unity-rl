using UnityEngine;
using System.Collections;
using System;

public class Tile
{
    public Tile(
        string ch,
        int x,
        int y,
        bool obstructsEverything = false,
        int layer = 3,
        Color? fgColor = null,
        Color? bgColor = null
    )
    {
        this.ch = ch;
        this.x = x;
        this.y = y;
        this.layer = layer;    
        this.bgColor = bgColor ?? Color.black;
        this.fgColor = fgColor ?? Color.white;
        this.setObstructsEverything(obstructsEverything);
    }

    public int x;
    public int y;
    public int layer;
    public string ch;
    public Color fgColor;
    public Color bgColor;

    public bool obstructsPassability = false;
    public bool obstructsVision = false;
    
    public static Color WallfgColor = new Color(.07f, .07f, .07f);
    public static Color WallbgColor = new Color(.45f, .40f, .40f);
    public static Color FloorfgColor = new Color(.30f, .30f, .30f);
    public static Color FloorbgColor = new Color(.02f, .02f, .10f);

    //color wallBackColor;
    //									Red		Green	Blue	RedRand	GreenRand	BlueRand	Rand	Dances?

    //const color wallForeColor = { 7, 7, 7, 3, 3, 3, 0, false };
    //const Color wallBackColorStart = { 45, 40, 40, 15, 0, 5, 20, false };
    //const Color wallBackColorEnd = { 40, 30, 35, 0, 20, 30, 20, false };

    //const color floorForeColor = { 30, 30, 30, 0, 0, 0, 35, false };
    //const color floorBackColorStart = { 2, 2, 10, 2, 2, 0, 0, false };
    //const color floorBackColorEnd = { 5, 5, 5, 2, 2, 0, 0, false };

    //public bool obstructsItems;
    //public bool obstructsGas;
    //public bool obstructsSurfaceEffects;
    //public bool obstructsDiagonalMovement;

    public bool obstructsEverything = false;

    void setObstructsEverything(bool obstructsEverything)
    {
        if(obstructsEverything)
        {
            this.obstructsEverything = true;
            this.obstructsPassability = true;
            this.obstructsVision = true;
        }
        //public bool obstructsItems;
        //public bool obstructsGas;
        //public bool obstructsSurfaceEffects;
        //public bool obstructsDiagonalMovement;
    }

    void setX(int x)
    {
        if (x >= 0 && x < Display.GetDisplayWidth())
        {
            this.x = x;
        }
    }

    void setY(int y)
    {
        if (y >= 0 && y < Display.GetDisplayHeight())
        {
            this.y = y;
        }
    }

    public void render()
    {
        //TODO this is heavy handed

        /*
        for (int x = 0; x < Display.GetDisplayWidth(); x++)
        {
            for (int y = 0; y < Display.GetDisplayHeight(); y++)
            {
                Cell c = Display.CellAt(layer, x, y);
                c.Clear();
            }
        }
        */

        //Check if moving horizontally, if so set vertical to zero.

        //Check if we have a non-zero value for horizontal or vertical
        Cell cell = Display.CellAt(layer, x, y);
        cell.SetContent(ch, Color.clear, Color.Lerp(Color.white, Color.black, 0.15f));
    }
}
