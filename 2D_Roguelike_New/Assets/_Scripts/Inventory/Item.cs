using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public abstract class Item : ScriptableObject
{
    public int ID;
    public Sprite icon;
    public string itemName;
    [TextArea]
    public string itemDescription;

    public float buyValue;
    public float sellValue;

    public int stackAmount;
    public int itemLevel;

    public bool isDefaultItem;
    public bool isUnique;
}
