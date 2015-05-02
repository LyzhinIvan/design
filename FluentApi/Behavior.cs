using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentTask
{
    public class Behavior
    {
        private List<Action> commandList = new List<Action>();

        public Behavior()
        {}

        public Behavior(IEnumerable<Action> actions)
        {
            this.commandList = actions.ToList();
        }

        /// <summary>Выводит переданную строку на консоль</summary>
        public Behavior Say(string phrase)
        {
            commandList.Add(() => Console.WriteLine(phrase));
            return this;
        }

        /// <summary>Выполняет действие, пока пользователь не нажмет клавишу</summary>
        public Behavior UntilKeyPressed(Func<Behavior, Behavior> func)
        {
            commandList.Add(() =>
            {
                while (!Console.KeyAvailable)
                {
                    func(new Behavior()).Execute();
                    Thread.Sleep(500);
                }
                Console.ReadKey(true);
            }
                );
            return this;
        }

        /// <summary>Выводит сообщение о высоте прыжка</summary>
        public Behavior Jump(JumpHeight height)
        {
            commandList.Add(() =>
            {
                if (height == JumpHeight.High)
                    Console.WriteLine("HighJump");
                else if (height == JumpHeight.Low)
                    Console.WriteLine("LowJump");
                else Console.WriteLine("Jump"); // Вдруг появится новый вид прыжка:)    
            }
            );
            return this;
        }

        /// <summary>Приостанавливает выполнение на заданное время</summary>
        public Behavior Delay(TimeSpan timeSpan)
        {
            commandList.Add(() => Thread.Sleep(timeSpan));
            return this;
        }

        /// <summary>Выполняет последовательность команд</summary>
        public void Execute()
        {
            foreach (var action in commandList)
            {
                action();
            }
        }
    }
}
