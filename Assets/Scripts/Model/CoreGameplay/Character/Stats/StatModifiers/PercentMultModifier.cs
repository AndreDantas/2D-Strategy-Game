using Stats;
[System.Serializable]
public class PercentMultModifier : StatModifier
{
    public PercentMultModifier(float value, int order) : base(value, order)
    {
    }

    public PercentMultModifier(int order, float value, object source) : base(order, value, source)
    {
    }

    public override StatModHelper Modify(StatModHelper stat)
    {
        stat.value += (stat.value * (Value / 100f));

        return stat;
    }
}

