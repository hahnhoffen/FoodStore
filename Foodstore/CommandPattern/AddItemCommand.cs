using Foodstore.BuilderPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Foodstore.CommandPattern
{
    public interface ICommand
    {
        void Execute();
    }

    public class AddItemCommand : ICommand
    {
        private readonly FoodCart _cart;
        private readonly FoodItem _item;

        public AddItemCommand(FoodCart cart, FoodItem item)
        {
            _cart = cart;
            _item = item;
        }

        public void Execute()
        {
            _cart.DirectAddItem(_item);
        }
    }
}

