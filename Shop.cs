

namespace SimpleShop;
using static Console;
using System.Threading;
using System.Linq;
public class Shop
{
    private readonly Player _hero;
    private readonly Player _shop;
    private int _menuIndex;
    private ConsoleKey _userInput;
    string[] _menu = new string[] {"Buy", "Sell","Exit"};
    public Shop()
    {
        _hero = new Player(200);
        _shop = new Player(900);
    }

   /* private void CreateShopList(string[] itemsNames)
    {
        Random randomPrice = new Random();
        foreach (var item in itemsNames)
        {
            _shop.Add(new Item(item,randomPrice.Next(5,78)));
        }
    }*/

    private void DrawShopMenu()
    {
        for (int i = 0; i < _menu.Length; i++)
        {
            WriteLine((_menuIndex == i) ? $">>{_menu[i]}" : $"{_menu[i]}"); 
        }
        
    }

    private void ShowListSelected (Player target)
    {
        target.ShowGoldAmount();
        for (int i = 0; i < target.Inventory.Count; i++)
        {
            WriteLine((_menuIndex == i) 
                ? $">>{target.Inventory[i].Name}    {target.Inventory[i].Price}<<" 
                : $"{target.Inventory[i].Name}    {target.Inventory[i].Price}");
        }
    }
    private void ShowList (Player target)
    {
        target.ShowGoldAmount();
        foreach (var item in target.Inventory)
        {
            WriteLine($"{item.Name}    {item.Price}");
        }
    }
    

    private void BuyItem() => TradeItem(_shop, _hero, "BUY", true, false);
    private void SellItem() => TradeItem(_hero, _shop, "SELL", false, true);
    
    private void TradeItem(Player from, Player to, string action, bool buy, bool sell)
    {
        _menuIndex = 0;
        bool inProgress = true;
        while (inProgress)
        {
            Clear();
            WriteLine("\x1b[3J");
            WriteLine($"Choose what you want to {action}");
            ShowListSelected(from);
            WriteLine();
            ShowList(to);
            _userInput = ReadKey().Key;
        
            switch (_userInput)
            {
                case ConsoleKey.UpArrow:
                    _menuIndex = (_menuIndex == 0) ? from.Inventory.Count - 1 : _menuIndex - 1;
                    break;

                case ConsoleKey.DownArrow:
                    _menuIndex = (_menuIndex == from.Inventory.Count - 1) ? 0 : _menuIndex + 1;
                    break;

                case ConsoleKey.Enter:
                    
                        if (from.Inventory.Any())
                        {
                            to.PayGold(from.Inventory[_menuIndex].Price);
                            from.GetGold(from.Inventory[_menuIndex].Price);
                            to.Inventory.Add(from.Inventory[_menuIndex]);
                            from.Inventory.RemoveAt(_menuIndex);
                            inProgress = false;
                        }
                        else
                        {
                            WriteLine("The shop is empty!");
                            inProgress = false;
                            Thread.Sleep(1000);
                        }
                        break;
                        
            }
        }

    }
    
    public void Run()
    {
        Clear();
        WriteLine("\x1b[3J");
        Clear();
        WriteLine("Choose option with >Up< and >Down< arrows, then press >Enter<");
            DrawShopMenu();
            _userInput = ReadKey().Key;
            switch (_userInput)
            {
                case ConsoleKey.UpArrow:
                    _menuIndex = (_menuIndex == 0) ? _menu.Length - 1 : _menuIndex - 1;
                    break;

                case ConsoleKey.DownArrow:
                    _menuIndex = (_menuIndex == _menu.Length - 1) ? 0 : _menuIndex + 1;
                    break;

                case ConsoleKey.Enter:
                    switch (_menu[_menuIndex])
                    {
                     case "Buy": BuyItem(); break;
                     case "Sell": SellItem(); break;
                     case "Exit": Environment.Exit(0); break;
                    }
                    break;
            }
    }
}