namespace RecyclingStation.WasteDisposal.Model
{
    using System.Collections.Generic;
    using Interfaces;
    using System.Linq;

    public class Repository : IRepository
    {
        public double TotalEnergyBalance { get; private set; }

        public double TotalCapitalBalance { get; private set; }

        public void CalculateBalance(IProcessingData data)
        {
            this.TotalEnergyBalance += data.EnergyBalance;
            this.TotalCapitalBalance += data.CapitalBalance;
        }
      
        public override string ToString()
        {
            return $"Energy: {this.TotalEnergyBalance:F2} Capital: {this.TotalCapitalBalance:F2}";
        }

    }
}
