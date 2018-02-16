using System;

public class ButtonPage
{
	public ButtonPage(int x, int y)
	{
        this.x = x;
        this.y = y;
        description = new Description(
            text: "Buttons have a hover state and can deploy callback methods",
            x: 20,
            y: 0,
            //height: 4,
            width: 20,
            layer: 1
        );
        buttons = new Button[] {
            new Button(
               text: "Example Button",
               x: 20,
               y: description.y + description.height + 1,
               layer: 1
            )
        };
	}   

    public int x;
    public int y;
    public Button[] buttons;
    public Description description;

    public void render()
    {
        for (var i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] != null)
            {
                buttons[i].render();
            }
        }

        if (description != null)
        {
            description.render();
        }
    }
}
