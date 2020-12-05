using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObjectDiedEvent
{
    private readonly List<Action<DamageableObject>> _callbacks = new List<Action<DamageableObject>>();

    public void Subscribe(Action<DamageableObject> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(DamageableObject obj)
    {
        foreach (Action<DamageableObject> callback in _callbacks)
            callback(obj);
    }
}
