using System;
using System.ComponentModel;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.PopupPages;
using Actemium.Translations;
using Actemium.UserManagement2.Business;
using Actemium.L3IC.OrderManager.General.Translations;

namespace Actemium.L3IC.OrderManager.Client.General.Base
{
	public partial class BaseUserControl : UserControl
	{
    private const string CLASSNAME = nameof(BaseUserControl);

    public string Title { get; protected set; }
    public string ACICategory { get; set; }

    public BaseUserControl()
		{
      try
      {
        InitializeComponent();
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
		}

    public bool AllowBusyBox
    {
      get => _allowBusyBox;
      set => _allowBusyBox = value;
    } private bool _allowBusyBox = true;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowBusyBox
    {
      set 
      {
        if (_allowBusyBox)
          GlobalHandler.ShowBusyBox = value; 
      }
    }


		public void AddHistoryAction(TranslationKey translationKey, string message, params object[] messageArgs)
		{
			GlobalHandler.AddHistoryAction(translationKey, message, messageArgs);
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
			if (ex is ApplicationException || ex is BusinessException)
				DisplayError(ex.Message, messageArgs);
			else
				DisplayError(methodName, translationKey, translationKey.GetCommonCaption(), translationKey.GetCommonMessage(), ex, messageArgs);
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


  }
}
