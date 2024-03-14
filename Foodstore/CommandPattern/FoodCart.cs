using Foodstore.BuilderPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;


namespace Foodstore.CommandPattern
{
    public class FoodCart
    {
        private List<FoodItem> items = new List<FoodItem>();
        public void AddItem(FoodItem item)
        {
            items.Add(item);
            Console.WriteLine(item.Name + " added to cart.");
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
            if (items.Count == 0)
            {
                Console.WriteLine("Cart is empty. Please add items to the cart.");
                return 0;
            }

            double totalPrice = 0;
            foreach (var item in items)
            {
                totalPrice += item.Price;
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
    }
}

