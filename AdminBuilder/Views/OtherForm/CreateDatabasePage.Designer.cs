namespace AdminBuilder.Views
{
    partial class CreateDatabasePage
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
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectionText = new System.Windows.Forms.TextBox();
            this.testButton = new Sunny.UI.UIButton();
            this.OkButton = new Sunny.UI.UIButton();
            this.ExitButton = new Sunny.UI.UIButton();
            this.testResult = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.DbTypeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(28, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "连接名";
            // 
            // ConnectionName
            // 
            this.ConnectionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConnectionName.Location = new System.Drawing.Point(134, 55);
            this.ConnectionName.Name = "ConnectionName";
            this.ConnectionName.Size = new System.Drawing.Size(355, 27);
            this.ConnectionName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "连接字符串";
            // 
            // ConnectionText
            // 
            this.ConnectionText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConnectionText.Location = new System.Drawing.Point(134, 108);
            this.ConnectionText.Name = "ConnectionText";
            this.ConnectionText.Size = new System.Drawing.Size(355, 27);
            this.ConnectionText.TabIndex = 3;
            // 
            // testButton
            // 
            this.testButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.testButton.Font = new System.Drawing.Font("宋体", 10F);
            this.testButton.Location = new System.Drawing.Point(27, 206);
            this.testButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(100, 35);
            this.testButton.TabIndex = 4;
            this.testButton.Text = "测试连接";
            this.testButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testButton.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // OkButton
            // 
            this.OkButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OkButton.Font = new System.Drawing.Font("宋体", 10F);
            this.OkButton.Location = new System.Drawing.Point(280, 206);
            this.OkButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(100, 35);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "确认";
            this.OkButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Font = new System.Drawing.Font("宋体", 10F);
            this.ExitButton.Location = new System.Drawing.Point(408, 206);
            this.ExitButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 35);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "退出";
            this.ExitButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // testResult
            // 
            this.testResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.testResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.testResult.Location = new System.Drawing.Point(134, 206);
            this.testResult.Name = "testResult";
            this.testResult.Size = new System.Drawing.Size(100, 35);
            this.testResult.TabIndex = 7;
            this.testResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 10F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(28, 154);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(109, 26);
            this.uiLabel1.TabIndex = 9;
            this.uiLabel1.Text = "数据库类型";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DbTypeBox
            // 
            this.DbTypeBox.FormattingEnabled = true;
            this.DbTypeBox.Items.AddRange(new object[] {
            "MySQL",
            "SQLServer"});
            this.DbTypeBox.Location = new System.Drawing.Point(134, 154);
            this.DbTypeBox.Name = "DbTypeBox";
            this.DbTypeBox.Size = new System.Drawing.Size(179, 25);
            this.DbTypeBox.TabIndex = 10;
            // 
            // CreateDatabaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(545, 265);
            this.Controls.Add(this.DbTypeBox);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.testResult);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.ConnectionText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConnectionName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(602, 286);
            this.Name = "CreateDatabaseForm";
            this.Text = "创建连接";
            this.TitleFont = new System.Drawing.Font("宋体", 10F);
            this.ZoomScaleDisabled = true;
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConnectionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ConnectionText;
        private Sunny.UI.UIButton testButton;
        private Sunny.UI.UIButton OkButton;
        private Sunny.UI.UIButton ExitButton;
        private Sunny.UI.UILabel testResult;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.ComboBox DbTypeBox;
    }
}