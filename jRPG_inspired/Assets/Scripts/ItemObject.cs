using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemObject : ScriptableObject
{
    public int cost;
    public ItemType type;
    public GameObject prefab;
    public Sprite image;
    [TextArea(15, 20)]
    public string description;

    public int Sell()
    {
        return cost / 2;
    }
}

public enum ItemType
{
    Consumable,
    Weapon,
    Armor,
    Default
}
