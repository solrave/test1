namespace SimpleShop;

public class Item
{
    public readonly string Name;
    public readonly int Price;

    public Item(string name, int price)
    {
        Name = name;
        Price = price;
    }
}