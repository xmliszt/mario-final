using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MushroomEvent", menuName = "ScriptableObjects/MushroomEvent", order = 2)]
public class MushroomGameEvent : ScriptableObject
{
    private readonly List<MushroomEventListener> listeners = new List<MushroomEventListener>();
    public void Raise(MushroomBooster booster)
    {
        foreach (MushroomEventListener listener in listeners)
        {
            listener.OnEventRaised(booster);
        }
    }
    public void Register(MushroomEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnRegister(MushroomEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
