using AdminBuilder.Utils;
using AdminBuilder.Utils.ControlEvent;
using AdminBuilder.Utils.DataBaseConfig;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Drawing;

namespace AdminBuilder.Views
{
    public partial class CreateDatabasePage : UIForm
    {
        public Func<string,string, string, bool> CreateDatabase; 
        public Func<string, string, bool> TestClientIsOneBase;

        public CreateDatabasePage()
        {
            InitializeComponent();
        }
        //测试连接
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (DbTypeBox.SelectedItem == null)
            {
                UIMessageTip.ShowError("未选择数据库");
                return;
            }
            else
            {
                bool result = TestClientIsOneBase(DbTypeBox.SelectedItem.ToString(), ConnectionText.Text);
                if (result)
                {
                    testResult.Text = "成功";
                    testResult.ForeColor = Color.Green;
                }
                else
                {
                    testResult.Text = "失败";
                    testResult.ForeColor = Color.Red;
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (DbTypeBox.SelectedItem == null)
            {
                UIMessageTip.ShowError("未选择数据库");
                return;
            }
            if (ConnectionName.Text.IsNullOrEmpty())
            {
                UIMessageTip.ShowError("未添加数据库名");
                return;
            }
            //测试连接是否是数据库
            if(!TestClientIsOneBase(DbTypeBox.SelectedItem.ToString(), ConnectionText.Text))
            {
                UIMessageTip.ShowError("数据库连接字符串错误或不为单数据库字符串");
                return;
            }
            CreateDatabase(ConnectionName.Text, ConnectionText.Text, DbTypeBox.SelectedItem.ToString());
            UIMessageTip.Show("成功创建连接");
            Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
