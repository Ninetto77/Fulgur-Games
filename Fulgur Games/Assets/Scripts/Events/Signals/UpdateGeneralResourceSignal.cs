namespace CustomEventBus.Signals
{
    /// <summary>
    /// Signal about changes general resources
    /// </summary>
    public class UpdateGeneralResourceSignal
    {
        public readonly int GeneralCount;
        public UpdateGeneralResourceSignal(int generalCount)
        {
            GeneralCount = generalCount;
        }
    }
}