using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Inventory/Armor", order = 2)]
public class ArmorItem : Item
{
    public float health;
    public float armor;
    public float magicResistance;
}
