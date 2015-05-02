using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PerfLogger
{
    public static class PerfLogger
    {
        public class StopWatcher : IDisposable
        {
            private Action<long> actionOnDispose;
            private Stopwatch stopwatch;

            public StopWatcher(Action<long> actionOnDispose)
            {
                this.actionOnDispose = actionOnDispose;
                stopwatch = new Stopwatch();
                stopwatch.Start();
            }

            public void Dispose()
            {
                stopwatch.Stop();
                actionOnDispose(stopwatch.ElapsedMilliseconds);
            }  
        }

        public static IDisposable Measure(Action<long> actionOnDispose)
        {
            return new StopWatcher(actionOnDispose);
        }
    }


}
