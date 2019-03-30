using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreScrpit : MonoBehaviour
{
    
    public int hp = 100;
<<<<<<< HEAD
    bool flinching = false;
=======
    //bool flinching = False;
>>>>>>> 74ab8be3416070fc142860573cd2e987456796fe
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< HEAD
    public void Take_Damage(int dmg)
    {
        if (!flinching)
            hp -= dmg;
=======
    public void Damage(int dmg)
    {
        //if (!flinching)
            hp -= dmg;
>>>>>>> 74ab8be3416070fc142860573cd2e987456796fe
    }
}
