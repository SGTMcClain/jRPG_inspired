using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    Item myItem = new Item("Pebble", 10, "Good for skipping across a pond");
    Item myNewItem = new Item();
    Item myStick = new Item("Stick", 2);

    Consumable potion = new Consumable();

    Armor armor = new Armor();
    Armor moreArmor = new Armor();

    Weapon unanamedWeapon = new Weapon();
    Weapon rustySword = new Weapon("Rusty Sword", "A rusty Sword", 50, 60, 20, WeaponType.Sword);
    Weapon battleAxe = new Weapon("Battle Axe", "An axe stained with the blood of your enemies", 100, 150, 50, WeaponType.Axe);

    // Start is called before the first frame update
    void Start()
    {
        // assign armor properties
        armor.name = "leather shirt";
        armor.weight = 15;
        armor.description = "a simple leather shirt";
        armor.cost = 20;
        armor.defense = 10;
        armor.isMetalic = false;
        armor.type = "shirt";

        List<Item> allItems = new List<Item>();

        allItems.Add(myItem);
        allItems.Add(myNewItem);
        allItems.Add(myStick);
        allItems.Add(armor);
        allItems.Add(moreArmor);
        allItems.Add(unanamedWeapon);
        allItems.Add(rustySword);
        allItems.Add(battleAxe);

        foreach(Item item in allItems)
        {
            Debug.Log("My Item's Name: " + item.name);
            Debug.Log(item.name + " Cost: " + item.cost);
            Debug.Log(item.name + " Description: " + item.description);
            Debug.Log(item.name + " is worth " + item.Sell() + " at a merchant");

            if(item.GetType() == typeof(Armor))
            {
                Debug.Log(item.name + "'s Defense is " ); // Find Fix
            } 
            else if (item.GetType() == typeof(Weapon))
            {
                Debug.Log(item.name + "'s Attack is ");  // Find Fix
            }
        }

        /*
        //Array
        List<Armor> armorList = new List<Armor>();
        List<Item> itemList = new List<Item>();

        armorList.Add(armor);
        //armorList.Add(myItem);
        armorList.Add(moreArmor);

        itemList.Add(armor);
        itemList.Add(myItem);

        // My Item
        Debug.Log("My Item's Name: " + myItem.name);
        Debug.Log(myItem.name + " Cost: " + myItem.cost);
        Debug.Log(myItem.name + " Description: " + myItem.description);
        Debug.Log(myItem.name + " is worth " + myItem.Sell() + " at a merchant");


        // Armor
        Debug.Log("My Item's Name: " + armor.name);
        Debug.Log(armor.name + " Cost: " + armor.cost);
        Debug.Log(armor.name + " Description: " + armor.description);
        Debug.Log(armor.name + " is worth " + armor.Sell() + " at a merchant");
        Debug.Log(armor.name + " has a weight of " + armor.weight + " a defense of " + armor.defense + " and a type of " + armor.type);

        
        //MyNewItem
        Debug.Log("My Item's Name: " + myNewItem.name);
        Debug.Log(myNewItem.name + " Cost: " + myNewItem.cost);
        Debug.Log(myNewItem.name + " Description: " + myNewItem.description);

        Debug.Log(myNewItem.name + " is worth " + myNewItem.Sell() + " at a merchant");

        //MyStick
        Debug.Log("My Item's Name: " + myStick.name);
        Debug.Log(myStick.name + " Cost: " + myStick.cost);
        Debug.Log(myStick.name + " Description: " + myStick.description);

        Debug.Log(myStick.name + " is worth " + myStick.Sell() + " at a merchant");
        */
    }


}
