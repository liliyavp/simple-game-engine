using System;
using System.Collections.Generic;
using static System.Console;
using static Time;

public class Snake{
    private double x; //the x position of the snake
    private double y; //the y position of the snake

    private int xDir = 0; //the x direction of the snake

    private int yDir = 1; //the y direction of the snake

    private double speed; //the speed that the snake is moving at

    /*  A List holding all the SnakeSegments of the snake.
        List are like arrays, but you don't have to set a size.
        The name between <> specifies the type List stores. */
    private List<SnakeSegment> segments = new List<SnakeSegment>();

    public Snake(int x, int y, double speed){
        /*  ------------------------------------------
            2.1
            ------------------------------------------   
            Initialize the x, y and speed fields 
            using the values passed to the constructor
        */

        this.x = x;
        this.y = y;
        this.speed = speed;

        
        /*  Adds a segment to the segments List
            This segment will serve as the head of the snake. */
        segments.Add(new SnakeSegment(x,y,'O'));
    }

    /*  You will notice that we round the double x and y fields
        to integers before returning them as ints in our properties
        below.

        Our snake's x and y positions will only be increasing by fractions
        with every execution of our GameLoop (see the Update method in this class). 
        Our game canvas only supports whole numbers. 
        
        Returning our positions in this way means we keep the precision
        of our positions, but only expose whole numbers the can place our
        snake correctly on our canvas */
    public int X {
        /*  Math.Floor will round our value 
            down to the nearest whole number. 
            We still have to cast it to an int */
        get {return (int) Math.Floor(x);}
    }

    public int Y {
        get {return (int) Math.Floor(y);}
    }

    public double Speed {
        get { return speed; }
        set { speed = value; }
    }

    public List<SnakeSegment> Segments {
        get { return segments; }
    }

    public void AddSegment(){
        /*  ------------------------------------------
            2.2
            ------------------------------------------   
            The AddSegment method adds a segment to our snake.

            1. First you need to store the last segment in our segments List
            in a variable called lastSegment. We can access items in a List
            the same way we access elements in an array. For instance 
            segments[0] will get the first item in the segments List.
            You can use the segments.Count property to determine the number of
            elements in the segments List.

            2. Next we need to create the new Segment that we can add to the 
            segments List. We can store it in a variable called newSegment.
            If you look at the constructor for SnakeSegment you will see we need 
            to specify the x and y position as well as a character that will represent
            the segment visually.
            The x and y positions should be the PrevX and PrevY positions of 
            the lastSegment. The character must be an 'o'.

            3. use the segments.Add method to add the newSegment to the back of
            the segments List.
        */
<<<<<<< Updated upstream

        SnakeSegment lastSegment = segments[segments.Count];
        SnakeSegment newSegment = new SnakeSegment(lastSegment.PrevX, lastSegment.PrevY, 'o');
        segments.Add(newSegment);

=======
<<<<<<< Updated upstream
=======

        SnakeSegment lastSegment = segments[segments.Count-1];
        SnakeSegment newSegment = new SnakeSegment(lastSegment.PrevX, lastSegment.PrevY, 'o');
        segments.Add(newSegment);

>>>>>>> Stashed changes
>>>>>>> Stashed changes
    }

    public void UpdateSegments(){
        /*  ------------------------------------------
            2.3
            ------------------------------------------   
            Update segments must update all the segments
            inside our segments List to their new positions.

            The X and Y position of the first segment in the list 
            must be set to the value of the X and Y properties of 
            our snake.

            The subsequent segments must have their X and Y position
            set to the PrevX and PrevY of the segment before it.

            You can use the segments.Count property to loop through
            the List of snake segments.  
        */

        for (int i = 0; i < segments.Count; i++)
        {
            if (i == 0)
            {
                segments[i].X = X;
                segments[i].Y = Y;
            }
            else
            {
                segments[i].X = segments[i - 1].PrevX;
                segments[i].Y = segments[i - 1].PrevY;
            }
        }
    }

    public bool IsHeadTouchingBody(){
        /*  ------------------------------------------
            2.4
            ------------------------------------------   
            This method should return true if the first item in the segments List
            has the exact same x and y positions as any of the other items in the
            segments List.

            It should return false otherwise.
        */
<<<<<<< Updated upstream

        if (segments[0].X == segments[segments.Count].X && segments[0].Y == segments[segments.Count-1].Y)
        {
            return true;
        }
        else
=======
<<<<<<< Updated upstream
=======

        for (int i = 1; i<segments.Count; i++)
        {
            if (segments[0].X == segments[i].X && segments[0].Y == segments[i].Y)
            {
                return true;
            }                
        }
>>>>>>> Stashed changes
>>>>>>> Stashed changes
        return false;
    }

    public void Update(){
        if(Input.KeyPressed == InputType.UP){
            yDir = -1;
            xDir = 0;
        }
        else if(Input.KeyPressed == InputType.DOWN){
            yDir = 1;
            xDir = 0;
        }
        /*  ------------------------------------------
            2.5
            ------------------------------------------   
            Complete this decision structure to also update the 
            directions when the LEFT and RIGHT keys are pressed.
        */
        else if(Input.KeyPressed == InputType.LEFT)
        {
            yDir = 0;
            xDir = -1;
        }
        else if (Input.KeyPressed == InputType.RIGHT)
        {
            yDir = 0;
            xDir = 1;
        }
        /*  ------------------------------------------
            2.6
            ------------------------------------------
            We will now need to update the x and y positions of the snake
            using the equation:
                direction * speed * deltaTime
                
            -   We can say that the speed is in units per second.
            -   deltaTime gives use the time passed since the last update,
                which is usually less than a second an differs from one
                update to the next 
            -   If we multipy the direction with the speed * deltaTime
                we get the distance that our snake should have moved since
                the last update.

            Update the x position of the snake by adding distance travelled
            in the xDir since the last update.

            Do the same for the y position.

            REMEMBER: you can use the static Time class to access the 
            DeltaTime property.
        */

        double distanceTravelled = xDir * speed * DeltaTime;
        x = x + distanceTravelled;
        distanceTravelled = yDir * speed * DeltaTime;
        y = y + distanceTravelled;

    }
}