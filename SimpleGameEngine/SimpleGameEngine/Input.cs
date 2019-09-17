using System;
using static System.Console;

public enum InputType{
    UP, DOWN, LEFT, RIGHT, ESC, NONE
}

public static class Input{

    private static InputType keyPressed = InputType.NONE;

    public static InputType KeyPressed {
        get{ return keyPressed; }
    }

    public static void Update(){
        if (Console.KeyAvailable){
            ConsoleKey key = Console.ReadKey().Key;

            if(key == ConsoleKey.Escape){
                keyPressed = InputType.ESC;
                return;
            }
            else if(key == ConsoleKey.UpArrow){
                keyPressed = InputType.UP;
                return;
            }
            else if(key == ConsoleKey.DownArrow){
                keyPressed = InputType.DOWN;
                return;
            }
            else if(key == ConsoleKey.LeftArrow){
                keyPressed = InputType.LEFT;
                return;
            }
            else if(key == ConsoleKey.RightArrow){
                keyPressed = InputType.RIGHT;
                return;
            }
        }
        keyPressed = InputType.NONE;
    }
}