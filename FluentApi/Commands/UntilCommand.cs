using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentTask.Commands
{
    public class UntilCommand : ICommand
    {
        private Func<Behavior, Behavior> func;

        public UntilCommand(Func<Behavior, Behavior> func)
        {
            this.func = func;
        }

        public void Execute()
        {
            while (!Console.KeyAvailable)
            {
                func(new Behavior()).Execute();
                Thread.Sleep(500);
            }
            Console.ReadKey(true);
        }
    }
}
