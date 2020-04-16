using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;  // Item Name
    public string description;  // Item Description
    public int cost; // Item Cost

    public Item()  //Generic Constructor, A constructor that takes no arguments
    {
        name = "Rock";
        description = "A rock";
        cost = 6;
    }

    public Item(string aName, int aCost) // A constructor that takes 2 arguments
    {
        name = aName;
        cost = aCost;
        description = name + " was not given a description.";
    }

    public Item(string aName, int aCost, string aDescription)
    {
        name = aName;
        cost = aCost;
        description = aDescription;
    }

    public int Sell()
    {
        return cost / 2;
    }
}
