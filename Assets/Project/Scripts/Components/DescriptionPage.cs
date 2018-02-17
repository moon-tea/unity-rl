using System;

public class DescriptionPage
{
    public DescriptionPage(int x, int y)
    {
        this.x = x;
        this.y = y;
        description = new Description(
            text: "Descriptions have text that breaks at word boundaries. their width can be overridden and their height grows automatically.",
            x: 20,
            y: 0,
            //height: 4,
            width: 20,
            layer: 1
        );
        descriptions = new Description[] {
            new Description(
               text: "Hello World",
               x: 25,
               y: description.y + description.height + 1,
               layer: 1
            ),
            new Description(
               text: "This line of text is very long.",
               x: 40,
               y: description.y + description.height + 3,
               layer: 1,
               width: 16
            ),
            new Description(
               text: "lorem impsum dolor sit amet lorem dolor sit amet ipsum  impsum dolor sit amet  dolor sit amet ipsum dolor sit amet lorem dolor sit amet ipsum",
               x: 20,
               y: description.y + description.height + 8,
               layer: 1,
               width: 30
            ),
        };
    }

    public int x;
    public int y;
    public Description[] descriptions;
    public Description description;

    public void render()
    {
        for (var i = 0; i < descriptions.Length; i++)
        {
            if (descriptions[i] != null)
            {
                descriptions[i].render();
            }
        }

        if (description != null)
        {
            description.render();
        }
    }
}
