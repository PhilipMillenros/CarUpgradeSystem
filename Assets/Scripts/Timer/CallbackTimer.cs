using System;
using System.Collections.Generic;
using UnityEngine;

public class CallbackTimer : MonoBehaviour
{
    public static List<Timer> timers = new();
    private CallbackTimer instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Update()
    {
        for (var i = 0; i < timers.Count; i++)
        {
            timers[i].time -= Time.deltaTime;
            if (timers[i].time <= 0)
            {
                timers[i].callback.Invoke();
                timers.Remove(timers[i]);
            }
        }
    }

    public static void AddTimer(float time, Action callback)
    {
        timers.Add(new Timer(time, callback));
    }
}