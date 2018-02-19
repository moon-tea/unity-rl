using UnityEngine;
using System.Collections;
using System;

public class Player
{
	public Player(
        int x,
        int y,
        int layer = 3
    )
	{
        this.x = x;
        this.y = y;
        this.layer = layer;
	}

    public int x;
    public int y;
    public int layer;
    Map map;

    private float inputRate = .15f;
    private float timeOfLastInput = 0f;

    public void addMapData(Map m)
    {
        map = m;
    }

    void setX (int x)
    {
        if (x >= 0 
            && x < Display.GetDisplayWidth()
            && !map.tileAt(x,y).obstructsPassability)
        {
            this.x = x;
        }
    }

    void setY(int y)
    {
        if (y >= 0 
            && y < Display.GetDisplayHeight()
            && !map.tileAt(x, y).obstructsPassability)
        {
            this.y = y;
        }
    }

    public void render()
    {
        //TODO this is heavy handed
        for (int i = x - 1; i < x + 3; i++)
        {
            for (int j = y - 1; j < y + 3; j++)
            {
                Cell c = Display.CellAt(layer, i, j);
                if(c != null)
                {
                    c.Clear();
                }
            }
        }        
        
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
        
        int horizontal = 0;     //Used to store the horizontal move direction.
        int vertical = 0;       //Used to store the vertical move direction.

        //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        Debug.Log(horizontal + ", " + vertical);

        //Check if moving horizontally, if so set vertical to zero.
        if (horizontal != 0 && Time.time >= timeOfLastInput)
        {
            vertical = 0;
            setX(x + horizontal);
            timeOfLastInput = Time.time + inputRate;
        }

        //Check if we have a non-zero value for horizontal or vertical
        if (vertical != 0 && Time.time >= timeOfLastInput)
        {
            //Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
            //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
            setY(y - vertical);
            timeOfLastInput = Time.time + inputRate;
        }
        Cell cell = Display.CellAt(layer, x, y);
        cell.SetContent("@", Color.clear, Color.Lerp(Color.white, Color.black, 0.15f));
    }
}
