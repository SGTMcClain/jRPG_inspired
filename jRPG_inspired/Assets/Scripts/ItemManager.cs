using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item myItem = new Item("Rock", 6); // Generate new Item
    // Start is called before the first frame update
    void Start()
    {
        // Part 1 setup basic item
        // myItem.Name = "Stick"; // Give the item a name
        // myItem.Cost = 2; // Give the item a cost

        //Print Item Name and Cost to the Console
        Debug.Log("My Item's Name: " + myItem.Name);
        Debug.Log(myItem.Name + " Cost: " + myItem.Cost);
        Debug.Log(myItem.Name + " Description: " + myItem.Description);

        //Show Sell price
        Debug.Log(myItem.Name + " is worth " + myItem.Sell() + " at a vendor.");
    }

}
