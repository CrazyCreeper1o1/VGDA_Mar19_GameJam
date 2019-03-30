using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D PlayerRigidbody;
    public BoxCollider2D FeetCollider;
    public float Speed = 30;
    public float JumpPower = 10;
    enum States { idle, walking, airborne, flinching, dying }
    States currentState = States.airborne;

    private Transform groundCheck;

    private void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
    }

    void Start()
    {

    }

    void Update()
    {
        //to-do make sure colliders are for solid objects
        RaycastHit2D hit2D = Physics2D.Raycast(groundCheck.position, Vector2.down, .1f);
        Collider2D objectAtFeet = hit2D.collider;

        if (objectAtFeet == null)
            currentState = States.airborne;
        else
            currentState = States.idle;

        if (GameInput.Left())
        {
            if (currentState != States.airborne)
                currentState = States.walking;
            Move(-Speed, null);
        }
        else if (GameInput.Right())
        {
            if (currentState != States.airborne)
                currentState = States.walking;
            Move(Speed, null);
        }
        else
        {
            if (currentState != States.airborne)
                currentState = States.idle;
            PlayerRigidbody.velocity = new Vector2(0, PlayerRigidbody.velocity.y);
        }
        if (GameInput.Jump())
        {
            if (currentState != States.airborne)
                Move(null, JumpPower);
        }

        switch (currentState)
        {

        }

    }

    private void Move(float? x, float? y)
    {
        float newX = x == null ? PlayerRigidbody.velocity.x : (float)x * Time.deltaTime * 10;
        float newY = y == null ? PlayerRigidbody.velocity.y : (float)y * Time.deltaTime * 10;
        PlayerRigidbody.velocity = new Vector2(newX, newY);
    }


}
