using DataEvent.Utils.ControlEvent;

namespace AdminBuilder.Utils.ControlEvent
{
    /// <summary>
    /// 数据刷新事件管理
    /// </summary>
    public class DataEventManager
    {
        public static DataEventManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataEventManager();
                }

                return _instance;
            }
        }

        private static DataEventManager _instance;

        private IDataEventHub _eventHub;

        public DataEventManager()
        {
            this._eventHub = new DataEventHub();
        }

        /// <summary>
        /// 添加监听事件
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="listener"></param>
        public void AddListener(string eventType, IEventListener listener)
        {
            this._eventHub.AddListener(eventType, listener);
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="args">事件参数可通过 EventArgs.CreateEventArgs 创建</param>
        public void Dispatch(string eventType, DataRefreshEventArgs args = null)
        {
            this._eventHub.Dispatch(eventType, args);
        }

        /// <summary>
        /// 移除监听事件
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="listener"></param>
        public void RemoveListener(string eventType, IEventListener listener)
        {
            this._eventHub.RemoveListener(eventType, listener);
        }
    }
}
