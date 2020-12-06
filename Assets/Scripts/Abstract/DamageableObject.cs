using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableObject : MonoBehaviour
{
    public delegate void OnObjectDie(DamageableObject obj);
    public static event OnObjectDie ObjectDieEvent;

    //PUBLIC
    public float healtPoints;

    public UnityEvent hitEvent;

    //PRIVATE

    //PUBLIC FUNCTIONS
    public void TakeDamage(float damage)
    {
        healtPoints -= damage;
        hitEvent.Invoke();
    }

    //PRIVATE FUNCTIONS
    private void Start()
    {

    }

    private void Update()
    {
        if (healtPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ObjectDieEvent.Invoke(this);
        Destroy(gameObject);
        //EventAggregator.DamageableObjectDied.Publish(isPlayer);
    }
}
