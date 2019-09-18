using System;

public class Pickup{
    private int maxX; //the maximum x position for our pickup
    private int maxY; //the maximum y position for our pickup
    private int x; //the current x position for our pickup
    private int y; //the current y position for our pickup
    private Random r = new Random();

    public Pickup(int maxX, int maxY){
        /*  ------------------------------------------
            3.1
            ------------------------------------------   
            Initialize the maxX and maxY fields 
            using the values passed to the constructor

            Call the SetPosition method.
        */

        this.maxX = maxX;
        this.maxY = maxY;

        SetPosition();
    }

    public int X {
        get { return x; }
    }

    public int Y {
        get { return y; }
    }

    public void SetPosition(){
        /*  ------------------------------------------
            3.2
            ------------------------------------------   
            SetPosition should set x to a random value 
            between 0 and maxX, and y to a random value 
            between 0 maxY.
        */

        x = r.Next(maxX);
        y = r.Next(maxY);

    }
}