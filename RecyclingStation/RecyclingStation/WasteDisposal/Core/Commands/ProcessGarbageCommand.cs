namespace RecyclingStation.WasteDisposal.Core.Commands
{
    using Attributes;
    using Factories;
    using Interfaces;

    public class ProcessGarbageCommand : Command
    {
        [Inject]
        private IWasteFactory wasteFactory;

        [Inject]
        private IRepository repo;

        [Inject]
        private IGarbageProcessor processor;

        public ProcessGarbageCommand(string[] data) 
            : base(data)
        {
        }

        //{name}|{weight}|{volumePerKg}|{type}
        public override string Execute()
        {
            string name = base.Data[1];
            double weight = double.Parse(base.Data[2]);
            double volumePerKg = double.Parse(base.Data[3]);
            string type = base.Data[4];

            IWaste garbage = this.wasteFactory.CreateWaste(name, weight, volumePerKg, type);
            IProcessingData data =  this.processor.ProcessWaste(garbage);
            this.repo.CalculateBalance(data);

            return $"{(garbage.Weight):F2} kg of { garbage.Name} successfully processed!";
        }
    }
}
