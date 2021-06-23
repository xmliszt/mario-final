using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationEvent", menuName = "ScriptableObjects/LocationEvent", order = 2)]
public class LocationGameEvent : ScriptableObject
{
    private readonly List<LocationEventListener> listeners = new List<LocationEventListener>();
    public void Raise(Vector3 location)
    {
        foreach (LocationEventListener listener in listeners)
        {
            listener.OnEventRaised(location);
        }
    }
    public void Register(LocationEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnRegister(LocationEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
