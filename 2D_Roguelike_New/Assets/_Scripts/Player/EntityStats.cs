using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats", order = 1)]
public class EntityStats : ScriptableObject
{
    public float health;
    public float mana;
    public float armor;
    public float magicResist;
    public int experience;
    public int level;
}
