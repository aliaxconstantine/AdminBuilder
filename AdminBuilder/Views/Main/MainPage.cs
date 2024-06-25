using AdminBuilder.Utils;
using Sunny.UI;
using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Drawing;
using AdminBuilder.Model;
using AdminBuilder.Utils.ControlEvent;
using DataEvent.Utils.ControlEvent;
using AdminBuilder.Service.View;
using System.Collections.Generic;
using AdminBuilder.Service.DataBase;
using AdminBuilder.Views.OtherForm;
using AdminBuilder.Config;
using Autofac;
using AdminBuilder.Service.EventModelDTO;
using AdminBuilder.Service.Connection;

namespace AdminBuilder.Views
{
    public partial class MainPage : UIPage, IEventListener
    {
        public readonly IViewService viewService;
        public readonly IDataBaseService dataBaseService;
        public readonly IConnectionService connectionService;
        public string CurrentlyDataBase { get; set; } = string.Empty;
        public string CurrentlyView { get; set; } = string.Empty;
        public string CurrentlyColumn { get; set; } = string.Empty;

        //判断是否显示所有的表数据 
        public bool IsView { get; set; } = false;
        //当前页数
        public int PageNum { get; set; } = 1;

        public MainPage(IViewService dataBaseService, IDataBaseService baseService, IConnectionService connectionService)
        {
            InitializeComponent();
            this.viewService = dataBaseService;
            this.dataBaseService = baseService;
            this.connectionService = connectionService;
            InitAllControls();
        }

        private void InitAllControls()
        {
            FreshDataBases();
            FreshSeleViews();
            DataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        //初始化列
        public void InitPageByColumnData(string dataBaseName, string viewName, int PageNum)
        {
            this.DataView.ClearAll();
            var currentlyColumnData = viewService.GetAllColumInfo(dataBaseName, viewName, PageNum);
            DataView.AddCheckBoxColumn("选择", "string");
            DataView.AddColumn("列名", "string");
            DataView.AddColumn("类型", "string");
            DataView.AddColumn("是否主键", "bool");
            DataView.AddColumn("是否允许为Null", "bool", 300);
            DataView.AddColumn("备注", "string", 300);
            DataView.AddButtonColumn("添加", "button", 100);
            DataView.AddButtonColumn("删除", "button", 100);
            DataView.AddButtonColumn("修改", "button", 100);
            DataView.CellContentClick -= ClickButtonByView;
            DataView.CellContentClick -= ClickButtonByColumn;
            DataView.CellContentClick += ClickButtonByColumn;
            currentlyColumnData.ForEach(t =>
            {
                DataView.AddRow(new object[] { false, t.ColumnName, t.DataType, t.isMain.ToString(), t.IsNullable.ToString(), t.Description, "  添加  ", "  删除  ", "  修改  " });
            });
            this.CurrentlyDataBase = dataBaseName;
            this.CurrentlyView = viewName;
            if (this.CurrentlyDataBase != null && currentlyColumnData.Count > 0)
            {
                this.CurrentlyColumn = currentlyColumnData[0]?.ColumnName;
            }
            this.CurrentlyColumn = null;
            this.IsView = false;

        }


        //初始化表
        public void InitPageByViewData(string dataBaseName, int PageNum)
        {
            this.DataView.ClearAll();
            var currentViewData = viewService.GetAllViews(dataBaseName, PageNum);
            DataView.AddCheckBoxColumn("选择", "string");
            DataView.AddColumn("表名", "string");
            DataView.AddColumn("表描述", "string", 300);
            DataView.AddButtonColumn("添加", "button", 100);
            DataView.AddButtonColumn("删除", "button", 100);
            DataView.AddButtonColumn("修改", "button", 100);
            DataView.CellContentClick -= ClickButtonByColumn;
            DataView.CellContentClick -= ClickButtonByView;
            DataView.CellContentClick += ClickButtonByView;
            currentViewData.ForEach(t =>
            {
                DataView.AddRow(new object[] { false, t.TableName, t.Desc, "  添加   ", "  删除  ", "  修改  " });
            });
            this.CurrentlyDataBase = dataBaseName;
            if (currentViewData != null && currentViewData.Count > 0)
            {
                this.CurrentlyView = currentViewData[0]?.TableName;
            }
            this.CurrentlyView = null;
            this.CurrentlyColumn = null;
            this.IsView = true;
        }

        public bool AddView(TableBaseInfo view)
        {
            return viewService.AddView(view, CurrentlyView);
        }

        public bool UpdateView(TableBaseInfo view)
        {
            return viewService.UpDateView(view, CurrentlyView);
        }

        public bool AddColumn(ColumnInfo column)
        {
            return viewService.AddColumn(column, CurrentlyView, CurrentlyDataBase);
        }

        public bool UpdateColumn(ColumnInfo column)
        {
            return viewService.UpDateColumn(column, CurrentlyView, CurrentlyDataBase);
        }

        private void ClickButtonByView(object sender, DataGridViewCellEventArgs e)
        {
            var name = (string)DataView.Rows[DataView.CurrentCell.RowIndex].Cells[1].Value;
            if (DataView.CurrentCell.Value == null)
            {
                return;
            }
            //点击按钮时候
            ChickViewButton(
                () => { return viewService.DelView(CurrentlyDataBase, CurrentlyView); },
                () =>
                  {
                      var form = FormControlFactory.CreateDataForm<TableBaseInfo>();
                      form.UpdateAction += UpdateView;
                      form.SetData(viewService.GetView(CurrentlyDataBase, name));
                      form.ShowDialog();
                      return true;
                  },
                () =>
                    {
                        var form = FormControlFactory.CreateDataForm<TableBaseInfo>();
                        form.SaveAction += AddView;
                        form.ShowDialog();
                        return true;
                    }
                );
            //当点击到表时
            CurrentlyView = DataView.CurrentRow.Cells[0].Value.ToString();
        }


        private void ClickButtonByColumn(object sender, DataGridViewCellEventArgs e)
        {
            var name = (string)DataView.Rows[DataView.CurrentCell.RowIndex].Cells[1].Value;
            if (DataView.CurrentCell.Value == null)
            {
                return;
            }
            //点击按钮时
            ChickViewButton(
                () => { return viewService.DelColumn(CurrentlyDataBase, CurrentlyView, CurrentlyColumn); },
                () =>
                    {
                        var form = FormControlFactory.CreateDataForm<ColumnInfo>();
                        form.UpdateAction += UpdateColumn;
                        form.SetData(viewService.GetColumnInfo(CurrentlyDataBase, CurrentlyView, name));
                        form.ShowDialog();
                        return true;
                    },
                () =>
                {
                    var form = FormControlFactory.CreateDataForm<ColumnInfo>();
                    form.SaveAction += AddColumn;
                    form.ShowDialog();
                    return true;
                }
                );
            //当点击到列时
            CurrentlyColumn = DataView.CurrentRow.Cells[0].Value.ToString();
        }

        private void ChickViewButton(Func<bool> delAction, Func<bool> updateAction, Func<bool> addAction)
        {
            if (DataView.CurrentCell.ColumnIndex == 0)
            {
                // 获取该控件是否选中
                bool isChecked = (bool)DataView.CurrentCell.Value;
                DataView.CurrentCell.Value = !isChecked;
            }
            if (DataView.CurrentCell.Value.ToString().Trim() == "添加")
            {
                bool result = addAction();
                if (!result)
                {
                    UIMessageBox.Show("添加失败");
                }
            }
            if (DataView.CurrentCell.Value.ToString().Trim() == "删除")
            {
                bool result = delAction();
                if (!result)
                {
                    UIMessageBox.Show("删除失败");
                }
            }
            if (DataView.CurrentCell.Value.ToString().Trim() == "修改")
            {
                bool result = updateAction();
                if (!result)
                {
                    UIMessageBox.Show("修改失败");
                }
            }
        }


        public void HandleEvent(string eventType, DataRefreshEventArgs args)
        {
            switch (eventType)
            {
                case nameof(DataViewEventArgs):
                    HandleViewFresh(args);
                    break;
            }
        }

        /// <summary>
        /// 更新数据事件
        /// </summary>
        /// <param name="args"></param>
        private void HandleViewFresh(DataRefreshEventArgs args)
        {
            //转换信息为json
            var data = JsonConvert.DeserializeObject<DataViewEventArgs>(args.Data);
            if (data.FreshType == AppConstants.ColumnKey)
            {
                //是否更新本数据行
                if (data.DataBaseName == CurrentlyDataBase && data.ViewName == CurrentlyView && !this.IsView)
                {
                    InitPageByColumnData(CurrentlyDataBase, data.ViewName, PageNum);
                }
            }
            else if (data.FreshType == AppConstants.ViewKey)
            {
                //更新的是当前显示的库
                if (CurrentlyDataBase.Equals(data.DataBaseName))
                {
                    //改变下拉框数据
                    FreshSeleViews();
                    if (ViewSelect.SelectedItem.ToString() == "")
                    {
                        InitPageByViewData(CurrentlyDataBase, 1);
                    }
                }
            }
            else if (data.FreshType == AppConstants.DataBaseKey)
            {
                FreshDataBases();
                FreshSeleViews();
            }
        }

        private void FreshDataBases()
        {
            DataBaseSelect.Clear();
            List<string> strings = new List<string>();
            //更新库信息
            dataBaseService.GetALllDataBaseInfo().ForEach(e =>
            {
                strings.Add(e.Name);
            });
            DataBaseSelect.DataSource = strings;
            DataBaseSelect.SelectedItem = CurrentlyDataBase;
        }

        private void FreshSeleViews()
        {
            ViewSelect.Clear();
            List<string> views = new List<string>();
            if (CurrentlyDataBase == null)
            {
                if (DataBaseSelect.SelectedItem != null)
                {
                    CurrentlyDataBase = DataBaseSelect.Items[0].ToString();
                }
                else
                {
                    throw new Exception("数据库为null");
                }
            }
            viewService.GetViewBases(CurrentlyDataBase).ForEach(t =>
            {
                views.Add(t.TableName);
            });
            ViewSelect.DataSource = views;
            ViewSelect.SelectedItem = CurrentlyView;
        }


        private void ButtonToVue_Click(object sender, EventArgs e)
        {

        }

        private void ButtonToApi_Click(object sender, EventArgs e)
        {
            if (!CurrentlyDataBase.IsNullOrEmpty())
            {
                CodeOut();
            }
            else
            {
                UIMessageTip.ShowWarning("未选中数据库或数据表");
            }
        }

        private void CodeOut()
        {
            using (var scope = AutoFacConfig.AutoFacContainer.BeginLifetimeScope())
            {
                var form = scope.Resolve<CreateApiPage>();
                form.CurrentlyTableName = connectionService.GetConnection(CurrentlyDataBase);
                //当前是表
                if (IsView)
                {
                    foreach (DataGridViewRow select in DataView.Rows)
                    {

                        if (select.Cells[0].Value == null)
                        {
                            break;
                        }
                        if ((bool)select.Cells[0].Value)
                        {
                            var tableName = select.Cells[1].Value.ToString();
                            var tableInfo = viewService.GetView(CurrentlyDataBase, tableName);
                            form.columnInfuse.Add(tableInfo, viewService.GetColumnInfos(CurrentlyDataBase, tableName));
                        }

                    }
                }
                //当前是行
                else
                {
                    //获取当前选中的所有行
                    var viewInfo = viewService.GetView(CurrentlyDataBase, CurrentlyView);
                    form.columnInfuse.Add(viewInfo, new List<ColumnInfo>());
                    foreach (DataGridViewRow select in DataView.Rows)
                    {
                        if (select.Cells[0].Value == null)
                        {
                            break;
                        }
                        if ((bool)select.Cells[0].Value)
                        {
                            var cellName = select.Cells[1].Value.ToString();
                            var columnInfo = viewService.GetColumnInfo(CurrentlyDataBase, CurrentlyView, cellName);
                            form.columnInfuse[viewInfo].Add(columnInfo);
                        }
                    }
                }
                form.ShowDialog();
            }
        }

        private void DataBaseSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewSelect.SelectedItem = null;
            if (DataBaseSelect.SelectedItem != null)
            {
                InitPageByViewData(DataBaseSelect.SelectedItem.ToString(), 1);
                FreshSeleViews();
            }
            else
            {
                InitPageByViewData(DataBaseSelect.Items[0].ToString(), 1);
                FreshSeleViews();
            }
        }

        private void ViewSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewSelect.SelectedItem != null)
            {
                //刷新数据
                InitPageByColumnData(CurrentlyDataBase, ViewSelect.SelectedItem.ToString(), 1);
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            ViewSelect.SelectedItem = null;
            InitPageByViewData(CurrentlyDataBase, 1);
        }

        private void dataPageControll_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            if (CurrentlyDataBase == null)
            {
                return;
            }
            if (IsView)
            {
                InitPageByViewData(CurrentlyDataBase, pageIndex);
            }
            else
            {
                InitPageByColumnData(CurrentlyDataBase, CurrentlyView, pageIndex);
            }
        }
    }
}
