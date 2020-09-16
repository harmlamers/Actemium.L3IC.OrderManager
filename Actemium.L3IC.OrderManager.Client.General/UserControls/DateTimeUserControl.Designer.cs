using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.UserControls
{
	partial class DateTimeUserControl
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
			this.nowCheckBox = new Actemium.Windows.Forms.DevComponents2.Controls.CheckBoxX();
			this.lblStartTime = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.dateDateTimeInput = new Actemium.Windows.Forms.DevComponents2.Controls.DateTimeInput(this.components);
			this.timeTextBox = new Actemium.Windows.Forms.DevComponents2.Controls.MaskedTextBoxAdv(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dateDateTimeInput)).BeginInit();
			this.SuspendLayout();
			// 
			// nowCheckBox
			// 
			this.nowCheckBox.AutoSize = true;
			// 
			// 
			// 
			this.nowCheckBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.nowCheckBox.Checked = true;
			this.nowCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nowCheckBox.CheckValue = "Y";
			this.nowCheckBox.Location = new System.Drawing.Point(242, 2);
			this.nowCheckBox.Name = "nowCheckBox";
			this.nowCheckBox.Size = new System.Drawing.Size(45, 15);
			this.nowCheckBox.TabIndex = 80;
			this.nowCheckBox.Text = "Now";
			this.nowCheckBox.Translate = true;
			this.nowCheckBox.CheckedChanged += new System.EventHandler(this.NowCheckBoxCheckedChanged);
			// 
			// lblStartTime
			// 
			this.lblStartTime.AutoSize = true;
			// 
			// 
			// 
			this.lblStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblStartTime.Location = new System.Drawing.Point(192, 3);
			this.lblStartTime.Name = "lblStartTime";
			this.lblStartTime.Size = new System.Drawing.Size(40, 15);
			this.lblStartTime.TabIndex = 79;
			this.lblStartTime.Text = "HH:MM";
			this.lblStartTime.Translate = true;
			// 
			// dateDateTimeInput
			// 
			// 
			// 
			// 
			this.dateDateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dateDateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateDateTimeInput.ButtonDropDown.Visible = true;
			this.dateDateTimeInput.CustomFormat = "dd-MM-yyyy";
			this.dateDateTimeInput.Enabled = false;
			this.dateDateTimeInput.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dateDateTimeInput.IsPopupCalendarOpen = false;
			this.dateDateTimeInput.Location = new System.Drawing.Point(0, 0);
			this.dateDateTimeInput.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
			// 
			// 
			// 
			this.dateDateTimeInput.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dateDateTimeInput.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
			this.dateDateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateDateTimeInput.MonthCalendar.ClearButtonVisible = true;
			// 
			// 
			// 
			this.dateDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dateDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dateDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dateDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dateDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dateDateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dateDateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateDateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2010, 2, 1, 0, 0, 0, 0);
			this.dateDateTimeInput.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
			this.dateDateTimeInput.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dateDateTimeInput.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dateDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dateDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dateDateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dateDateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dateDateTimeInput.MonthCalendar.TodayButtonVisible = true;
			this.dateDateTimeInput.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dateDateTimeInput.Name = "dateDateTimeInput";
			this.dateDateTimeInput.Size = new System.Drawing.Size(136, 20);
			this.dateDateTimeInput.TabIndex = 77;
			// 
			// timeTextBox
			// 
			// 
			// 
			// 
			this.timeTextBox.BackgroundStyle.Class = "TextBoxBorder";
			this.timeTextBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.timeTextBox.Location = new System.Drawing.Point(142, 0);
			this.timeTextBox.Mask = "00:00";
			this.timeTextBox.Name = "timeTextBox";
			this.timeTextBox.PromptChar = '-';
			this.timeTextBox.Size = new System.Drawing.Size(44, 19);
			this.timeTextBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.timeTextBox.TabIndex = 82;
			this.timeTextBox.Text = "";
			this.timeTextBox.ValidatingType = typeof(System.DateTime);
			// 
			// DateTimeUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.timeTextBox);
			this.Controls.Add(this.nowCheckBox);
			this.Controls.Add(this.lblStartTime);
			this.Controls.Add(this.dateDateTimeInput);
			this.Name = "DateTimeUserControl";
			this.Size = new System.Drawing.Size(290, 20);
			((System.ComponentModel.ISupportInitialize)(this.dateDateTimeInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Actemium.Windows.Forms.DevComponents2.Controls.CheckBoxX nowCheckBox;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblStartTime;
		private Actemium.Windows.Forms.DevComponents2.Controls.DateTimeInput dateDateTimeInput;
		private Windows.Forms.DevComponents2.Controls.MaskedTextBoxAdv timeTextBox;
	}
}
