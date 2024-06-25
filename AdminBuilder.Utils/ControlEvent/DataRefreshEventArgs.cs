using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Utils.ControlEvent
{
    public class DataRefreshEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Data { get; set; }
    }

}
