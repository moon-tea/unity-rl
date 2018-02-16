using UnityEngine;
using System.Collections;
using System;

public class Button : IClickAction, IHoverAction
{
    public Button(
        string text,
        int x = 0,
        int y = 0,
        int layer = 0,
        int width = -1,
        Color? bgColor = null,
        Color? fgColor = null,
        bool clickable = true,
        bool hoverable = true,
        Action<Button> mouseDown = null,
        Action<Button> hoverEnter = null,
        Action<Button> hoverExit = null
    )
    {
        this.text = text;
        this.x = x;
        this.y = y;
        this.layer = layer;
        this.width = width > -1 ? width : text.Length + 4;
        this.clickable = clickable;
        this.hoverable = hoverable;
        this.mouseDownCallBack = mouseDown != null ? mouseDown : delegate { Debug.Log("mouseDown NotInUse"); };
        this.hoverEnterCallBack = hoverEnter != null ? hoverEnter: delegate { Debug.Log("hoverEnter NotInUse"); };
        this.hoverExitCallBack = hoverExit != null ? hoverExit : delegate { Debug.Log("hoverExit NotInUse"); };
        this.bgColor = bgColor ?? Color.Lerp(Color.blue, Color.white, .3f);
        this.fgColor = fgColor ?? Color.white;

        //render();
    }

    private string text;
    public int x;
    public int y;
    public int layer;
    private int width;
    private Color fgColor;
    private Color bgColor;
    private Action<Button> mouseDownCallBack;
    private Action<Button> hoverEnterCallBack;
    private Action<Button> hoverExitCallBack;

    private bool clickable;
    private bool hoverable;
    private bool hovered;
    private bool clicked;
    public bool dirty = true;

    public bool isDirty()
    {
        return dirty;
    }

    public void render()
    {
        Debug.Log("render button: " + text);
        Color[] bgColors = new Color[width];

        int startText = (int)Math.Floor((width / 2.0f) - Math.Floor(text.Length / 2.0f));
        for (int i = 0; i < bgColors.Length; i++)
        {
            string c = (i < startText || i >= startText + text.Length) ? " " : text.Substring(i - startText, 1);
            //woah, what the hell does this do? it basically makes a centered gradient. weird.
            float lerpAmount = Math.Abs(((float)width / 2f) - (float)i) / (float)width;
            Color localBgColor = Color.Lerp(bgColor, Color.black, lerpAmount);
            Color localFgColor = fgColor;
            if (hovered)
            {
                localBgColor = Color.Lerp(localBgColor, Color.yellow, .1f);
            }
            if (clicked)
            {
                localBgColor = Color.Lerp(localBgColor, Color.black, .7f);
                localFgColor = Color.Lerp(localBgColor, Color.black, .7f);
            }

            Cell cell = Display.CellAt(layer, x + i, y);
            cell.SetContent(c, localBgColor, localFgColor);
            if (clickable)
            {
                cell.clickAction = this;
            }
            if (hoverable)
            {
                cell.hoverAction = this;
            }
        }
        clicked = false;
        dirty = false;
    }

    public void OnMouseDown()
    {
        mouseDownCallBack(this);
        //Debug.Log("clicked");
        clicked = true;
        dirty = true;
    }

    #region IHoverAction implementation

    public void OnHoverEnter()
    {
        hoverEnterCallBack(this);
        //Debug.Log("hovered");
        hovered = true;
        dirty = true;
    }

    public void OnHoverExit()
    {
        hoverExitCallBack(this);
        //Debug.Log("unhovered");
        hovered = false;
        dirty = true;
    }

    #endregion
}
