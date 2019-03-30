using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D EnemyRigidbody;
    public float speed = 1;
    private GameObject protectedCore;
    public float speedMultiplier = 1f;

    private Transform target;

    private void Awake()
    {
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        target = GetComponent<Enemy>().target;
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
        float newX = x == null ? EnemyRigidbody.velocity.x : (float)x;
        float newY = y == null ? EnemyRigidbody.velocity.y : (float)y;
        EnemyRigidbody.velocity = new Vector2(newX, newY);
    }
}
