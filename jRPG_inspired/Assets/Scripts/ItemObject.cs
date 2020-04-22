using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Weapon,
    Armor,
    Default

}
public abstract class ItemObject : ScriptableObject
{
    public Sprite image;
    public ItemType type;
    public int cost;
    [TextArea(15, 20)]
    public string description;

}
