using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Translations;
using Actemium.Windows.Forms.DevComponents2.Interfaces;

namespace Actemium.L3IC.OrderManager.Client.General.UserControls
{
	public partial class PeriodFilterUserControl : UserControl, IInitializeControl, ITranslatableControl
	{
		private const string CLASSNAME = nameof(PeriodFilterUserControl);

		private Boolean _automaticChange;
		private DateTime _lastAutoChange;

		private class PredefinedPeriod
		{
			public int Id { get; }

		  public String Description { get; }

		  public TimeSpan DurationPast { get; }

		  public TimeSpan DurationFuture { get; }

		  public PredefinedPeriod(PredefinedPeriodsEnum id, String description, TimeSpan durationPast, TimeSpan durationFuture)
			{
				Id = (int)id;
				Description = description;
				DurationPast = durationPast;
				DurationFuture = durationFuture;
			}
		}

		private readonly List<PredefinedPeriod> _predefinedPeriods = new List<PredefinedPeriod>();

    public enum PredefinedPeriodsEnum
    {
      PastYears4AndNextDays7 = -35040,
      NextDays_14 = -336,
      NextDays_7 = -168,
      NextDays_3 = -72,
      NextHours_24 = -24,
      NextHours_8 = -8,
      NextHours_4 = -4,
      PastAndNextDays_7 = -2,
      Customized = -1,
      PastHours_4 = 4,
      PastHours_8 = 8,
      PastHours_24 = 24,
      PastDays_3 = 72,
      PastDays_7 = 168,
      PastDays_14 = 336,
      PastDays_100 = 2400,
    }

    #region User Control properties
    /// <summary>
    /// Gets the current Start of Period of the selected filter.
    /// </summary>
    [Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DateTime? StartOfPeriod { get; private set; } = null;

	  /// <summary>
		/// Gets the current End of Period of the selected filter.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DateTime? EndOfPeriod { get; private set; } = null;

	  /// <summary>
		/// Gets / sets the default selected period of the filter.
		/// </summary>
		[Category("Actemium")]
		[Description("Gets / sets the default selected period of the filter.")]
		public PredefinedPeriodsEnum DefaultPeriod
		{
			get => _defaultPeriod;
	    set
			{
				try
				{
					_defaultPeriod = value;
					FillPredefinedPeriods();
					CheckAndSetFilter(!_defaultFiltered, true, false);
				}
				catch (Exception ex)
				{
					Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, value);
				}
			}
		}

    private PredefinedPeriodsEnum _defaultPeriod = PredefinedPeriodsEnum.PastHours_24;

		/// <summary>
		/// Gets / sets the default status of the filter.
		/// </summary>
		[Category("Actemium")]
		[Description("Gets / sets the default status of the filter.")]
		public Boolean DefaultFiltered
		{
			get => _defaultFiltered;
		  set
			{
				try
				{
					_defaultFiltered = _mandatory || value;
					CheckAndSetFilter(!_defaultFiltered, true, false);
				}
				catch (Exception ex)
				{
					Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, value);
				}
			}
		}

    private Boolean _defaultFiltered = false;

		/// <summary>
		/// Gets / sets the interval on which the filter is re-applied (thus triggering the FilterApplied event. (value in seconds).
		/// </summary>
		[Category("Actemium")]
		[Description(" Gets / sets the interval on which the filter is re-applied (thus triggering the FilterApplied event. (value in seconds).")]
		public Int32? AutoApplyInterval { get; set; } = null;

	  /// <summary>
		/// Gets / sets the expanded value. When true the control is expanded, when false the control is collapsed.
		/// </summary>
		[Category("Actemium")]
		[Description("Gets / sets the expanded value. When true the control is expanded, when false the control is collapsed.")]
		public Boolean Expanded
		{
			get => expnlFilter.Expanded;
	    set => expnlFilter.Expanded = value;
	  }

		/// <summary>
		/// Gets / sets  the mandatory value. When true, filtering is mandatory and the filter can't be disabled.
		/// </summary>
		[Category("Actemium")]
		[Description("Gets / sets  the mandatory value. When true, filtering is mandatory and the filter can't be disabled.")]
		public Boolean Mandatory
		{
			get => _mandatory;
		  set
			{
				try
				{
					_mandatory = value;
					_defaultFiltered = value || _defaultFiltered;
					btnRemoveFilter.Enabled = !value;
					CheckAndSetFilter(!_defaultFiltered, true, false);
				}
				catch (Exception ex)
				{
					Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, value);
				}
			}
		}

    private Boolean _mandatory = false;

		/// <summary>
		/// Gets the actual visible size of the control.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Int32 HeightVisible { get; private set; }

	  [Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Boolean ManualFiltered { get; private set; }

	  #endregion

		public void ResetFilter(PredefinedPeriodsEnum predefinedPeriod)
		{
			cbPredefinedPeriods.SelectedValue = (Int32)predefinedPeriod;
			CheckAndSetFilter(true, false, false);
		}

		#region Public Events
		public class ApplyEventArgs : EventArgs
		{
			public Boolean Automatic { get; }

		  public DateTime? StartOfPeriod { get; }

		  public DateTime? EndOfPeriod { get; }

		  public ApplyEventArgs(DateTime? startOfPeriod, DateTime? endOfPeriod, bool automatic)
			{
				Automatic = automatic;
				StartOfPeriod = startOfPeriod;
				EndOfPeriod = endOfPeriod;
			}
		}

		public delegate void ApplyEventHandler(object sender, ApplyEventArgs e);

		/// <summary>
		/// Will be triggered when the filter value has been changed
		/// </summary>
		public event ApplyEventHandler FilterApplied;

		/// <summary>
		/// Will be triggerd when the control is expanded or closed
		/// </summary>
		public event EventHandler ExpandedChanged;
		#endregion


		public PeriodFilterUserControl()
		{
			_automaticChange = true;

			InitializeComponent();

			HeightVisible = expnlFilter.Height;
			FillPredefinedPeriods();
			btnRemoveFilter.Enabled = _mandatory;

			refreshTimer.Start();

			_lastAutoChange = DateTime.Now;
			_automaticChange = false;
			ManualFiltered = true;
		}


		private void FillPredefinedPeriods()
		{
			try
			{
				_automaticChange = true;

				_predefinedPeriods.Add(new PredefinedPeriod(PredefinedPeriodsEnum.Customized, Translation.IsInitialized ? Translations.PeriodFilterUserControl.ManualSelection : "Manual", new TimeSpan(), new TimeSpan()));
				_predefinedPeriods.Add(new PredefinedPeriod(PredefinedPeriodsEnum.PastHours_4, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Last4Hours : "Last 4 hours", new TimeSpan(-4, 0, 0), new TimeSpan()));
				_predefinedPeriods.Add(new PredefinedPeriod(PredefinedPeriodsEnum.PastHours_8, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Last8Hours : "Last 8 hours", new TimeSpan(-8, 0, 0), new TimeSpan()));
				_predefinedPeriods.Add(new PredefinedPeriod(PredefinedPeriodsEnum.PastHours_24, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Last24Hours : "Last 24 hours", new TimeSpan(-24, 0, 0), new TimeSpan()));
				_predefinedPeriods.Add(new PredefinedPeriod(PredefinedPeriodsEnum.PastDays_3, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Last3Days : "Last 3 days", new TimeSpan(-72, 0, 0), new TimeSpan()));
				_predefinedPeriods.Add(new PredefinedPeriod(PredefinedPeriodsEnum.PastDays_7, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Last7Days : "Last 7 days", new TimeSpan(-168, 0, 0), new TimeSpan()));
				_predefinedPeriods.Add(new PredefinedPeriod(PredefinedPeriodsEnum.PastDays_14, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Last14Days : "Last 14 days", new TimeSpan(-336, 0, 0), new TimeSpan()));
				_predefinedPeriods.Add(new PredefinedPeriod(PredefinedPeriodsEnum.PastDays_100, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Last100Days : "Last 100 days", new TimeSpan(-2400, 0, 0), new TimeSpan()));
        //PredefinedPeriods.Add(new PredefinedPeriod(-336, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Next14days : "Next 14 days", new TimeSpan(336, 0, 0)));
        //PredefinedPeriods.Add(new PredefinedPeriod(-168, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Next7days : "Next 7 days", new TimeSpan(168, 0, 0)));
        //PredefinedPeriods.Add(new PredefinedPeriod(-72, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Next3days : "Next 3 days", new TimeSpan(72, 0, 0)));
        //PredefinedPeriods.Add(new PredefinedPeriod(-24, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Next24hours : "Next 24 hours", new TimeSpan(24, 0, 0)));
        //PredefinedPeriods.Add(new PredefinedPeriod(-8, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Next8hours : "Next 8 hours", new TimeSpan(8, 0, 0)));
        //PredefinedPeriods.Add(new PredefinedPeriod(-4, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Next4hours : "Next 4 hours", new TimeSpan(4, 0, 0)));
        _predefinedPeriods.Add(new PredefinedPeriod(PredefinedPeriodsEnum.PastAndNextDays_7, Translation.IsInitialized ? Translations.PeriodFilterUserControl.PastAndNext7Days : "Last and next 7 days", new TimeSpan(-168, 0, 0), new TimeSpan(168, 0, 0)));
				_predefinedPeriods.Add(new PredefinedPeriod(PredefinedPeriodsEnum.PastYears4AndNextDays7, Translation.IsInitialized ? Translations.PeriodFilterUserControl.Past4YearsAndNext7Days : "Last 4 years and next 7 days", new TimeSpan(-35040, 0, 0), new TimeSpan(168, 0, 0)));

				cbPredefinedPeriods.ValueMember = "Id";
				cbPredefinedPeriods.DisplayMember = "Description";
				cbPredefinedPeriods.DataSource = _predefinedPeriods;

				cbPredefinedPeriods.SelectedValue = (Int32)DefaultPeriod;

				_automaticChange = false;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}

		private void CheckAndSetFilter(Boolean resetFilter, Boolean noEventTrigger, Boolean automatic)
		{
			try
			{
				_automaticChange = true;

				DateTime? newStartofPeriod = null;
				DateTime? newEndofPeriod = null;

				bool hasError = false;


				if (!resetFilter && mtbStartofPeriod.MaskFull && (!dtiStartofPeriod.IsEmpty))
				{
					Int32 hour = Convert.ToInt32(mtbStartofPeriod.Text.Substring(0, 2));
					Int32 minute = Convert.ToInt32(mtbStartofPeriod.Text.Substring(3, 2));

          if ((hour < 0) || (hour > 23) || (minute < 0) || (minute > 59))
          {
            hasError = true;
            errorProvider.SetError(mtbStartofPeriod, Translation.IsInitialized ? Translation.Instance.Translate(TranslationKey.PeriodFilter_InvalidTime, "Invalid time...") : "Invalid time...");
          }
          else
          {
            newStartofPeriod = new DateTime(dtiStartofPeriod.Value.Year, dtiStartofPeriod.Value.Month, dtiStartofPeriod.Value.Day, hour, minute, 0, DateTimeKind.Local);
          }
        }

				if (!resetFilter && mtbEndofPeriod.MaskFull && (!dtiEndofPeriod.IsEmpty))
				{
					Int32 hour = Convert.ToInt32(mtbEndofPeriod.Text.Substring(0, 2));
					Int32 minute = Convert.ToInt32(mtbEndofPeriod.Text.Substring(3, 2));

          if ((hour < 0) || (hour > 23) || (minute < 0) || (minute > 59))
          {
            hasError = true;
            errorProvider.SetError(mtbEndofPeriod, Translation.IsInitialized ? Translation.Instance.Translate(TranslationKey.PeriodFilter_InvalidTime, "Invalid time...") : "Invalid time...");
          }
          else
          {
            newEndofPeriod = new DateTime(dtiEndofPeriod.Value.Year, dtiEndofPeriod.Value.Month, dtiEndofPeriod.Value.Day, hour, minute, 0, DateTimeKind.Local);
          }
        }

				if (!hasError)
				{
					StartOfPeriod = newStartofPeriod;
					EndOfPeriod = newEndofPeriod;

					var manual = Translation.IsInitialized ? Translations.PeriodFilterUserControl.Manual : "(Manual)";
					var current = Translation.IsInitialized ? Translations.PeriodFilterUserControl.Current : "(Current)";

					if (StartOfPeriod.HasValue && EndOfPeriod.HasValue)
						expnlFilter.TitlePanel.Text = Translation.IsInitialized ? string.Format(Translations.PeriodFilterUserControl.FilteredFromSelected, StartOfPeriod.Value, EndOfPeriod.Value, (int)cbPredefinedPeriods.SelectedValue == -1 ? manual : current) : $"Period filter - Filtered from {StartOfPeriod.Value:dd-MM-yyyy HH:mm} to {EndOfPeriod.Value:dd-MM-yyyy HH:mm} {( (int)cbPredefinedPeriods.SelectedValue == -1 ? manual : current )}";
					else if (StartOfPeriod.HasValue && !EndOfPeriod.HasValue)
						expnlFilter.TitlePanel.Text = Translation.IsInitialized ? string.Format(Translations.PeriodFilterUserControl.FilterdFrom, StartOfPeriod.Value, (int)cbPredefinedPeriods.SelectedValue == -1 ? (" " + manual) : (" " + current)) : $"Period filter - Filtered from {StartOfPeriod.Value:dd-MM-yyyy HH:mm} {( (int)cbPredefinedPeriods.SelectedValue == -1 ? ( " " + manual ) : ( " " + current ) )}";
					else if (!StartOfPeriod.HasValue && EndOfPeriod.HasValue)
						expnlFilter.TitlePanel.Text = Translation.IsInitialized ? string.Format(Translations.PeriodFilterUserControl.FilterdTill, EndOfPeriod.Value, (int)cbPredefinedPeriods.SelectedValue == -1 ? (" " + manual) : (" " + current)) : $"Period filter - Filtered till {EndOfPeriod.Value:dd-MM-yyyy HH:mm} {( (int)cbPredefinedPeriods.SelectedValue == -1 ? ( " " + manual ) : ( " " + current ) )}";
					else
						expnlFilter.TitlePanel.Text = Translation.IsInitialized ? Translations.PeriodFilterUserControl.NoFilter : "Period filter - No filter used";

					btnRemoveFilter.Enabled = !_mandatory && !resetFilter;

					if (!noEventTrigger)
						FilterApplied?.Invoke(this, new ApplyEventArgs(StartOfPeriod, EndOfPeriod, automatic));
				}

				_automaticChange = false;
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0}, {1})", Trace.GetMethodName(), CLASSNAME, ex, resetFilter, noEventTrigger);
				throw;
			}
		}


		#region Form Events
		private void BtnApplyFilterClick(object sender, EventArgs e)
		{
			try
			{
				CheckAndSetFilter(false, false, false);
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
			}
		}

		private void BtnRemoveFilterClick(object sender, EventArgs e)
		{
			try
			{
				CheckAndSetFilter(true, false, false);
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
			}
		}


		private void ManualValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (!_automaticChange)
					cbPredefinedPeriods.SelectedValue = -1;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
			}
		}

		private void CbPredefinedPeriodsSelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if ((int)cbPredefinedPeriods.SelectedValue != -1)
				{
					_automaticChange = true;

					//dtiEndofPeriod.Value = DateTime.Now;
					//mtbEndofPeriod.Text = DateTime.Now.ToString("HH:mm");

					dtiEndofPeriod.Value = DateTime.Now.Add(((PredefinedPeriod)cbPredefinedPeriods.SelectedItem).DurationFuture);
					mtbEndofPeriod.Text = DateTime.Now.Add(((PredefinedPeriod)cbPredefinedPeriods.SelectedItem).DurationFuture).ToString("HH:mm");

					dtiStartofPeriod.Value = DateTime.Now.Add(((PredefinedPeriod)cbPredefinedPeriods.SelectedItem).DurationPast);
					mtbStartofPeriod.Text = DateTime.Now.Add(((PredefinedPeriod)cbPredefinedPeriods.SelectedItem).DurationPast).ToString("HH:mm");

					_automaticChange = false;
				}

				ManualFiltered = (int)cbPredefinedPeriods.SelectedValue == -1;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}


		private void ExpnlFilterExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
		{
			try
			{
				Height = expnlFilter.Height;
				HeightVisible = expnlFilter.Height;
			  ExpandedChanged?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
			}
		}


		private void RefreshTimerTick(object sender, EventArgs e)
		{
			try
			{
			  if (!Visible || (int)cbPredefinedPeriods.SelectedValue == -1)
          return;

        _automaticChange = true;

			  //dtiEndofPeriod.Value = DateTime.Now;
			  //mtbEndofPeriod.Text = DateTime.Now.ToString("HH:mm");

			  dtiEndofPeriod.Value = DateTime.Now.Add(((PredefinedPeriod)cbPredefinedPeriods.SelectedItem).DurationFuture);
			  mtbEndofPeriod.Text = DateTime.Now.Add(((PredefinedPeriod)cbPredefinedPeriods.SelectedItem).DurationFuture).ToString("HH:mm");

			  dtiStartofPeriod.Value = DateTime.Now.Add(((PredefinedPeriod)cbPredefinedPeriods.SelectedItem).DurationPast);
			  mtbStartofPeriod.Text = DateTime.Now.Add(((PredefinedPeriod)cbPredefinedPeriods.SelectedItem).DurationPast).ToString("HH:mm");

			  if ((EndOfPeriod.HasValue || StartOfPeriod.HasValue) && AutoApplyInterval != null && AutoApplyInterval > 0 && DateTime.Now > _lastAutoChange.AddSeconds((int)AutoApplyInterval))
			  {
			    _lastAutoChange = DateTime.Now;
			    CheckAndSetFilter(false, false, true);
			  }

			  _automaticChange = false;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
			}
		}

		private void DtiStartofPeriodPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				CheckAndSetFilter(false, false, false);
		}

		private void MtbStartofPeriodKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				CheckAndSetFilter(false, false, false);
		}

		private void DtiEndofPeriodPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				CheckAndSetFilter(false, false, false);
		}

		private void MtbEndofPeriodKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				CheckAndSetFilter(false, false, false);
		}

		private void CbPredefinedPeriodsKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				CheckAndSetFilter(false, false, false);
		}
		#endregion

		#region IInitializeControl

		private bool _initialized;

		public void Initialize()
		{
			if (!_initialized)
			{
				// Event removed at desposing in designer file
				Translation.CurrentLanguageChangedEvent += OnLanguageChangedEvent;
				TranslateControl();
			}
			_initialized = true;
		}

		public void Reinitialize()
		{
			if (_initialized)
			{
				// Remove event
				Translation.CurrentLanguageChangedEvent -= OnLanguageChangedEvent;
				_initialized = false;
			}
			Initialize();
		}

		#endregion

		#region ITranslatableControl

		[Browsable(true)]
		[Category("Actemium")]
		[Description("Do not translate this control if set to false")]
		public Boolean Translate { get; set; }
		
		public void OnLanguageChangedEvent(object sender, EventArgs e)
		{
			TranslateControl();
		}

		private void TranslateControl()
		{
		  if (!Translate)
        return;

      var manual = Translation.IsInitialized ? Translations.PeriodFilterUserControl.Manual : "(Manual)";
		  var current = Translation.IsInitialized ? Translations.PeriodFilterUserControl.Current : "(Current)";

		  if (StartOfPeriod.HasValue && EndOfPeriod.HasValue)
		    expnlFilter.TitlePanel.Text = Translation.IsInitialized ? string.Format(Translations.PeriodFilterUserControl.FilteredFromSelected, StartOfPeriod.Value, EndOfPeriod.Value, (int)cbPredefinedPeriods.SelectedValue == -1 ? manual : current) : $"Period filter - Filtered from {StartOfPeriod.Value:dd-MM-yyyy HH:mm} to {EndOfPeriod.Value:dd-MM-yyyy HH:mm} {((int)cbPredefinedPeriods.SelectedValue == -1 ? manual : current)}";
		  else if (StartOfPeriod.HasValue && !EndOfPeriod.HasValue)
		    expnlFilter.TitlePanel.Text = Translation.IsInitialized ? string.Format(Translations.PeriodFilterUserControl.FilterdFrom, StartOfPeriod.Value, (int)cbPredefinedPeriods.SelectedValue == -1 ? (" " + manual) : (" " + current)) : $"Period filter - Filtered from {StartOfPeriod.Value:dd-MM-yyyy HH:mm} {((int)cbPredefinedPeriods.SelectedValue == -1 ? (" " + manual) : (" " + current))}";
		  else if (!StartOfPeriod.HasValue && EndOfPeriod.HasValue)
		    expnlFilter.TitlePanel.Text = Translation.IsInitialized ? string.Format(Translations.PeriodFilterUserControl.FilterdTill, EndOfPeriod.Value, (int)cbPredefinedPeriods.SelectedValue == -1 ? (" " + manual) : (" " + current)) : $"Period filter - Filtered till {EndOfPeriod.Value:dd-MM-yyyy HH:mm} {((int)cbPredefinedPeriods.SelectedValue == -1 ? (" " + manual) : (" " + current))}";
		  else
		    expnlFilter.TitlePanel.Text = Translation.IsInitialized ? Translations.PeriodFilterUserControl.NoFilter : "Period filter - No filter used";
    }
		#endregion

	}
}

