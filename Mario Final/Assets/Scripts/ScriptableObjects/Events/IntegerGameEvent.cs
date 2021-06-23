using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntegerGameEvent", menuName = "ScriptableObjects/IntegerGameEvent", order = 2)]
public class IntegerGameEvent : ScriptableObject
{
    private readonly List<IntegerEventListener> listeners = new List<IntegerEventListener>();
    public void Raise(int value)
    {
        foreach (IntegerEventListener listener in listeners)
        {
            listener.OnEventRaised(value);
        }
    }
    public void Register(IntegerEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnRegister(IntegerEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
