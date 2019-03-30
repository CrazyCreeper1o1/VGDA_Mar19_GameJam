using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int hp = 10;
    public int HP
    {
        get { return hp; }
        set
        {
            if (value <= 0)
                Die();
            else
                hp = value;
        }
    }
    public int maxHP;
    public int threat;
    public int power = 1;

    public Transform target;
    public GameObject itemPrefab;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
        target = player.transform;
    }

    void Start()
    {
        HP = maxHP;
    }

    public void TakeDamage(int dam)
    {
        HP -= dam;
    }
    public void TakeSlow(float mult, float length)
    {
        this.gameObject.GetComponent<EnemyMovement>().SetSlow(mult, length);
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

    private void Die()
    {
        if (Random.Range(0, 3) != 0)
        {
            GameObject item = Instantiate(itemPrefab);
            item.transform.position = transform.position;
            item.transform.parent = transform.parent;
        }
        Destroy(gameObject);
    }
}
