namespace RecyclingStation.WasteDisposal.Interfaces
{
    using System;

    public interface IGarbageProcessor
    {
        IStrategyHolder StrategyHolder { get;}

        IProcessingData ProcessWaste(IWaste garbage);
    }
}
