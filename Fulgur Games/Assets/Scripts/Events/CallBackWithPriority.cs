namespace CustomEventBus
{
    public class CallBackWithPriority
    {
        /// <summary>
        /// then more prioritet then faster event play
        /// </summary>
        public readonly object Callback;
        public readonly int Priority;

        public CallBackWithPriority(object callback, int priority)
        {
            Callback = callback;
            Priority = priority;
        }
    }
}

