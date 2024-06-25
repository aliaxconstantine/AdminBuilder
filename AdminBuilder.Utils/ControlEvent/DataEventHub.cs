using DataEvent.Utils.ControlEvent;
using System.Collections.Generic;

namespace AdminBuilder.Utils.ControlEvent
{
    internal class DataEventHub : IDataEventHub
    {
        private readonly Dictionary<string, List<IEventListener>> listeners = new Dictionary<string, List<IEventListener>>();
        public void AddListener(string eventType, IEventListener listener)
        {
            if (!listeners.ContainsKey(eventType))
            {
                listeners.Add(eventType, new List<IEventListener>());
                listeners[eventType].Add(listener);
            }
            else
            {
                listeners[eventType].Add(listener);
            }
        }


        public void Dispatch(string eventType, DataRefreshEventArgs args)
        {
            if (!listeners.ContainsKey(eventType))
            {
                return;
            }
            else
            {
                listeners[eventType].ForEach(l =>
                {
                    l.HandleEvent(eventType, args);
                });
            }
        }

        public void RemoveListener(string eventType, IEventListener listener)
        {
            if (!listeners.ContainsKey(eventType))
            {
                listeners.Remove(eventType);
            }
            else
            {
                listeners[eventType].Remove(listener);
            }
        }

    }
}
