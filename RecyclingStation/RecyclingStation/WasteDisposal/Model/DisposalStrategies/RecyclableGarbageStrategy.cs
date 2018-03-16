namespace RecyclingStation.WasteDisposal.Model.DisposalStrategies
{
    using Interfaces;

    public class RecyclableGarbageStrategy : GarbageDisposalStrategy
    {
        private const int EnergyUsedFactor = 50;
        private const int CapitalEarnedFactor = 400;

        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double energyBalance = -garbage.TotalGarbageVolume * EnergyUsedFactor / 100;
            double capitalBalance = CapitalEarnedFactor * garbage.Weight;

            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}
