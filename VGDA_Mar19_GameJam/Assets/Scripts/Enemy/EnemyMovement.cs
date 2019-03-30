using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D EnemyRigidbody;
    public Transform target;
    public float speed = 1;
    private GameObject player;
    private GameObject protectedCore;
    public float speedMultiplier = 1f;

    private void Awake()
    {
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Start()
    {
        target = player.transform;
    }

    void Update()
    {
        float angle = MathExtra.Vector2ToDiamondAngle(transform.position.y - target.transform.position.y, transform.position.x - target.transform.position.x);

        Vector2 movement = MathExtra.DiamondAngleToVector2(angle);

        Move(-movement.x * speed, -movement.y * speed);
    }

    private void Move(float? x, float? y)
    {
        float newX = x == null ? EnemyRigidbody.velocity.x : (float)x;
        float newY = y == null ? EnemyRigidbody.velocity.y : (float)y;
        EnemyRigidbody.velocity = new Vector2(newX, newY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
            // to-do damage amount variable
            player.GetComponent<PlayerBehaviour>().TakeDamage(1);
    }
}
