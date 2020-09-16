using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.Events;
using Actemium.L3IC.OrderManager.Client.General.PopupPages;
using Actemium.Translations;
using Actemium.UserManagement2.Business;
using Actemium.Windows.Forms.DevComponents2.Interfaces;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Actemium.L3IC.OrderManager.Client.General.Base
{
  public partial class BaseMainForm : DevComponents.DotNetBar.Office2007RibbonForm
  {
    private const string CLASSNAME = nameof(BaseMainForm);

    public BaseMainForm()
    {
      InitializeComponent();
      Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
    }

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
        SetMainFormTitle();
      }
    }

    protected void SetMainFormTitle()
    {
      List<String> applicationTitles = new List<string>() {
        "Actemium",
        ApplicationSettings.Business.ApplicationSettings.Instance[(Int32)L3IC.OrderManager.General.Enums.ApplicationSettings.ApplicationName],
        ApplicationSettings.Business.ApplicationSettings.Instance[(Int32)L3IC.OrderManager.General.Enums.ApplicationSettings.ApplicationSite]
      };

      if (Settings.ACT.IsProduction == false)
      {
        applicationTitles.Add(Settings.ACT.EnvironmentName);
      }

      Text = string.Join(" - ", applicationTitles.Where(s => !string.IsNullOrEmpty(s)));

    }

    private static void InitializeControls(Control parent)
    {
      try
      {
        foreach (Control control in parent.Controls)
        {
          if (control is IInitializeControl initializeControl)
          {
            initializeControl.Initialize();
          }

          if (!(control is Form)) // Ignore sub forms, they will be translated in the subform itself (Since they will be added dynamically)
            InitializeControls(control);
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    #endregion

    public bool ShowBusyBox
    {
      set => GlobalHandler.ShowBusyBox = value;
    }

    #region Call Dialog functions

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

    public virtual void DisplayErrorNotTranslated(string caption, string function, string message)
    {
      string errorMessage = function != null ? $"Function: {function}\n\nMessage: {message}" : $"Error: {message}";

      const MessageBoxButtons buttons = MessageBoxButtons.OK;
      const MessageBoxIcon icon = MessageBoxIcon.Error;

      Trace.WriteError("ERROR DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, errorMessage, buttons);
      int timestamp = Environment.TickCount;
      DialogResult result = new MessageBoxForm(caption, errorMessage, buttons, icon, null).ShowDialog(this);
      Trace.WriteError("ERROR DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, errorMessage, buttons, result);
    }

    public virtual void DisplayWarningNotTranslated(string caption, string message)
    {
      const MessageBoxButtons buttons = MessageBoxButtons.OK;
      const MessageBoxIcon icon = MessageBoxIcon.Warning;

      Trace.WriteError("WARNING DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
      int timestamp = Environment.TickCount;
      DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
      Trace.WriteError("WARNING DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);
    }

    public virtual void DisplayExclamationNotTranslated(string caption, string message)
    {
      const MessageBoxButtons buttons = MessageBoxButtons.OK;
      const MessageBoxIcon icon = MessageBoxIcon.Exclamation;

      Trace.WriteWarning("WARNING DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
      int timestamp = Environment.TickCount;
      DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
      Trace.WriteWarning("WARNING DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);
    }

    public virtual void DisplayInfoNotTranslated(string caption, string message)
    {
      const MessageBoxButtons buttons = MessageBoxButtons.OK;
      const MessageBoxIcon icon = MessageBoxIcon.Information;

      Trace.WriteInformation("INFO DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
      int timestamp = Environment.TickCount;
      DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
      Trace.WriteInformation("INFO DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);
    }

    public virtual DialogResult ConfirmNotTranslated(string caption, string message, MessageBoxButtons buttons)
    {
      const MessageBoxIcon icon = MessageBoxIcon.Question;

      Trace.WriteInformation("CONFIRM DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
      int timestamp = Environment.TickCount;
      DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
      Trace.WriteInformation("CONFIRM DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);

      return result;
    }

    #endregion


    #region events
    public event BeforeUserLogoutHandler BeforeUserLogoutEvent;
    public delegate void BeforeUserLogoutHandler(object sender, EventArgs e);

    internal void RaiseBeforeUserLogoutEvent()
    {
      BeforeUserLogoutEvent?.Invoke(this, EventArgs.Empty);
    }

    public event ScreenChangedHandler ScreenChangedEvent;
    public delegate void ScreenChangedHandler(object sender, ScreenChangedEventArgs e);

    internal void RaiseScreenChangedEvent(NavigationItems screen)
    {
      ScreenChangedEvent?.Invoke(this, new ScreenChangedEventArgs(screen));
    }
    #endregion
  }
}
