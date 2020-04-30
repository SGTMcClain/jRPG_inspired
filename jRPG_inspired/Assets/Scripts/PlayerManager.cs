using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<Item>();

        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }

        Debug.Log("Touched the item");
    }
    public void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
