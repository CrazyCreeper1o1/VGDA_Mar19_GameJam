using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Tower
{
    private static double cooldown;
    private float shotTimer;
    private Targeter targeter;


    // Start is called before the first frame update
    void Start()
    {
        targeter = this.GetComponentInChildren<Targeter>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemy target = targeter.getBestTarget();
        if (target)
            target.TakeDamage(999);
    }

    override public int GetMetalCost() { return 5; }
    override public int GetCircuitCost() { return 5; }
    override public int GetGearCost() { return 0; }
    override public void Scrap() { GameObject.Destroy(this.gameObject); }


}
