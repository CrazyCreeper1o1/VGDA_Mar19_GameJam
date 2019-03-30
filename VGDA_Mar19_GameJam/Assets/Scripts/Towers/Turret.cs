using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Tower
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public int getMetalCost() { return 5; }
    override public int getCircuitCost() { return 5; }
    override public int getGearCost() { return 0; }

}
