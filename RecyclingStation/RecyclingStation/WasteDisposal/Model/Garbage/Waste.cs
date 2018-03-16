namespace RecyclingStation.WasteDisposal.Model.Garbage
{
    using Enums;
    using Interfaces;
    using System;
    using System.Linq;

    public abstract class Waste : IWaste
    {
        private string name;
        private double volumePerKg;
        private double weight;
        private WasteType type;

        //ProcessGarbage {name}|{weight}|{volumePerKg}|{type}
        protected Waste (string name, double weight, double volumePerKg, WasteType type)
        {
            this.Name = name;
            this.Weight = weight;
            this.VolumePerKg = volumePerKg;
            this.type = type;
        }
            
        public string Name
        {
            get { return this.name; }

            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Any(l => !char.IsLetterOrDigit(l)))
                {
                    throw new ArgumentException($"{nameof(Name)} must be valid non-empty string consisting of only alphanumerical characters!");
                }

                this.name = value;
            }
        }

        public double VolumePerKg
        {
            get { return this.volumePerKg; }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(VolumePerKg)} can not be zero!");
                }
                this.volumePerKg = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Weight)} can not be zero!");
                }
                this.weight = value;
            }
        }

        public double TotalGarbageVolume => (this.Weight * this.VolumePerKg);
    }
}
