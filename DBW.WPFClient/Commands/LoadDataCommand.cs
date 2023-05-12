using DBW.WPFClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DBW.WPFClient.Commands
{
    internal class LoadDataCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
       
    }
}
