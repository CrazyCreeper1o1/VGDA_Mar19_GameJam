using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInput
{

    public static bool Left()
    {
        return Input.GetAxisRaw("Horizontal") < 0;
    }

    public static bool Right()
    {
        return Input.GetAxisRaw("Horizontal") > 0;
    }

    public static bool Jump()
    {
        return Input.GetButtonDown("Jump");
    }
}
