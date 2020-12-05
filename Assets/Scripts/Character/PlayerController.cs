using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DamageableObject
{
    //PUBLIC
    public float speed;
    
    public GameObject eyes;
    public GameObject weapon;

    public Sprite[] eyesArray;

    public Joystick joystick;
    
    //PRIVATE
    private Vector2 moveVelocity;
    private Rigidbody2D rb;

    private int facing;

    public void setFacing(int f)
    {
        facing = f;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facing = 3;
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        if (facing == 0)
        {
            eyes.GetComponent<SpriteRenderer>().sprite = eyesArray[0];
            eyes.GetComponent<SpriteRenderer>().flipX = true;
            Vector3 swordPos = new Vector3(0.3f, -0.0f, -0.001f);
            swordPos += gameObject.transform.position;
            weapon.transform.position = swordPos;
            weapon.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (facing == 1)
        {
            eyes.GetComponent<SpriteRenderer>().sprite = eyesArray[0];
            eyes.GetComponent<SpriteRenderer>().flipX = false;
            Vector3 swordPos = new Vector3(-0.3f, -0.0f, -0.1f);
            swordPos += gameObject.transform.position;
            weapon.transform.position = swordPos;
            weapon.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (facing == 2)
        {
            eyes.GetComponent<SpriteRenderer>().sprite = eyesArray[2];
            eyes.GetComponent<SpriteRenderer>().flipX = false;
            Vector3 swordPos = new Vector3(0.0f, 0.3f, -0.001f);
            swordPos += gameObject.transform.position;
            weapon.transform.position = swordPos;
            weapon.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (facing == 3)
        {
            eyes.GetComponent<SpriteRenderer>().sprite = eyesArray[1];
            eyes.GetComponent<SpriteRenderer>().flipX = false;
            Vector3 swordPos = new Vector3(0.0f, -0.3f, -0.1f);
            swordPos += gameObject.transform.position;
            weapon.transform.position = swordPos;
            weapon.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
