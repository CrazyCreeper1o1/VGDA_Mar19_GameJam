using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    private int hp = 10;
    public int HP
    {
        get { return hp; }
        set
        {
            GameObject.Find("HPLabel").GetComponent<HealthDisplay>().healthText.text = "Health: " + value;
            hp = value;
        }
    }
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
        if (!flinchInvincibility && currentState != States.dying)
        {
            HP -= dmg;
            if (HP <= 0)
                currentState = States.dying;
        }
    }

    private void Die()
    {
        if (transform.localScale.y > 0)
            transform.localScale -= new Vector3(0, 0.1f, 0);
        else
            SceneManager.LoadScene("GameOver");
    }
}
