public class Item
{
    // What properties should an item have in an RPG?

    // Item Name
    private string name; 
    public string Name 
    {
        get{return name;}
        set{name = value;}
    }

    // Item Cost
    private int cost;
    public int Cost 
    {
        get{return cost;} 
        set{cost = value;}
    }

    // Item Description
    private string description;

    public string Description
    {
        get {return description;}
        set {description = value;}
    }



    public Item()
    {
        name = "Stick";
        cost = 2;
        description = "It's a stick";
    }

    public Item(string aName, int aCost)
    {
        name = aName;
        cost = aCost;
        description = name + " has no description yet.";
    }

    /** Sell
    * Method to Sell items at half cost
    */
    public int Sell()
    {
        return cost/2;
    }
    
}
