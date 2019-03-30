using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    public int HP = 10;
    private PlayerMovement playerMovement;
    public enum States { idle, walking, airborne, flinching, dying }
    public States currentState = States.airborne;
    private bool flinchInvincibility = false;
    public bool FlinchInvincibility
    {
        get { return flinchInvincibility; }
        set
        {
            if (value)
                flinchInvincibilityTime = 40;
            flinchInvincibility = value;
        }
    }
    private int flinchInvincibilityTime = 0;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
    {

    }

    private void Update()
    {
        switch (currentState)
        {
            case States.dying:
                Die();
                break;
        }

        if (flinchInvincibility)
        {
            if (flinchInvincibilityTime > 0)
                flinchInvincibilityTime--;
            else
                flinchInvincibility = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Item item = other.gameObject.GetComponent<Item>();
        if (item)
            item.Collect();

    }

    public void TakeDamage(int dmg)
    {
        if (!flinchInvincibility)
        {
            HP -= dmg;
            if (HP <= 0)
                currentState = States.dying;
        }
    }

    private void Die()
    {
        int time = 10000;
        while (time > 0)
        {
            time--;
            transform.localScale -= new Vector3(0, 0.00001f, 0);
        }
    }
}
