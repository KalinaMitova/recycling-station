namespace RecyclingStation.WasteDisposal.Model.Garbage
{
    using Attributes;
    using Enums;

    [RecyclableGarbageDisposable]
    public class RecyclableGarbage : Waste
    {
        private const WasteType garbageType = WasteType.Recyclable;

        public RecyclableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg, garbageType)
        {
        }
    }
}
