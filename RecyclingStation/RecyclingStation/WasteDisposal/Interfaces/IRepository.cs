namespace RecyclingStation.WasteDisposal.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository
    {
        void CalculateBalance(IProcessingData data);
    }
}
