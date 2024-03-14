using Foodstore.BuilderPattern;
using Foodstore.CommandPattern;
using Foodstore.Singleton.FoodStore;
using Foodstore.Singleton.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStore
{
    public class FoodStoreApp
    {
        private GroceryStore store;
        private FoodCart cart;

        public FoodStoreApp()
        {
            store = GroceryStore.GetInstance();
            cart = new FoodCart();
            InitializeMenu();
        }
        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("1. Add item to cart");
                Console.WriteLine("2. Display cart");
                Console.WriteLine("3. Calculate total price");
                Console.WriteLine("4. Remove Item");
                Console.WriteLine("5. Search for Item");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice:");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        DisplayMenu();
                        Console.WriteLine("Enter the item number to add:");
                        Console.WriteLine();
                        int itemNumber;
                        if (int.TryParse(Console.ReadLine(), out itemNumber) && itemNumber >= 0 && itemNumber < store.GetMenu().Count)
                        {
                            cart.AddItem(store.GetMenu()[itemNumber]);
                            Console.WriteLine("Item added to cart.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid item number.");
                            Console.WriteLine();
                        }
                        break;
                    case "2":
                        cart.DisplayCart();
                        break;
                    case "3":
                        double totalPrice = CalculateTotalPrice();
                        Console.WriteLine();
                        Console.WriteLine($"Total Price: ${totalPrice}");
                        Console.WriteLine();
                        break;
                    case "4":
                        cart.DisplayCart();
                        Console.WriteLine("Enter the item number to remove:");
                        Console.WriteLine();
                        int itemToRemove;
                        if (int.TryParse(Console.ReadLine(), out itemToRemove))
                        {
                            cart.RemoveItem(itemToRemove);
                        }
                        break;
                    case "5":
                        SearchForItem();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                        break;
                }
            }
        }
        private void InitializeMenu()
        {
            store.AddMenuItem(new FoodItemBuilder().SetName("Burger").SetPrice(5.99).SetDescription("Classic beef burger").Build());
            store.AddMenuItem(new FoodItemBuilder().SetName("Pizza").SetPrice(7.99).SetDescription("Cheese pizza").Build());
            store.AddMenuItem(new FoodItemBuilder().SetName("Salad").SetPrice(4.99).SetDescription("Fresh garden salad").Build());
            store.AddMenuItem(new FoodItemBuilder().SetName("Fries").SetPrice(2.49).SetDescription("Crispy fries").Build());
            store.AddMenuItem(new FoodItemBuilder().SetName("Soda").SetPrice(1.99).SetDescription("Refreshing soda").Build());
            store.AddMenuItem(new FoodItemBuilder().SetName("Sandwich").SetPrice(6.49).SetDescription("Classic sandwich").Build());
        }
        private void DisplayMenu()
        {
            List<FoodItem> menu = store.GetMenu();
            Console.WriteLine("Menu:");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i}. {menu[i].Name}: ${menu[i].Price}");
            }
        }
        private double CalculateTotalPrice()
        {
            var menu = store.GetMenu();
            if (menu == null || menu.Count == 0)
            {
                Console.WriteLine("Menu is empty. Please add items to the menu.");
                return -1;
            }
            var itemPrices = menu.ToDictionary(item => item.Name, item => item.Price);
            return cart.CalculateTotalPrice(itemPrices);
        }
        private void SearchForItem()
        {
            Console.WriteLine("Enter the name of the item to search:");
            Console.WriteLine();
            string itemName = Console.ReadLine();
            FoodItem foundItem = store.FindItemByName(itemName);
            if (foundItem != null)
            {
                Console.WriteLine($"Item found: {foundItem.Name}, Price: ${foundItem.Price}, Description: {foundItem.Description}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Item not found.");
                Console.WriteLine();
            }
        }
    }
}
