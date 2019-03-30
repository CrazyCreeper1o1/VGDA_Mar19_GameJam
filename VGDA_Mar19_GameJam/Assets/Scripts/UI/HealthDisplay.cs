using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private GameObject player;
    public int hp;
    public Text healthText; 

    private void Awake()
    {

        player = GameObject.Find("Player");
        hp = player.GetComponent<PlayerBehaviour> ().HP;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH: " + hp;

    }
}
