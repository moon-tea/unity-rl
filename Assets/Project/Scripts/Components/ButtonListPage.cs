using System;

public class ButtonListPage
{
    public ButtonListPage(int x, int y)
    {
        this.x = x;
        this.y = y;
        description = new Description(
            text: "ButtonLists render stacked buttons also known as menus",
            x: 20,
            y: 0,
            //height: 4,
            width: 20,
            layer: 1
        );
        buttonLists = new ButtonList[] {
            new ButtonList(
                new Button[] {
                    new Button(
                        text: "Button 0"
                    ),
                    new Button(
                        text: "Button 1"
                    ),
                    new Button(
                        text: "Button 2"
                    )
                },
                x: x,
                y: description.height + y + 1,
                layer: 1
           )
        };
    }

    public int x;
    public int y;
    public ButtonList[] buttonLists;
    public Description description;

    public void render()
    {
        for (var i = 0; i < buttonLists.Length; i++)
        {
            if (buttonLists[i] != null)
            {
                buttonLists[i].render();
            }
        }

        if (description != null)
        {
            description.render();
        }
    }
}
