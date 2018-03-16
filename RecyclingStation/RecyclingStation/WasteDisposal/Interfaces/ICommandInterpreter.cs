namespace RecyclingStation.WasteDisposal.Interfaces
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data, string commandName);
    }
}
