using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentTask.Commands
{
    public class JumpCommand : ICommand
    {
        private JumpHeight height;

        public JumpCommand(JumpHeight height)
        {
            this.height = height;
        }

        public void Execute()
        {
            if (height == JumpHeight.High)
                Console.WriteLine("HighJump");
            else if (height == JumpHeight.Low)
                Console.WriteLine("LowJump");
            else Console.WriteLine("Jump"); // Вдруг появится новый вид прыжка:)
        }
    }
}
