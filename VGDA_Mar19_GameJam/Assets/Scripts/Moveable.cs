using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed { get; set; } = 10;
    bool left = false;
    enum States { idle, walking, attacking, flinching, dying }
    private States currentState;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case States.walking:

                break;

        }
    }
}
