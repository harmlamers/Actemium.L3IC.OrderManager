namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  partial class PropertiesPopupForm
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
    /// the contents of this method met the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pnlEvents = new System.Windows.Forms.Panel();
      this.PropertiesSupergrid = new Actemium.Windows.Forms.SuperGrid.SuperGrid();
      this.lblTitle = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvcDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.backgroundPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.pnlEvents.SuspendLayout();
      this.SuspendLayout();
      // 
      // backgroundPanel
      // 
      this.backgroundPanel.Controls.Add(this.pnlEvents);
      this.backgroundPanel.Size = new System.Drawing.Size(900, 539);
      this.backgroundPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
      this.backgroundPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
      this.backgroundPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(215)))), ((int)(((byte)(224)))));
      this.backgroundPanel.Style.Border = DevComponents.DotNetBar.eBorderType.Raised;
      this.backgroundPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.backgroundPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.backgroundPanel.Style.GradientAngle = 90;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.DataPropertyName = "Tag";
      this.dataGridViewTextBoxColumn1.FillWeight = 53.71481F;
      this.dataGridViewTextBoxColumn1.HeaderText = "Tag";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      this.dataGridViewTextBoxColumn1.Width = 84;
      // 
      // pnlEvents
      // 
      this.pnlEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlEvents.Controls.Add(this.PropertiesSupergrid);
      this.pnlEvents.Controls.Add(this.lblTitle);
      this.pnlEvents.Location = new System.Drawing.Point(0, 0);
      this.pnlEvents.Name = "pnlEvents";
      this.pnlEvents.Size = new System.Drawing.Size(1508, 793);
      this.pnlEvents.TabIndex = 12;
      // 
      // PropertiesSupergrid
      // 
      this.PropertiesSupergrid.BackColor = System.Drawing.Color.Green;
      this.PropertiesSupergrid.ClipboardCellSeparator = ',';
      this.PropertiesSupergrid.ClipboardContextMenu = false;
      this.PropertiesSupergrid.ClipboardDateFormat = "yyyy-MM-dd HH:mm:ss";
      this.PropertiesSupergrid.ClipboardEnableDateFormat = false;
      this.PropertiesSupergrid.ClipboardEnableIncludeHeaders = false;
      this.PropertiesSupergrid.ClipboardEnableQuotedValues = false;
      this.PropertiesSupergrid.CopyToClipboard = false;
      this.PropertiesSupergrid.DataSource = null;
      this.PropertiesSupergrid.DisplayNumberOfItems = false;
      this.PropertiesSupergrid.DisplayNumberOfItemsFunc = null;
      this.PropertiesSupergrid.DisplayNumberOfItemsTemplate = null;
      this.PropertiesSupergrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PropertiesSupergrid.EditedCellBackgroundColor = System.Drawing.Color.LightPink;
      this.PropertiesSupergrid.EnableHighlighter = false;
      this.PropertiesSupergrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
      this.PropertiesSupergrid.IdentifyingColumn = null;
      this.PropertiesSupergrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      this.PropertiesSupergrid.Location = new System.Drawing.Point(0, 20);
      this.PropertiesSupergrid.Name = "PropertiesSupergrid";
      this.PropertiesSupergrid.PersistentUserSettings = true;
      // 
      // 
      // 
      this.PropertiesSupergrid.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
      // 
      // 
      // 
      this.PropertiesSupergrid.PrimaryGrid.Filter.ShowPanelFilterExpr = true;
      this.PropertiesSupergrid.PrimaryGrid.Filter.Visible = true;
      this.PropertiesSupergrid.RestoreSelectionAfterSortChanged = true;
      this.PropertiesSupergrid.SettingsStorageType = Actemium.Windows.Forms.SuperGrid.SuperGrid.SettingsStorageTypeEnum.ToFile;
      this.PropertiesSupergrid.Size = new System.Drawing.Size(1508, 773);
      this.PropertiesSupergrid.TabIndex = 23;
      this.PropertiesSupergrid.Text = "PropertiesSupergrid";
      this.PropertiesSupergrid.Translate = true;
      // 
      // lblTitle
      // 
      // 
      // 
      // 
      this.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.lblTitle.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTitle.FormatMask = null;
      this.lblTitle.Location = new System.Drawing.Point(0, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.PaddingLeft = 5;
      this.lblTitle.Size = new System.Drawing.Size(1508, 20);
      this.lblTitle.TabIndex = 22;
      this.lblTitle.Text = "Title";
      this.lblTitle.Translate = false;
      // 
      // dgvcName
      // 
      this.dgvcName.HeaderText = "Name";
      this.dgvcName.Name = "dgvcName";
      // 
      // dgvcDefaultValue
      // 
      this.dgvcDefaultValue.HeaderText = "Default Value";
      this.dgvcDefaultValue.Name = "dgvcDefaultValue";
      // 
      // dgvcValue
      // 
      this.dgvcValue.HeaderText = "Value";
      this.dgvcValue.Name = "dgvcValue";
      // 
      // PropertiesPopupForm
      // 
      this.BackColor = System.Drawing.Color.LightGray;
      this.ClientSize = new System.Drawing.Size(900, 539);
      this.DoubleBuffered = true;
      this.ForeColor = System.Drawing.SystemColors.ControlText;
      this.Name = "PropertiesPopupForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Text = "Properties";
      this.TitleText = "Properties";
      this.Translate = true;
      this.Activated += new System.EventHandler(this.PropertiesPopupFormActivated);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertiesPopupFormFormClosing);
      this.Controls.SetChildIndex(this.backgroundPanel, 0);
      this.backgroundPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.pnlEvents.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.Panel pnlEvents;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblTitle;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDefaultValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcValue;
    private Windows.Forms.SuperGrid.SuperGrid PropertiesSupergrid;
  }
}
