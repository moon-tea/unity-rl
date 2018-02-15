using UnityEngine;
using System.Collections;
using System;

public class Button : IClickAction, IHoverAction
{
    public Button(
        string text,
        int x,
        int y,
        int layer = 0,
        int width = -1,
        Color? bgColor = null,
        Color? fgColor = null,
        Action<Button> mouseDown = null,
        Action<Button> hoverEnter = null,
        Action<Button> hoverExit = null
    )
    {
        text = text;
        width = width > -1 ? width : text.Length + 2;
        mouseDownCallBack = mouseDown != null ? mouseDown : delegate { Debug.Log("mouseDown NotInUse"); };
        hoverEnterCallBack = hoverEnter != null ? hoverEnter: delegate { Debug.Log("hoverEnter NotInUse"); };
        hoverExitCallBack = hoverExit != null ? hoverExit : delegate { Debug.Log("hoverExit NotInUse"); };
        Color _bgColor = bgColor ?? Color.blue;
        Color _fgColor = fgColor ?? Color.white;

        Color[] bgColors = new Color[width];
        int startText = (int) Math.Floor((width / 2.0f) - Math.Floor(text.Length / 2.0f));
        for (int i = 0; i < bgColors.Length; i++)
        {
            //string c = (i < startText && i > startText + text.Length) ? " " : text.Substring(startText - i, 1);
            string c = " ";
            //woah, what the hell does this do? it basically makes a centered gradient. weird.
            Color localBgColor = Color.Lerp(_bgColor, Color.black, Math.Abs((text.Length / 2) - i) / text.Length / 2);

            Cell cell = Display.CellAt(layer, x + i, y);
            cell.SetContent(c, localBgColor, _fgColor);
        }
    }

    private string text;
    private int x;
    private int y;
    private int layer;
    private int width;
    private Color fgColor;
    private Color bgColor;
    private Action<Button> mouseDownCallBack;
    private Action<Button> hoverEnterCallBack;
    private Action<Button> hoverExitCallBack;

    public void OnMouseDown()
    {
        mouseDownCallBack(this);
    }

    #region IHoverAction implementation

    public void OnHoverEnter()
    {
        hoverEnterCallBack(this);
    }

    public void OnHoverExit()
    {
        hoverExitCallBack(this);
    }

    #endregion
}
