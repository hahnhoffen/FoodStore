using Foodstore.BuilderPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodstore.Singleton
{
    namespace FoodStore
    {
        public class GroceryStore
        {
            private static GroceryStore instance;
            private List<FoodItem> menu;
            private GroceryStore()
            {
                menu = new List<FoodItem>();
            }
            public static GroceryStore GetInstance()
            {
                if (instance == null)
                {
                    instance = new GroceryStore();
                }
                return instance;
            }
            public void AddMenuItem(FoodItem item)
            {
                menu.Add(item);
            }
            public List<FoodItem> GetMenu()
            {
                return menu.ToList();
            }
            public FoodItem FindItemByName(string name)
            {
                return menu.FirstOrDefault(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
