using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    List<Enemy> EnemyList;

    enum States { threat, hp, closest }
    States targetSystem = States.threat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyList.Add(collision.gameObject.GetComponent<Enemy>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyList.Remove(collision.gameObject.GetComponent<Enemy>());
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Enemy getBestTarget()
    {
        Enemy best = EnemyList[0];
        int index = 0;
        int value;
        switch (targetSystem)
        {
            case States.threat:
                value = best.threat;
                for (int i = 1; i < EnemyList.Count; i++)
                {
                    Enemy temp = EnemyList[i];
                    int tempValue = temp.threat;
                    if (tempValue >= value)
                    {
                        index = i;
                        best = temp;
                        value = tempValue;
                    }
                }
                return best;

            case States.hp:
                value = best.hp;
                for (int i = 1; i < EnemyList.Count; i++)
                {
                    Enemy temp = EnemyList[i];
                    int tempValue = temp.hp;
                    if (tempValue >= value)
                    {
                        index = i;
                        best = temp;
                        value = tempValue;
                    }
                }
                return best;


            default:
                return null;
        }
    }
    



    public void setStateThreat()
    {
        targetSystem = States.threat;
    }
    public void setStateHP()
    {
        targetSystem = States.hp;
    }
    public void setStateClosest()
    {
        targetSystem = States.closest;
    }



}
