using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    //PUBLIC
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public int difficulty;
    public int damage;
    public float healtPoints;
    public float attackRange;
    public float attackCoolDown;

    public delegate void OnEnemyDie(int dif);
    public static event OnEnemyDie EnemyDieEvent;

    public UnityEvent hitEvent;

    //PRIVATE
    private Rigidbody2D playerRB;
    private PlayerController player;
    private Rigidbody2D rb;

    private float coolDown;

    private void Start()
    {
        playerRB = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        coolDown = attackCoolDown;
    }

    private void FixedUpdate()
    {
        float realSpeed = speed * Time.fixedDeltaTime;

        if (healtPoints <= 0)
        {
            Die();
        }
        if (Vector2.Distance(rb.position, playerRB.position) >= stoppingDistance)
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.position, realSpeed);
            Vector2 dir = (playerRB.position - rb.position).normalized;
            Vector2 moveVelocity = realSpeed * dir;
            rb.MovePosition(rb.position + moveVelocity);
        }
        else if (Vector2.Distance(rb.position, playerRB.position) < retreatDistance )
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.position, -realSpeed);
            Vector2 dir = (playerRB.position - rb.position).normalized;
            Vector2 moveVelocity = realSpeed * dir;
            rb.MovePosition(rb.position - moveVelocity);
        }
        if (coolDown <= 0)
        {
            if (Vector2.Distance(rb.position, playerRB.position) <= attackRange)
            {
                player.TakeDamage(damage);
                coolDown = attackCoolDown;
            }
        }
        else
        {
            coolDown -= Time.fixedDeltaTime;
        }
        
    }

    private void Die()
    {
        EnemyDieEvent.Invoke(difficulty);

        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        healtPoints -= damage;
        hitEvent.Invoke();
    }
}
