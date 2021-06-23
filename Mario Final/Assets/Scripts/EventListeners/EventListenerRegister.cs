using System.Collections.Generic;
using UnityEngine;

public class EventListenerRegister : MonoBehaviour
{
    public List<EventListener> listeners;

    private void OnEnable() {
        foreach (EventListener listener in listeners)
        {
            listener.Event.Register(listener);
        }
    }

    private void OnDisable() {
        foreach (EventListener listener in listeners)
        {
            listener.Event.UnRegister(listener);
        }
    }

}
