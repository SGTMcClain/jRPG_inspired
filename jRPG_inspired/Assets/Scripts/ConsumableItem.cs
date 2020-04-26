using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Inventory System/Items/Consumable")]
public class ConsumableItem : ItemObject
{
    public int healthRegen;
    public int manaRegen;
    public void Awake()
    {
        type = ItemType.Consumable;
    }
}
