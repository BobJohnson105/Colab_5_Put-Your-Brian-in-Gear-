using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public enum EventType { Police, Hitchhiker, GasStation };
    public EventType currentEvent;

    public void Start()
    {
   
        currentEvent = EventType.Police;
          
    }
}
