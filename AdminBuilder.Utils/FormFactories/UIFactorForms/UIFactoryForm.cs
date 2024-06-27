using AdminBuilder.Utils.AttributeUtils;
using AdminBuilder.Utils.FormFactories.UIFactorForms;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AdminBuilder.Utils.FactoryForm
{
    public partial class UIFactoryForm<T>: UIForm 
    {
        public bool isUpdate = false;
        public T FormKey { get; set; } = default;
        public Func<T,bool> SaveAction { get; set; }
        public Func<T,bool> UpdateAction { get; set; }
        public UIFactoryForm()
        {
            InitializeComponent();
            this.AutoSize = true;
        }

        public void SetData(T FormKey)
        {
            //根据FormKey反射获取数据
            var attributes = ModelAttributeUtil.GetModelAttribute<T>();
            var properties = typeof(T).GetProperties();
            Dictionary<ModelAttribute, PropertyInfo> values = new Dictionary<ModelAttribute, PropertyInfo>();
            for (int i = 0; i < properties.Length; i++)
            {
                values.Add(attributes.Keys.First(t => t.PropertyName == properties[i].Name), properties[i]);
            }
            foreach (var property in values)
            {
                var control = Controls.Find(property.Key.DisplayName, true).First();
                if (control != null)
                {
                    if (control is UIIntegerUpDown numericUp)
                    {
                        numericUp.Value = (int)property.Value.GetValue(FormKey);
                    }
                    else if (control is UIDoubleUpDown doubleUpDown)
                    {
                        doubleUpDown.Value = (double)property.Value.GetValue(FormKey);
                    }
                    else if (control is UITextBox textBox)
                    {
                        textBox.Text = property.Value.GetValue(FormKey).ToString();
                    }
                    else if (control is UIComboBox comboBox)
                    {
                        comboBox.SelectedItem = property.Value.GetValue(FormKey).ToString();
                    }
                    else if (control is UIDatetimePicker datetimePicker)
                    {
                        datetimePicker.Value = (DateTime)property.Value.GetValue(FormKey);
                    }
                    else if(control is SelectFileButton selectFileButton)
                    {
                        if (property.Value.ToString().IsNullOrEmpty())
                        {
                            selectFileButton.CurrentlyFileName = property.Value.ToString();
                        }
                    }
                }
                if (property.Value.PropertyType == typeof(bool))
                {
                    bool result = (bool)property.Value.GetValue(FormKey);
                    object boolControl;
                    if (result)
                    {
                        boolControl = Controls.Find(property.Key.DisplayName + "yes", true).First();
                    }
                    else
                    {
                        boolControl = Controls.Find(property.Key.DisplayName + "no", true).First();
                    }
                    if (boolControl != null && boolControl is UIRadioButton radioButton)
                    {
                        radioButton.Checked = true;
                    }
                }
            }
            this.FormKey = FormKey;
            isUpdate = true;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void uiButton1_Click(object sender, EventArgs e)
        {
            //根据FormKey反射获取数据
            var attributes = ModelAttributeUtil.GetModelAttribute<T>();
            var properties = typeof(T).GetProperties();
            T FormKey = (T)Activator.CreateInstance(typeof(T));
            Dictionary<ModelAttribute,PropertyInfo> values = new Dictionary<ModelAttribute,PropertyInfo>();
            for (int i = 0 ; i < properties.Length; i++)
            {
                values.Add(attributes.Keys.First( t => t.PropertyName == properties[i].Name), properties[i]);
            }
            foreach (var property in values)
            {
                var control = Controls.Find(property.Key.DisplayName,true).First();
                if (!property.Key.AllowUpdate && isUpdate)
                {
                    property.Value.SetValue(FormKey, property.Value.GetValue(this.FormKey));
                }
                if (control != null)
                {
                    if(control is UIIntegerUpDown numericUp)
                    {
                        property.Value.SetValue(FormKey, numericUp.Value);
                    }
                    else if(control is UIDoubleUpDown doubleUpDown)
                    {
                        property.Value.SetValue(FormKey, doubleUpDown.Value);
                    }
                    else if (control is UITextBox textBox)
                    {
                        property.Value.SetValue(FormKey, textBox.Text);
                    }
                    else if (control is UIComboBox comboBox)
                    {
                        if (comboBox.Items.Count < 1 || comboBox.SelectedItem == null)
                        {
                            UIMessageTip.ShowError(property.Key.DisplayName + "未输入！");
                        }
                        else
                        {
                            property.Value.SetValue(FormKey, comboBox.SelectedItem.ToString());
                        }
                    }
                    else if(control is UIRadioButton radioButton)
                    {
                        property.Value.SetValue(FormKey, radioButton.Checked);
                    }
                    else if(control is UIDatetimePicker datetimePicker)
                    {
                        property.Value.SetValue(FormKey, datetimePicker.Value);
                    }
                    else if(control is SelectFileButton selectFile)
                    {
                        property.Value.SetValue(FormKey, selectFile.CurrentlyFileName);
                    }
                }
            }
            if (SaveAction != null && !isUpdate)
            {
                bool result = SaveAction(FormKey);
                if (result)
                {
                    UIMessageTip.Show("创建成功");
                }
                else
                {
                    UIMessageTip.ShowError("创建失败");
                }
            }
            if (UpdateAction != null && isUpdate)
            {
                bool result = UpdateAction(FormKey);
                if (result)
                {
                    UIMessageTip.Show("修改成功");
                }
                else
                {
                    UIMessageTip.ShowError("修改失败");
                }
            }
            Close();
        }
    }
}
