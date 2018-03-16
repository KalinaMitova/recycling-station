namespace RecyclingStation.WasteDisposal.Core
{
    using System;
    using Interfaces;
    using IO;

    public class Engine : IRunable
    {
        private ICommandInterpreter commandInterpretor;
        private IInputReader inputReader;
        private IOutputWriter outputWriter;

        public Engine(ICommandInterpreter commandInterpretor, IInputReader inputReader, IOutputWriter outputWriter)
        {
            this.commandInterpretor = commandInterpretor;

            this.inputReader = inputReader;
            this.outputWriter = outputWriter;
        }

        public void Run()
        {
            while (true)
            {
                string[] data = this.inputReader.ReadLine().Split(new[] { '|', ' '}, StringSplitOptions.RemoveEmptyEntries);
                string commandName = data[0];

                try
                {
                    IExecutable command = this.commandInterpretor.InterpretCommand(data, commandName);
                    string result = command.Execute();
                    this.outputWriter.WriteMessageOnNewLine(result);
                }
                catch (Exception e)
                {
                    this.outputWriter.WriteMessageOnNewLine(e.Message);
                }
            }
        }
    }
}
