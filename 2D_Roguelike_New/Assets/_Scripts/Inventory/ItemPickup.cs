using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if player or enemy
        if (collision.GetComponent<Inventory>()!=null)
        {
            collision.GetComponent<Inventory>().AddItem(item);
            Destroy(gameObject);
        }
    }
}
