using AdminBuilder.Utils;
using AdminBuilder.Utils.AttributeUtils;
using AdminBuilder.Utils.ControlEvent;
using AdminBuilder.Utils.DataBaseConfig;
using AdminBuilder.Utils.FactoryForm;
using DataEvent.Utils.ControlEvent;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AdminBuilder.Views.Main
{
    public partial class TDataView<T> : UserControl
    {
        private Func<T,bool> RemoveFunc;
        private Func<T,bool> AddFunc;
        private Func<T,bool> UpdateFunc;
        public Func<int,List<T>> EditFunc;

        public List<T> CurrentlySelect = new List<T>();

        public int currentlyPagNum = 1;
        public bool IsRemove = false;
        public bool IsUpdate = false;
        public bool IsAdd = false;
        public T currentlyData { get; set; }

        public TDataView()
        {
            InitializeComponent();
        }

        public void SetRemove(Func<T,bool> func)
        {
            this.IsRemove = true;
            this.RemoveFunc += func;
        }

        public void SetAdd(Func<T,bool> func)
        {
            this.IsAdd = true;
            this.AddFunc += func;
        }

        public void SetUpdate(Func<T, bool> UpdateFunc)
        {
            this.IsUpdate = true;
            this.UpdateFunc += UpdateFunc;
        }


        public void InitForm(List<T> dates)
        {
            DataView.ClearAll();
            var attributes = ModelAttributeUtil.GetModelAttribute<T>();
            DataView.AddCheckBoxColumn("选择","select");
            attributes.ForEach(a =>
            {
                DataView.AddColumn(a.Key.DisplayName, a.Key.PropertyName);
            });

            //如果有删除更新
            if (IsAdd)
            {
                DataView.AddButtonColumn("添加", "button");
            }
            if (IsRemove)
            {
                DataView.AddButtonColumn("删除", "button");
            }
            if (IsUpdate)
            {
                DataView.AddButtonColumn("修改", "button");
            }

            Type type = typeof(T);
            var pros = type.GetProperties();    
            foreach (var data in dates)
            {
                //获取属性值
                List<object> list = new List<object>{false};
                foreach (var property in pros)
                {
                    list.Add(property.GetValue(data));
                }
                if(IsAdd) { list.Add("  添加  "); }
                if (IsRemove) { list.Add("  删除  "); }
                if (IsUpdate) { list.Add("  修改  "); }
                DataView.AddRow(list.ToArray());
            }
            DataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void DataViewPagination_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            if(EditFunc != null)
            {
                InitForm(EditFunc(pageIndex));
                currentlyPagNum = pageIndex;
            }
        }

        private void DataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataView.CurrentCell.Value == null)
            {
                return;
            }
            ChickViewButton(RemoveFunc, UpdateFunc,AddFunc);
        }

        private void ChickViewButton(Func<T,bool> delAction, Func<T, bool> updateAction, Func<T, bool> addFunc)
        {
            var index = (int)DataView.Rows[DataView.CurrentCell.RowIndex].Cells[1].Value;
            if (DataView.CurrentCell.ColumnIndex == 0)
            {
                // 获取该控件是否选中
                bool isChecked = (bool)DataView.CurrentCell.Value;
                DataView.CurrentCell.Value = !isChecked;
                if (isChecked)
                {
                    CurrentlySelect.Remove(GetCurrentlyObj());
                }
                else
                {
                    CurrentlySelect.Add(GetCurrentlyObj());
                }
            }
            else if (DataView.CurrentCell.Value.ToString().Trim() == "添加" &&
                addFunc != null)
            {
                var form = FormControlFactory.CreateDataForm<T>();
                form.SaveAction += AddFunc;
                form.ShowDialog();
                InitForm(EditFunc(currentlyPagNum));
            }
            else if (DataView.CurrentCell.Value.ToString().Trim() == "修改"&&
                updateAction != null)
            {
                currentlyData = GetCurrentlyObj();
                var form = FormControlFactory.CreateDataForm<T>();
                form.SetData(currentlyData);
                form.UpdateAction += UpdateFunc;
                form.ShowDialog();
                InitForm(EditFunc(currentlyPagNum));
            }
            else if (DataView.CurrentCell.Value.ToString().Trim() != "删除" && DataView.CurrentCell.Value.ToString().Trim() != "修改")
            {
                currentlyData = GetCurrentlyObj();
                InitForm(EditFunc(currentlyPagNum));
            }
            else if (DataView.CurrentCell.Value.ToString().Trim() == "删除" &&
            delAction != null)
            {
                currentlyData = GetCurrentlyObj();
                bool result =  RemoveFunc(currentlyData);
                if (!result)
                {
                    UIMessageTip.Show("删除失败，请重试");
                }
                UIMessageTip.Show("删除成功");
                InitForm(EditFunc(currentlyPagNum));
            }

        }

        private T GetCurrentlyObj()
        {
            var index = DataView.Rows[DataView.CurrentCell.RowIndex].Cells;
            var properties = typeof(T).GetProperties();
            T FormKey = (T)Activator.CreateInstance(typeof(T));
            for (int i = 0; i < properties.Length + 1; i++)
            {
                if(i < 1)
                {
                    continue;
                }
                properties[i-1].SetValue(FormKey, index[i].Value);
            }
            return FormKey;
        }

        private void TDataView_SizeChanged(object sender, EventArgs e)
        {
           this.DataView.Height = Parent.Height - this.DataViewPagination .Height - 10;
        }

        private void DataViewPagination_Click(object sender, EventArgs e)
        {

        }
    }
}
