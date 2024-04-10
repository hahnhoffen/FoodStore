using Foodstore.BuilderPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Formats.Asn1.AsnWriter;


namespace Foodstore.CommandPattern
{
    public class FoodCart
    {
        private List<FoodItem> items = new List<FoodItem>();
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        public void ExecuteCommand()
        {
            if (_command != null)
            {
                _command.Execute();
            }
            else
            {
                Console.WriteLine("No command set for the cart.");
            }
        }
        public void AddItem(FoodItem item)
        {

            if (_command == null)
            {
                Console.WriteLine("No command set for adding item to cart.");
                return;
            }
            ExecuteCommand();
        }
        public void DisplayCart()
        {
            Console.WriteLine("Items in cart:");
            foreach (var item in items)
            {
                Console.WriteLine("- " + item.Name);
            }
        }
        public double CalculateTotalPrice(Dictionary<string, double> itemPrices)
        {
            double totalPrice = 0;
            foreach (var item in items)
            {
                if (itemPrices.ContainsKey(item.Name))
                {
                    totalPrice += itemPrices[item.Name];
                }
            }
            return totalPrice;
        }
        public void RemoveItem(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                FoodItem removedItem = items[index];
                items.RemoveAt(index);
                Console.WriteLine(removedItem.Name + " removed from cart.");
            }
            else
            {
                Console.WriteLine("Invalid item number.");
            }
        }
        public void DirectAddItem(FoodItem item)
        {
            items.Add(item);
            Console.WriteLine(item.Name + " added to cart.");
        }
    }
}