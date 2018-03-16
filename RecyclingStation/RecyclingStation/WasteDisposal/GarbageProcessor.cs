namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using Attributes;
    using Interfaces;
    using Model.DisposalStrategies;
    using System.Reflection;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
            this.AddStratagyHolder();
        }

        public GarbageProcessor() 
            : this(new StrategyHolder())
        {
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        private void AddStratagyHolder()
        {
            //this.StrategyHolder.AddStrategy(typeof(RecyclableGarbageDisposableAttribute), new RecyclableGarbageStrategy());
            //this.StrategyHolder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());
            //this.StrategyHolder.AddStrategy(typeof(BurnableGarbageDisposableAttribute), new BurnableGarbageStrategy());

            TypeInfo[] assemblyStrategyTypes = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(x => x.Name.EndsWith("Strategy") && !x.IsAbstract && !x.IsInterface)
                .ToArray();

            //TypeInfo[] assemblyAtrributsTypes = Assembly.GetExecutingAssembly().DefinedTypes
            //    .Where(x => x.Name.EndsWith("DisposableAttribute") && !x.IsAbstract && !x.IsInterface)
            //    .ToArray();

            TypeInfo[] assemblyAtrributsTypes = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(x => typeof(DisposableAttribute).IsAssignableFrom(x) &&
               x != typeof(DisposableAttribute) &&
               !x.IsAbstract).ToArray();

            foreach (var attr in assemblyAtrributsTypes)
            {

                //match the corresponding strategy type to the current attribute type
                // instantiate it and send it to the StrategyHolder for mapping
                string strategyName = attr.Name.Replace("DisposableAttribute", "Strategy");
                var strategy = assemblyStrategyTypes.FirstOrDefault(x => x.Name == strategyName);
                if (strategy != null)
                {
                    var stratInstance = (IGarbageDisposalStrategy)Activator.CreateInstance(strategy);
                    this.StrategyHolder.AddStrategy(attr, stratInstance);
                }
            }
        }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            if (garbage == null)
            {
                throw new ArgumentNullException();
            }

            Type type = garbage.GetType();

            DisposableAttribute disposalAttribute = (DisposableAttribute)type.GetCustomAttributes(true).
                FirstOrDefault();

            IGarbageDisposalStrategy currentStrategy;
            if (disposalAttribute == null
                || !this.StrategyHolder.GetDisposalStrategies.TryGetValue(disposalAttribute.GetType(),
                out currentStrategy))
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}
