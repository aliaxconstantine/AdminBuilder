using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Utils
{
    public class DataViewEventArgs
    {
        public string ViewName { get; set; } = string.Empty;
        public string DataBaseName { get; set; } = string.Empty;
        public string FreshType { get; set; } = string.Empty;
    }
}
