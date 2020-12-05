using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageableObject
{
    //PUBLIC
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    //PRIVATE
    private Rigidbody2D player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float realSpeed = speed * Time.fixedDeltaTime;

        if (Vector2.Distance(rb.position, player.position) >= stoppingDistance)
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.position, realSpeed);
            Vector2 dir = (player.position - rb.position).normalized;
            Vector2 moveVelocity = realSpeed * dir;
            rb.MovePosition(rb.position + moveVelocity);
        }
        else if (Vector2.Distance(rb.position, player.position) < retreatDistance )
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.position, -realSpeed);
            Vector2 dir = (player.position - rb.position).normalized;
            Vector2 moveVelocity = realSpeed * dir;
            rb.MovePosition(rb.position - moveVelocity);
        }
    }
}
