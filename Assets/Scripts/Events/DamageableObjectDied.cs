using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObjectDiedEvent
{
    private readonly List<Action<bool>> _callbacks = new List<Action<bool>>();

    public void Subscribe(Action<bool> callback)
    {
        _callbacks.Add(callback);
    }

    public void Publish(bool a_isPlayer)
    {
        Debug.Log("Died!");
        foreach (Action<bool> callback in _callbacks)
            callback(a_isPlayer);
    }
}
