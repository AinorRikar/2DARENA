using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    //PUBLIC
    public float fullCDTime;
    public Transform attackPos;
    public Transform attackPoint;
    public LayerMask damageableLayerMask;
    public float damage;
    public Joystick attackJoystick;

    //PRIVATE
    private float timeCD;
    private Animator anim;
    private bool canAttack;
    private float attackRange;

    public void Attack()
    {
        if (canAttack)
        {
            anim.SetTrigger("attack");
            Vector3 aV = attackPos.position - attackPoint.position;
            attackRange = Mathf.Sqrt(aV.x * aV.x + aV.y * aV.y + aV.z * aV.z);
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, damageableLayerMask);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<DamageableObject>().TakeDamage(damage);
            }
            timeCD = fullCDTime;
            canAttack = false;
        }
    }

    private void AttackUpdate()
    {
        if (timeCD <= 0)
        {
            canAttack = true;
        }
        else
        {
            if(timeCD > 0)
                timeCD -= Time.deltaTime;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        canAttack = true;
    }

    private void Update()
    {
        AttackUpdate();

        if(attackJoystick.Vertical != 0 || attackJoystick.Horizontal != 0)
        {
            if (Mathf.Abs(attackJoystick.Horizontal) >= Mathf.Abs(attackJoystick.Vertical))
            {
                if (attackJoystick.Horizontal > 0)
                {
                    Debug.Log("RIGHT");
                    gameObject.GetComponent<PlayerController>().setFacing(0);
                }
                if (attackJoystick.Horizontal < 0)
                {
                    Debug.Log("LEFT");
                    gameObject.GetComponent<PlayerController>().setFacing(1);
                }
            }
            else
            {
                if (attackJoystick.Vertical > 0)
                {
                    Debug.Log("UP");
                    gameObject.GetComponent<PlayerController>().setFacing(2);
                }
                if (attackJoystick.Vertical < 0)
                {
                    Debug.Log("DOWN");
                    gameObject.GetComponent<PlayerController>().setFacing(3);
                }
            }
            Attack();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
