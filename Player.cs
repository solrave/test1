namespace SimpleShop;

public class Player
{
    public readonly List<Item> Inventory;
    public int Gold { get; set; }

    public Player(int gold)
    {
        Inventory = new(){new Item("Sword",25), new Item("Shield",15), new Item("Apple",5)};
        Gold = gold;
    }
    
    
}