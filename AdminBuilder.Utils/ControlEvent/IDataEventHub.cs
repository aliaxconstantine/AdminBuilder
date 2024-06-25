using DataEvent.Utils.ControlEvent;

namespace AdminBuilder.Utils.ControlEvent
{
    public interface IDataEventHub
    {
        void AddListener(string eventType, IEventListener listener);

        void RemoveListener(string eventType, IEventListener listener);

        void Dispatch(string eventType, DataRefreshEventArgs args);
    }
}
