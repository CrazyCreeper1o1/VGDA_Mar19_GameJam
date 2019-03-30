using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    public int HP = 10;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Item item = other.gameObject.GetComponent<Item>();
        if (item)
            item.Collect();

    }

    public void TakeDamage(int dmg)
    {
        if (playerMovement.currentState != PlayerMovement.States.flinching)
        {
            HP -= dmg;
            if (HP > 0)
                playerMovement.currentState = PlayerMovement.States.flinching;
            else
                Die();
        }
    }

    private void Die()
    {
        int time = 10000;
        while (time > 0)
        {
            transform.localScale -= new Vector3(0, 0.00001f, 0);
        }
    }
}
