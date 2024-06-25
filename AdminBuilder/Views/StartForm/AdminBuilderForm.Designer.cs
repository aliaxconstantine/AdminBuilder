namespace AdminBuilder.Views
{
    partial class AdminBuilderForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CreateConnectionButton = new Sunny.UI.UISymbolButton();
            this.FormStyleManger = new Sunny.UI.UIStyleManager(this.components);
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // Aside
            // 
            this.Aside.LineColor = System.Drawing.Color.Black;
            this.Aside.Location = new System.Drawing.Point(0, 130);
            this.Aside.Size = new System.Drawing.Size(250, 590);
            // 
            // Header
            // 
            this.Header.Controls.Add(this.uiLabel1);
            this.Header.Controls.Add(this.CreateConnectionButton);
            this.Header.Size = new System.Drawing.Size(1280, 95);
            // 
            // CreateConnectionButton
            // 
            this.CreateConnectionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateConnectionButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CreateConnectionButton.Location = new System.Drawing.Point(3, 54);
            this.CreateConnectionButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.CreateConnectionButton.Name = "CreateConnectionButton";
            this.CreateConnectionButton.Size = new System.Drawing.Size(247, 35);
            this.CreateConnectionButton.TabIndex = 0;
            this.CreateConnectionButton.Text = "创建连接";
            this.CreateConnectionButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CreateConnectionButton.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // FormStyleManger
            // 
            this.FormStyleManger.DPIScale = true;
            this.FormStyleManger.GlobalFont = true;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(256, 66);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(537, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "左侧栏目查看模板规则与帮助";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AdminBuilderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Font = new System.Drawing.Font("华文行楷", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "AdminBuilderForm";
            this.Text = "代码生成器V1.0";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminBuilderForm_FormClosed);
            this.Header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UISymbolButton CreateConnectionButton;
        private Sunny.UI.UILabel uiLabel1;
        public Sunny.UI.UIStyleManager FormStyleManger;
    }
}

