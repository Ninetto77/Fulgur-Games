namespace CustomEventBus
{
    public interface IDisposable
    {
        /// <summary>
        /// In this method you need to unsubscribe from all events of the signal bus
        /// </summary>
        public void Dispose();
    }
}
