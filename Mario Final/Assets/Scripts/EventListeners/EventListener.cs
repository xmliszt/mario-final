using UnityEngine.Events;

[System.Serializable]
public class EventListener
{
    public GameEvent Event;
    public UnityEvent Response;
    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
