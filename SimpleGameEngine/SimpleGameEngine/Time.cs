using System;

public static class Time{
    private static DateTime prevFrameTime = DateTime.Now;
    private static double deltaTime;

    public static void Update(){
        DateTime now = DateTime.Now;
        deltaTime = now.Subtract(prevFrameTime).TotalMilliseconds/1000.0;
        prevFrameTime = DateTime.Now;
    }
    
    public static double DeltaTime{
        get{ return deltaTime; }
    }
}