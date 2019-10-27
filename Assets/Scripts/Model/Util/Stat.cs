using Sirenix.OdinInspector;
using UnityEngine;
[System.Serializable]
public struct Stat
{

    [SerializeField, ReadOnly] private int minValue, maxValue;

    [SerializeField, HideInInspector] private int _value;

    public Stat(int minValue, int maxValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
        _value = 0;
        value = value;
    }

    public Stat(int minValue, int maxValue, int value)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
        this._value = 0;
        this.value = value;
    }

    [ShowInInspector] public int value { get => _value; set => this._value = Mathf.Clamp(value, minValue, maxValue); }

    public override string ToString()
    {
        return value.ToString();
    }
}
