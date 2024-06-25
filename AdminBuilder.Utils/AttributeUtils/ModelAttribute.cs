using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Utils.AttributeUtils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ModelAttribute:Attribute
    {
        public string DisplayName { get; set; }
        public string PropertyName { get; set; }
        public bool IsComboBox { get; set; }
        public bool AllowUpdate { get; set; } = true;
        public string[] Options { get; set; }  = new string[1];
        public string Description { get; set; } = string.Empty;
        public bool IsFile { get; set; } = false;
        public ModelAttribute(string name, string property , bool isUpdate = true ,bool isFile = false) 
        {
            this.DisplayName = name;
            this.PropertyName = property;
            this.AllowUpdate = isUpdate;
            this.IsFile = isFile;
        }


        public ModelAttribute(string name, string property, bool isComboBox, string[] strings)
            : this(name,property)
        {
            this.Options = strings;
            this.IsComboBox = isComboBox;
        }

        public ModelAttribute(string name, string property,  bool isComboBox, string[] strings, string desc)
            : this(name, property, isComboBox, strings)
        {
            this.Description = desc;
        }
    }
}
