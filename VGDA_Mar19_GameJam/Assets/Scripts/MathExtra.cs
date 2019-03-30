using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExtra
{
    public static float Vector2ToDiamondAngle(float y, float x)
    {
        if (y >= 0)
            return (x >= 0 ? y / (x + y) : 1 - x / (y - x));
        else
            return (x < 0 ? 2 - y / (-x - y) : 3 + x / (x - y));
    }

    public static Vector2 DiamondAngleToVector2(float dia)
    {
        return new Vector2(DiamondCos(dia), DiamondSin(dia));
    }

    public static float DiamondAngleToRadian(float dia)
    {
        Vector2 direction = DiamondAngleToVector2(dia);
        return Mathf.Atan2(direction.y, direction.x);
    }

    public static float NormalizedDiamondAngle(float dia)
    {
        if (dia > 4)
            return dia - (((int)dia / 4) * 4);
        else if (dia < 0)
            return dia - ((((int)dia / 4) - 1) * 4);
        return dia;
    }

    public static float DiamondCos(float dia)
    {
        float res = NormalizedDiamondAngle(dia);
        return (res < 2 ? 1 - res : res - 3);
    }

    public static float DiamondSin(float dia)
    {
        float res = NormalizedDiamondAngle(dia);
        return (res < 3 ? ((res > 1) ? 2 - res : res) : res - 4);
    }
}
