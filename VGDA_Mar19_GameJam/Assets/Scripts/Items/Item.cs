using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemTypes { metal, circuit_board, gear }
    public ItemTypes ThisItemType;
    public Sprite[] sprites;

    void Start()
    {
        ThisItemType = (ItemTypes)Random.Range(0, 3);

        switch (ThisItemType)
        {
            case ItemTypes.circuit_board:
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case ItemTypes.gear:
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case ItemTypes.metal:
                GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
        }
    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Collect();
        }
    }

    public void Collect()
    {
        switch (ThisItemType)
        {
            case ItemTypes.circuit_board:
                Global.Circuit_Boards++;
                break;

            case ItemTypes.gear:
                Global.Gears++;
                break;

            case ItemTypes.metal:
                Global.Metals++;
                break;
        }

        Destroy(gameObject);
    }
}
