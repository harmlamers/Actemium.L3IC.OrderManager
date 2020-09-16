using System;
using System.Windows.Forms;

namespace Actemium.L3IC.OrderManager.Client.General.UserControls
{
  public partial class DateTimeUserControl : UserControl
	{
		public DateTimeUserControl()
		{
			InitializeComponent();
		}

		public DateTime? Value
		{
			get
			{
				if (nowCheckBox.Checked)
					return DateTime.Now;

				if (dateDateTimeInput.IsEmpty || (timeTextBox.MaskFull == false))
					return null;
				
				int hour = Convert.ToInt32(timeTextBox.Text.Substring(0, 2));
				int minute = Convert.ToInt32(timeTextBox.Text.Substring(3, 2));
				
				return new DateTime(dateDateTimeInput.Value.Year, dateDateTimeInput.Value.Month, dateDateTimeInput.Value.Day, hour, minute, 0, DateTimeKind.Local);
			}
		}

		public void SetValue(DateTime? value, bool now)
		{
			if (now)
			{
				nowCheckBox.Checked = true;
			}
			else
			{
				nowCheckBox.Checked = false;
				if (value != null)
				{
					dateDateTimeInput.Value = value.Value;
					timeTextBox.Text = $"{value.Value.Hour:00}:{value.Value.Minute:00}";
				}
				else
				{
					dateDateTimeInput.IsEmpty = true;
					timeTextBox.Text = "-:--";

				}
			}
		}

		private void NowCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			dateDateTimeInput.Enabled = !nowCheckBox.Checked;
			timeTextBox.Enabled = !nowCheckBox.Checked;
			if (nowCheckBox.Checked)
			{
				dateDateTimeInput.ResetValue();
				timeTextBox.Text = "";
			}
			else
			{
				dateDateTimeInput.Value = DateTime.Now;
				timeTextBox.Text = $"{DateTime.Now.Hour:00}:{DateTime.Now.Minute:00}";
			}
		}
	}
}
