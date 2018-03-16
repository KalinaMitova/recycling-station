namespace RecyclingStation.WasteDisposal.Core.Factories
{
    using Interfaces;
    using System; 

    public class WasteFactory : IWasteFactory
    {
        private const string NamespacePath = "RecyclingStation.WasteDisposal.Model.Garbage.";

        //{name}|{weight}|{volumePerKg}|{type}
        public IWaste CreateWaste(string name, double weight, double volumePerKg, string type)
        {
            Type wasteType = Type.GetType(NamespacePath + type + "Garbage");
            try
            {
                IWaste waste = (IWaste)Activator.CreateInstance(wasteType, new object[] { name, weight, volumePerKg });
                return waste;
            }
            catch 
            {
                throw new OperationCanceledException("Can not create waste!");
            }
        }
    }
}
