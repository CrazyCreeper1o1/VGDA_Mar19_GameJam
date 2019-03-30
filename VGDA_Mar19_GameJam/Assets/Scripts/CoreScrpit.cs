using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreScrpit : MonoBehaviour
{

    public int hp = 100;
    bool flinching = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Take_Damage(int dmg)
    {
        if (!flinching)
            hp -= dmg;
    }
    public void Damage(int dmg)
    {
        hp -= dmg;
    }
}
