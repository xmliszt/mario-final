using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LocationUnityEvent : UnityEvent<Vector3>{}

public class LocationEventListener : MonoBehaviour
{
    public LocationGameEvent Event;
    public LocationUnityEvent Response;

    private void OnEnable() {
        Event.Register(this);
    }

    private void OnDisable() {
        Event.UnRegister(this);
    }

    public void OnEventRaised(Vector3 location)
    {
        Response.Invoke(location);
    }
}
