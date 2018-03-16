namespace RecyclingStation.WasteDisposal.Model.Garbage
{
    using Attributes;
    using Enums;

    [StorableGarbageDisposable]
    public class StorableGarbage : Waste
    {
        private const WasteType garbageType = WasteType.Storable;

        public StorableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg, garbageType)
        {
        }
    }
}
