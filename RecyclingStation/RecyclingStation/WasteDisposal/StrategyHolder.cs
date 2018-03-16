namespace RecyclingStation.WasteDisposal
{
    using Attributes;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Model.DisposalStrategies;

    public class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        }

        public IReadOnlyDictionary<Type, IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get { return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies; }
        }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if (disposableAttribute == null || strategy == null)
            {
                throw new ArgumentNullException();
            }

            if (this.GetDisposalStrategies.ContainsKey(disposableAttribute))
            {
                return false;
            }

            this.strategies.Add(disposableAttribute, strategy);
            return true;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if (disposableAttribute == null )
            {
                throw new ArgumentNullException();
            }

            if (this.GetDisposalStrategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Remove(disposableAttribute);

                return true;
            }

            return false;
            
        }      
    }
}
