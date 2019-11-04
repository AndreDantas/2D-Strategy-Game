using UnityEngine;
using Sirenix.OdinInspector;
using Stats;
[System.Serializable]
[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public const float MAX_HEALTH = 9999;
    public const float MAX_ATTACK = 999;
    public const float MAX_MAGIC = 999;
    public const float MAX_DEFENSE = 999;
    public const float MAX_STAMINA = 99;

    public new string name = "";

    public Level level;
    [SerializeField, HideInInspector] private Stat _maxHealth = new Stat(100);
    [SerializeField, HideInInspector] private Stat _health = new Stat(10);
    [SerializeField, HideInInspector] private Stat _attack = new Stat(10);
    [SerializeField, HideInInspector] private Stat _magic = new Stat(10);
    [SerializeField, HideInInspector] private Stat _defense = new Stat(10);
    [SerializeField, HideInInspector] private Stat _stamina = new Stat(10);


    [ShowInInspector] public Stat maxHealth { get => _maxHealth; set => _maxHealth = new Stat(value.BaseValue, 0, MAX_HEALTH); }
    [ShowInInspector] public Stat health { get => _health; set => _health = new Stat(value.BaseValue, 0, maxHealth.Value); }
    [ShowInInspector] public Stat attack { get => _attack; set => _attack = new Stat(value.BaseValue, 0, MAX_ATTACK); }
    [ShowInInspector] public Stat magic { get => _magic; set => _magic = new Stat(value.BaseValue, 0, MAX_MAGIC); }
    [ShowInInspector] public Stat defense { get => _defense; set => _defense = new Stat(value.BaseValue, 0, MAX_DEFENSE); }
    [ShowInInspector] public Stat stamina { get => _stamina; set => _stamina = new Stat(value.BaseValue, 0, MAX_STAMINA); }

    public Character()
    {
    }

    public Character(string name, Level level, Stat health, Stat attack, Stat defense, Stat stamina)
    {
        this.level = level;
        this.name = name;
        this.health = health;
        this.attack = attack;
        this.defense = defense;
        this.stamina = stamina;
    }
}
