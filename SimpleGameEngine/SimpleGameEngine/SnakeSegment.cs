public class SnakeSegment{
    private int x; //the x position of this snake segment
    private int y; //the y position of this snake segment
    private int prevX; //the previous x position of this snake segment
    private int prevY; //the previous y position of this snake segment

    private char character; //the character representing this snake segment visually

    public SnakeSegment(int x, int y, char character){
        /*  ------------------------------------------
            1.1
            ------------------------------------------   
            Initialize the x, y and character fields 
            using the values passed to the constructor
        */

        this.x = x;
        this.y = y;
        this.character = character;

    }

    public int X {
        get {return x;}
        set {
            /*  ------------------------------------------
                1.2
                ------------------------------------------
                Before overwriting x with the new value,
                set prevX to the current value of x
            */

            prevX = x;
            x = value;

        }
    }

    public int Y {
        get {return y;}
        set {
            /*  ------------------------------------------
                1.3
                ------------------------------------------
                Before overwriting y with the new value,
                set prevY to the current value of y
            */

            prevY = y;
            y = value;

        }
    }

    public int PrevX {
        get {return prevX;}
    }

    public int PrevY {
        get {return prevY;}
    }

    public char Character{
        get {return character;}
    }
}