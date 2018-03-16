namespace RecyclingStationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RecyclingStation.WasteDisposal.Interfaces;
    using RecyclingStation.WasteDisposal.Model.DisposalStrategies;
    using RecyclingStation.WasteDisposal.Model.Garbage;
    using RecyclingStation.WasteDisposal;

    [TestClass]
    public class GarbageProcessorTests
    {
        private IGarbageProcessor processor;
        private IWaste waste;

		[TestInitialize]
		public void Initialize()
        {
            this.waste = new BurnableGarbage("Paper", 58, 10);
            this.processor = new GarbageProcessor(MyMock.GetMockedStratagyHolder());
        }

        //double capitalBalance = 0;
        //double energyBalance = (garbage.TotalGarbageVolume * EnergyProdusedFactor / 100) - (garbage.TotalGarbageVolume * EnergyUsedFactor / 100);

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]

		public void ProcessWaste_WithNullWaste_ShoudThrowArgumentNullException()
        {
            this.processor.ProcessWaste(null);
        }

        [TestMethod]
        public void ProcessWaste_WithVallidWaste_ShoudReturnCorrectEnergyAndCapitalBalance()
        {
            IProcessingData result = this.processor.ProcessWaste(this.waste);

            double expectedEnergyBalance = 464.0;
            double capitalEnergyBalance = 0.0;

            Assert.AreEqual(expectedEnergyBalance, result.EnergyBalance, "Energy Balance not calculated correctly");
            Assert.AreEqual(capitalEnergyBalance, result.CapitalBalance, "CapitalBalance not calculated correctly");

        }

    }
}
