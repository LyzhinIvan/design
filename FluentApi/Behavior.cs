using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentTask.Commands;

namespace FluentTask
{
    public class Behavior
    {
        private LinkedList<ICommand> commands = new LinkedList<ICommand>(); 

        /// <summary>Выводит переданную строку на консоль</summary>
        public Behavior Say(string phrase)
        {
            commands.AddLast(new SayCommand(phrase));
            return this;
        }

        /// <summary>Выполняет действие, пока пользователь не нажмет клавишу</summary>
        public Behavior UntilKeyPressed(Func<Behavior, Behavior> func)
        {
            commands.AddLast(new UntilCommand(func));
            return this;
        }

        /// <summary>Выводит сообщение о высоте прыжка</summary>
        public Behavior Jump(JumpHeight height)
        {
            commands.AddLast(new JumpCommand(height));
            return this;
        }

        /// <summary>Приостанавливает выполнение на заданное время</summary>
        public Behavior Delay(TimeSpan timeSpan)
        {
            commands.AddLast(new DelayCommand(timeSpan));
            return this;
        }

        /// <summary>Выполняет последовательность команд</summary>
        public void Execute()
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }
    }
}
