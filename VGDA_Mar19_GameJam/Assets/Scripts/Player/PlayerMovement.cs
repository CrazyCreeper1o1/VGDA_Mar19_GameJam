using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D PlayerRigidbody;
    public float Speed = 15;
    public float JumpPower = 30;

    private PlayerBehaviour playerBehaviour;
    private Transform groundCheck;
    private PlayerBehaviour.States currentState;
    private bool flinchLeft;
    private Vector2 flinchPower = new Vector2(20, 10);
    private int flinchTime = 0;

    private void Awake()
    {
        playerBehaviour = GetComponent<PlayerBehaviour>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
    }

    void Start()
    {

    }

    void Update()
    {
        currentState = GetComponent<PlayerBehaviour>().currentState;
        //to-do make sure colliders are for solid objects

        if (currentState != PlayerBehaviour.States.flinching && currentState != PlayerBehaviour.States.dying)
        {
            AirborneOrIdle();
            if (GameInput.Left())
            {
                if (currentState != PlayerBehaviour.States.airborne)
                    currentState = PlayerBehaviour.States.walking;
                Move(-Speed, null);
            }
            else if (GameInput.Right())
            {
                if (currentState != PlayerBehaviour.States.airborne)
                    currentState = PlayerBehaviour.States.walking;
                Move(Speed, null);
            }
            else
            {
                if (currentState != PlayerBehaviour.States.airborne)
                    currentState = PlayerBehaviour.States.idle;
                PlayerRigidbody.velocity = new Vector2(0, PlayerRigidbody.velocity.y);
            }
            if (GameInput.Jump())
            {
                if (currentState != PlayerBehaviour.States.airborne)
                    Move(null, JumpPower);
            }
        }
        else if (currentState == PlayerBehaviour.States.flinching)
            Flinch();
    }

    private void AirborneOrIdle()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(groundCheck.position, Vector2.down, .1f);
        Collider2D objectAtFeet = hit2D.collider;
        if (objectAtFeet == null)
            playerBehaviour.currentState = PlayerBehaviour.States.airborne;
        else
            playerBehaviour.currentState = PlayerBehaviour.States.idle;
    }

    public void BeginFlinch(bool left)
    {
        if (!playerBehaviour.FlinchInvincibility && playerBehaviour.currentState != PlayerBehaviour.States.dying)
        {
            flinchLeft = left;
            playerBehaviour.currentState = PlayerBehaviour.States.flinching;
            playerBehaviour.FlinchInvincibility = true;
            flinchTime = 3;
        }
    }

    private void Flinch()
    {
        if (flinchTime > 0)
        {
            PlayerRigidbody.velocity = new Vector2(flinchPower.x * (flinchLeft ? -1 : 1), flinchPower.y);
            flinchTime--;
        }
        else
            AirborneOrIdle();
    }

    private void Move(float? x, float? y)
    {
        float newX = x == null ? PlayerRigidbody.velocity.x : (float)x;
        float newY = y == null ? PlayerRigidbody.velocity.y : (float)y;
        PlayerRigidbody.velocity = new Vector2(newX, newY);
    }
}
