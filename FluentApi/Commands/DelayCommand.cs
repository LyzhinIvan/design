using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentTask.Commands
{
    public class DelayCommand : ICommand
    {
        private TimeSpan delayTime;

        public DelayCommand(TimeSpan delayTime)
        {
            this.delayTime = delayTime;
        }

        public void Execute()
        {
            Console.WriteLine("Ждем {0} мс", delayTime.TotalMilliseconds);
            Thread.Sleep(delayTime);
        }
    }
}
