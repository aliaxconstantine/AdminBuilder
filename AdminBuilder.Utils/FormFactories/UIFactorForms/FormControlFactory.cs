using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using AdminBuilder.Utils.AttributeUtils;
using AdminBuilder.Utils.FactoryForm;
using AdminBuilder.Utils.FormFactories.UIFactorForms;
using Sunny.UI;
using static Azure.Core.HttpHeader;

namespace AdminBuilder.Utils
{
    public static class FormControlFactory
    {
        public static UIFactoryForm<T> CreateDataForm<T>()
        {
            UIFactoryForm<T> uIForm = new UIFactoryForm<T> ();
            FlowLayoutPanel panelAll = new FlowLayoutPanel
            {
                Location = new Point(20, 50),
                FlowDirection = FlowDirection.TopDown,
                Margin = new Padding(0,5,0,0)
            };
            uIForm.Controls.Add (panelAll);
    
            var attributes = ModelAttributeUtil.GetModelAttribute<T>();
            foreach (var attribute in attributes)
            {
                Panel panel = null;
                string attributeType = attribute.Value;

                switch (attributeType)
                {
                    case "System." + nameof(System.Int32):
                        panel = CreateNumPanel(attribute.Key.DisplayName);
                        break;

                    case "System." + nameof(System.Double):
                        panel = CreateDoublePanel(attribute.Key.DisplayName);
                        break;

                    case "System." + nameof(System.String):
                        if (attribute.Key.IsFile)
                        {
                            panel = CreateFilePanel(attribute.Key.DisplayName);
                        }

                        else if (attribute.Key.IsComboBox)
                        {
                            panel = CreateStringPanelWithComboBox(attribute.Key.DisplayName, attribute.Key.Options.ToList());
                        }
                        else
                        {
                            panel = CreateStringPanelWithTextBox(attribute.Key.DisplayName);
                        }
                        break;

                    case "System." + nameof(System.Boolean):
                        panel = CreateBoolPanel(attribute.Key.DisplayName);
                        break;

                    case "System." + nameof(System.DateTime):
                        panel = CreateStringPanelWithDateTime(attribute.Key.DisplayName);
                        break;

                    default:
                        break;
                }
                if (panel != null)
                {
                    panelAll.Controls.Add(panel);
                    panel.Visible = attribute.Key.AllowUpdate;
                }
            }

            int Height = 0;
            int padding = 7;
            foreach (Control control in panelAll.Controls)
            {
                Height += control.Height;
                control.Margin = new Padding(padding);
            }
            // 将计算出的宽度和高度设置为panelAll的大小
            panelAll.Size = new Size(500, Height+ (panelAll.Controls.Count + 1) * padding + 35);
            //改变Form的大小
            uIForm.Size = new Size(500,panelAll.Height + 150);
            uIForm.MaximizeBox = false;
            return uIForm;
        }

        private static Panel CreateFilePanel(string name)
        {
            Panel panel = new Panel
            {
                Name = name + "panel",
                AutoSize = true,
            };
            UILabel label = new UILabel
            {
                Text = name,
                AutoSize = true,
            };

            SelectFileButton textBox = new SelectFileButton
            {
                Name = name,
                Location = new Point(label.Location.X + label.Width + 15, label.Location.Y),
                Size = new Size(300, 30)
            };

            label.Location = new Point(label.Location.X, label.Location.Y + 3);
            panel.Controls.Add(label);
            panel.Controls.Add(textBox);
            panel.Size = new Size(40, 300);
            return panel;
        }

        /// <summary>
        /// 创建日期输入
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static Panel CreateStringPanelWithDateTime(string name)
        {
            Panel panel = new Panel
            {
                Name = name + "panel",
                AutoSize = true,
            };
            UILabel label = new UILabel
            {
                Text = name,
                AutoSize = true,
            };

            UIDatetimePicker textBox = new UIDatetimePicker
            {
                Name = name,
                Location = new Point(label.Location.X + label.Width + 15, label.Location.Y),
                Size = new Size(300, 30)
            };

            label.Location = new Point(label.Location.X, label.Location.Y + 3);
            panel.Controls.Add(label);
            panel.Controls.Add(textBox);
            panel.Size = new Size(40, 300);
            return panel;
        }

        /// <summary>
        /// 创建数字输入
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Panel CreateNumPanel(string name)
        {
            Panel panel = new FlowLayoutPanel
            {
                Name = name + "panel",
                AutoSize = true
            };
            UILabel label = new UILabel
            {
                Text = name,
            };

            UIIntegerUpDown numericInput = new UIIntegerUpDown
            {
                Text = name,
                Name = name,
                Location = new Point(label.Location.X + label.Width + 15,label.Location.Y )
            };
            label.Show();
            numericInput.Show();

            panel.Controls.Add(label);
            panel.Controls.Add(numericInput);
            label.Location = new Point(label.Location.X, label.Location.Y + 3);
            return panel;
        }

        /// <summary>
        /// 创建数字输入
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static FlowLayoutPanel CreateDoublePanel(string name)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Name = name + "panel",
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };
            UILabel lblNum = new UILabel
            {
                Text = name,
            };
            UIDoubleUpDown numericInput = new UIDoubleUpDown
            {
                Text = name,
                Name = name
            };
            lblNum.Show();
            numericInput.Show();

            panel.Controls.Add(lblNum);
            panel.Controls.Add(numericInput);
            panel.Size = new Size(40, 300);
            return panel;
        }
        /// <summary>
        /// 创建bool面板
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Panel CreateBoolPanel(string name)
        {
            Panel panel = new Panel
            {
                Name = name + "panel",
                AutoSize = true
            };

            Label label = new Label
            {
                Text = name,
                AutoSize = true,
            };
            panel.Controls.Add(label);

            UIRadioButton yesRadioButtonTrue = new UIRadioButton
            {
                Name = name + "yes",
                Text = "是",
                Location = new Point(label.Location.X + label.Width + 30, label.Location.Y)
            };
            UIRadioButton noRadioButtonTrue = new UIRadioButton
            {
                Name = name + "no",
                Text = "否",
                Location = new Point(label.Location.X + label.Width + yesRadioButtonTrue.Width+ 30, label.Location.Y)
            };

            panel.Controls.Add(yesRadioButtonTrue);
            panel.Controls.Add(noRadioButtonTrue);
            yesRadioButtonTrue.Checked = false; 
            noRadioButtonTrue .Checked = true;

            label.Location = new Point(label.Location.X, label.Location.Y + 3);
            panel.Size = new Size(40, 300);
            return panel;
        }


        /// <summary>
        /// 创建带下拉框的表单
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strings"></param>
        /// <returns></returns>
        private static Panel CreateStringPanelWithComboBox(string name, List<string> strings)
        {
            Panel panel = new Panel
            {
                Name = name + "panel",
                AutoSize = true,
            };

            UILabel label = new UILabel
            {
                Text = name,
                AutoSize = true,
            };


            UIComboBox comboBox = new UIComboBox
            {
                Name = name,
                Size = new Size(150, label.Height + 5),
                Location = new Point(label.Location.X + label.Width + 15,label.Location.Y)
            };

            comboBox.Items.AddRange(strings.ToArray());
            label.Location = new Point(label.Location.X, label.Location.Y + 3);
            panel.Controls.Add(label);
            panel.Controls.Add(comboBox);
            panel.Size = new Size(40, 300);
            return panel;
        }
        /// <summary>
        /// 创建字符串的表单
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Panel CreateStringPanelWithTextBox(string name)
        {

            Panel panel = new Panel
            {
                Name = name + "panel",
                AutoSize = true,
            };
            UILabel label = new UILabel
            {
                Text = name,
                AutoSize = true,
            };

            UITextBox textBox = new UITextBox
            {
                Name = name,
                Location = new Point(label.Location.X + label.Width + 15, label.Location.Y),
                Size = new Size(300, 30)
            };

            label.Location = new Point(label.Location.X, label.Location.Y + 3);
            panel.Controls.Add(label);
            panel.Controls.Add(textBox);
            panel.Size = new Size(40, 300);
            return panel;
        }


    }
}
