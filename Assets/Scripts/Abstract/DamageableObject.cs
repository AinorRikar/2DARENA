using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableObject : UnityEngine.MonoBehaviour
{
    //PUBLIC
    public float healtPoints;

    public UnityEvent hitEvent;
    public UnityEvent deathEvent;

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
        //EventAggregator.DamageableObjectDied.Publish(this);
        Destroy(gameObject);
    }
}
