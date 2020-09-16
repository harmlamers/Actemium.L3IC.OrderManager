using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.UserControls
{
  partial class PeriodFilterUserControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			this.components = new System.ComponentModel.Container();
			this.btnApplyFilter = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
			this.btnRemoveFilter = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
			this.mtbStartofPeriod = new System.Windows.Forms.MaskedTextBox();
			this.dtiStartofPeriod = new Actemium.Windows.Forms.DevComponents2.Controls.DateTimeInput(this.components);
			this.mtbEndofPeriod = new System.Windows.Forms.MaskedTextBox();
			this.dtiEndofPeriod = new Actemium.Windows.Forms.DevComponents2.Controls.DateTimeInput(this.components);
			this.cbPredefinedPeriods = new Actemium.Windows.Forms.DevComponents2.Controls.ComboBoxEx(this.components);
			this.lblTo = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.lblFrom = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.expnlFilter = new DevComponents.DotNetBar.ExpandablePanel();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dtiStartofPeriod)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtiEndofPeriod)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.expnlFilter.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnApplyFilter
			// 
			this.btnApplyFilter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnApplyFilter.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_OK_16;
			this.btnApplyFilter.Location = new System.Drawing.Point(639, 28);
			this.btnApplyFilter.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
			this.btnApplyFilter.Name = "btnApplyFilter";
			this.btnApplyFilter.Size = new System.Drawing.Size(100, 25);
			this.btnApplyFilter.TabIndex = 2;
			this.btnApplyFilter.Text = "Filter";
			this.btnApplyFilter.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
			this.btnApplyFilter.Translate = true;
			this.btnApplyFilter.Click += new System.EventHandler(this.BtnApplyFilterClick);
			// 
			// btnRemoveFilter
			// 
			this.btnRemoveFilter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnRemoveFilter.Enabled = false;
			this.btnRemoveFilter.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_ApplicationExit_16;
			this.btnRemoveFilter.Location = new System.Drawing.Point(745, 28);
			this.btnRemoveFilter.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
			this.btnRemoveFilter.Name = "btnRemoveFilter";
			this.btnRemoveFilter.Size = new System.Drawing.Size(100, 25);
			this.btnRemoveFilter.TabIndex = 3;
			this.btnRemoveFilter.Text = "No filter";
			this.btnRemoveFilter.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
			this.btnRemoveFilter.Translate = true;
			this.btnRemoveFilter.Click += new System.EventHandler(this.BtnRemoveFilterClick);
			// 
			// mtbStartofPeriod
			// 
			this.mtbStartofPeriod.Location = new System.Drawing.Point(159, 31);
			this.mtbStartofPeriod.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
			this.mtbStartofPeriod.Mask = "##:##";
			this.mtbStartofPeriod.Name = "mtbStartofPeriod";
			this.mtbStartofPeriod.PromptChar = '-';
			this.mtbStartofPeriod.Size = new System.Drawing.Size(44, 20);
			this.mtbStartofPeriod.TabIndex = 40;
			this.mtbStartofPeriod.TextChanged += new System.EventHandler(this.ManualValueChanged);
			this.mtbStartofPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MtbStartofPeriodKeyDown);
			// 
			// dtiStartofPeriod
			// 
			// 
			// 
			// 
			this.dtiStartofPeriod.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dtiStartofPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtiStartofPeriod.ButtonDropDown.Visible = true;
			this.dtiStartofPeriod.CustomFormat = "dd-MM-yyyy";
			this.dtiStartofPeriod.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dtiStartofPeriod.IsPopupCalendarOpen = false;
			this.dtiStartofPeriod.Location = new System.Drawing.Point(32, 31);
			this.dtiStartofPeriod.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
			this.dtiStartofPeriod.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
			// 
			// 
			// 
			this.dtiStartofPeriod.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtiStartofPeriod.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
			this.dtiStartofPeriod.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtiStartofPeriod.MonthCalendar.ClearButtonVisible = true;
			// 
			// 
			// 
			this.dtiStartofPeriod.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dtiStartofPeriod.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dtiStartofPeriod.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dtiStartofPeriod.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dtiStartofPeriod.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dtiStartofPeriod.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dtiStartofPeriod.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtiStartofPeriod.MonthCalendar.DisplayMonth = new System.DateTime(2010, 2, 1, 0, 0, 0, 0);
			this.dtiStartofPeriod.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
			this.dtiStartofPeriod.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dtiStartofPeriod.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtiStartofPeriod.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dtiStartofPeriod.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dtiStartofPeriod.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dtiStartofPeriod.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtiStartofPeriod.MonthCalendar.TodayButtonVisible = true;
			this.dtiStartofPeriod.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dtiStartofPeriod.Name = "dtiStartofPeriod";
			this.dtiStartofPeriod.Size = new System.Drawing.Size(121, 20);
			this.dtiStartofPeriod.TabIndex = 39;
			this.dtiStartofPeriod.ValueChanged += new System.EventHandler(this.ManualValueChanged);
			this.dtiStartofPeriod.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DtiStartofPeriodPreviewKeyDown);
			// 
			// mtbEndofPeriod
			// 
			this.mtbEndofPeriod.Location = new System.Drawing.Point(362, 31);
			this.mtbEndofPeriod.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
			this.mtbEndofPeriod.Mask = "##:##";
			this.mtbEndofPeriod.Name = "mtbEndofPeriod";
			this.mtbEndofPeriod.PromptChar = '-';
			this.mtbEndofPeriod.Size = new System.Drawing.Size(44, 20);
			this.mtbEndofPeriod.TabIndex = 43;
			this.mtbEndofPeriod.TextChanged += new System.EventHandler(this.ManualValueChanged);
			this.mtbEndofPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MtbEndofPeriodKeyDown);
			// 
			// dtiEndofPeriod
			// 
			// 
			// 
			// 
			this.dtiEndofPeriod.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dtiEndofPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtiEndofPeriod.ButtonDropDown.Visible = true;
			this.dtiEndofPeriod.CustomFormat = "dd-MM-yyyy";
			this.dtiEndofPeriod.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dtiEndofPeriod.IsPopupCalendarOpen = false;
			this.dtiEndofPeriod.Location = new System.Drawing.Point(235, 31);
			this.dtiEndofPeriod.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
			this.dtiEndofPeriod.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
			// 
			// 
			// 
			this.dtiEndofPeriod.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtiEndofPeriod.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
			this.dtiEndofPeriod.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtiEndofPeriod.MonthCalendar.ClearButtonVisible = true;
			// 
			// 
			// 
			this.dtiEndofPeriod.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dtiEndofPeriod.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dtiEndofPeriod.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dtiEndofPeriod.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dtiEndofPeriod.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dtiEndofPeriod.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dtiEndofPeriod.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtiEndofPeriod.MonthCalendar.DisplayMonth = new System.DateTime(2010, 2, 1, 0, 0, 0, 0);
			this.dtiEndofPeriod.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
			this.dtiEndofPeriod.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dtiEndofPeriod.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtiEndofPeriod.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dtiEndofPeriod.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dtiEndofPeriod.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dtiEndofPeriod.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtiEndofPeriod.MonthCalendar.TodayButtonVisible = true;
			this.dtiEndofPeriod.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dtiEndofPeriod.Name = "dtiEndofPeriod";
			this.dtiEndofPeriod.Size = new System.Drawing.Size(121, 20);
			this.dtiEndofPeriod.TabIndex = 42;
			this.dtiEndofPeriod.ValueChanged += new System.EventHandler(this.ManualValueChanged);
			this.dtiEndofPeriod.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DtiEndofPeriodPreviewKeyDown);
			// 
			// cbPredefinedPeriods
			// 
			this.cbPredefinedPeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPredefinedPeriods.FormattingEnabled = true;
			this.cbPredefinedPeriods.Location = new System.Drawing.Point(416, 31);
			this.cbPredefinedPeriods.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
			this.cbPredefinedPeriods.Name = "cbPredefinedPeriods";
			this.cbPredefinedPeriods.Size = new System.Drawing.Size(216, 21);
			this.cbPredefinedPeriods.TabIndex = 45;
			this.cbPredefinedPeriods.SelectedIndexChanged += new System.EventHandler(this.CbPredefinedPeriodsSelectedIndexChanged);
			this.cbPredefinedPeriods.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CbPredefinedPeriodsKeyDown);
			// 
			// lblTo
			// 
			this.lblTo.AutoSize = true;
			this.lblTo.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.lblTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblTo.Location = new System.Drawing.Point(210, 34);
			this.lblTo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(15, 15);
			this.lblTo.TabIndex = 47;
			this.lblTo.Text = "To";
			this.lblTo.Translate = true;
			// 
			// lblFrom
			// 
			this.lblFrom.AutoSize = true;
			this.lblFrom.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.lblFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblFrom.Location = new System.Drawing.Point(4, 34);
			this.lblFrom.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(28, 15);
			this.lblFrom.TabIndex = 46;
			this.lblFrom.Text = "From";
			this.lblFrom.Translate = true;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// expnlFilter
			// 
			this.expnlFilter.CanvasColor = System.Drawing.SystemColors.Control;
			this.expnlFilter.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.expnlFilter.Controls.Add(this.dtiStartofPeriod);
			this.expnlFilter.Controls.Add(this.dtiEndofPeriod);
			this.expnlFilter.Controls.Add(this.mtbEndofPeriod);
			this.expnlFilter.Controls.Add(this.lblTo);
			this.expnlFilter.Controls.Add(this.mtbStartofPeriod);
			this.expnlFilter.Controls.Add(this.lblFrom);
			this.expnlFilter.Controls.Add(this.btnApplyFilter);
			this.expnlFilter.Controls.Add(this.cbPredefinedPeriods);
			this.expnlFilter.Controls.Add(this.btnRemoveFilter);
			this.expnlFilter.ExpandOnTitleClick = true;
			this.expnlFilter.Location = new System.Drawing.Point(0, 0);
			this.expnlFilter.Name = "expnlFilter";
			this.expnlFilter.Size = new System.Drawing.Size(850, 60);
			this.expnlFilter.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.expnlFilter.Style.BackColor1.Color = System.Drawing.Color.LightGray;
			this.expnlFilter.Style.BackColor2.Color = System.Drawing.Color.LightGray;
			this.expnlFilter.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.expnlFilter.Style.BorderColor.Color = System.Drawing.Color.DarkGray;
			this.expnlFilter.Style.CornerDiameter = 1;
			this.expnlFilter.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
			this.expnlFilter.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expnlFilter.Style.GradientAngle = 90;
			this.expnlFilter.TabIndex = 52;
			this.expnlFilter.TitleHeight = 25;
			this.expnlFilter.TitleStyle.BackColor1.Color = System.Drawing.Color.LightGray;
			this.expnlFilter.TitleStyle.BackColor2.Color = System.Drawing.Color.LightGray;
			this.expnlFilter.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
			this.expnlFilter.TitleStyle.BorderColor.Color = System.Drawing.Color.DarkGray;
			this.expnlFilter.TitleStyle.CornerDiameter = 1;
			this.expnlFilter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
			this.expnlFilter.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.expnlFilter.TitleStyle.GradientAngle = 90;
			this.expnlFilter.TitleStyle.MarginLeft = 4;
			this.expnlFilter.TitleText = "Period filter - No filter applied";
			this.expnlFilter.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.ExpnlFilterExpandedChanged);
			// 
			// refreshTimer
			// 
			this.refreshTimer.Interval = 1000;
			this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimerTick);
			// 
			// PeriodFilterUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.expnlFilter);
			this.MaximumSize = new System.Drawing.Size(850, 60);
			this.MinimumSize = new System.Drawing.Size(850, 0);
			this.Name = "PeriodFilterUserControl";
			this.Size = new System.Drawing.Size(850, 60);
			((System.ComponentModel.ISupportInitialize)(this.dtiStartofPeriod)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtiEndofPeriod)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.expnlFilter.ResumeLayout(false);
			this.expnlFilter.PerformLayout();
			this.ResumeLayout(false);

    }

    #endregion

    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnApplyFilter;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnRemoveFilter;
    private System.Windows.Forms.MaskedTextBox mtbStartofPeriod;
    private Actemium.Windows.Forms.DevComponents2.Controls.DateTimeInput dtiStartofPeriod;
    private System.Windows.Forms.MaskedTextBox mtbEndofPeriod;
    private Actemium.Windows.Forms.DevComponents2.Controls.DateTimeInput dtiEndofPeriod;
    private Actemium.Windows.Forms.DevComponents2.Controls.ComboBoxEx cbPredefinedPeriods;
    private System.Windows.Forms.ErrorProvider errorProvider;
    private DevComponents.DotNetBar.ExpandablePanel expnlFilter;
    private System.Windows.Forms.Timer refreshTimer;
    private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblTo;
    private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblFrom;
  }
}
