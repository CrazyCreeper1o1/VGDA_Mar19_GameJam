using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1;
    private GameObject protectedCore;
    public float speedMultiplier = 1f;

    private Transform target;
    private Rigidbody2D thisRigidbody;

    private void Awake()
    {
        target = GetComponent<Enemy>().target;
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
    }

    void Update()
    {
        float angle = MathExtra.Vector2ToDiamondAngle(transform.position.y - target.position.y, transform.position.x - target.position.x);

        Vector2 movement = MathExtra.DiamondAngleToVector2(angle);
        
        Move(-movement.x * speed, -movement.y * speed);
    }

    private void Move(float? x, float? y)
    {
        float newX = x == null ? thisRigidbody.velocity.x : (float)x;
        float newY = y == null ? thisRigidbody.velocity.y : (float)y;
        thisRigidbody.velocity = new Vector3(newX, newY, 0);
    }
}
