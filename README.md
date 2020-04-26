# jRPG_inspired

A game inspired by old school jRPGs to teach basics in Unity Game Development and C# programming.

This project makes use of:

* [Spritesheets](#assets)
* [Basic c# classes](#a-basic-class)
* [UI Panel and Text](#ui-panel-and-text)
* [Save & Load](#save-and-load)

## April 29, 2020
### Scriptable Object intro
[Based On Unity3D - Inventory System w/Scriptable Objects by Coding with Unity](https://youtu.be/_IqTeruf3-s)

1. Create a new script called "ItemObject" and make it an abstract class and make it of type ScriptableObject
    ```csharp
    public abstract class ItemObject : ScriptableObject
    {
     
    }
   ```
   as an abstract class this class can never be used, it is just a model for our base items.
2. Add an enumerated class at the top of script file called ItemType.  Your file should look like this
   ```csharp
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public enum ItemType
    {
        Consumable,
        Weapon,
        Armor,
        Default

    }
    public abstract class ItemObject : ScriptableObject
    {
        
    }
   ```
   1. Add a public Sprite named image, A public ItemType named type, a public int called cost, and a public string called description. Over description add "[TextArea(15,20)]" to establish a text area that is large enough in the inspector to fit a length description
   ```csharp
    public abstract class ItemObject : ScriptableObject
    {
        public Sprite image;
        public ItemType type;
        public int cost;
        [TextArea(15, 20)]
        public string description;
        
    }

   ```
3. Create a new script called DefaultItem
4. Remove the Start() and Update Classes
5. Replace Monobehavior with ScriptableObject
6. Above the class name add:
   ```csharp
   [CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Items/Default")]
   ```
   This will allow us to create a new Default Item from the Create Menu in the Unity Editor
7. Next we want to make sure the item type is set to Default every time we create this object and we will do that by adding the Awake() function to the DefaultItem class and having the type = ItemType.Default
   ```csharp
    public void Awake()
    {
        type = ItemType.Default;
    }
   ```

8. We can test this out by going to our Scriptable objects folder right clicking and going to Inventory System -> Items -> Default and then giving the new object a name a description and an image from your spritesheet.
   
9. Add another script for your ConsumableItem... It should be the same as the DeafultItem Class but add public ints for restoring health and magic values
    ```csharp
    [CreateAssetMenu(fileName = "New Consumable Item", menuName = "Inventory System/Items/Consumable")]
    public class ConsumableItem : ItemObject
    {
        public int restoreHealthValue;
        public int restoreMagicValue;
        public void Awake()
        {
            type = ItemType.Consumable;
        }
    }
    ```
10. We could continue to make more items like Weapon or Armor in this same manner.
11. Now we need to create an inventory for all of this stuff to go in so in the ScriptableObjects and add an Inventory folder then inside the Inventory folder add a Scripts folder
12. inside of scipts create a new script called InventoryObject and replace Monobehavior with ScriptableObject then delete Start() and Update()
13. Add:
```csharp
public List<InventorySlot> Container = new List<InventorySlot>();
```
To InventoryObject 
14. Below the final closing bracket of InventoryObject create a new class called InventorySlot with the properties public ItemObject call item and a public in called amount.
```csharp
public class InventorySlot
{
    public ItemObject item;
    public int amount;
}
```

15. Directly above InventorySlot add [System.Serializable] so that you can see Inventory Slot in the inspector
16. Add a constructor that takes two arguments of ItemObject named item and int name amount, then assign those arguments to the classes variables

```csharp
    public InventorySlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
```

17. Add a method to the InventorySlot class called AddAmount with one argument, an int called value. Inside the method should be amount += value.

```csharp
    public void AddAmount(int value)
    {
        amount += value;
    }
```

18. Then create a method called AddItem with 2 arguments an ItemObject called _item and an int called _amount.
19. Inside add item will be a bool called hasItem and set it to false

```csharp
    bool hasItem = false;
```

20. Inside AddItem a for loop to test if the container already has one of the items, if it does then change hasItem to true then break out of the loop.
21. If it doesn't contain one of the items after the loop write an if statement where if hasItem is false you add a new inventory slot with the _item and _amount as arguments
22. The entire AddItem should look like this when you are done.

```csharp
    public void AddItem(ItemObject _item, int _amount)
    {
        // Check  if item is in the inventory
        bool hasItem = false;
        for(int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if(!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
```

23. Create a new menu item by adding:

```csharp
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
```
On top of the InventoryObject class

24. Now you can create a new Inventory inside your inventory folder and call it "PlayerInventory"


## April 22, 2020

### UI Panel and Text

We are going to create a simple UI Panel and Text that will display the players X and Y location on screen and make the panel appear and disappear on a button press

**Setting Up The UI**
1. Add a UI Panel element
2. Click 'Canvas' and In the inspector Change the Canvas Render Mode to "Screen Space - Camera"
3. Drag the Main Camera onto the Render Camera
4. Set the Order in Layer to something large like 50
5. Click 'Panel' and In the inspector click Color in the Image Component
6. Set the Alpha "A" to 255
7. In the inspector set the Bottom in the Rect Transform to 450
8. Add a UI Text element to your scene and nest it as a child to the Panel
9. Duplicate the UI Text element
10. Change the names of the two Text elements under Canvas to "Display_X_Text" and "Display_Y_Text"
11. In the inspector change the Text to "Display X" and "Display Y" respectively.
12. Set "Display_X_Text" to Pos X: -300
13. Set "Display_X_Text" to Pos Y: 250
14. Set "Display_X_Text" to Pos X: -300
15. Set "Display_X_Text" to Pos Y: 200
16. Create an empty Game Object and name it GameManager
17. Create a new script and name it GameManager (This will turn the script into a gear)
18. Drag the GameManager script onto the GameManager GameObject
19. Open the Game Manager Script in your IDE (Visual Studio)
20. At the very top of the script add
    ```csharp
    using UnityEngine.UI;
    ```
21. After the class declaration right inside the first curly braces add
    ```csharp
    public GameObject player;
    public Text displayX;
    public Text displayY;
    ```
22. Inside void Update() Add
    ```csharp
    string xText = player.transform.position.x.ToString();
    string yText = player.transform.position.y.ToString();
    displayX.text = "X: " + xText;
    displayY.text = "Y: " + yText;
    ```
23. Click on the GameManager game object and drag Display_X_Text into Display X in the inspector
24. Drag Display_Y_Text into Display Y in the inspector
25. Drag the Player onto Player in the inspector
26. Test your scene
27. After everything is working lets move the code we just wrote to a method named Update_XY() underneath the Update() Method like this:

    ```csharp
    void Update_XY()
    {
        string xText = player.transform.position.x.ToString();
        string yText = player.transform.position.y.ToString();
        displayX.text = "X: " + xText;
        displayY.text = "Y: " + yText;
    }
    ```

28. In the Update() method add:

    ```csharp
    Update_XY();
    ```

    This helps us keep the Update method clean and our code reusable

**Hiding The UI Panel**

Now we don't want to always display this information so lets hide it with a button press.

1. Rename the Canvas to TopUI_Canvas
2. Directly under Text displayY Add:
    ```csharp
    public Canvas TopUI;
   ```
3. Then in Update() Add:
   ```csharp
    if (Input.GetKeyDown(KeyCode.M))
    {
        //Toggle TopUI
        if (!TopUI.activeSelf)
        {
            TopUI.SetActive(true);
        }
        else
        {
            TopUI.SetActive(false);
        }
    }
   ```
This sets the GameManager up to listen for the user to press 'M' and when it hears it our script checks if the TopUI is active and then turns it off if it is active or turns it on if it is inactive.
4. Lets turn off the TopUI_Canvas by clearing the check mark next to its name in the inspector.
5. Lets test to see if our code execute properly
6. If everything went well lets clean up the Update() method again by creating a ToggleCanvas() method

```csharp
    void ToggleCanvas()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggle Top UI
            if (!TopUI.activeSelf) // if the Top UI is not active
            {
                TopUI.SetActive(true); // Show the Canvas
            }
            else
            {
                TopUI.SetActive(false); // Hide the Canvas
            }

        }
    }
```

7. And placing the statement we just wrote into that method

    ```csharp
    ToggleCanvas();
    ```

### Save and Load

**Getting Setup**

1. Lets make the TopUI_Canvas active again by checking the box next to it's name in the inspector
2. Add a UI Button
3. Press the arrow and then click text and change the Text(Script) in the inspector to Save.  Also change the Button name from Button to Save_Button
4. Duplicate Save_Button and change the Text Script to Load and change the Button name from Save_Button to Load_Button
5. Set Save_Button Pos X to 300 and Pos Y to 250
6. Set Load Button Pos X to 300 and Pos Y to 200

#### PlayerPrefs

[Unity PlayerPref Documentation](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html?_ga=2.202986198.637285251.1587509263-628809777.1585687538)

Playerprefs in Unity are a built in way of storing basic string, int, and/or float data from your games in a way that is accessible to any platform that Unity runs on.

We will need a Save() Function and a Load() Function in the GameManager script

```csharp
    public void Save()
    {
        float xPosition = player.transform.position.x;
        float yPosition = player.transform.position.y;


        PlayerPrefs.SetFloat(PP_xPOSITION_STRING, xPosition);
        PlayerPrefs.SetFloat(PP_yPOSITION_STRING, yPosition);

        Debug.Log("Player Prefs Saved : x = " + xPosition + " y = " + yPosition);
    }
```

```csharp
    public void Load()
    {
        float load_x = PlayerPrefs.GetFloat(PP_xPOSITION_STRING);
        float load_y = PlayerPrefs.GetFloat(PP_yPOSITION_STRING);

        Vector2 loadPlayer = new Vector2(load_x, load_y);

        player.transform.position = loadPlayer;
        Debug.Log("Player Prefs Loaded!");
    }
```

Now go back to your Save_Button in the Button(Script) Component in the inspector look for the "On Click ()" box, click the plus button, then drag the GameManager GameObject onto the open spot. That should activate the dropdown that shows "No Function"

Next press the "No Function" dropdown and Select GameManager -> Save().  Then repeat this process for the Load_Button selecting Load().

Thats it you are now saving and loading from player prefs.  You can add more properties to this setup if you choose.

Make sure to make the canvas inactive again so that it hidden when you start your game.


## April 15, 2020

### A basic class

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


### Constructors


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

### Inheritance

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
-----------------
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
