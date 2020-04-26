using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Item", menuName = "Inventory System/Items/Weapon", order = 0)]
public class WeaponItem : ItemObject
{
    public int minDamage;
    public int maxDamage;
    public float timeToAttack;

    public void Awake()
    {
        type = ItemType.Weapon;
    }
}

