namespace RecyclingStation.WasteDisposal.Model.Garbage
{
    using Attributes;
    using Enums;

    [BurnableGarbageDisposable]
    public class BurnableGarbage : Waste
    {
        private const WasteType garbageType = WasteType.Burnable;

        public BurnableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg, garbageType)
        {
        }
    }
}
