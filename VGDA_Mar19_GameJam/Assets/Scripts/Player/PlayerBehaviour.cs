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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
        }
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
