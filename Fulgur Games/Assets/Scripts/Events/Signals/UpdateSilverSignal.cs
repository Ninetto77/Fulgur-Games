namespace CustomEventBus.Signals
{
    /// <summary>
    /// Signal about changes silver resources
    /// </summary>
    public class UpdateSilverSignal
    {
        public readonly int SilverCount;
        public UpdateSilverSignal(int silverCount)
        {
            SilverCount = silverCount;
        }
    }
}