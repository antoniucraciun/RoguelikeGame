using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventWrapper : UnityEvent
{
    private int _listenerCount;

    public int ListenerCount { get { return _listenerCount; } }

    new public void AddListener(UnityAction call)
    {
        base.AddListener(call);
        _listenerCount++;
    }

    new public void RemoveListener(UnityAction call)
    {
        base.RemoveListener(call);
        _listenerCount--;
    }
}
