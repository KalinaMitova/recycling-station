namespace RecyclingStation.WasteDisposal.Interfaces
{
    public interface IOutputWriter
    {
        void WriteMessageOnNewLine(string message);

        void WriteMessage(string message);
    }
}
