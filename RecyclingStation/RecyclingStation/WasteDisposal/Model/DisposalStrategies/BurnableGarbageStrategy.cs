namespace RecyclingStation.WasteDisposal.Model.DisposalStrategies
{
    using Interfaces;

    public class BurnableGarbageStrategy : GarbageDisposalStrategy
    {
        private const int EnergyProdusedFactor = 100;
        private const int EnergyUsedFactor = 20;

        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double capitalBalance = 0;
            double energyBalance = (garbage.TotalGarbageVolume * EnergyProdusedFactor / 100) - (garbage.TotalGarbageVolume * EnergyUsedFactor / 100);

            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}
