using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FluentTask.Commands
{
    public class SayCommand : ICommand
    {
        private string phrase;

        public SayCommand(string phrase)
        {
            this.phrase = phrase;
        }

        public void Execute()
        {
            Console.WriteLine(phrase);
        }
    }
}
