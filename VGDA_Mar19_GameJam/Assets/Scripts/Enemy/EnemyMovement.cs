using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D EnemyRigidbody;
    public Transform Target;
    public float speed = 1;

    private void Awake()
    {
        EnemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Target = GameObject.Find("Player").transform;
    }

    void Update()
    {

        //angle = MathExtra.Vector2ToDiamondAngle(this.Position.Y - target.Position.Y, this.Position.X - target.Position.X);

        //Vector2 movement = MathExtra.DiamondAngleToVector2(angle);

        //Move(-movement);

        float angle = MathExtra.Vector2ToDiamondAngle(transform.position.y - Target.transform.position.y, transform.position.x - Target.transform.position.x);

        Vector2 movement = MathExtra.DiamondAngleToVector2(angle);

        Move(-movement.x * speed, -movement.y * speed);
    }

    private void Move(float? x, float? y)
    {
        float newX = x == null ? EnemyRigidbody.velocity.x : (float)x * Time.deltaTime * 10;
        float newY = y == null ? EnemyRigidbody.velocity.y : (float)y * Time.deltaTime * 10;
        EnemyRigidbody.velocity = new Vector2(newX, newY);
    }
}
