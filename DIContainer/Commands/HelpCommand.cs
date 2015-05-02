using System;
using System.Collections.Generic;
using System.IO;
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

        public HelpCommand(TextWriter writer)
            : base(writer)
        {
        }

        public override void Execute()
        {
            foreach (var command in commandsList.Value)
            {
                Writer.WriteLine(command.Name);
            }
        }
    }
}
