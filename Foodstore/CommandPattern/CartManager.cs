using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Foodstore.CommandPattern
{
    internal class CartManager
    {
        private ICommand _command;
        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        public void ExecuteCommand(object parameter)
        {
            _command.Execute(parameter);
        }
    }
}
