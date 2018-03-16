﻿namespace RecyclingStation.WasteDisposal.Model.DisposalStrategies
{
    using Interfaces;

    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public abstract IProcessingData ProcessGarbage(IWaste garbage);

    }
}
