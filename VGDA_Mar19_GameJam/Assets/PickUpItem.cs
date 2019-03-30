using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Text pickUpText;
    private bool pickUpAllowed;
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }
    public void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {

        }
    }
}
