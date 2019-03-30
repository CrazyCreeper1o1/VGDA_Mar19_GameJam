using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int hp = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);
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

    public void TakeDamage(int dam)
    {
        hp -= dam;
    }
}