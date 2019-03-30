using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp;
    public int maxHP;
    public int threat;
    
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
    
}
