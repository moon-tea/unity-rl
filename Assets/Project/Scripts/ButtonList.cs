using System;
using System.Collections.Generic;

public class ButtonList
{
	public ButtonList(
        Button[] buttons,
        int x,
        int y,
        int layer
    )
	{
        this.x = x;
        this.y = y;
        this.layer = layer;

        for (var i = 0; i < buttons.Length; i++)
        {
            buttons[i].x = this.x;
            buttons[i].y = this.y + i;
            buttons[i].layer = this.layer;
            buttons[i].dirty = true;
        }

        this.buttons = buttons;

        //render();
	}

    public void render()
    {
        for (var i = 0; i < buttons.Length; i++)
        {
            if(buttons[i] != null)
            {
                buttons[i].render();
            }
        }
    }

    private Button[] buttons;
    private int x;
    private int y;
    private int layer;
    
    //We can't detect child dirty and this has no internal state, thus it needs no dirtyness
    //private bool dirty = true;
}
