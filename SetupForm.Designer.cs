namespace LeaveReadCard
{
    partial class SetupForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvClassMap = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chClassName = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.chCardName = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnAutoClass = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cboOverride = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.dgvLeaveMap = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chCardLeave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chLeave = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.cboReadingCardStartYear = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveMap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClassMap
            // 
            this.dgvClassMap.AllowUserToAddRows = false;
            this.dgvClassMap.AllowUserToDeleteRows = false;
            this.dgvClassMap.AllowUserToResizeRows = false;
            this.dgvClassMap.BackgroundColor = System.Drawing.Color.White;
            this.dgvClassMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chClassName,
            this.chCardName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClassMap.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClassMap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvClassMap.HighlightSelectedColumnHeaders = false;
            this.dgvClassMap.Location = new System.Drawing.Point(12, 38);
            this.dgvClassMap.Margin = new System.Windows.Forms.Padding(2);
            this.dgvClassMap.Name = "dgvClassMap";
            this.dgvClassMap.RowHeadersWidth = 25;
            this.dgvClassMap.RowTemplate.Height = 24;
            this.dgvClassMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvClassMap.Size = new System.Drawing.Size(292, 316);
            this.dgvClassMap.TabIndex = 1;
            this.dgvClassMap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassMap_CellClick);
            this.dgvClassMap.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvClassMap_KeyUp);
            // 
            // chClassName
            // 
            this.chClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chClassName.DefaultCellStyle = dataGridViewCellStyle1;
            this.chClassName.DisplayMember = "Text";
            this.chClassName.DropDownHeight = 106;
            this.chClassName.DropDownWidth = 121;
            this.chClassName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chClassName.HeaderText = "班級名稱";
            this.chClassName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chClassName.IntegralHeight = false;
            this.chClassName.ItemHeight = 17;
            this.chClassName.Name = "chClassName";
            this.chClassName.ReadOnly = true;
            this.chClassName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chClassName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // chCardName
            // 
            this.chCardName.DropDownHeight = 106;
            this.chCardName.DropDownWidth = 121;
            this.chCardName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chCardName.HeaderText = "讀卡代碼";
            this.chCardName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chCardName.IntegralHeight = false;
            this.chCardName.ItemHeight = 17;
            this.chCardName.Name = "chCardName";
            this.chCardName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chCardName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(87, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "班級名稱對照";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(145, 394);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(229, 394);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "離開";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAutoClass
            // 
            this.btnAutoClass.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutoClass.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoClass.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAutoClass.Location = new System.Drawing.Point(105, 11);
            this.btnAutoClass.Name = "btnAutoClass";
            this.btnAutoClass.Size = new System.Drawing.Size(75, 23);
            this.btnAutoClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAutoClass.TabIndex = 11;
            this.btnAutoClass.Text = "自動產生";
            this.btnAutoClass.Visible = false;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(12, 365);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(208, 21);
            this.labelX6.TabIndex = 13;
            this.labelX6.Text = "讀卡資料與現有資料衝突處理方式";
            // 
            // cboOverride
            // 
            this.cboOverride.DisplayMember = "Text";
            this.cboOverride.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboOverride.FormattingEnabled = true;
            this.cboOverride.ItemHeight = 19;
            this.cboOverride.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cboOverride.Location = new System.Drawing.Point(12, 392);
            this.cboOverride.Name = "cboOverride";
            this.cboOverride.Size = new System.Drawing.Size(113, 25);
            this.cboOverride.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboOverride.TabIndex = 14;
            this.cboOverride.Text = "略過讀卡資料";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "覆蓋現有資料";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "略過讀卡資料";
            // 
            // dgvLeaveMap
            // 
            this.dgvLeaveMap.AllowUserToAddRows = false;
            this.dgvLeaveMap.AllowUserToDeleteRows = false;
            this.dgvLeaveMap.AllowUserToResizeRows = false;
            this.dgvLeaveMap.BackgroundColor = System.Drawing.Color.White;
            this.dgvLeaveMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeaveMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chCardLeave,
            this.chLeave});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLeaveMap.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLeaveMap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvLeaveMap.HighlightSelectedColumnHeaders = false;
            this.dgvLeaveMap.Location = new System.Drawing.Point(475, 38);
            this.dgvLeaveMap.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLeaveMap.Name = "dgvLeaveMap";
            this.dgvLeaveMap.RowHeadersWidth = 25;
            this.dgvLeaveMap.RowTemplate.Height = 24;
            this.dgvLeaveMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLeaveMap.Size = new System.Drawing.Size(262, 316);
            this.dgvLeaveMap.TabIndex = 16;
            // 
            // chCardLeave
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chCardLeave.DefaultCellStyle = dataGridViewCellStyle3;
            this.chCardLeave.HeaderText = "讀卡假別";
            this.chCardLeave.Name = "chCardLeave";
            this.chCardLeave.ReadOnly = true;
            this.chCardLeave.Width = 90;
            // 
            // chLeave
            // 
            this.chLeave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chLeave.DropDownHeight = 106;
            this.chLeave.DropDownWidth = 121;
            this.chLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chLeave.HeaderText = "假別";
            this.chLeave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chLeave.IntegralHeight = false;
            this.chLeave.ItemHeight = 17;
            this.chLeave.Name = "chLeave";
            this.chLeave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chLeave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(482, 12);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(104, 21);
            this.labelX7.TabIndex = 15;
            this.labelX7.Text = "請假卡:假別對照";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(650, 365);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(87, 21);
            this.labelX8.TabIndex = 17;
            this.labelX8.Text = "讀卡起始年份";
            // 
            // cboReadingCardStartYear
            // 
            this.cboReadingCardStartYear.DisplayMember = "Text";
            this.cboReadingCardStartYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboReadingCardStartYear.FormattingEnabled = true;
            this.cboReadingCardStartYear.ItemHeight = 19;
            this.cboReadingCardStartYear.Location = new System.Drawing.Point(650, 390);
            this.cboReadingCardStartYear.Name = "cboReadingCardStartYear";
            this.cboReadingCardStartYear.Size = new System.Drawing.Size(88, 25);
            this.cboReadingCardStartYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboReadingCardStartYear.TabIndex = 18;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 427);
            this.Controls.Add(this.cboReadingCardStartYear);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.dgvLeaveMap);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.cboOverride);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.btnAutoClass);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dgvClassMap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(336, 466);
            this.MinimumSize = new System.Drawing.Size(336, 466);
            this.Name = "SetupForm";
            this.Text = "學生出缺席讀卡設定";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvClassMap;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnAutoClass;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chClassName;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chCardName;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboOverride;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
		private DevComponents.DotNetBar.Controls.DataGridViewX dgvLeaveMap;
		private DevComponents.DotNetBar.LabelX labelX7;
		private System.Windows.Forms.DataGridViewTextBoxColumn chCardLeave;
		private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chLeave;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboReadingCardStartYear;
    }
}