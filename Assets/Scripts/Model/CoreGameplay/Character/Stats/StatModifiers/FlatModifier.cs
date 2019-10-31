
using Stats;
[System.Serializable]
public class FlatModifier : StatModifier
{
    public FlatModifier(float value, int order) : base(value, order)
    {
    }

    public FlatModifier(int order, float value, object source) : base(order, value, source)
    {
    }

    public override StatModHelper Modify(StatModHelper stat)
    {
        stat.value += Value;
        stat.statsMods.Add(this);
        return stat;
    }
}

