using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 10;
    public int hp;
    public int threat;
    public int power = 1;

    public Transform target;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
        target = player.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            GameObject.Destroy(this.gameObject);
    }

    public void TakeDamage(int dam)
    {
        hp -= dam;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj == player)
        {
            obj.GetComponent<PlayerBehaviour>().TakeDamage(power);
            obj.GetComponent<PlayerMovement>().BeginFlinch(transform.position.x > player.transform.position.x);
        }
    }
}
