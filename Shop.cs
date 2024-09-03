namespace SimpleShop;
using static Console;
public class Shop
{
    private Player _hero;
    private readonly List<Item> _shop;
    private int _menuIndex;
    string[] menu = new string[] {"Buy", "Sell","Exit"};
    public Shop()
    {
        var items = new string[] {"Sword", "Buckler", "Staff", "Apple", "Book", "Helm" };
        _shop = new();
        CreateShopList(items);
        _hero = new Player(200);
    }

    private void CreateShopList(string[] itemsNames)
    {
        Random randomPrice = new Random();
        for (int i = 0; i < itemsNames.Length; i++)
        {
            _shop.Add(new Item(itemsNames[i],randomPrice.Next(5,78)));
        }
    }

    public void DrawShopMenu()
    {
        _menuIndex = 0;
        for (int i = 0; i < menu.Length; i++)
        {
            WriteLine((_menuIndex == i) ? $">>{menu[i]}" : $"{menu[i]}"); 
        }
        
    }

    public void ShowItemList (List<Item> itemList, string action)
    {
        Clear();
        WriteLine($"Choose what you want to {action}");
        _menuIndex = 0;
        for (int i = 0; i < itemList.Count; i++)
        {
            WriteLine((_menuIndex == i) 
                ? $">>{itemList[i].Name}    {itemList[i].Price}<<" 
                : $"{itemList[i].Name}    {itemList[i].Price}");
        }
    }

    public void BuyItems()
    {
    }

    public void SellItems()
    {
    }

    public void Run()
    {
            Clear();
            DrawShopMenu();
            var userInput = ReadKey().Key;
            switch (userInput)
            {
                case ConsoleKey.UpArrow:
                    _menuIndex = (_menuIndex == 0) ? menu.Length - 1 : _menuIndex - 1;
                    break;

                case ConsoleKey.DownArrow:
                    _menuIndex = (_menuIndex == menu.Length) ? 0 : _menuIndex + 1;
                    break;

                case ConsoleKey.Enter:
                    switch (menu[_menuIndex])
                    {
                        case "Buy": BuyItems(); break;
                        case "Sell": SellItems(); break;
                        case "Exit": return;
                    }
                    break;
            }
    }
}