using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int minDamage;
    public int maxDamage;
    public int durability;
    public WeaponType weaponType;

    private int minDamageOffset = 10;

    public Weapon()
    {
        name = "unammed weapon";
        cost = 4;
        description = "no description for this weapon";
        minDamage = 1;
        maxDamage = 10;
        durability = 10;
        weaponType = WeaponType.Sword;
    }

    public Weapon(string name, string description, int cost, int maxDamage, int durability, WeaponType type)
    {
        this.name = name;
        this.cost = cost;
        this.description = description;
        this.minDamage =  maxDamage - minDamageOffset;
        this.maxDamage = maxDamage;
        this.durability = durability;
        this.weaponType = type;
    }

    public int Attack()
    {
        return Random.Range(minDamage, maxDamage);
    }
}

public enum WeaponType
{
    Sword,
    Axe,
    Staff,
    Polearm
}

