﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public abstract int GetMetalCost();
    public abstract int GetCircuitBoardCost();
    public abstract int GetGearCost();
    public abstract void Scrap();
    
}
