using System;

public class Canvas{
    private int width;
    private int height;

    private int fieldX;
    private int fieldY;

    public Canvas(int width, int height){
        this.height = height;
        this.width = width;

        Console.Clear();
        fieldX = Console.CursorLeft + 3;
        fieldY = Console.CursorTop + 2;
        DrawBorder();
    }

    public int Width{
        get {return width;}
    }

    public int Height{
        get {return height;}
    }

    public void WriteMessageTop(string message, ConsoleColor color = ConsoleColor.White){
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = color;
        Console.Write(message);
    }

    public void WriteMessageBottom(string message, ConsoleColor color = ConsoleColor.White){
        Console.SetCursorPosition(0, height + 3);
        Console.ForegroundColor = color;
        Console.Write(message);
    }

    public void Clear(int x, int y){
        Console.SetCursorPosition(fieldX + x * 3, fieldY + y);
        Console.Write("   ");
    }

    public void Draw(int x, int y, char character, ConsoleColor color = ConsoleColor.White){
        Console.SetCursorPosition(fieldX + x * 3, fieldY + y);
        Console.ForegroundColor = color;
        Console.Write(" " + character + " ");
    }

    private void DrawBorder(){
        Console.WriteLine();
        for(int y = 0; y <= height + 1; y++){
            for(int x = 0; x <= width + 1; x++){
                if(y == 0 || y == height + 1){
                    Console.Write("===");
                }
                else if(x == 0){
                    Console.Write("|  ");   
                }
                else if(x == width + 1){
                    Console.Write("  |");  
                }
                else{
                   Console.Write("   "); 
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public override string ToString(){
        return "canvas to string";
    }
}