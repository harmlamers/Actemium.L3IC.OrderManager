using System;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.Windows.Forms.DevComponents2.Controls;

namespace Actemium.L3IC.OrderManager.Client.General.Pages
{
  partial class OrdersPage {
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
      this.OrdersSettingsGroupBox = new Actemium.Windows.Forms.GroupBox();
      this.OrdersToTimeFilterLabel = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.OrdersFromTimeFilterLabel = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.OrdersToTimeFilterTextBox = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
      this.OrdersFromTimeFilterTextBox = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
      this.OrdersToDateFilterInput = new System.Windows.Forms.DateTimePicker();
      this.OrdersFromDateFilterInput = new System.Windows.Forms.DateTimePicker();
      this.OrdersPredefinedFilterDropdownX = new System.Windows.Forms.ComboBox();
      this.OrdersPredefinedFilterLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.OrdersFilterApplyButtonX = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.OrdersFilterResetButtonX = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.OrdersToDateTimeFilterLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.OrdersFromDateTimeFilterLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.OrdersActualFilterLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.OrdersPanelSplitter = new System.Windows.Forms.Splitter();
      this.OrdersSupergrid = new Actemium.Windows.Forms.SuperGrid.SuperGrid();
      this.OrdersStartStopOrderGroupBox = new Actemium.Windows.Forms.GroupBox();
      this.OrdersStartOrderButtonX = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.OrdersStopOrderButtonX = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.OrdersSettingsGroupBox.SuspendLayout();
      this.OrdersStartStopOrderGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // OrdersSettingsGroupBox
      // 
      this.OrdersSettingsGroupBox.AutoSize = true;
      this.OrdersSettingsGroupBox.BorderColor = System.Drawing.SystemColors.ActiveBorder;
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersToTimeFilterLabel);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersFromTimeFilterLabel);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersToTimeFilterTextBox);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersFromTimeFilterTextBox);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersToDateFilterInput);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersFromDateFilterInput);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersPredefinedFilterDropdownX);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersPredefinedFilterLabelX);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersFilterApplyButtonX);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersFilterResetButtonX);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersToDateTimeFilterLabelX);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersFromDateTimeFilterLabelX);
      this.OrdersSettingsGroupBox.Controls.Add(this.OrdersActualFilterLabelX);
      this.OrdersSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
      this.OrdersSettingsGroupBox.Location = new System.Drawing.Point(0, 0);
      this.OrdersSettingsGroupBox.Name = "OrdersSettingsGroupBox";
      this.OrdersSettingsGroupBox.Size = new System.Drawing.Size(1016, 211);
      this.OrdersSettingsGroupBox.TabIndex = 16;
      this.OrdersSettingsGroupBox.TabStop = false;
      this.OrdersSettingsGroupBox.TextColor = System.Drawing.SystemColors.MenuHighlight;
      // 
      // OrdersToTimeFilterLabel
      // 
      // 
      // 
      // 
      this.OrdersToTimeFilterLabel.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
      this.OrdersToTimeFilterLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.OrdersToTimeFilterLabel.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.OrdersToTimeFilterLabel.FormatMask = null;
      this.OrdersToTimeFilterLabel.Location = new System.Drawing.Point(763, 81);
      this.OrdersToTimeFilterLabel.Name = "OrdersToTimeFilterLabel";
      this.OrdersToTimeFilterLabel.Size = new System.Drawing.Size(50, 23);
      this.OrdersToTimeFilterLabel.TabIndex = 27;
      this.OrdersToTimeFilterLabel.Text = "hh:mm";
      this.OrdersToTimeFilterLabel.Translate = false;
      // 
      // OrdersFromTimeFilterLabel
      // 
      // 
      // 
      // 
      this.OrdersFromTimeFilterLabel.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
      this.OrdersFromTimeFilterLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.OrdersFromTimeFilterLabel.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.OrdersFromTimeFilterLabel.FormatMask = null;
      this.OrdersFromTimeFilterLabel.Location = new System.Drawing.Point(396, 82);
      this.OrdersFromTimeFilterLabel.Name = "OrdersFromTimeFilterLabel";
      this.OrdersFromTimeFilterLabel.Size = new System.Drawing.Size(50, 23);
      this.OrdersFromTimeFilterLabel.TabIndex = 26;
      this.OrdersFromTimeFilterLabel.Text = "hh:mm";
      this.OrdersFromTimeFilterLabel.Translate = false;
      // 
      // OrdersToTimeFilterTextBox
      // 
      // 
      // 
      // 
      this.OrdersToTimeFilterTextBox.Border.Class = "TextBoxBorder";
      this.OrdersToTimeFilterTextBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.OrdersToTimeFilterTextBox.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.OrdersToTimeFilterTextBox.FormatMask = null;
      this.OrdersToTimeFilterTextBox.Location = new System.Drawing.Point(707, 80);
      this.OrdersToTimeFilterTextBox.Name = "OrdersToTimeFilterTextBox";
      this.OrdersToTimeFilterTextBox.PreventEnterBeep = true;
      this.OrdersToTimeFilterTextBox.Size = new System.Drawing.Size(50, 20);
      this.OrdersToTimeFilterTextBox.TabIndex = 25;
      // 
      // OrdersFromTimeFilterTextBox
      // 
      // 
      // 
      // 
      this.OrdersFromTimeFilterTextBox.Border.Class = "TextBoxBorder";
      this.OrdersFromTimeFilterTextBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.OrdersFromTimeFilterTextBox.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.OrdersFromTimeFilterTextBox.FormatMask = null;
      this.OrdersFromTimeFilterTextBox.Location = new System.Drawing.Point(340, 81);
      this.OrdersFromTimeFilterTextBox.Name = "OrdersFromTimeFilterTextBox";
      this.OrdersFromTimeFilterTextBox.PreventEnterBeep = true;
      this.OrdersFromTimeFilterTextBox.Size = new System.Drawing.Size(50, 20);
      this.OrdersFromTimeFilterTextBox.TabIndex = 19;
      // 
      // OrdersToDateFilterInput
      // 
      this.OrdersToDateFilterInput.Location = new System.Drawing.Point(501, 80);
      this.OrdersToDateFilterInput.Name = "OrdersToDateFilterInput";
      this.OrdersToDateFilterInput.Size = new System.Drawing.Size(200, 20);
      this.OrdersToDateFilterInput.TabIndex = 24;
      // 
      // OrdersFromDateFilterInput
      // 
      this.OrdersFromDateFilterInput.Location = new System.Drawing.Point(134, 81);
      this.OrdersFromDateFilterInput.Name = "OrdersFromDateFilterInput";
      this.OrdersFromDateFilterInput.Size = new System.Drawing.Size(200, 20);
      this.OrdersFromDateFilterInput.TabIndex = 19;
      this.OrdersFromDateFilterInput.Value = new System.DateTime(2020, 5, 13, 15, 24, 9, 254);
      // 
      // OrdersPredefinedFilterDropdownX
      // 
      this.OrdersPredefinedFilterDropdownX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.OrdersPredefinedFilterDropdownX.Font = new System.Drawing.Font("Tahoma", 10F);
      this.OrdersPredefinedFilterDropdownX.Location = new System.Drawing.Point(134, 118);
      this.OrdersPredefinedFilterDropdownX.Name = "OrdersPredefinedFilterDropdownX";
      this.OrdersPredefinedFilterDropdownX.Size = new System.Drawing.Size(200, 24);
      this.OrdersPredefinedFilterDropdownX.TabIndex = 23;
      // 
      // OrdersPredefinedFilterLabelX
      // 
      // 
      // 
      // 
      this.OrdersPredefinedFilterLabelX.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
      this.OrdersPredefinedFilterLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.OrdersPredefinedFilterLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.OrdersPredefinedFilterLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
      this.OrdersPredefinedFilterLabelX.FormatMask = null;
      this.OrdersPredefinedFilterLabelX.Location = new System.Drawing.Point(5, 117);
      this.OrdersPredefinedFilterLabelX.Name = "OrdersPredefinedFilterLabelX";
      this.OrdersPredefinedFilterLabelX.Size = new System.Drawing.Size(123, 25);
      this.OrdersPredefinedFilterLabelX.TabIndex = 22;
      this.OrdersPredefinedFilterLabelX.Text = "Predefined:";
      this.OrdersPredefinedFilterLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
      this.OrdersPredefinedFilterLabelX.Translate = false;
      // 
      // OrdersFilterApplyButtonX
      // 
      this.OrdersFilterApplyButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.OrdersFilterApplyButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
      this.OrdersFilterApplyButtonX.Font = new System.Drawing.Font("Tahoma", 12F);
      this.OrdersFilterApplyButtonX.Location = new System.Drawing.Point(5, 159);
      this.OrdersFilterApplyButtonX.Name = "OrdersFilterApplyButtonX";
      this.OrdersFilterApplyButtonX.Size = new System.Drawing.Size(103, 33);
      this.OrdersFilterApplyButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      this.OrdersFilterApplyButtonX.TabIndex = 21;
      this.OrdersFilterApplyButtonX.Text = "Filter";
      this.OrdersFilterApplyButtonX.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
      this.OrdersFilterApplyButtonX.Translate = false;
      // 
      // OrdersFilterResetButtonX
      // 
      this.OrdersFilterResetButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.OrdersFilterResetButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
      this.OrdersFilterResetButtonX.Font = new System.Drawing.Font("Tahoma", 12F);
      this.OrdersFilterResetButtonX.Location = new System.Drawing.Point(114, 159);
      this.OrdersFilterResetButtonX.Name = "OrdersFilterResetButtonX";
      this.OrdersFilterResetButtonX.Size = new System.Drawing.Size(103, 33);
      this.OrdersFilterResetButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      this.OrdersFilterResetButtonX.TabIndex = 20;
      this.OrdersFilterResetButtonX.Text = "Reset Filter";
      this.OrdersFilterResetButtonX.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
      this.OrdersFilterResetButtonX.Translate = false;
      // 
      // OrdersToDateTimeFilterLabelX
      // 
      // 
      // 
      // 
      this.OrdersToDateTimeFilterLabelX.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
      this.OrdersToDateTimeFilterLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.OrdersToDateTimeFilterLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.OrdersToDateTimeFilterLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
      this.OrdersToDateTimeFilterLabelX.FormatMask = null;
      this.OrdersToDateTimeFilterLabelX.Location = new System.Drawing.Point(452, 78);
      this.OrdersToDateTimeFilterLabelX.Name = "OrdersToDateTimeFilterLabelX";
      this.OrdersToDateTimeFilterLabelX.Size = new System.Drawing.Size(43, 25);
      this.OrdersToDateTimeFilterLabelX.TabIndex = 19;
      this.OrdersToDateTimeFilterLabelX.Text = "To: ";
      this.OrdersToDateTimeFilterLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
      this.OrdersToDateTimeFilterLabelX.Translate = false;
      // 
      // OrdersFromDateTimeFilterLabelX
      // 
      // 
      // 
      // 
      this.OrdersFromDateTimeFilterLabelX.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
      this.OrdersFromDateTimeFilterLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.OrdersFromDateTimeFilterLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.OrdersFromDateTimeFilterLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
      this.OrdersFromDateTimeFilterLabelX.FormatMask = null;
      this.OrdersFromDateTimeFilterLabelX.Location = new System.Drawing.Point(6, 78);
      this.OrdersFromDateTimeFilterLabelX.Name = "OrdersFromDateTimeFilterLabelX";
      this.OrdersFromDateTimeFilterLabelX.Size = new System.Drawing.Size(122, 25);
      this.OrdersFromDateTimeFilterLabelX.TabIndex = 18;
      this.OrdersFromDateTimeFilterLabelX.Text = "Startdate from:";
      this.OrdersFromDateTimeFilterLabelX.TextAlignment = System.Drawing.StringAlignment.Far;
      this.OrdersFromDateTimeFilterLabelX.Translate = false;
      // 
      // OrdersActualFilterLabelX
      // 
      // 
      // 
      // 
      this.OrdersActualFilterLabelX.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
      this.OrdersActualFilterLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.OrdersActualFilterLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.OrdersActualFilterLabelX.FormatMask = null;
      this.OrdersActualFilterLabelX.Location = new System.Drawing.Point(6, 47);
      this.OrdersActualFilterLabelX.Name = "OrdersActualFilterLabelX";
      this.OrdersActualFilterLabelX.Size = new System.Drawing.Size(500, 25);
      this.OrdersActualFilterLabelX.TabIndex = 16;
      this.OrdersActualFilterLabelX.Text = "Active period filter: Start dd-mm-yyyy hh:mm to dd-mm-yyyy hh:mm";
      this.OrdersActualFilterLabelX.Translate = false;
      // 
      // OrdersPanelSplitter
      // 
      this.OrdersPanelSplitter.BackColor = System.Drawing.SystemColors.Control;
      this.OrdersPanelSplitter.Cursor = System.Windows.Forms.Cursors.HSplit;
      this.OrdersPanelSplitter.Dock = System.Windows.Forms.DockStyle.Top;
      this.OrdersPanelSplitter.Location = new System.Drawing.Point(0, 211);
      this.OrdersPanelSplitter.MinExtra = 12;
      this.OrdersPanelSplitter.MinSize = 12;
      this.OrdersPanelSplitter.Name = "OrdersPanelSplitter";
      this.OrdersPanelSplitter.Size = new System.Drawing.Size(1016, 5);
      this.OrdersPanelSplitter.TabIndex = 17;
      this.OrdersPanelSplitter.TabStop = false;
      // 
      // OrdersSupergrid
      // 
      this.OrdersSupergrid.BackColor = System.Drawing.Color.Green;
      this.OrdersSupergrid.ClipboardCellSeparator = ',';
      this.OrdersSupergrid.ClipboardContextMenu = false;
      this.OrdersSupergrid.ClipboardDateFormat = "yyyy-MM-dd HH:mm:ss";
      this.OrdersSupergrid.ClipboardEnableDateFormat = false;
      this.OrdersSupergrid.ClipboardEnableIncludeHeaders = false;
      this.OrdersSupergrid.ClipboardEnableQuotedValues = false;
      this.OrdersSupergrid.CopyToClipboard = true;
      this.OrdersSupergrid.DataSource = null;
      this.OrdersSupergrid.DisplayNumberOfItems = false;
      this.OrdersSupergrid.DisplayNumberOfItemsFunc = null;
      this.OrdersSupergrid.DisplayNumberOfItemsTemplate = null;
      this.OrdersSupergrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OrdersSupergrid.EditedCellBackgroundColor = System.Drawing.Color.LightPink;
      this.OrdersSupergrid.EnableHighlighter = false;
      this.OrdersSupergrid.EnableValidator = false;
      this.OrdersSupergrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
      this.OrdersSupergrid.FooterUpdateCallback = null;
      this.OrdersSupergrid.GridContextMenu = false;
      this.OrdersSupergrid.IdentifyingColumn = null;
      this.OrdersSupergrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      this.OrdersSupergrid.Location = new System.Drawing.Point(0, 216);
      this.OrdersSupergrid.Name = "OrdersSupergrid";
      this.OrdersSupergrid.PersistentUserSettings = true;
      // 
      // 
      // 
      this.OrdersSupergrid.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
      this.OrdersSupergrid.RestoreSelectionAfterSortChanged = true;
      this.OrdersSupergrid.SettingsStorageType = Actemium.Windows.Forms.SuperGrid.SuperGrid.SettingsStorageTypeEnum.ToFile;
      this.OrdersSupergrid.Size = new System.Drawing.Size(1016, 423);
      this.OrdersSupergrid.TabIndex = 18;
      this.OrdersSupergrid.Text = "InstallBaseSupergrid";
      this.OrdersSupergrid.Translate = true;
      this.OrdersSupergrid.ValidatorColumnName = null;
      this.OrdersSupergrid.ValidatorCustomHighlightHandler = null;
      this.OrdersSupergrid.ValidatorHandler = null;
      this.OrdersSupergrid.ValidatorHighlightColor = System.Drawing.Color.Red;
      this.OrdersSupergrid.ValidatorHighlightFontStyle = System.Drawing.FontStyle.Bold;
      this.OrdersSupergrid.ValidatorHighlightType = Actemium.Windows.Forms.SuperGrid.SuperGrid.ValidatorHighlightTypes.BackgroundColor;
      this.OrdersSupergrid.SelectionChanged += OrdersSupergrid_SelectionChanged;

      // 
      // OrdersStartStopOrderGroupBox
      // 
      this.OrdersStartStopOrderGroupBox.BorderColor = System.Drawing.SystemColors.ActiveBorder;
      this.OrdersStartStopOrderGroupBox.Controls.Add(this.OrdersStartOrderButtonX);
      this.OrdersStartStopOrderGroupBox.Controls.Add(this.OrdersStopOrderButtonX);
      this.OrdersStartStopOrderGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.OrdersStartStopOrderGroupBox.Location = new System.Drawing.Point(0, 579);
      this.OrdersStartStopOrderGroupBox.Margin = new System.Windows.Forms.Padding(1);
      this.OrdersStartStopOrderGroupBox.Name = "OrdersStartStopOrderGroupBox";
      this.OrdersStartStopOrderGroupBox.Padding = new System.Windows.Forms.Padding(1);
      this.OrdersStartStopOrderGroupBox.Size = new System.Drawing.Size(1016, 60);
      this.OrdersStartStopOrderGroupBox.TabIndex = 19;
      this.OrdersStartStopOrderGroupBox.TabStop = false;
      this.OrdersStartStopOrderGroupBox.TextColor = System.Drawing.SystemColors.MenuHighlight;
      // 
      // OrdersStartOrderButtonX
      // 
      this.OrdersStartOrderButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.OrdersStartOrderButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
      this.OrdersStartOrderButtonX.Font = new System.Drawing.Font("Tahoma", 12F);
      this.OrdersStartOrderButtonX.Location = new System.Drawing.Point(792, 16);
      this.OrdersStartOrderButtonX.Name = "OrdersStartOrderButtonX";
      this.OrdersStartOrderButtonX.Size = new System.Drawing.Size(103, 33);
      this.OrdersStartOrderButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      this.OrdersStartOrderButtonX.TabIndex = 3;
      this.OrdersStartOrderButtonX.Text = "Start Order";
      this.OrdersStartOrderButtonX.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
      this.OrdersStartOrderButtonX.Translate = false;
      this.OrdersStartOrderButtonX.Click += OrdersStartOrderButtonX_Click;
      // 
      // OrdersStopOrderButtonX
      // 
      this.OrdersStopOrderButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.OrdersStopOrderButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
      this.OrdersStopOrderButtonX.Font = new System.Drawing.Font("Tahoma", 12F);
      this.OrdersStopOrderButtonX.Location = new System.Drawing.Point(901, 17);
      this.OrdersStopOrderButtonX.Name = "OrdersStopOrderButtonX";
      this.OrdersStopOrderButtonX.Size = new System.Drawing.Size(103, 33);
      this.OrdersStopOrderButtonX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      this.OrdersStopOrderButtonX.TabIndex = 2;
      this.OrdersStopOrderButtonX.Text = "Stop Order";
      this.OrdersStopOrderButtonX.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
      this.OrdersStopOrderButtonX.Translate = false;
      this.OrdersStopOrderButtonX.Click += OrdersStopOrderButtonX_Click;
      // 
      // OrdersPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.BackColor = System.Drawing.Color.LightGray;
      this.ClientSize = new System.Drawing.Size(1016, 639);
      this.Controls.Add(this.OrdersStartStopOrderGroupBox);
      this.Controls.Add(this.OrdersSupergrid);
      this.Controls.Add(this.OrdersPanelSplitter);
      this.Controls.Add(this.OrdersSettingsGroupBox);
      this.DoubleBuffered = true;
      this.ForeColor = System.Drawing.SystemColors.ControlText;
      this.KeyPreview = true;
      this.Name = "OrdersPage";
      this.Resize += new System.EventHandler(this.OrdersPageResize);
      this.OrdersSettingsGroupBox.ResumeLayout(false);
      this.OrdersStartStopOrderGroupBox.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private Windows.Forms.GroupBox OrdersSettingsGroupBox;
        private System.Windows.Forms.ComboBox OrdersPredefinedFilterDropdownX;
        private Windows.Forms.DevComponents2.Controls.LabelX OrdersPredefinedFilterLabelX;
        private Windows.Forms.DevComponents2.Controls.ButtonX OrdersFilterApplyButtonX;
        private Windows.Forms.DevComponents2.Controls.ButtonX OrdersFilterResetButtonX;
        private Windows.Forms.DevComponents2.Controls.LabelX OrdersToDateTimeFilterLabelX;
        private Windows.Forms.DevComponents2.Controls.LabelX OrdersFromDateTimeFilterLabelX;
        private Windows.Forms.DevComponents2.Controls.LabelX OrdersActualFilterLabelX;
        private System.Windows.Forms.Splitter OrdersPanelSplitter;
        private Windows.Forms.SuperGrid.SuperGrid OrdersSupergrid;
        private System.Windows.Forms.DateTimePicker OrdersFromDateFilterInput;
        private System.Windows.Forms.DateTimePicker OrdersToDateFilterInput;
        private LabelX OrdersToTimeFilterLabel;
        private LabelX OrdersFromTimeFilterLabel;
        private TextBoxX OrdersToTimeFilterTextBox;
        private TextBoxX OrdersFromTimeFilterTextBox;
        private Windows.Forms.GroupBox OrdersStartStopOrderGroupBox;
        private ButtonX OrdersStartOrderButtonX;
        private ButtonX OrdersStopOrderButtonX;
    }
}
