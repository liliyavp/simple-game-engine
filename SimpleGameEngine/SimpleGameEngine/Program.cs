using System;
using static System.Console;

class Program
{
    const int WIDTH = 20;
    const int HEIGHT = 20;

    //the speed increase to the game after picking up a pickup.
    const double SPEED_INCREASE = 0.1;

    //the speed the game will start at.
    const double START_SPEED = 3.5;

    private static Canvas canvas;
    private static Snake snake;
    private static Pickup pickup;
    private static int score;

    static void Main()
    {
        //Initializing our variables
        canvas = new Canvas(WIDTH, HEIGHT);
        snake = new Snake(WIDTH / 2, HEIGHT / 2, START_SPEED);
        pickup = new Pickup(WIDTH, HEIGHT);
        score = 0;

        //Drawing our snake on the canvas
        canvas.Draw(snake.X, snake.Y, 'O');

        //Writing the score at the top of the canvas
        canvas.WriteMessageTop("Score: 0");

        //Hiding the cursor in the console.
        Console.CursorVisible = false;

        //Starting the GameLoop
        GameLoop();
    }

    static void GameLoop()
    {
        //Create game loop
        while (true)
        {
            Time.Update();
            Input.Update();

            //check if esc was pressed so we can exit the game
            if (Input.KeyPressed == InputType.ESC)
            {
                canvas.WriteMessageBottom("Exiting Game...");
                WriteLine();
                break;
            }

            /*  ------------------------------------------
                4.1
                ------------------------------------------   
                -   Store the x position of the snake in a variable called prevSnakeX.
                -   Store the y position of the snake in a variable called prevSnakeY.
                -   Call the Update method of snake.

                This way we can store the previous position of the snake before
                we update it
            */

            int prevSnakeX = snake.X;
            int prevSnakeY = snake.Y;
            snake.Update();

            /*  ------------------------------------------
                4.2
                ------------------------------------------   
                Change the if statement below so that it will only be true
                if either the x or y position of the snake has changed since
                the last update.

                This will allow us to only make updates to the game
                if the snake moved.
            */

            if (snake.X != prevSnakeX || snake.Y != prevSnakeY)
            {

                /*  ------------------------------------------
                    4.3
                    ------------------------------------------   
                    If the position of the snake is equal to the position of 
                    the pickup (It's been picked up),  do the following:

                    -   Add 100 to the score.
                    -   Use the relevant method of cnavas to update the score 
                        displaying at the top of the screen.
                    -   Increase the speed of the snake with the value of SPEED_INCREASE.
                    -   Use the relevant method to add a segment to the snake.
                    -   Use the relevant method of the pickup to change 
                        its position.
                */

                if (snake.X == pickup.X && snake.Y == pickup.Y)
                {
                    score += 100;
                    canvas.WriteMessageTop("Score: " + score);
                    snake.Speed += SPEED_INCREASE;
                    snake.AddSegment();
                    pickup.SetPosition();
                }

                /*  ------------------------------------------
                    4.4
                    ------------------------------------------   
                    If the IsSnakeInBounds mehtod returns false, or 
                    the IsHeadTouchingBody method of the snake returns true,
                    the game is over. Do the following:

                    -   "Game Over :(" should be written to the bottom of the
                        screen using the relevant method of the canvas object.
                    -   Call the WriteLine method of the Console class.
                    -   Call the Beep method of the Console class.
                    -   Break out of the game loop.
                */

                if (IsSnakeInBounds() == false || snake.IsHeadTouchingBody())
                {
                    canvas.WriteMessageBottom("Game Over :(");
                    Console.WriteLine();
                    Console.Beep();
                    break;
                }

                //This method call will update the positions of all the snake segments.
                snake.UpdateSegments();

                /*  ------------------------------------------
                    4.5
                    ------------------------------------------ 
                    We have updated the positions of all the segments of the snake,  
                    but now we need to draw the segements to the canvas.

                    REMEMBER: We need to clear the character drawn at the previous
                    segment position before we draw the new one.

                    BONUS: See if you can alternate the colours of the segments 
                    between Magenta and Green.
                */

                for (int i = 0; i<snake.Segments.Count; i++)
                {
                    if (i%2 == 0)
                    {
                        canvas.Draw(snake.Segments[i].X, snake.Segments[i].Y, snake.Segments[i].Character, ConsoleColor.Magenta);
                    }
                    else
                    {
                        canvas.Draw(snake.Segments[i].X, snake.Segments[i].Y, snake.Segments[i].Character, ConsoleColor.Green);
                    }
                }

                //draw pickup
                canvas.Draw(pickup.X, pickup.Y, '', ConsoleColor.Red);
            }
        }
    }

    static bool IsSnakeInBounds()
    {
        /*  ------------------------------------------
            4.6
            ------------------------------------------
            Returns true if the snake's X and Y positions are 
            within the bounds of the canvas and false if it's not
        */

        if (snake.X <= canvas.Width && snake.Y <= canvas.Height)
        {
            return true;
        }
        else
        return false;
    }
}