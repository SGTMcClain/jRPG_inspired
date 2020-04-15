using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int minDamage;
    public int maxDamage;
    public int durablitiy;
    public WeaponType type;

    public int Attack()
    {
        return Random.Range(minDamage, maxDamage);
    }
}

public enum WeaponType 
{
    Sword,
    Axe,
    Pike,
    Knife,
    Staff
}