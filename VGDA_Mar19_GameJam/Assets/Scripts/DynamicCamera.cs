using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    public Transform target;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    void Start()
    {

    }

    void Update()
    {
        Vector3 vel = new Vector3(1, 1, 0);
        Vector3 newPos = Vector3.SmoothDamp(transform.position, target.position, ref vel, .15f);
        newPos.z = transform.position.z;
        transform.position = newPos;

    }
}
