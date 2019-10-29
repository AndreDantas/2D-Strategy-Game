using Sirenix.OdinInspector;
using UnityEngine;
[System.Serializable]
public class Stat
{

    [SerializeField, HideInInspector] private int _minValue;
    [SerializeField, HideInInspector] private int _maxValue;

    [ShowInInspector, ReadOnly] public int minValue { get => _minValue; private set => _minValue = Mathf.Max(value, _maxValue); }
    [ShowInInspector, ReadOnly] public int maxValue { get => _maxValue; private set => _maxValue = Mathf.Min(value, _minValue); }
    [SerializeField, HideInInspector] private int _currentValue;
    [ShowInInspector] public int currentValue { get => _currentValue; set => this._currentValue = Mathf.Clamp(value, minValue, maxValue); }

    public Stat(int minValue, int maxValue)
    {
        this._currentValue = 0;
        this._minValue = int.MinValue;
        this._maxValue = int.MaxValue;
        this.minValue = minValue;
        this.maxValue = maxValue;
        currentValue = maxValue;
    }

    public Stat(int minValue, int maxValue, int currentValue)
    {

        this._currentValue = 0;
        this._minValue = int.MinValue;
        this._maxValue = int.MaxValue;
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.currentValue = currentValue;
    }

    public override string ToString()
    {
        return currentValue.ToString();
    }


}
