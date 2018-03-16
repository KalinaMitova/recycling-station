namespace RecyclingStationTests
{
    using RecyclingStation.WasteDisposal.Interfaces;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Model.DisposalStrategies;
    using System.Collections.Generic;
    using System;
    using Moq;
       
    public class MyMock
    {
        private static Dictionary<Type, IGarbageDisposalStrategy> strategies;

        public static IStrategyHolder GetMockedStratagyHolder()
        {
            strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            strategies.Add(typeof(BurnableGarbageDisposableAttribute), new BurnableGarbageStrategy());
            strategies.Add(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());
            strategies.Add(typeof(RecyclableGarbageDisposableAttribute), new RecyclableGarbageStrategy());
            var mock = new Mock<IStrategyHolder>();
            mock.Setup(h => h.GetDisposalStrategies)
                .Returns(strategies);
            var holder = mock.Object;
            return holder;
        }
    }
}
