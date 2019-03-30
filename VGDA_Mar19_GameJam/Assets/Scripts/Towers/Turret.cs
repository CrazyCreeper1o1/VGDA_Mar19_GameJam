using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Tower
{
    public float cooldown;
    public int damage;
    private float shotTimer;
    private Targeter targeter;

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
        {
            shotTimer += Time.deltaTime;
            Enemy target = targeter.getBestTarget();
            if (target)
            {
                if(shotTimer >= cooldown)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, (target.transform.position - transform.position).normalized, 8f, checkMask.value);
                    if(hit.rigidbody != null && hit.rigidbody.gameObject.tag == "Enemy")
                    {
                        //Debug.Log("HIT THE BOY.");
                        hit.rigidbody.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                        shotTimer = 0;
                        Transform barrel = gameObject.GetComponentInChildren<Transform>();
                        //barrel.transform.rotation.z = (Mathf.Atan2(target.transform.position.y - gameObject.GetComponent<Transform>().position.y, target.transform.position.x - gameObject.GetComponent<Transform>().position.x));
                        barrel.transform.Rotate(0, 0, -barrel.transform.rotation.z, Space.Self);
                        barrel.transform.Rotate(0, 0, (Mathf.Atan2(target.transform.position.y - gameObject.GetComponent<Transform>().position.y, target.transform.position.x - gameObject.GetComponent<Transform>().position.x)), Space.Self);
                    }
                    else
                    {
                        targeter.Ignore(target);
                        shotTimer -= Time.deltaTime;
                        this.Update();
                        targeter.Recall(target);
                    }
                }
            }
        }
    }

    override public int GetMetalCost() { return 5; }
    override public int GetCircuitBoardCost() { return 5; }
    override public int GetGearCost() { return 0; }
    override public void Scrap() { GameObject.Destroy(this.gameObject); }


}
