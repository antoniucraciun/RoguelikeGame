using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    public StatType debuffType;
    public float debuffAmount;

    public Debuff()
    {
        debuffType = StatType.Armor;
        debuffAmount = 0;
    }

    public Debuff(StatType type, float amount)
    {
        debuffType = type;
        debuffAmount = amount;
    }

    public Debuff(Debuff buff)
    {
        debuffType = buff.debuffType;
        debuffAmount = buff.debuffAmount;
    }
}
