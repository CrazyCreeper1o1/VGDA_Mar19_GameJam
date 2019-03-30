using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{  
    public Rigidbody2D contactBody;
    public float speed = 1;
    public bool right = true;
    

    // Start is called before the first frame update
    void Start()
    {
 
    }

    
    void FixedUpdate()
    {
      
        if (right)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }

        else if (!right)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }


    }
}
