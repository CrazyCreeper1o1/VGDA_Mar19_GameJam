using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreScrpit : MonoBehaviour
{
    
    public int hp = 100;
    bool flinching = False;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(int dmg)
    {
        if (!flinching)
            hp -= dmg:
    }
}
