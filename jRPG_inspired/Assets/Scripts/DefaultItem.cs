using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Items/Default")]
public class DefaultItem : ItemObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
