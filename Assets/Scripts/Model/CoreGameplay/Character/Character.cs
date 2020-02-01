using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UtilityLibrary.Classes;
using Pathfinding;
using Stats;
[System.Serializable]
[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    [System.Serializable]
    public enum Faction
    {
        Ally, Enemy, Wild
    }
    public Faction faction = Faction.Ally;
    public const float MAX_HEALTH = 9999;
    public const float MAX_ATTACK = 999;
    public const float MAX_MAGIC = 999;
    public const float MAX_DEFENSE = 999;
    public const float MAX_STAMINA = 99;

    public new string name = "";

    [InlineProperty]
    public Position mapPosition;

    [SerializeField, HideInInspector] private Level _level = new Level(1);
    [ShowInInspector] public Level level { get => _level; private set => _level = value ?? _level; }


    [SerializeField, HideInInspector] private Stat _maxHealth = new Stat(100);
    [SerializeField, HideInInspector] private Stat _health = new Stat(10);
    [SerializeField, HideInInspector] private Stat _attack = new Stat(10);
    [SerializeField, HideInInspector] private Stat _magic = new Stat(10);
    [SerializeField, HideInInspector] private Stat _defense = new Stat(10);
    [SerializeField, HideInInspector] private Stat _stamina = new Stat(5);


    [ShowInInspector, Title("Stats")] public Stat maxHealth { get => _maxHealth; set => _maxHealth = new Stat(value.BaseValue, 1, MAX_HEALTH); }
    [ShowInInspector] public Stat health { get => _health; set => _health = new Stat(value.BaseValue, 0, maxHealth.Value); }
    [ShowInInspector] public Stat attack { get => _attack; set => _attack = new Stat(value.BaseValue, 0, MAX_ATTACK); }
    [ShowInInspector] public Stat magic { get => _magic; set => _magic = new Stat(value.BaseValue, 0, MAX_MAGIC); }
    [ShowInInspector] public Stat defense { get => _defense; set => _defense = new Stat(value.BaseValue, 0, MAX_DEFENSE); }
    [ShowInInspector] public Stat stamina { get => _stamina; set => _stamina = new Stat(value.BaseValue, 0, MAX_STAMINA); }

    [PropertyOrder(10), PropertySpace(20)] public List<Skill> skills = new List<Skill>();

    public Character()
    {
        level.OnLevelUp += OnLevelUp;
    }

    public Character(string name, Level level, Stat health, Stat attack, Stat defense, Stat stamina) : this()
    {
        this.level = level;
        this.name = name;
        this.health = health;
        this.attack = attack;
        this.defense = defense;
        this.stamina = stamina;
    }

    /// <summary>
    /// Returns all nodes that this character can move to.
    /// </summary>
    /// <returns></returns>
    public virtual List<MapNode> GetMovementTiles(GameMap map)
    {
        if (map == null)
            return null;
        var positions = BreadthFirstSearch.FindRange(
                        mapPosition,
                        (int)stamina.Value,
                        (pos) => (!map.GetNode(pos)?.blocked ?? false) && map.GetNode(pos)?.character == null,
                        (pos) => map.GetNode(pos)?.walkCost ?? 1,
                        (pos) => map.getNodeNeighbors(pos).ConvertAll(node => node.pos));

        return map.GetNodes(positions);

    }

    public virtual void OnLevelUp(Level level)
    {

    }
}
