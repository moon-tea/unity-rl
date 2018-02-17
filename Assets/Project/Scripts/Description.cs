using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Description
{
	public Description(
        string text = "",
        int x = 0,
        int y = 0,
        int width = 20,
        int height = -1,
        int layer = 0,
        Color? bgColor = null,
        Color? fgColor = null        
    )
	{
        string[] _words = text.Split(' ');
        string _line = "";
        this.lines = new List<string>();

        for(var i = 0; i < _words.Length; i++)
        {
            string _possibleLine = i == 0 ? _words[i] : _line + " " + _words[i];
            if(_possibleLine.Length <= width)
            {
                _line = _possibleLine;
            }
            else
            {
                this.lines.Add(_line);
                _line = _words[i];
            }

            if(i == _words.Length - 1 && _line.Length > 0)
            {
                this.lines.Add(_line);
            }
        }

        this.text = text;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height > -1 ? height : lines.Count;
        this.bgColor = bgColor ?? Color.Lerp(Color.black, Color.white, 0.05f);
        this.fgColor = fgColor ?? Color.Lerp(Color.white, Color.black, 0.15f);
        this.layer = layer;
    }

    public string text;
    public int x;
    public int y;
    public int layer;
    public int width;
    public int height;
    private Color fgColor;
    private Color bgColor;
    public bool dirty = true;

    private List<string> lines;

public void render()
    {
        int count = 0;
        foreach (string _line in lines)
        {
            for (int i = 0; i < width; i++)
            {
                Cell cell = Display.CellAt(layer, x + i, y + count);
                if(i < _line.Length)
                {
                    cell.SetContent(_line.Substring(i, 1), bgColor, fgColor);
                }
                else
                {
                    cell.SetContent(" ", bgColor, fgColor);
                }                
            }
            count++;
        }
        dirty = false;
    }
}
