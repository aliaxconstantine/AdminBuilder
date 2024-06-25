namespace AdminBuilder.Views
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataView = new Sunny.UI.UIDataGridView();
            this.dataPageControll = new Sunny.UI.UIPagination();
            this.ButtonToApi = new Sunny.UI.UIButton();
            this.DataBaseSelect = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.ViewSelect = new Sunny.UI.UIComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.ButtonToVue = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataView
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataView.BackgroundColor = System.Drawing.Color.White;
            this.DataView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataView.DefaultCellStyle = dataGridViewCellStyle8;
            this.DataView.EnableHeadersVisualStyles = false;
            this.DataView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataView.Location = new System.Drawing.Point(3, 47);
            this.DataView.Name = "DataView";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DataView.RowHeadersWidth = 51;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DataView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.DataView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.DataView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.DataView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PowderBlue;
            this.DataView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataView.RowTemplate.Height = 27;
            this.DataView.SelectedIndex = -1;
            this.DataView.Size = new System.Drawing.Size(1025, 485);
            this.DataView.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataView.TabIndex = 0;
            // 
            // dataPageControll
            // 
            this.dataPageControll.ButtonFillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.dataPageControll.ButtonStyleInherited = false;
            this.dataPageControll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataPageControll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataPageControll.Location = new System.Drawing.Point(0, 540);
            this.dataPageControll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataPageControll.MinimumSize = new System.Drawing.Size(1, 1);
            this.dataPageControll.Name = "dataPageControll";
            this.dataPageControll.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.dataPageControll.ShowText = false;
            this.dataPageControll.Size = new System.Drawing.Size(1030, 35);
            this.dataPageControll.TabIndex = 1;
            this.dataPageControll.Text = "dataPageControll";
            this.dataPageControll.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dataPageControll.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.dataPageControll_PageChanged);
            // 
            // ButtonToApi
            // 
            this.ButtonToApi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToApi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.ButtonToApi.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.ButtonToApi.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.ButtonToApi.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.ButtonToApi.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.ButtonToApi.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonToApi.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.ButtonToApi.Location = new System.Drawing.Point(912, 3);
            this.ButtonToApi.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonToApi.Name = "ButtonToApi";
            this.ButtonToApi.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.ButtonToApi.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.ButtonToApi.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.ButtonToApi.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.ButtonToApi.Size = new System.Drawing.Size(106, 38);
            this.ButtonToApi.Style = Sunny.UI.UIStyle.Custom;
            this.ButtonToApi.TabIndex = 4;
            this.ButtonToApi.Text = "导出API";
            this.ButtonToApi.TipsColor = System.Drawing.Color.White;
            this.ButtonToApi.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonToApi.Click += new System.EventHandler(this.ButtonToApi_Click);
            // 
            // DataBaseSelect
            // 
            this.DataBaseSelect.DataSource = null;
            this.DataBaseSelect.FillColor = System.Drawing.Color.White;
            this.DataBaseSelect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataBaseSelect.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.DataBaseSelect.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataBaseSelect.Location = new System.Drawing.Point(93, 6);
            this.DataBaseSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DataBaseSelect.MinimumSize = new System.Drawing.Size(63, 0);
            this.DataBaseSelect.Name = "DataBaseSelect";
            this.DataBaseSelect.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.DataBaseSelect.Size = new System.Drawing.Size(188, 34);
            this.DataBaseSelect.SymbolSize = 24;
            this.DataBaseSelect.TabIndex = 6;
            this.DataBaseSelect.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.DataBaseSelect.Watermark = "";
            this.DataBaseSelect.SelectedIndexChanged += new System.EventHandler(this.DataBaseSelect_SelectedIndexChanged);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(14, 6);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(75, 35);
            this.uiLabel1.TabIndex = 7;
            this.uiLabel1.Text = "数据库";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(288, 13);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(37, 23);
            this.uiLabel2.TabIndex = 8;
            this.uiLabel2.Text = "表";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewSelect
            // 
            this.ViewSelect.DataSource = null;
            this.ViewSelect.FillColor = System.Drawing.Color.White;
            this.ViewSelect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ViewSelect.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ViewSelect.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.ViewSelect.Location = new System.Drawing.Point(332, 6);
            this.ViewSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ViewSelect.MinimumSize = new System.Drawing.Size(63, 0);
            this.ViewSelect.Name = "ViewSelect";
            this.ViewSelect.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.ViewSelect.Size = new System.Drawing.Size(238, 34);
            this.ViewSelect.SymbolSize = 24;
            this.ViewSelect.TabIndex = 9;
            this.ViewSelect.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ViewSelect.Watermark = "";
            this.ViewSelect.SelectedIndexChanged += new System.EventHandler(this.ViewSelect_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiSymbolButton1);
            this.panel1.Controls.Add(this.ViewSelect);
            this.panel1.Controls.Add(this.ButtonToVue);
            this.panel1.Controls.Add(this.uiLabel2);
            this.panel1.Controls.Add(this.ButtonToApi);
            this.panel1.Controls.Add(this.uiLabel1);
            this.panel1.Controls.Add(this.DataBaseSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 46);
            this.panel1.TabIndex = 10;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(577, 4);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(99, 35);
            this.uiSymbolButton1.TabIndex = 10;
            this.uiSymbolButton1.Text = "重置表";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // ButtonToVue
            // 
            this.ButtonToVue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonToVue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.ButtonToVue.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.ButtonToVue.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.ButtonToVue.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.ButtonToVue.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.ButtonToVue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonToVue.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.ButtonToVue.Location = new System.Drawing.Point(800, 4);
            this.ButtonToVue.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonToVue.Name = "ButtonToVue";
            this.ButtonToVue.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.ButtonToVue.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.ButtonToVue.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.ButtonToVue.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.ButtonToVue.Size = new System.Drawing.Size(106, 38);
            this.ButtonToVue.Style = Sunny.UI.UIStyle.Custom;
            this.ButtonToVue.TabIndex = 2;
            this.ButtonToVue.Text = "导出前端";
            this.ButtonToVue.TipsColor = System.Drawing.Color.White;
            this.ButtonToVue.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonToVue.Click += new System.EventHandler(this.ButtonToVue_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1030, 575);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataPageControll);
            this.Controls.Add(this.DataView);
            this.Name = "MainPage";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView DataView;
        private Sunny.UI.UIPagination dataPageControll;
        private Sunny.UI.UIButton ButtonToApi;
        private Sunny.UI.UIComboBox DataBaseSelect;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox ViewSelect;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UIButton ButtonToVue;
    }
}