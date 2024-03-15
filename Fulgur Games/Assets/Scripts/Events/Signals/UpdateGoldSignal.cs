namespace CustomEventBus.Signals
{
    /// <summary>
    /// Signal about changes gold resources
    /// </summary>
    public class UpdateGoldSignal
    {
        public readonly int GoldCount;
        public UpdateGoldSignal(int goldCount)
        {
            GoldCount = goldCount;
        }
    }
}
