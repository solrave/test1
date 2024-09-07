namespace SimpleShop;

public class Player
{
    public readonly List<Item> Inventory;
    private int _gold;

    public Player(int gold)
    {
        Inventory = new(){new Item("Sword",25), new Item("Shield",15), new Item("Apple",5)};
        _gold = gold;
    }

    public void PayGold(int amount)
    {
            _gold -= amount;
    }

    public void GetGold(int amount)
    {
        _gold += amount;
    }
    public void ShowGoldAmount()
    {
        Console.WriteLine(_gold);
    }
}