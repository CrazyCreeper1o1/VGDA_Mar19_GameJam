using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody2D PlayerRigidbody;
    public float Speed = 30;
    bool left = false;
    enum States { idle, walking, jumping, falling, flinching, dying }
    States currentState = States.idle;

    void Start()
    {

    }

    void Update()
    {
        if (GameInput.Left())
        {
            currentState = States.walking;
            left = true;
        }
        else if (GameInput.Right())
        {
            currentState = States.walking;
            left = false;
        }
        else
        {
            currentState = States.idle;
            PlayerRigidbody.velocity = new Vector2(0, PlayerRigidbody.velocity.y);
        }

        switch (currentState)
        {
            case States.walking:
                PlayerRigidbody.velocity = (new Vector2(left ? -1 : 1, 0) * Speed * 10 * Time.deltaTime);
                break;

        }
    }
}
