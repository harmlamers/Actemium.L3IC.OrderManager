using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.PopupPages;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Translations;
using Actemium.UserManagement2.Business;
using Actemium.Windows.Forms.DevComponents2.Controls;
using Actemium.Windows.Forms.DevComponents2.Interfaces;

namespace Actemium.L3IC.OrderManager.Client.General.Base
{
  public partial class BasePageForm : DevComponents.DotNetBar.Office2007Form
	{
		private const string CLASSNAME = nameof(BasePageForm);

		public BasePageForm()
		{
			InitializeComponent();
			Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
		}

	  public BasePageForm(NavigationItems navigationItem)
	  {
	    InitializeComponent();

	    Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

	    NavigationItem = navigationItem;
	    //EditModeController.OnEditChanged += EditModeController_OnEditChanged;

	    Title = "<Title not yet defined in Form>";
	  }

    public NavigationItems NavigationItem { get; protected set; }

		public string TranslatedTitle
		{
			get
			{
				if (Title != null) {
					return Translation.IsInitialized ? Translation.Instance.Translate(this, "Title_" + NavigationItem.ToString(), Title) : Title;
				}

				return "";
			}
		}

		public string Title { get; protected set; }
		public string ACICategory { get; protected set; }

		public virtual bool ShowBusyBox
		{
			set => GlobalHandler.ShowBusyBox = value;
		}

		public void AddHistoryAction(TranslationKey translationKey, string message, params object[] messageArgs)
		{
		  try
		  {
        GlobalHandler.AddHistoryAction(translationKey, message, messageArgs);
      }
		  catch (Exception ex)
		  {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
		  }
		}

	  public List<Tuple<string, RibbonBar>> RibbonBars => this._ribbonBars ?? (this._ribbonBars = new List<Tuple<string, RibbonBar>>());

	  private List<Tuple<string, RibbonBar>> _ribbonBars;

    #region Initialize controls

    public new bool DesignMode
		{
			get
			{
				bool isInDesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

			  if (isInDesignMode)
          return true;

        using (var process = System.Diagnostics.Process.GetCurrentProcess())
			  {
			    return process.ProcessName.IndexOf("devenv", StringComparison.InvariantCultureIgnoreCase) >= 0;
			  }

			}
		}

		public void Initialize()
		{
			if (!DesignMode)
			{
				InitializeControls(this);
			}
		}

		private static void InitializeControls(Control parent)
		{
			foreach (Control control in parent.Controls)
			{
			  if (control is IInitializeControl initializeControl)
				{
					initializeControl.Initialize();
				}
				InitializeControls(control);
			}
		}

		#endregion

    protected void ExecuteOnMainThread(Action action)
    {
      if (InvokeRequired) {
				BeginInvoke(action);
			}
			else {
				action();
			}
		}

		#region Call Dialog functions

		public virtual void DisplayError(string methodName, TranslationKey translationKey, string caption, string message, Exception ex, params object[] messageArgs)
		{
			// translate
			caption = Translation.Instance.Translate(translationKey, TranslationSubKey.Caption, caption);
			message = Translation.Instance.Translate(translationKey, TranslationSubKey.Message, $"Error: {message}", messageArgs);
      
		  message = $"Function: {methodName} {message} {ex.Message}";

			const MessageBoxButtons buttons = MessageBoxButtons.OK;
			const MessageBoxIcon icon = MessageBoxIcon.Error;

			Trace.WriteError("ERROR DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", methodName, CLASSNAME, Text, message, buttons);
			int timestamp = Environment.TickCount;

			DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
			Trace.WriteError("ERROR DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", methodName, CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);
		}

		public virtual void DisplayError(string methodName, TranslationKey translationKey, Exception ex, params object[] messageArgs)
		{
			if (ex is ApplicationException || ex is BusinessException) {
				DisplayError(ex.Message, messageArgs);
			}
			else {
				DisplayError(methodName, translationKey, translationKey.GetCommonCaption(), translationKey.GetCommonMessage(), ex, messageArgs);
			}
		}

		public virtual void DisplayError(string message, params object[] mesageArgs)
		{
			DisplayError("Error", message, mesageArgs);
		}

		public virtual void DisplayError(string caption, string message, params object[] messageArgs)
		{
			// translate
			const MessageBoxButtons buttons = MessageBoxButtons.OK;
			const MessageBoxIcon icon = MessageBoxIcon.Error;

			Trace.WriteError("ERROR DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
			int timestamp = Environment.TickCount;

			DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
			Trace.WriteError("ERROR DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);
		}

		public virtual void DisplayError(TranslationKey translationKey, string caption, string message, params object[] messageArgs)
		{
			// translate
			caption = Translation.Instance.Translate(translationKey, TranslationSubKey.Caption, caption);
			message = Translation.Instance.Translate(translationKey, TranslationSubKey.Message, $"Error: {message}", messageArgs);

			const MessageBoxButtons buttons = MessageBoxButtons.OK;
			const MessageBoxIcon icon = MessageBoxIcon.Error;

			Trace.WriteError("ERROR DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
			int timestamp = Environment.TickCount;

			DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
			Trace.WriteError("ERROR DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);
		}

		public virtual void DisplayError(TranslationKey translationKey, params object[] messageArgs)
		{
			DisplayError(translationKey, translationKey.GetCommonCaption(), translationKey.GetCommonMessage(), messageArgs);
		}

		public virtual void DisplayWarning(TranslationKey translationKey, params object[] messageArgs)
		{
			DisplayWarning(translationKey, translationKey.GetCommonCaption(), translationKey.GetCommonMessage(), messageArgs);
		}

		public virtual void DisplayWarning(TranslationKey translationKey, string caption, string message, params object[] messageArgs)
		{
			// translate
			caption = Translation.Instance.Translate(translationKey, TranslationSubKey.Caption, caption);
			message = Translation.Instance.Translate(translationKey, TranslationSubKey.Message, message, messageArgs);

			const MessageBoxButtons buttons = MessageBoxButtons.OK;
			const MessageBoxIcon icon = MessageBoxIcon.Warning;

			Trace.WriteWarning("WARNING DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
			int timestamp = Environment.TickCount;

			DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
			Trace.WriteWarning("WARNING DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);
		}

		public virtual void DisplayExclamation(TranslationKey translationKey, string caption, string message, params object[] messageArgs)
		{
			// translate
			caption = Translation.Instance.Translate(translationKey, TranslationSubKey.Caption, caption);
			message = Translation.Instance.Translate(translationKey, TranslationSubKey.Message, message, messageArgs);

			const MessageBoxButtons buttons = MessageBoxButtons.OK;
			const MessageBoxIcon icon = MessageBoxIcon.Exclamation;

			Trace.WriteWarning("WARNING DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
			int timestamp = Environment.TickCount;

			DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
			Trace.WriteWarning("WARNING DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);
		}

    public virtual void DisplayInfo(TranslationKey translationKey, params object[] messageArgs)
    {
      DisplayInfo(translationKey, translationKey.GetCommonCaption(), translationKey.GetCommonMessage(), messageArgs);
    }

    public virtual void DisplayInfo(TranslationKey translationKey, string caption, string message, params object[] messageArgs)
		{
			// translate
			caption = Translation.Instance.Translate(translationKey, TranslationSubKey.Caption, caption);
			message = Translation.Instance.Translate(translationKey, TranslationSubKey.Message, message, messageArgs);

			const MessageBoxButtons buttons = MessageBoxButtons.OK;
			const MessageBoxIcon icon = MessageBoxIcon.Information;

			Trace.WriteInformation("INFO DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
			int timestamp = Environment.TickCount;

			DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
			Trace.WriteInformation("INFO DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);
		}

		public virtual DialogResult Confirm(TranslationKey translationKey, string caption, string message, MessageBoxButtons buttons, params object[] messageArgs)
		{
			// translate
			caption = Translation.Instance.Translate(translationKey, TranslationSubKey.Caption, caption);
			message = Translation.Instance.Translate(translationKey, TranslationSubKey.Message, message, messageArgs);

			const MessageBoxIcon icon = MessageBoxIcon.Question;

			Trace.WriteInformation("CONFIRM DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
			int timestamp = Environment.TickCount;

			DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
			Trace.WriteInformation("CONFIRM DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);

			return result;
		}

	  public virtual DialogResult Confirm(string caption, string message, MessageBoxButtons buttons, params object[] messageArgs)
	  {
	    const MessageBoxIcon icon = MessageBoxIcon.Question;

	    Trace.WriteInformation("CONFIRM DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
	    int timestamp = Environment.TickCount;

	    DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
	    Trace.WriteInformation("CONFIRM DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);

	    return result;
	  }

    public virtual DialogResult ConfirmWithInput(TranslationKey translationKey, string caption, string message, MessageBoxButtons buttons, string labelTextInputField, out string userInput, params object[] messageArgs)
		{
			// translate
			caption = Translation.Instance.Translate(translationKey, TranslationSubKey.Caption, caption);
			message = Translation.Instance.Translate(translationKey, TranslationSubKey.Message, message, messageArgs);

			const MessageBoxIcon icon = MessageBoxIcon.Question;

			Trace.WriteInformation("CONFIRM DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
			int timestamp = Environment.TickCount;

			var m = new MessageBoxForm(caption, message, buttons, icon, labelTextInputField);
			DialogResult result = m.ShowDialog(this);
			userInput = m.UserInput;
			Trace.WriteInformation("CONFIRM DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}, userInput={5}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result, userInput);

			return result;
		}

		#endregion

		public Boolean DoDeActivateAllowed()
		{
			return DeActivateAllowed();
		}

		public virtual Boolean DeActivateAllowed()
		{
			return true;
		}

		public void DoActivateFromMain(EventArgs e)
		{
			Initialize();
			ActivateFromMain(e);
		}

		/// <summary>
		/// Event triggered once the screen will be activated
		/// </summary>
		/// <param name="e"></param>
		public virtual void ActivateFromMain(EventArgs e)
		{

		}

		public void DoActivatedFromMain(EventArgs e)
		{
			ActivatedFromMain(e);
		}

		/// <summary>
		/// Event triggered once the screen is fully loaded an shown
		/// </summary>
		/// <param name="e"></param>
		public virtual void ActivatedFromMain(EventArgs e)
		{

		}

		public void DoDeActivateFromMain()
		{
			DeActivateFromMain();
		}

		/// <summary>
		/// Event triggered once the screen is deactivated and placed in the background
		/// </summary>
		public virtual void DeActivateFromMain()
		{
		}

		public void DoDestroy()
		{
			Destroy();
		}

		public virtual void Destroy()
		{
		}

		public void DoSetFocus()
		{
			SetFocus();
		}

		public virtual void SetFocus()
		{
		}

	}
}
