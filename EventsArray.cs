using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    public UnityEvent[] _event;
    public void StartEvent(int index)
    {
        _event[index].Invoke();
    }
}
