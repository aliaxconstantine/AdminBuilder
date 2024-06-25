using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminBuilder.Utils.FormFactories.UIFactorForms
{
    public partial class SelectFileButton : UserControl
    {
        public string CurrentlyFileName { get; set; } = string.Empty;
        public SelectFileButton()
        {
            InitializeComponent();
            this.uiButton1.Text = CurrentlyFileName;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog fileDialog = new OpenFileDialog())
            {
                if(fileDialog.ShowDialog() == DialogResult.OK)
                {
                    CurrentlyFileName = fileDialog.FileName;
                    this.uiButton1.Text = CurrentlyFileName;
                    this.uiButton1.AutoSize = true;
                    this.AutoSize = true;
                }
                else
                {
                    UIMessageTip.ShowWarning("未选择文件");
                }
            }
        }
    }
}
