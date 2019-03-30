using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject enemy1Prefab, enemy2Prefab;
    public GameObject itemPrefab;

    private int enemySpawnTimer = 0;
    private int itemSpawnTimer = 0;

    void Start()
    {
        enemySpawnTimer = Random.Range(0, 500);
        itemSpawnTimer = Random.Range(0, 500);
        enemy1Prefab.GetComponent<Enemy>().target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (enemySpawnTimer > 0)
            enemySpawnTimer--;
        else
        {
            AddEnemy();
            enemySpawnTimer = Random.Range(0, 500);
        }

        if (itemSpawnTimer > 0)
            itemSpawnTimer--;
        else
        {
            AddItem();
            itemSpawnTimer = Random.Range(0, 500);
        }
    }

    void AddEnemy()
    {
        GameObject enemy = Instantiate(enemy1Prefab);
        enemy.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-30, 60));
        enemy.transform.parent = transform;
    }

    void AddItem()
    {
        GameObject item = Instantiate(itemPrefab);
        item.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(0, 500));
        item.transform.parent = transform;
    }
}
