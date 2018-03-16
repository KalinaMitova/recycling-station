namespace RecyclingStationTests
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Model.DisposalStrategies;
    using System.Linq;
    using System;

    [TestClass]
    public class StrategyHolderTests
    {
        private StrategyHolder holder;

        [TestInitialize]
        public void TestConstructor_CreateEmptyDictionary()
        {
            this.holder = new StrategyHolder();

            Assert.AreEqual(0, this.holder.GetDisposalStrategies.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStrategy_WithNullAttribute_ThrowExeption()
        {
            this.holder.AddStrategy(null, new StorableGarbageStrategy());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStrategy_WithNullType_ThrowExeption()
        {
            this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), null);
        }

        [TestMethod]
        public void AddStrategy_WithValidParameters_ShoudIncreaseCountAndReturnTrue()
        {
           bool isAddStrategy =  this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());

            Assert.AreEqual(1, this.holder.GetDisposalStrategies.Count);
        }

        [TestMethod]
        public void AddStrategy_WithValidParameters_ShoudReturnTrue()
        {
            bool isAddStrategy = this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());

            Assert.IsTrue(isAddStrategy);
        }

        [TestMethod]
        public void AddStrategy_WithExistingKey_ShoudCountNotChangeAndReturnFalse()
        {
            this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());
            this.holder.AddStrategy(typeof(BurnableGarbageDisposableAttribute), new BurnableGarbageStrategy());

            bool isAddStrategy = this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());

            Assert.AreEqual(2, this.holder.GetDisposalStrategies.Count);
        }

        [TestMethod]
        public void AddStrategy_WithExistingKey_ShoudReturnFalse()
        {
            this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());
            this.holder.AddStrategy(typeof(BurnableGarbageDisposableAttribute), new BurnableGarbageStrategy());

            bool isAddStrategy = this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());

            Assert.IsFalse(isAddStrategy);
        }

        [TestMethod]
        public void RemoveStrategy_WithValidExistingKey_ShoudReturnTrue()
        {
            this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());
            this.holder.AddStrategy(typeof(BurnableGarbageDisposableAttribute), new BurnableGarbageStrategy());
            bool isRemovedStrategy = this.holder.RemoveStrategy(typeof(StorableGarbageDisposableAttribute));

            Assert.IsTrue(isRemovedStrategy);
        }

        [TestMethod]
        public void RemoveStrategy_WithValidExistingKey_ShoudIncreasedCount()
        {
            this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());
            this.holder.AddStrategy(typeof(BurnableGarbageDisposableAttribute), new BurnableGarbageStrategy());
            bool isRemovedStrategy = this.holder.RemoveStrategy(typeof(StorableGarbageDisposableAttribute));

            Assert.AreEqual(1, this.holder.GetDisposalStrategies.Count);
        }

        [TestMethod]
        public void RemoveStrategy_WithUnexistingKey_ReturnFalse()
        {
            this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());
            this.holder.AddStrategy(typeof(BurnableGarbageDisposableAttribute), new BurnableGarbageStrategy());

            bool isRemovedStrategy = this.holder.RemoveStrategy(typeof(RecyclableGarbageDisposableAttribute));

            Assert.IsFalse(isRemovedStrategy);
        }

        [TestMethod]
        public void RemoveStrategy_WithUnexistingKey_ShoudNotChangeCount()
        {
            this.holder.AddStrategy(typeof(StorableGarbageDisposableAttribute), new StorableGarbageStrategy());
            this.holder.AddStrategy(typeof(BurnableGarbageDisposableAttribute), new BurnableGarbageStrategy());

            bool isRemovedStrategy = this.holder.RemoveStrategy(typeof(RecyclableGarbageDisposableAttribute));

            Assert.AreEqual(2, this.holder.GetDisposalStrategies.Count);
        }
    }
}
