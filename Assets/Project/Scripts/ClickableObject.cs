using UnityEngine;
using System.Collections;
using System;

public class ClickableObject : IClickAction, IHoverAction
{
	public ClickableObject()
	{
	}

    public string myName;
    private Action<string> mouseDownCallBack; 

    public void setMyName(string str)
    {
        myName = str;
    }

    public void setMouseDownCallback(Action<string> f)
    {
        mouseDownCallBack = f;
    }

    public void OnMouseDown()
    {
        // show clicked text
        string clicked = "You Clicked: " + myName;
        Debug.Log(clicked);
        mouseDownCallBack(myName);
    }

    #region IHoverAction implementation

    public void OnHoverEnter()
    {
        // show hover text
        string hover = "You Hovered!"+myName;
        Debug.Log(hover);
    }

    public void OnHoverExit()
    {
        // show hover text
        string hover = "You unHovered!" + myName;
        Debug.Log(hover);
    }

    #endregion
}
