namespace RecyclingStation
{
    using WasteDisposal;
    using WasteDisposal.Model;
    using WasteDisposal.Interfaces;
    using WasteDisposal.Core.Factories;
    using WasteDisposal.Core;
    using WasteDisposal.IO;

    public class RecyclingStationMain
    {
        private static void Main()
        {
            IOutputWriter outputWriter = new ConsoleWriter();
            IInputReader inputReader = new ConsoleReader();
            IRepository repo = new Repository();
            IWasteFactory wasteFactory = new WasteFactory();
            StrategyHolder strategies = new StrategyHolder();
            IGarbageProcessor processor = new GarbageProcessor(strategies);
            ICommandInterpreter commandInterpreter = new CommandInterpreter(repo, wasteFactory, processor);

            IRunable engine = new Engine(commandInterpreter, inputReader, outputWriter);
            engine.Run();
        }
    }
}
