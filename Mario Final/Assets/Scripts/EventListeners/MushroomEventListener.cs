using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MushroomUnityEvent : UnityEvent<MushroomBooster>{}

public class MushroomEventListener : MonoBehaviour
{
    public MushroomGameEvent Event;
    public MushroomUnityEvent Response;

    private void OnEnable() {
        Event.Register(this);
    }

    private void OnDisable() {
        Event.UnRegister(this);
    }

    public void OnEventRaised(MushroomBooster booster)
    {
        Response.Invoke(booster);
    }
}
