namespace RecyclingStation.WasteDisposal.Core.Commands
{
    using Attributes;
    using WasteDisposal.Interfaces;
    public class StatusCommand : Command
    {
        [Inject]
        private IRepository repo;

        public StatusCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            return this.repo.ToString();
        }
    }
}
