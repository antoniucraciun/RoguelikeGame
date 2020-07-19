public class Buff
{
    public StatType buffType;
    public float buffAmount;

    public Buff()
    {
        buffType = StatType.Armor;
        buffAmount = 0;
    }

    public Buff(StatType type, float amount)
    {
        buffType = type;
        buffAmount = amount;
    }

    public Buff(Buff buff)
    {
        buffType = buff.buffType;
        buffAmount = buff.buffAmount;
    }
}
