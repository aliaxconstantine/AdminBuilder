using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.EventModelDTO
{
    /// <summary>
    /// 修改全局字体参数
    /// </summary>
    public class ControlFontEventArgs
    {
        public string Name { get; set; }

        public Color FontColor { get; set; } = Color.White;
        public string FontStyle { get; set; } = "宋体";
        public int FontNum { get; set; } = 10;
    }
}
