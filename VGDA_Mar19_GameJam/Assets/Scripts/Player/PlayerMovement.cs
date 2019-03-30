using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody2D PlayerRigidbody;
    public float Speed = 10;
    bool left = false;
    enum States { idle, walking, jumping, flinching, dying }
    States currentState = States.idle;

    void Start()
    {

    }

    void Update()
    {
        switch (currentState)
        {
            case States.walking:
                PlayerRigidbody.position += (new Vector2(left ? -1 : 1, 0) * Speed * Time.deltaTime);
                break;

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentState = States.walking;
            if (!left) left = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            currentState = States.walking;
            if (left) left = false;
        }
        else
        {
            currentState = States.idle;
        }

    }
}
