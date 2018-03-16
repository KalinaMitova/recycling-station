namespace RecyclingStation.WasteDisposal.Core.Commands
{
    using Interfaces;

    public abstract class Command : IExecutable
    {
        public string[] Data { get; private set; }

        protected Command(string[] data)
        {
            this.Data = data;
        }

        public abstract string Execute();
    }
}
