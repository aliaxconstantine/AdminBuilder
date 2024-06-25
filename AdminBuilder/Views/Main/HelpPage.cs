using Sunny.UI;
using System;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;


namespace AdminBuilder.Views.Main
{
    public partial class HelpPage : UIPage
    {
        public HelpPage()
        {
            InitializeComponent();
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                uiComboBox1.Items.Add(family.Name);
            }
            uiComboBox1.SelectedItem = UIStyles.GlobalFontName;
            uiIntegerUpDown1.Value = UIStyles.GlobalFontScale;
            uiLabel1.AutoSize = true;
            uiLabel2.AutoSize = true;

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            UIForm uIForm = new UIForm();
            uIForm.Text = "模板窗口";
            UIRichTextBox uIRichTextBox = new UIRichTextBox();
            uIRichTextBox.Visible = true;
            uIRichTextBox.Text = "public class [表名类]Service {\r\n​    \t%public [表名类]  getBy[属性名称] ([属性类型]  [属性名称]){}%\r\n​\tpublic bool delete[表名类] ([表名类] [表名]){}\r\n​\tpublic bool Insert[表名类] ([表名类] [表名]){}\r\n​\tpublic bool update[表名类] ([表名类] [表名]){}\r\n\r\n}\r\n\r\n";
            uIForm.Controls.Add(uIRichTextBox);
            uIRichTextBox.Dock = DockStyle.Fill;
            uIForm.Show();
        }


        private void uiButton3_Click_1(object sender, EventArgs e)
        {
            UIStyles.GlobalFontName = uiComboBox1.Text;
            UIStyles.SetDPIScale();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            UIStyles.GlobalFontScale = uiIntegerUpDown1.Value;
            UIStyles.SetDPIScale();
        }
    }
}
