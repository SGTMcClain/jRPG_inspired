using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    
    // Methods for Inventory Object
    public void AddItem(ItemObject givenItem, int givenAmount)
    {
        bool hasItem = false;

        for (int i = 0; i < Container.Count; i++)
        {
            // Adds to the items counter if it already exists in inventory
            if (Container[i].item == givenItem)
            {
                hasItem = true;
                Container[i].AddAmount(givenAmount);
                break;
            }

        }
        // Adds the item if it isn't in the inventory
        if (!hasItem)
        {
            Container.Add(new InventorySlot(givenItem, givenAmount));
        }
 
        
    }
}

// Inventory Slot Class
[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    //Constructor for Inventory Class
    public InventorySlot(ItemObject givenItem, int givenAmount)
    {
        item = givenItem;
        amount = givenAmount;
    }

    // Methods for Inventory Class 
    public void AddAmount(int value)
    {
        amount += value;
    }
}
