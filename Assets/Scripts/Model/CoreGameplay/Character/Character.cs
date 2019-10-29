using UnityEngine;
using Sirenix.OdinInspector;
using Model.Util;
[System.Serializable]
public class Character
{
    public string name = "";

    public const int MAX_HEALTH = 9999;
    public const int MAX_ATTACK = 999;
    public const int MAX_DEFENSE = 999;
    public const int MAX_STAMINA = 99;

    [SerializeField, HideInInspector] private Stat _health;
    [SerializeField, HideInInspector] private Stat _attack;
    [SerializeField, HideInInspector] private Stat _defense;
    [SerializeField, HideInInspector] private Stat _stamina;


    [ShowInInspector] public Stat health { get => _health; set => _health = new Stat(0, Mathf.Min(value.maxValue, MAX_HEALTH), value.currentValue); }
    [ShowInInspector] public Stat attack { get => _attack; set => _attack = new Stat(0, Mathf.Min(value.maxValue, MAX_ATTACK), value.currentValue); }
    [ShowInInspector] public Stat defense { get => _defense; set => _defense = new Stat(0, Mathf.Min(value.maxValue, MAX_DEFENSE), value.currentValue); }
    [ShowInInspector] public Stat stamina { get => _stamina; set => _stamina = new Stat(0, Mathf.Min(value.maxValue, MAX_STAMINA), value.currentValue); }

    public Character()
    {
    }

    public Character(string name, Stat health, Stat attack, Stat defense, Stat stamina)
    {
        this.name = name;
        this.health = health;
        this.attack = attack;
        this.defense = defense;
        this.stamina = stamina;
    }
}
