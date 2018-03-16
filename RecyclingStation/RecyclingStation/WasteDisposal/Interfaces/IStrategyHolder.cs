namespace RecyclingStation.WasteDisposal.Interfaces
{
    using System;
    using System.Collections.Generic;
    
    public interface IStrategyHolder
    {
        IReadOnlyDictionary<Type,IGarbageDisposalStrategy> GetDisposalStrategies { get; } 
   
        bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy);
      
        bool RemoveStrategy(Type disposableAttribute);
    }
}
