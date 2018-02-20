using UnityEngine;
using System;

[Serializable]
public class RlColor
{
    public RlColor (
       float red = 0f,
       float green = 0f,
       float blue = 0f,
       float redRand = 0f,
       float greenRand = 0f,
       float blueRand = 0f,
       float rand = 0f,
       bool dances = false
    )
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.redRand = redRand;
        this.greenRand = greenRand;
        this.blueRand = blueRand;
        this.redRand = rand;
        //not used yet
        this.dances = dances;
    }

    static public Color getColor(RlColor rlColor)
    {
        float myRand = rnd.Next(0, (int)(rlColor.rand * 100f)) / 100f;
        //Debug.Log(rlColor.red + rnd.Next(0, (int)(rlColor.redRand * 100)) / 100 + rlColor.rand);
        //Debug.Log(rlColor.redRand*100f);// + rlColor.rand);
        //Debug.Log(rnd.Next(0, 10));
        //Debug.Log(rnd.Next(0, (int)(rlColor.redRand * 100f)) / 100f);// + rlColor.rand);
        return new Color(
           rlColor.red + rnd.Next(0, (int)(rlColor.redRand * 100f)) / 100f + myRand,
           rlColor.green + rnd.Next(0, (int)(rlColor.greenRand * 100f)) / 100f + myRand,
           rlColor.blue + rnd.Next(0, (int)(rlColor.blueRand * 100f)) / 100f + myRand
       );
    }

    public float red;
    public float green;
    public float blue;

    public float redRand;
    public float greenRand;
    public float blueRand;

    public float rand;

    public bool dances;
    //public Color color;
        
    public static RlColor WallfgColor  = new RlColor(.07f, .07f, .07f, .03f, .03f, .03f, .00f, false);
    public static RlColor WallbgColor  = new RlColor(.45f, .40f, .40f, .15f, .00f, .05f, .20f, false);
    public static RlColor FloorfgColor = new RlColor(.30f, .30f, .30f, .00f, .00f, .00f, .35f, false);
    public static RlColor FloorbgColor = new RlColor(.02f, .02f, .10f, .02f, .02f, .00f, .00f, false);
    private static System.Random rnd = new System.Random();

    //color wallBackColor;
    //									Red		Green	Blue	RedRand	GreenRand	BlueRand	Rand	Dances?

    //const color wallForeColor = { 7, 7, 7, 3, 3, 3, 0, false };
    //const Color wallBackColorStart = { 45, 40, 40, 15, 0, 5, 20, false };
    //const Color wallBackColorEnd = { 40, 30, 35, 0, 20, 30, 20, false };

    //const color floorForeColor = { 30, 30, 30, 0, 0, 0, 35, false };
    //const color floorBackColorStart = { 2, 2, 10, 2, 2, 0, 0, false };
    //const color floorBackColorEnd = { 5, 5, 5, 2, 2, 0, 0, false };

    //public bool obstructsItems;
    //public bool obstructsGas;
    //public bool obstructsSurfaceEffects;
    //public bool obstructsDiagonalMovement;

    /*
    public void render()
    {
    
    }
    */
}
