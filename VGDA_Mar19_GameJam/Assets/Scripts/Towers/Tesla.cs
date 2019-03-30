using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla : Tower
{
    public float cooldown;
    public int damage;
    private float shotTimer;
    private Targeter targeter;
    public float slowedSpeed;
    public float slowTime;



    public LayerMask checkMask;

    private void Awake()
    {
        targeter = this.GetComponentInChildren<Targeter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        shotTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        shotTimer += Time.deltaTime;
        if (shotTimer >= cooldown)
        {
                List<Enemy> EnemyList = this.gameObject.GetComponent<Targeter>().EnemyList;
                for(int i = 0; i < EnemyList.Count; i++)
               {
                Enemy hit = EnemyList[i];
                hit.TakeDamage(damage);
                hit.gameObject.GetComponent<EnemyMovement>().SetSlow(slowedSpeed, slowTime);
               }

            shotTimer = 0;
        }
    }
    

    override public int GetMetalCost() { return 5; }
    override public int GetCircuitBoardCost() { return 10; }
    override public int GetGearCost() { return 0; }
    override public void Scrap() { GameObject.Destroy(this.gameObject); }


}
