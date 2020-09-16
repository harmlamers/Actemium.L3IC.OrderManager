using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
	partial class MembershipPopupForm
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
      this.components = new System.ComponentModel.Container();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pnlEvents = new System.Windows.Forms.Panel();
      this.MembershipSupergrid = new Actemium.Windows.Forms.SuperGrid.SuperGrid();
      this.lblTitle = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvcDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.starlimsResultValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.variableResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.productionEventExtBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.productionPlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.pnlEvents.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.starlimsResultValueBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.variableResultBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.productionEventExtBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.productionPlanBindingSource)).BeginInit();
      this.SuspendLayout();
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
      this.pnlEvents.Controls.Add(this.MembershipSupergrid);
      this.pnlEvents.Controls.Add(this.lblTitle);
      this.pnlEvents.Location = new System.Drawing.Point(0, 0);
      this.pnlEvents.Name = "pnlEvents";
      this.pnlEvents.Size = new System.Drawing.Size(900, 527);
      this.pnlEvents.TabIndex = 12;
      // 
      // PropertiesSupergrid
      // 
      this.MembershipSupergrid.BackColor = System.Drawing.Color.Green;
      this.MembershipSupergrid.ClipboardCellSeparator = ',';
      this.MembershipSupergrid.ClipboardContextMenu = false;
      this.MembershipSupergrid.ClipboardDateFormat = "yyyy-MM-dd HH:mm:ss";
      this.MembershipSupergrid.ClipboardEnableDateFormat = false;
      this.MembershipSupergrid.ClipboardEnableIncludeHeaders = false;
      this.MembershipSupergrid.ClipboardEnableQuotedValues = false;
      this.MembershipSupergrid.CopyToClipboard = false;
      this.MembershipSupergrid.DataSource = null;
      this.MembershipSupergrid.DisplayNumberOfItems = false;
      this.MembershipSupergrid.DisplayNumberOfItemsFunc = null;
      this.MembershipSupergrid.DisplayNumberOfItemsTemplate = null;
      this.MembershipSupergrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MembershipSupergrid.EditedCellBackgroundColor = System.Drawing.Color.LightPink;
      this.MembershipSupergrid.EnableHighlighter = false;
      this.MembershipSupergrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
      this.MembershipSupergrid.IdentifyingColumn = null;
      this.MembershipSupergrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      this.MembershipSupergrid.Location = new System.Drawing.Point(0, 20);
      this.MembershipSupergrid.Name = "MembershipSupergrid";
      this.MembershipSupergrid.PersistentUserSettings = true;
      // 
      // 
      // 
      this.MembershipSupergrid.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
      // 
      // 
      // 
      this.MembershipSupergrid.PrimaryGrid.Filter.ShowPanelFilterExpr = true;
      this.MembershipSupergrid.PrimaryGrid.Filter.Visible = true;
      this.MembershipSupergrid.RestoreSelectionAfterSortChanged = true;
      this.MembershipSupergrid.SettingsStorageType = Actemium.Windows.Forms.SuperGrid.SuperGrid.SettingsStorageTypeEnum.ToFile;
      this.MembershipSupergrid.Size = new System.Drawing.Size(900, 507);
      this.MembershipSupergrid.TabIndex = 23;
      this.MembershipSupergrid.Text = "MembershipSupergrid";
      this.MembershipSupergrid.Translate = true;
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
      this.lblTitle.Size = new System.Drawing.Size(900, 20);
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
      // MembershipPopupForm
      // 
      this.BackColor = System.Drawing.Color.LightGray;
      this.ClientSize = new System.Drawing.Size(900, 539);
      this.backgroundPanel.Controls.Add(this.pnlEvents);
      this.ForeColor = System.Drawing.SystemColors.ControlText;
      this.Name = "MembershipPopupForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Text = "Membership";
      this.TitleText = "Membership";
      this.Translate = true;
      this.Activated += new System.EventHandler(this.MembershipPopupFormActivated);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MembershipPopupFormFormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.pnlEvents.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.starlimsResultValueBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.variableResultBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.productionEventExtBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.productionPlanBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.BindingSource starlimsResultValueBindingSource;
		private System.Windows.Forms.Panel pnlEvents;
		private System.Windows.Forms.BindingSource variableResultBindingSource;
		private System.Windows.Forms.BindingSource productionPlanBindingSource;
		private System.Windows.Forms.BindingSource productionEventExtBindingSource;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblTitle;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDefaultValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcValue;
    private Windows.Forms.SuperGrid.SuperGrid MembershipSupergrid;
  }
}