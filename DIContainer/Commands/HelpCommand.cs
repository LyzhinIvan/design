using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DIContainer.Commands
{
    public class HelpCommand : BaseCommand
    {
        [Inject]
        public Lazy<IEnumerable<ICommand>> commandsList { get; set; }

        public HelpCommand()
        {

        }

        public override void Execute()
        {
            foreach (var command in commandsList.Value)
            {
                Console.WriteLine(command.Name);
            }
        }
    }
}
