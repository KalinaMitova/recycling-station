namespace RecyclingStation.WasteDisposal.Model
{
    using System;
    using Interfaces;

    public class ProcessingData : IProcessingData
    {
        public ProcessingData(double energyBalance, double capitalBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }

        public double CapitalBalance { get; private set; }
        public double EnergyBalance { get; private set; }

    }
}
