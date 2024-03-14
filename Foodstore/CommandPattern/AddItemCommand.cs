using Foodstore.BuilderPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Foodstore.CommandPattern
{
    public class AddItemCommand : ICommand
    {
        private FoodCart _cart;
        private FoodItem _item;
        public AddItemCommand(FoodCart cart, FoodItem item)
        {
            _cart = cart;
            _item = item;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _cart.AddItem(_item);
        }
    }
}

