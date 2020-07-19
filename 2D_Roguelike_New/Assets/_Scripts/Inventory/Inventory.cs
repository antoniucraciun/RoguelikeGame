using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    public UnityEvent onInventoryChanged = new UnityEvent();

    private void Start()
    {
        //load inventory
    }

    public bool AddItem(Item itm)
    {
        bool added = false;
        if(itm.isUnique)
        {
            items.Add(itm);
            added = true;
            
        }
        if (!added)
        {
            foreach (Item item in items)
            {
                if (item.ID == itm.ID)
                {
                    item.stackAmount += itm.stackAmount;
                    added = true;
                    break;
                }
            }
            if (!added)
            {
                items.Add(itm);
                added = true;
            }
        }
        if(added)
            if (onInventoryChanged != null)
                onInventoryChanged.Invoke();
        return added;
    }
}
