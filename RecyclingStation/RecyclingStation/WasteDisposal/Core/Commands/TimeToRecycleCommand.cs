using System;

namespace RecyclingStation.WasteDisposal.Core.Commands
{
    public class TimeToRecycleCommand : Command
    {
        public TimeToRecycleCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
