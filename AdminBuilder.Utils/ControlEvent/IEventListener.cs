using AdminBuilder.Utils.ControlEvent;
namespace DataEvent.Utils.ControlEvent
{
    /// <summary>
    /// 事件监听者
    /// </summary>
    public interface IEventListener
    {
        void HandleEvent(string eventType, DataRefreshEventArgs args);
    }
}
