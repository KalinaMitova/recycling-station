namespace RecyclingStation.WasteDisposal.Model.DisposalStrategies
{
    using Interfaces;

    public class StorableGarbageStrategy : GarbageDisposalStrategy
    {
        private const int EnergyUsedFactor = 13;
        private const int CapitalUsiedFactor = 65;

        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double energyBalance = - garbage.TotalGarbageVolume * EnergyUsedFactor / 100;
            double capitalBalance = - CapitalUsiedFactor * garbage.TotalGarbageVolume / 100;

            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}
