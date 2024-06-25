using AdminBuilder.Model;
using AdminBuilder.Service.Connection;
using AdminBuilder.Service.EventModelDTO;
using AdminBuilder.Utils.ControlEvent;
using DataEvent.Utils.ControlEvent;
using Newtonsoft.Json;
using Sunny.UI;
using System.Windows.Forms;

namespace AdminBuilder.Views.Main
{
    public partial class ConnectionPage : UIPage, IEventListener
    {
        public TDataView<ConnectionModelInfo> DataView = new TDataView<ConnectionModelInfo>();
        public readonly IConnectionService connectionService;
        public ConnectionPage(IConnectionService connectionService)
        {
            this.connectionService = connectionService;
            this.DataView.Dock = DockStyle.Fill;
            InitializeComponent();
            InitView();
        }

        public void InitView()
        {
            DataView.EditFunc += connectionService.GetAllConnection;
            DataView.SetUpdate(connectionService.UpdateConnection);
            DataView.SetRemove(connectionService.RemoveConnection);
            DataView.InitForm(connectionService.GetAllConnection(1));
            this.Controls.Add(DataView);
        }

        public void HandleEvent(string eventType, DataRefreshEventArgs args)
        {
            switch (eventType)
            {
                case nameof(DataViewEventArgs):
                    HandleViewFresh(args);
                    break;
            }
        }

        private void HandleViewFresh(DataRefreshEventArgs args)
        {
            var data = JsonConvert.DeserializeObject<DataViewEventArgs>(args.Data);
            if (data.FreshType.Equals(AppConstants.DataBaseKey))
            {
                DataView.InitForm(connectionService.GetAllConnection(DataView.currentlyPagNum));
            }
        }
    }
}
