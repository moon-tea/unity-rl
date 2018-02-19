using UnityEngine;
using System.Collections;
using System;

public class Tile
{
    public Tile(
        string ch,
        int x,
        int y,
        bool obstructsEverything = true,
        int layer = 3
    )
    {
        this.ch = ch;
        this.x = x;
        this.y = y;
        this.layer = layer;
        this.obstructsEverything = obstructsEverything;
    }

    public int x;
    public int y;
    public int layer;
    public string ch;
    public bool obstructsEverything;

    private float inputRate = .15f;
    private float timeOfLastInput = 0f;

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
        if (vertical != 0 && Time.time >= timeOfLastInput)
        {
            //Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
            //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
            setY(y - vertical);
            timeOfLastInput = Time.time + inputRate;
        }
        Cell cell = Display.CellAt(layer, x, y);
        cell.SetContent(ch, Color.clear, Color.Lerp(Color.white, Color.black, 0.15f));
    }
}
