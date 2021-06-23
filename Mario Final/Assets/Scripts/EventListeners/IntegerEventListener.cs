using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntegerUnityEvent : UnityEvent<int>{}

public class IntegerEventListener : MonoBehaviour
{
    public IntegerGameEvent Event;
    public IntegerUnityEvent Response;

    private void OnEnable() {
        Event.Register(this);
    }

    private void OnDisable() {
        Event.UnRegister(this);
    }

    public void OnEventRaised(int value)
    {
        Response.Invoke(value);
    }
}
