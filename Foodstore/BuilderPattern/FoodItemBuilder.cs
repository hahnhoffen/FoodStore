using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodstore.BuilderPattern
{
    public class FoodItemBuilder
    {
        private FoodItem _foodItem;
        public FoodItemBuilder()
        {
            _foodItem = new FoodItem();
        }
        public FoodItemBuilder SetName(string name)
        {
            _foodItem.Name = name;
            return this;
        }
        public FoodItemBuilder SetPrice(double price)
        {
            _foodItem.Price = price;
            return this;
        }
        public FoodItemBuilder SetDescription(string description)
        {
            _foodItem.Description = description;
            return this;
        }
        public FoodItem Build()
        {
            return _foodItem;
        }
    }
}
