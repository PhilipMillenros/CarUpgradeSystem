using System;

public class Timer
{
    public Action callback;
    public float time;

    public Timer(float time, Action callback)
    {
        this.time = time;
        this.callback = callback;
    }
}