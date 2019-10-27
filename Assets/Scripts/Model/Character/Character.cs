using UnityEngine;
using Sirenix.OdinInspector;
using Util;
public class Character
{
    public string name = "";

    public Stat health = new Stat(0, 999);
    public Stat attack = new Stat(0, 99);
    public Stat defense = new Stat(0, 99);
}
