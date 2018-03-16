namespace RecyclingStation.WasteDisposal.Interfaces
{
    public interface IWaste
    {
        string Name { get; }
       
        double VolumePerKg { get; }

        double Weight { get; }

        double TotalGarbageVolume { get; }
    }
}
