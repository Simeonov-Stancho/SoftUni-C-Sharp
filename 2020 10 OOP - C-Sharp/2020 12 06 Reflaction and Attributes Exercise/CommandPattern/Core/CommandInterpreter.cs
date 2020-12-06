using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public CommandInterpreter()
        {

        }
         
        public string Read(string args)
        {
            string[] inputArgs = args
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();

            string commandName = inputArgs[0] + COMMAND_POSTFIX;
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly
                    .GetTypes()
                    .FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
