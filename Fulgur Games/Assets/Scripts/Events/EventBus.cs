using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CustomEventBus
{
    public class EventBus: IService
    {
        private Dictionary<string, List<CallBackWithPriority>> _signalCallbacks = new Dictionary<string, List<CallBackWithPriority>>();

        public void Subscribe<T>(Action<T> signal, int priority = 0)
        {
            string key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
            {
                _signalCallbacks[key].Add(new CallBackWithPriority( signal,priority));
            }
            else
            {
                _signalCallbacks.Add(key, new List<CallBackWithPriority>() { new(signal, priority) });
            }

            _signalCallbacks[key] = _signalCallbacks[key].OrderByDescending(x => x.Priority).ToList();
        }

        public void Invoke<T>(T signal)
        {
            var key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
            {
                foreach (var x in _signalCallbacks[key])
                {
                    var callbackToInvoke = x.Callback as Action<T>;
                    callbackToInvoke?.Invoke(signal);
                }
            }
        }

        public void Unsubscribe<T>(Action<T> signal) 
        {
            var key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
            {
                var callbackToDelete = _signalCallbacks[key].FirstOrDefault(x => x.Callback.Equals(signal));
                if (callbackToDelete != null)
                {
                    _signalCallbacks[key].Remove(callbackToDelete);
                }
            }
            else
            {
                Debug.WriteLine("Trying to unsubscribe for not existing key! {0} ", key);
            }
        }

        /// <summary>
        /// TODO: separate IServise to get eventBus.
        /// </summary>
        /// <returns>this EventBus</returns>
        public EventBus GetEventBus() => this;
    }
}
