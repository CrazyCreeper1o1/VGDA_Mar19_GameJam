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

        Debug.Log("Hi");
        /*
        if (other.gameObject.tag == "Item")
        {
            GameObject.Destroy(other.gameObject);
        }
        */
    }

    public void TakeDamage(int dmg)
    {
        if (playerMovement.currentState != PlayerMovement.States.flinching)
        {
            HP -= dmg;
            playerMovement.currentState = PlayerMovement.States.flinching;
        }
    }
}
