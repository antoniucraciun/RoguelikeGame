using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Weapon", order = 3)]
public class WeaponItem : Item
{
    public float physicalDamage;
    public float magicalDamage;
    public float trueDamage;
}