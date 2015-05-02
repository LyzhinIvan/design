using System;
using System.IO;
using System.Linq;

namespace DIContainer
{
    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(TextWriter writer)
        {
            Name = GetType().Name.Split(new [] { ".", "Command" }, StringSplitOptions.RemoveEmptyEntries).Last();
            Writer = writer;
        }

        public string Name { get; private set; }
        public TextWriter Writer { get; protected set; }
        public abstract void Execute();
    }

    public interface ICommand
    {
        string Name { get; }
        void Execute();
    }
}