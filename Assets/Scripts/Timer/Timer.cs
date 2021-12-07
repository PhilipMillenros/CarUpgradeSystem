using System;
public class Timer
{ 
    public float time; 
    public Action callback;

    public Timer(float time, Action callback)
    {
        this.time = time;
        this.callback = callback;
    }
}