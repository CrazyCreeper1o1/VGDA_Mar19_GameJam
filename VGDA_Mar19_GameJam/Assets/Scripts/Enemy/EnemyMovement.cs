using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D EnemyRigidbody;
    public Transform Target;
    public float speed = 1;
    private GameObject player;
    private GameObject protectedCore;

    private void Awake()
    {
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Start()
    {
        Target = player.transform;
    }

    void Update()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
            // to-do damage amount variable
            player.GetComponent<PlayerBehaviour>().TakeDamage(1);
    }
}
