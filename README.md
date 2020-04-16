# jRPG_inspired

A game inspired by old school jRPGs to teach basics in Unity Game Development and C# programming.

This project makes use of:

* tilesets
* spritesheets
* basic c# classes

## A basic class

Item.cs othewise known as the class (does not need to be in the scene)

```csharp
class Item
{
    private string name;

    public string Name
    {
        get {return name;} // get method
        set {name = value;} // set method
    }

    private string description;

    public string Description
    {
        get {return description;}
        set {description = value;}
    }

    public int cost;
    public int Cost
    {
        get {return cost;} // get method
        set {cost = value;} // set method
    }
}
```

ItemManager.cs (Unity Monobehavior on an item in the scene)

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Monobehavior
{
    Item myItem = new Item();  // Construct a new Item
    void Start()
    {
        myItem.Name = "Stick"; // Give the item a name
        myItem.Cost = 2; // Give the item a cost
        myItem.Description = "It's a stick" //Give the item a description

        //Print Item Name, Description and Cost to the Console
        Debug.Log("My Item's Name: " + myItem.Name);
        Debug.Log(myItem.Name + " Cost: " + myItem.Cost);
        Debug.Log(myItem.Name + " Description: " + myItem.Description);
    }

    void Update()
    {

    }
}
```

<!-- Vanilla C# Code -->
<details>
<summary>What about in regular C# ?</summary>
<br>
<pre>
<code>
class Program
{
    static void Main(string[] args)
    {
        Item myItem = new Item();  // Generate new Item
        myItem.Name = "Health Potion"; // Give the item a name
        myItem.Cost = 50; // Give the item a cost
    }
}
</code>
</pre>
</details>

### Properties & Encapsulation
[W3 schools notes on C# properties](https://www.w3schools.com/cs/cs_properties.asp)

## Class Methods
[W3 schools notes on C# methods ](https://www.w3schools.com/cs/cs_methods.asp)

Classes can have methods that are specific to that class.  We can add one to our Item class to set the price that a vendor will accept to purchase an item.

```csharp
// Method to Sell items at half cost
public int Sell()
{
    return cost/2;  //
}
```

Add this Debug.Log() to ItemManager to see this method in action

```csharp
//Show Sell price
Debug.Log(myItem.Name + " is worth " + myItem.Sell() + " at a merchant.");
```


## Constructors


 Constructors are used to initialize objects in specific ways.

Without a constructor on Item when you initalize a new item

 ```csharp
 public Item myItem = new Item();
 ```

you create a new Item where:

```csharp
myItem.name = null
myItem.cost = null
```

and we have to give name and cost value manually by saying

```csharp
myItem.Name = "Stick";
myItem.Cost = 2
```

But with a constructor we can make sure every new item starts off as a stick

```csharp
    public Item() //default constructor
    {
        name = "Stick"
        cost = 2
        description = "It's a stick"
    }
```

So now running the default constructor again

```csharp
 public Item myItem = new Item();
```

will initialize the name to Stick and the cost to 2 automatically.

If we go to our ItemManager script and remove

```csharp
    myItem.Name = "Stick"; // Give the item a name
    myItem.Cost = 2; // Give the item a cost
    myItem.Description = "It's a stick" //Give the item a description
```

from Start() and run your scene you will notice that you still get the same output as before.  The constructor is creating a stick for you.

We can add arguments to make it so that we can create any item we want with the constructor also.

Back in Item.cs lets add another constructor under our last one.

```csharp
public Item(string aName, int aCost)
{
    name = aName;
    cost = aCost;
    description = name + " has no description yet.";
}
```

This time we are adding two arguments to the Item constructor a string calle aName and an int called aCost.  This will allow us to pass any string for a name and any int as a cost.

Back in the ItemManager Script lets adjust this line

```csharp
 public Item myItem = new Item();
```

to

```csharp
 public Item myItem = new Item("Rock", 6);
```

Then play your scene again and it should show that items name is Rock, it Cost 6 and it is worth 3 at a vendor

## Inheritance

We have done basic items but what about other items that we could have in an inventory like Consumables, Weapons (Swords, Axes, Staffs, Wands), and Armor. Each one of these categories is a bit unique and will require different properties.

Using our Item class as a base we can create all of these other item types without having to duplicate the work that we did with the item class. Basic items all have a name, a cost, a description, and a sell value that is generated from the Item Method Sell().

Since consumables, weapons, and armor are all items they can be said to inherit from the item class.  Then all you have to do is add what's unique about each for instance:

Consumables need HPGain & MPGain
Weapons needs Type, MinDamage, MaxDamage
Armor needs Type, ArmorBonus, Resistance

So the weapon class would look something like:

```csharp
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
```

## Assets

**Free RPG World Tileset 32 x 32, 40 x 40, 48 x 48**
**Author: Pipoya**

![Image of RPG World Tileset](https://img.itch.zone/aW1nLzI0OTE5MTYucG5n/original/OFphzG.png)

<https://pipoya.itch.io/pipoya-free-rpg-world-tileset-32x32-40x40-48x48>

**Free RPG Character Sprites 32 x 32**
**Author: Pipoya**

![Image of RPG Character Sprites](https://img.itch.zone/aW1nLzI0NzI4MTQucG5n/original/Ya0NFV.png)

<https://pipoya.itch.io/pipoya-free-rpg-character-sprites-32x32>

**Kyrise's Free 16x16 rpg icon pack**
**Author: Kyrise**
![Image of RPG Icon Pack](https://img.itch.zone/aW1nLzE0MDY4ODQucG5n/original/JXizVY.png)

<https://kyrise.itch.io/kyrises-free-16x16-rpg-icon-pack>
