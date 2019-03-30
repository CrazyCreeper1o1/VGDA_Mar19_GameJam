using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1;
    private GameObject protectedCore;
    public float speedMultiplier = 1f;
    private float slowTimer;

    private Transform target;
    private Rigidbody2D thisRigidbody;

    private void Awake()
    {
        target = GetComponent<Enemy>().target;
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetSlow(float mult, float length)
    {
        speedMultiplier = Mathf.Min(speedMultiplier, mult);
        slowTimer = Mathf.Max(slowTimer, length);
    }


    void Start()
    {
    }

    void Update()
    {
        slowTimer -= Time.deltaTime;
        if (slowTimer <= 0f)
            speedMultiplier = 1f;


        float angle = MathExtra.Vector2ToDiamondAngle(transform.position.y - target.position.y, transform.position.x - target.position.x);

        Vector2 movement = MathExtra.DiamondAngleToVector2(angle);

        Move(-movement.x * speed * speedMultiplier, -movement.y * speed * speedMultiplier);
    }

    private void Move(float? x, float? y)
    {
        float newX = x == null ? thisRigidbody.velocity.x : (float)x;
        float newY = y == null ? thisRigidbody.velocity.y : (float)y;
        thisRigidbody.velocity = new Vector3(newX, newY, 0);
    }
}
