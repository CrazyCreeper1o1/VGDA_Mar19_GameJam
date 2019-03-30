using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float Speed { get; set; } = 10;
    bool left = false;
    enum States { idle, walking, jumping, flinching, dying }
    private States currentState = States.idle;

    void Start()
    {

    }
    
    void Update()
    {
        switch (currentState)
        {
            case States.walking:
                Rigidbody.AddForce(new Vector2(left ? -1 : 1, 0) * Speed);
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
