namespace RecyclingStation.WasteDisposal.Core
{
    using Attributes;
    using System;
    using Interfaces;
    using System.Reflection;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandsNamespacePath = "RecyclingStation.WasteDisposal.Core.Commands.";

        private IRepository repo;
        private IWasteFactory wasteFactory;
        private IGarbageProcessor processor;

        public CommandInterpreter(IRepository repo, IWasteFactory wasteFactory, IGarbageProcessor processor)
        {
            this.repo = repo;
            this.wasteFactory = wasteFactory;
            this.processor = processor;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string commandFullName = CommandsNamespacePath + commandName + "Command";

            object[] param = new object[] { data };

            Type commandType = Type.GetType(commandFullName);
            IExecutable command = null;

            try
            {
                command = (IExecutable)Activator.CreateInstance(commandType, param);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            command = this.InjectDependencies(command);
            return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            FieldInfo[] commandFields = command.GetType().
                GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo[] interpretorFields = typeof(CommandInterpreter).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in commandFields)
            {
                var fieldAtr = field.GetCustomAttribute(typeof(InjectAttribute));

                if (fieldAtr != null && interpretorFields.Any(f => f.FieldType == field.FieldType))
                {
                    field.SetValue(command, interpretorFields.First(f => f.FieldType == field.FieldType).GetValue(this));
                }
            }
            return command;
        }
    }
}
