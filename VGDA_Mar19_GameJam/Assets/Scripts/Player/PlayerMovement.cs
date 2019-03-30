using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D PlayerRigidbody;
    public float Speed = 15;
    public float JumpPower = 30;
    public enum States { idle, walking, airborne, flinching, dying }
    public States currentState = States.airborne;

    private Transform groundCheck;

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
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
        float newX = x == null ? PlayerRigidbody.velocity.x : (float)x;
        float newY = y == null ? PlayerRigidbody.velocity.y : (float)y;
        PlayerRigidbody.velocity = new Vector2(newX, newY);
    }
}
