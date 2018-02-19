using UnityEngine;
using System.Collections;

/*
 * public class Clicker
{
    public Action<int> onMouseDown;
    public void setOnMouseDown(Action<int> f)
    {
        this.onMouseDown = f;
    }
}
*/

public class FirstScene : MonoBehaviour, IClickAction, IHoverAction
{
    //private Button[] menuButtons;
    private ButtonList[] menus;
    private string renderPage;
    private int clearLayer = -1;

    private DescriptionPage descriptionPage;
    private ButtonPage buttonPage;
    private ButtonListPage buttonListPage;
    private PlayerPage playerPage;
    private MapPage mapPage;
    private ContainerPage containerPage;

    public IEnumerator Start()
    {

        // wait until display has initialized
        while (!Display.IsInitialized())
        {
            yield return null;
        }
        
        // output red hello world at 10,5 on layer 0
        string menuStr = "Menu:";
        Vector2 menuStart = new Vector2(0, 0);  
        renderText(
            str: menuStr,
            x: (int) menuStart.x,
            y: (int)menuStart.y,
            fgColor: Color.red,
            clickable: true,
            hoverable: true
        );
        renderText(
            str: "?",
            x: (int)menuStart.x + menuStr.Length,
            y: (int)menuStart.y,
            fgColor: Color.yellow,
            clickable: true,
            hoverable: true
        );

        menus = new ButtonList[] {
            new ButtonList(
                new Button[] {
                    new Button(
                        text: "clear",
                        mouseDown: delegate {
                            Debug.Log("clear");
                            this.renderPage = "";
                            this.clearLayer = 1;
                        }
                    ),
                    new Button(
                        text: "Description",
                        mouseDown: delegate {
                            Debug.Log("DescriptionPage");
                            this.renderPage = "DescriptionPage";
                            this.clearLayer = 1;
                        }
                    ),
                    new Button(
                        text: "Button",
                        mouseDown: delegate {
                            Debug.Log("ButtonPage");
                            this.renderPage = "ButtonPage";
                            this.clearLayer = 1;
                        }
                    ),
                    new Button(
                        text: "ButtonList",
                        mouseDown: delegate {
                            Debug.Log("ButtonListPage");
                            this.renderPage = "ButtonListPage";
                            this.clearLayer = 1;
                        }
                    ),
                    new Button(
                        text: "Player",
                        mouseDown: delegate {
                            Debug.Log("PlayerPage");
                            this.renderPage = "PlayerPage";
                            this.clearLayer = 1;
                        }
                    ),
                    new Button(
                        text: "Map",
                        mouseDown: delegate {
                            Debug.Log("MapPage");
                            this.renderPage = "MapPage";
                            this.clearLayer = 1;
                        }
                    ),
                    new Button(
                        text: "Container",
                        mouseDown: delegate {
                            Debug.Log("ContainerPage");
                            this.renderPage = "ContainerPage";
                            this.clearLayer = 1;
                        }
                    )
                },
                x: 1,
                y: 1,
                layer: 0
           )
        };

        buttonPage = new ButtonPage(x: 20, y: 1);
        buttonListPage = new ButtonListPage(x: 20, y: 1);
        descriptionPage = new DescriptionPage(x: 20, y: 1);
        playerPage = new PlayerPage(x: 20, y: 1);
        mapPage = new MapPage(x: 20, y: 1);
        containerPage = new ContainerPage(x: 20, y: 1);

        /*
        menuButtons[0] = new Button(
            text: "a Room",
            x: 0,
            y: 1
        );

        menuButtons[1] = new Button(
            text: "@ Walking",
            x: 0,
            y: 2
        );
        */

        /*for (int x = 0; x < menu.Length; x++)
        {
            Cell cell = Display.CellAt(0, 0 + x, 0);
            cell.SetContent(
                menu.Substring(x, 1),
                Color.clear,
                Color.red);
        }*/

        /*
        // add clickable cell text on layer 2
        string clickableText = "Click->";
        for (int x = 0; x < clickableText.Length; x++)
        {
            Cell cell = Display.CellAt(2, x, 17);
            cell.SetContent(
                clickableText.Substring(x, 1),
                Color.clear,
                Color.yellow);
        }
        */

        // add clickable cell on layer 0
        /*
        Cell clickable = Display.CellAt(0, 0 + menu.Length, 0);
        clickable.SetContent(
            "?",
            Color.black,
            Color.yellow);
        clickable.clickAction = this;
        clickable.hoverAction = this;
        */
        /*
        Cell clickable2 = Display.CellAt(0, 0 + menu.Length, 1);
        clickable2.SetContent(
            "#",
            Color.black,
            Color.yellow);
        clickable2.clickAction = this;
        clickable2.hoverAction = this;
        */
        //StartCoroutine(RandomGrid());
        //StartCoroutine(Transition());
    }

    public void Update()
    {
        // clear every cell on layer 1 with mouse click
        //if (Input.GetMouseButtonDown(0))
        if (this.clearLayer > -1)
        {
            for (int x = 0; x < Display.GetDisplayWidth(); x++)
            {
                for (int y = 0; y < Display.GetDisplayHeight(); y++)
                {
                    Cell cell = Display.CellAt(clearLayer, x, y);
                    cell.Clear();
                }
            }
            this.clearLayer = -1;
        }

        if (menus != null)
        {
            for (int i = 0; i < menus.Length; i++)
            {
                if (menus[i] != null)
                {
                    menus[i].render();
                }
            }
        }

        switch (renderPage)
        {
            case "DescriptionPage":
                descriptionPage.render();
                break;
            case "ButtonPage":
                buttonPage.render();
                break;
            case "ButtonListPage":
                buttonListPage.render();
                break;
            case "PlayerPage":
                playerPage.render();
                break;
            case "MapPage":
                mapPage.render();
                break;
            case "ContainerPage":
                containerPage.render();
                break;
            default:
                Debug.Log("!!PAGE NOT DEFINED!!");
                break;
        }
    }

    private void renderText(string str, int x, int y, int layer = 0, Color? bgColor = null, Color? fgColor = null, bool clickable = false, bool hoverable = false)
    {
        for (int i = 0; i < str.Length; i++)
        {
            Cell cell = Display.CellAt(layer, x + i, y);
            cell.SetContent(str.Substring(i, 1), bgColor ?? Color.clear, fgColor ?? Color.yellow);
            ClickableObject c = new ClickableObject();
            c.setMyName(str);
            c.setMouseDownCallback(doSomething);
            if (clickable)
            {
                cell.clickAction = c;
            }
            if(hoverable)
            {
                cell.hoverAction = c;
            }
        }
    }

    private void doSomething(string s)
    {
        Debug.Log("callback with s:" + s);
    }

    public IEnumerator RandomGrid()
    {

        // fill random cells every frame on layer 1
        while (Application.isPlaying)
        {
            for (int i = 0; i < 50; i++)
            {
                Cell cell = Display.CellAt(
                    1,
                    Random.Range(17, Display.GetDisplayWidth()),
                    Random.Range(0, Display.GetDisplayHeight()));

                // random color and alpha
                Color color = Color.Lerp(Color.yellow, Color.green, Random.Range(0f, 1f));
                color = new Color(color.r, color.g, color.b, Random.Range(0f, 1f));

                cell.SetContent(
                    Random.Range(0, 10) + "",
                    Color.clear,
                    color);
            }

            yield return null;
        }
    }

    public IEnumerator Transition()
    {

        // repeat transition animation
        while (Application.isPlaying)
        {

            // output white text at 0,15 on layer 2 with fade transition
            string text = "Transition Animation";
            for (int x = 0; x < text.Length; x++)
            {
                Cell cell = Display.CellAt(2, x, 15);
                cell.SetContent(
                    text.Substring(x, 1),
                    Color.clear,
                    Color.white,
                    0.5f,
                    Color.white);
            }

            // clear text after a while with red fade transition
            yield return new WaitForSeconds(0.75f);
            for (int x = 0; x < text.Length; x++)
            {
                Cell cell = Display.CellAt(2, x, 15);
                cell.Clear(
                    0.5f,
                    Color.red);
            }

            yield return new WaitForSeconds(0.75f);
        }
    }

    #region IClickAction implementation

    public void OnMouseDown()
    {
        // show clicked text
        string clicked = "You Clicked!";
        renderText(
            str: clicked,
            layer: 2,
            x: 0,
            y: 19,
            fgColor: Color.red
        );
    }

    #endregion

    #region IHoverAction implementation

    public void OnHoverEnter()
    {
        // show hover text
        string hover = "You Hovered!";
        renderText(
             str: hover,
             layer: 2,
             x: 0,
             y: 18,
             fgColor: Color.white
         );
    }

    public void OnHoverExit()
    {
    }

    #endregion
}
