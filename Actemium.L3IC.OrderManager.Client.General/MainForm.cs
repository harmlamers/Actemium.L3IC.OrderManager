using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.Events;
using Actemium.L3IC.OrderManager.Client.General.PopupPages;
using Actemium.L3IC.OrderManager.Client.General.Properties;
using Actemium.L3IC.OrderManager.General.Configuration;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Translations;
using Actemium.Translations.Objects;
using Actemium.UserManagement2;
using Actemium.UserManagement2.Business;
using Actemium.UserManagement2.Model;
using Actemium.Windows.Forms.DevComponents2.Controls;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General
{
  public sealed partial class MainForm : BaseMainForm
  {
    private const string CLASSNAME = nameof(MainForm);
    private const int DEFAULTLANGUAGE = 1; // Programming language ALWAYS ENGLISH!

    private readonly List<Control> _customControlParentList = new List<Control>();

    private readonly DateTime _clientStartTime;
    private DateTime _lastValidVersionRefresh;
    private DateTime? _inValidVersionWarning;
    private DateTime _lastInMaintenanceModeRefresh;
    private DateTime? _inMaintenaceModeWarning;
    private readonly Version _clientGeneralVersion;
    private bool _refreshMainForm;
    private DateTime _nexAutoLogoutTime;
    private Boolean _invalidResolution;
    private string _defaultUserName;
    private List<DetachedForm> _detachedForms = new List<DetachedForm>();
    private int _maxDetachedFormsCount;

    public MainForm()
    {
      SplashScreen.Show(this, "Waiting for initialization...", 1500);
      try
      {
        DoubleBuffered = true;

        _clientStartTime = DateTime.Now;
        _lastValidVersionRefresh = DateTime.Now;
        _lastInMaintenanceModeRefresh = DateTime.Now;
        _nexAutoLogoutTime = DateTime.Now.AddMinutes(1);
        _inValidVersionWarning = null;
        _inMaintenaceModeWarning = null;
        _clientGeneralVersion = new Version(999, 999);
        var defaultUserValue = CurrentUser.GetComputerProperty((Int32)UserManagementProperties.ComputerDefaultUser);
        _defaultUserName = string.IsNullOrEmpty(defaultUserValue?.Value)
          ? defaultUserValue?.DefaultValue ?? null
          : defaultUserValue.Value;

        foreach (AssemblyName assemblyName in Assembly.GetEntryAssembly().GetReferencedAssemblies())
        {
          if (!assemblyName.Name.Contains("Actemium.EmptyClient.Client.General"))
            continue;

          _clientGeneralVersion = assemblyName.Version;
          break;
        }

        if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
        {
          SplashScreen.Show(this, "Check for updates....", 0);
          CheckForClickOnceUpdates();
        }

        InitializeComponent();

      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        KillClient();
      }
    }

    private void KillClient()
    {
      System.Diagnostics.Process[] feProcess = System.Diagnostics.Process.GetProcesses();
      if (feProcess.Length <= 0)
        return;

      foreach (System.Diagnostics.Process process in feProcess)
      {
        if (process.ProcessName.StartsWith("Actemium.EmptyClient."))
          process.Kill();
      }
    }


    #region ClickOnce

    private bool _calClickOnceByUser;
    private bool _clickOnceInProcess;

    public bool ClosingMainForm { get; set; }

    private void CheckForClickOnceUpdates()
    {
      try
      {
        var clickOnce = new ClickOnce.ClickOnce(this);
        clickOnce.CheckForUpdateCompleted += ClickOnceCheckForUpdateCompleted;
        clickOnce.CheckForUpdatesThreaded(false, true);
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void ClickOnceCheckForUpdateCompleted(object sender, ClickOnce.CheckForUpdateCompleteEventArgs e)
    {
      try
      {
        //installed on: C:\Documents and Settings\username\Local Settings\Apps\2.0
        if (_refreshMainForm)
          return;

        _clickOnceInProcess = true;
        ClickOnce.ClickOnce clickOnceObj;
        const string caption = "Update application";
        switch (e.Result)
        {
          case ClickOnce.CheckForUpdateResult.BusyUpdating:
            DisplayInfoNotTranslated(caption, "The application is currently busy updating to the latest version..");
            break;
          case ClickOnce.CheckForUpdateResult.DeploymentDownloadFailure:
          case ClickOnce.CheckForUpdateResult.NoNetworkDeploymentFailure:
            DisplayInfoNotTranslated(caption, "Downloading the latest version has failed. \n\nCheck the network connection and try again.");
            break;
          case ClickOnce.CheckForUpdateResult.InvalidDeploymentFailure:
            DisplayInfoNotTranslated(caption, "Unable to check for the latest version. The publicated version might be corrupt. Republish the application and try again.");
            break;
          case ClickOnce.CheckForUpdateResult.InvalidOperationFailure:
            DisplayInfoNotTranslated(caption, "Updating the application to the latest version failed. The current installed version is probably not installed using ClickOnce.");
            break;
          case ClickOnce.CheckForUpdateResult.NoUpdatesAvailable:
            if (_calClickOnceByUser)
              DisplayInfoNotTranslated(caption, "There are no updates available.");
            break;
          case ClickOnce.CheckForUpdateResult.UpdateAvailableNotRequired:
            if (
              ConfirmNotTranslated(caption, "There is a new version available.\nClick 'OK' to update the application to the latest version.",
                      MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
              clickOnceObj = sender as ClickOnce.ClickOnce;
              if (clickOnceObj != null)
              {
                ShowBusyBox = true;
                clickOnceObj.Update();
                ShowBusyBox = false;
              }
            }
            break;
          case ClickOnce.CheckForUpdateResult.UpdateAvailableRequired:
            DisplayInfoNotTranslated(caption, "An required update is available. Press 'OK' to get the latest version.");
            clickOnceObj = sender as ClickOnce.ClickOnce;
            if (clickOnceObj != null)
            {
              ShowBusyBox = true;
              clickOnceObj.Update();
              ShowBusyBox = false;
            }
            break;
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        _calClickOnceByUser = false;
        _clickOnceInProcess = false;
      }
    }

    #endregion

    #region Events

    private void MainFormLoad(object sender, EventArgs e)
    {
      try
      {
        _refreshMainForm = true;

        CurrentUser.OnLoginStateChanged += MainPanelLoginStateChanged;

        #region Setup Translations
        Translation.Initialize(DEFAULTLANGUAGE);

        SetLanguage();


        SetExpandStateOfMenu();

        base.Initialize();

        InitTranslationButton();
        Translation.CurrentLanguageChangedEvent += TranslationCurrentLanguageChangedEvent;
        Translations.TranslationsInitializedEvent += TranslationsTranslationsInitializedEvent;
        #endregion

        SetMainFormElementColors();

        const int minHeight = 800;
        const int minWidth = 1200;
        if (Height < minHeight || Width < minWidth)
        {
          Trace.WriteCritical(
            $"Screenresolution too small. Mainform Height = '{Height.ToString()}', Width = {Width.ToString()}. Client will be closed", Trace.GetMethodName(), CLASSNAME);

          DisplayWarning(TranslationKey.Message_ScreenResolution, "Application is unable to start...",
                           "Reason: Screenresolution too small. Minimal resolution is {0}x{1}", minWidth, minHeight);
          _invalidResolution = true;
          Application.Exit();
        }

        actionsStatusStripDropDownButton.DropDownItems.Clear();
        AddHistoryAction(TranslationKey.History_ApplicationStarted, "Application started.");

        var computerTimeFormat = CurrentUser.GetComputerProperty((Int32)UserManagementProperties.ComputerTimeFormat);
        var format = "dd-MM-yyyy HH:mm:ss";
        if (computerTimeFormat != null)
        {
          if (!String.IsNullOrEmpty(computerTimeFormat.Value))
            format = computerTimeFormat.Value;
          else if (!String.IsNullOrEmpty(computerTimeFormat.DefaultValue))
            format = computerTimeFormat.DefaultValue;
        }

        timeStatusStripLabel.Text = DateTime.Now.ToString(format);

        SetAuthorisation();

        screenManagerPanel.SetMainWindow(NavigationItems.Logon);

        refreshTimer.Start();
      }
      catch (Exception ex)
      {
        string name = Trace.GetMethodName();
        Trace.WriteError("()", name, CLASSNAME, ex);

        string text = string.Format("The Client applcation occurred with an software error."
                                    + "\n\nThe error occurred in the startup process."
                                    + "\nUnfortunately, the application can not be continued and will be now ended."
                                    + "\nContact Actemium, if this problem still occurs."
                                    + "\nWrite down the error message and the current date and time.");

        DisplayError(TranslationKey.CommonMessage_InternalError, name, text);
        Close();
      }
      finally
      {
        _refreshMainForm = false;

        System.Threading.Thread.Sleep(1000);
        SplashScreen.Close();
      }
    }

    private void SetMainFormElementColors()
    {
      if (Settings.ACT.IsProduction == false)
      {
        Color explicitColor = Color.Red;
        Color contrastingTextColor = Color.White;

        statusStrip.BackColor = explicitColor;
        statusStrip.ForeColor = contrastingTextColor;

        actionsStatusStripDropDownButton.BackColor = explicitColor;
        actionsStatusStripDropDownButton.ForeColor = contrastingTextColor;

        headerLabel.BackColor = explicitColor;
        headerLabel.ForeColor = contrastingTextColor;
      }
    }

    private void TranslationsTranslationsInitializedEvent(object sender, EventArgs e)
    {
      Refresh();
    }

    public void MainFormKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F5:
        case Keys.BrowserRefresh:
          // call the refresh method
          Refresh();
          break;
        case Keys.F1:
          if (helpQuickButtonItem.Visible)
          {
            new PopupHelp().ShowDialog();
          }
          break;
        case Keys.Home:
        case Keys.BrowserHome:
          screenManagerPanel.GoToHome();
          break;
        case Keys.PageUp:
        case Keys.BrowserForward:
          screenManagerPanel.GoToNextScreen();
          break;
        case Keys.PageDown:
        case Keys.BrowserBack:
          screenManagerPanel.GoToPreviousScreen();
          break;
      }
    }

    private void MainFormFormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        if (!_clickOnceInProcess && !_invalidResolution
            && !(_inValidVersionWarning != null && _inValidVersionWarning.Value.AddSeconds(10) < DateTime.Now)
            && !(_inMaintenaceModeWarning != null && _inMaintenaceModeWarning.Value.AddSeconds(10) < DateTime.Now)
            && (e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.UserClosing))
        {
          if (Confirm(TranslationKey.Confirm_Client_Exit, "Exit Client", "Are you sure you want to exit the client?", MessageBoxButtons.YesNo)
              != DialogResult.Yes)
          {
            e.Cancel = true;
          }
        }

        if (e.Cancel)
          return;

        ShowBusyBox = true;
        ClosingMainForm = true;
        refreshTimer.Stop();

        //TODO Close UM Session

      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        ShowBusyBox = false;
        ClosingMainForm = false;
      }
    }

    private void StatusStripResize(object sender, EventArgs e)
    {
      try
      {
        // 800 = DefaultStripSize - 667
        actionsStatusStripDropDownButton.Size = new Size(statusStrip.Size.Width - 880,
                                                         actionsStatusStripDropDownButton.Size.Height);
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
      }
    }

    private void RibbonControlHeaderExpandedChanged(object sender, EventArgs e)
    {
      if (Size.Height < 920)
        ribbonControlHeader.Expanded = false;
    }

    public override void Refresh()
    {
      ApplicationSettings.Business.ApplicationSettings.Instance.InvalidateCache();
      screenManagerPanel.RefreshScreen();
      foreach (var screen in _detachedForms)
      {
        screen.Refresh();
      }
      base.Refresh();
    }

    private void RefreshTimerTick(object sender, EventArgs e)
    {
      try
      {
        if (DesignMode)
          return;

        var computerTimeFormat = CurrentUser.GetComputerProperty((Int32)UserManagementProperties.ComputerTimeFormat);
        var format = "dd-MM-yyyy HH:mm:ss";
        if (computerTimeFormat != null)
        {
          if (!String.IsNullOrEmpty(computerTimeFormat.Value))
            format = computerTimeFormat.Value;
          else if (!String.IsNullOrEmpty(computerTimeFormat.DefaultValue))
            format = computerTimeFormat.DefaultValue;
        }

        var defaultUserValue = CurrentUser.GetComputerProperty((Int32)UserManagementProperties.ComputerDefaultUser);
        _defaultUserName = string.IsNullOrEmpty(defaultUserValue.Value)
          ? defaultUserValue.DefaultValue
          : defaultUserValue.Value;

        timeStatusStripLabel.Text = DateTime.Now.ToString(format);


        ApplicationSettings.Business.ApplicationSettings.Instance.InvalidateCache();
        //Invalid version
        if (_lastValidVersionRefresh < DateTime.Now)
        {
          if (!(CurrentUser.User?.Username.Equals("actemium", StringComparison.CurrentCultureIgnoreCase) == true && Boolean.Parse(
                   ApplicationSettings.Business.ApplicationSettings.Instance[
                     (Int32)L3IC.OrderManager.General.Enums.ApplicationSettings.ActemiumCanUseOldClientVersion])))
          {

            Version validVersion = null;
            try
            {
              String validVersionString =
                ApplicationSettings.Business.ApplicationSettings.Instance[
                  (Int32)L3IC.OrderManager.General.Enums.ApplicationSettings.ValidClientVersion];
              validVersion = validVersionString != null ? new Version(validVersionString) : null;
            }
            catch
            {
              validVersion = null;
            }

            if (validVersion != null && _clientGeneralVersion < validVersion)
            {
              if (_inValidVersionWarning != null && _inValidVersionWarning.Value.AddSeconds(60) < DateTime.Now)
              {
                Trace.WriteWarning(
                  "Invalid version is used. Application will be forced to close.", Trace.GetMethodName(), CLASSNAME);
                Application.Exit();
              }
              else if (_inValidVersionWarning == null)
              {
                _inValidVersionWarning = DateTime.Now;
                Trace.WriteWarning(
                  "Invalid version is used. Warning to user has been issued.", Trace.GetMethodName(), CLASSNAME);
                DisplayWarning(
                  TranslationKey.Message_Client_Old_Version, "Application is running an old version",
                  "The version you are running is to old, the client will shutdown in 60 seconds.");
              }
            }
            else
            {
              _inValidVersionWarning = null;
            }

            _lastValidVersionRefresh = DateTime.Now.AddSeconds(_inValidVersionWarning.HasValue ? 10 : 60);
          }
        }

        //Maintenace mode
        if (_lastInMaintenanceModeRefresh < DateTime.Now)
        {
          if (CurrentUser.User?.Username.Equals("actemium", StringComparison.CurrentCultureIgnoreCase) != true)
          {
            bool inMaintenaceMode = false;
            try
            {
              String inMaintenaceModeString =
                ApplicationSettings.Business.ApplicationSettings.Instance[
                  (Int32)L3IC.OrderManager.General.Enums.ApplicationSettings.MaintenanceMode];
              inMaintenaceMode = bool.Parse(inMaintenaceModeString);
            }
            catch
            {
              inMaintenaceMode = false;
            }

            if (inMaintenaceMode)
            {
              if (_inMaintenaceModeWarning != null && _inMaintenaceModeWarning.Value.AddSeconds(60) < DateTime.Now)
              {
                Trace.WriteWarning(
                  "Application is in Maintenance mode. Application will be forced to close.", Trace.GetMethodName(),
                  CLASSNAME);
                Application.Exit();
              }
              else if (_inMaintenaceModeWarning == null)
              {
                _inMaintenaceModeWarning = DateTime.Now;
                Trace.WriteWarning(
                  "Application is in Maintenace mode. Warning to user has been issued.", Trace.GetMethodName(),
                  CLASSNAME);
                DisplayWarning(
                  TranslationKey.Message_Client_In_MaintenaceMode, "Application is in maintenace",
                  "The application is currently in maintenance mode, the client will shutdown in 60 seconds.");
              }
            }
            else
            {
              _inMaintenaceModeWarning = null;
            }

            _lastInMaintenanceModeRefresh = DateTime.Now.AddSeconds(_inMaintenaceModeWarning.HasValue ? 10 : 60);
          }
        }

        //Auto Log Off
        if (CurrentUser.User == null || _nexAutoLogoutTime >= DateTime.Now
                                     || !(Windows.Forms.OSInformation.GetLastInputDuration().TotalSeconds >= 60))
        {
          return;
        }

        _nexAutoLogoutTime = DateTime.Now.AddMinutes(1);

        var computerDefaultUser = CurrentUser.GetComputerProperty((Int32)UserManagementProperties.ComputerDefaultUser);
        String defaultUser = null;
        if (computerDefaultUser != null)
        {
          if (!String.IsNullOrEmpty(computerDefaultUser.Value))
            defaultUser = computerDefaultUser.Value;
          else if (!String.IsNullOrEmpty(computerDefaultUser.DefaultValue))
            defaultUser = computerDefaultUser.DefaultValue;
        }

        var computerAutoLogoutTime = CurrentUser.GetComputerProperty((Int32)UserManagementProperties.ComputerAutoLogoutTime);
        Int32? autoLogoutTime = null;
        if (computerAutoLogoutTime != null)
        {
          if (!String.IsNullOrEmpty(computerAutoLogoutTime.Value))
            autoLogoutTime = Convert.ToInt32(computerAutoLogoutTime.Value);
          else if (!String.IsNullOrEmpty(computerAutoLogoutTime.DefaultValue))
            autoLogoutTime = Convert.ToInt32(computerAutoLogoutTime.DefaultValue);
        }

        if (autoLogoutTime.HasValue && autoLogoutTime.Value > 0)
          _nexAutoLogoutTime = DateTime.Now.AddMinutes(autoLogoutTime.Value);
        else
          _nexAutoLogoutTime = DateTime.Now.AddMinutes(5);

        if (autoLogoutTime.HasValue && autoLogoutTime.Value > 0 && Windows.Forms.OSInformation.GetLastInputDuration().TotalMinutes >= autoLogoutTime.Value)
        {
          _nexAutoLogoutTime = DateTime.Now.AddMinutes(autoLogoutTime.Value);

          if (!String.Equals(defaultUser, CurrentUser.User.Username, StringComparison.InvariantCultureIgnoreCase))
          {
            RaiseBeforeUserLogoutEvent();

            Trace.WriteWarning(
              $"No activity over {autoLogoutTime.Value.ToString()} minutes for non-default user. Application will be logged out.", Trace.GetMethodName(), CLASSNAME);
            AddHistoryAction(TranslationKey.History_Automatic_LogOff, "User: {0} logged out after {1} minute(s) of inactivity", CurrentUser.User.Username, autoLogoutTime.Value);
            GlobalHandler.AutoLogout = true;
            CloseOpenPopUpForms();
            screenManagerPanel.SetMainWindow(NavigationItems.Logon);
          }
          else if (screenManagerPanel.CurrentScreen.NavigationItem != GlobalHandler.HomeNavigationItem)
          {
            Trace.WriteWarning($"No activity over {autoLogoutTime.Value.ToString()} minutes for default user. Return to home page.", Trace.GetMethodName(), CLASSNAME);
            AddHistoryAction(TranslationKey.History_Automatic_ReturnHome, "User: {0} returned to homescreen after {1} minutes of inactivity", CurrentUser.User.Username, autoLogoutTime.Value);
            CloseOpenPopUpForms();
            screenManagerPanel.SetMainWindow(GlobalHandler.HomeNavigationItem);
          }
        }


      }
      catch (Exception ex)
      {
        string name = Trace.GetMethodName();
        Trace.WriteError("()", name, CLASSNAME, ex);
      }
    }

    private void CloseOpenPopUpForms()
    {
      Trace.WriteInformation("Closing open popup forms", Trace.GetMethodName(), CLASSNAME);

      var OpenFormCollection = Application.OpenForms;
      foreach (Form currentForm in OpenFormCollection)
      {
        if (currentForm.GetType().ToString().Contains("PopupPages"))
        {
          currentForm.Close();
        }
      }
    }

    private void MainPanelLoginStateChanged(object sender, OnCurrentUserChangedEventArgs e)
    {

      ShowBusyBox = true;

      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, e);

      switch (e.LoginState)
      {
        // Logged on
        case LoginStates.LoggedIn when CurrentUser.User.Password.Length == 0 && ApplicationSettings.Business.ApplicationSettings.Instance[(Int32)Actemium.L3IC.OrderManager.General.Enums.ApplicationSettings.EmptyPasswordAllowed] == "False":

          DisplayWarning(TranslationKey.Message_EmptyPasswordNoLongerAllowed, "Logged in with an empty password", "The use of an empty password is currently disabled please change your password.");

          if (CurrentUser.HasPermission(ACICategories.USERPROFILE, ACIOptions.VIEW) && CurrentUser.HasPermission(ACICategories.USERPROFILE, ACIOptions.CHANGEPASSWORD))
          {
            screenManagerPanel.SetMainWindow(NavigationItems.UserProfile);
          }
          else if (screenManagerPanel.PreviousScreensCount > 0 && screenManagerPanel.PreviousScreen != NavigationItems.Error)
          {
            screenManagerPanel.SetMainWindow(GlobalHandler.HomeNavigationItem);
          }
          else
          {
            screenManagerPanel.SetMainWindow(NavigationItems.Home);
          }
          break;
        case LoginStates.LoggedIn when screenManagerPanel.PreviousScreensCount > 0 && screenManagerPanel.PreviousScreen != NavigationItems.Error:
          screenManagerPanel.SetMainWindow(GlobalHandler.HomeNavigationItem);
          break;
        case LoginStates.LoggedIn:
          screenManagerPanel.SetMainWindow(NavigationItems.Home);
          break;
        // Logged out
        case LoginStates.LoggedOut:
          screenManagerPanel.SetMainWindow(NavigationItems.Logon);
          foreach (var form in _detachedForms)
          {
            form.OnLogoff();
          }
          break;
        default:
          foreach (var form in _detachedForms)
          {
            form.OnLogoff();
          }
          throw new ArgumentOutOfRangeException();
      }
      SetLanguage();
      SetExpandStateOfMenu();
      SetAuthorisation();

      if (e.LoginState == LoginStates.LoggedIn)
      {
        _maxDetachedFormsCount = 0;
        var maxDetachedFormsProperty = CurrentUser.GetComputerProperty((int)UserManagementProperties.ComputerMaxDetachedForms);
        if (maxDetachedFormsProperty != null)
        {
          if (!int.TryParse(maxDetachedFormsProperty.Value ?? maxDetachedFormsProperty.DefaultValue, out _maxDetachedFormsCount))
            _maxDetachedFormsCount = 0;
        }

        if(_maxDetachedFormsCount < 0)
        {
          _maxDetachedFormsCount = Screen.AllScreens.Where(x => x.Primary == false).Count();
        }

        DetachButtonVisibility();

        foreach (var form in _detachedForms)
        {
          form.OnLogon();
        }
      }
      else if (e.LoginState == LoginStates.LoggedOut)
      {
        foreach (var form in _detachedForms)
        {
          form.OnLogoff();
        }
      }
    }

    private void SetLanguage()
    {
      int selectedLanguageId = DEFAULTLANGUAGE;
      int langId = DEFAULTLANGUAGE;
      var activeLanguages = GlobalHandler.ActiveLanguages();

      var userProperty = CurrentUser.GetUserProperty((Int32)UserManagementProperties.UserPreferredLanguage);
      var computerProperty = CurrentUser.GetComputerProperty((Int32)UserManagementProperties.ComputerDefaultLanguage);

      
      if (Int32.TryParse(computerProperty?.Value ?? computerProperty?.DefaultValue, out langId))
      {
        selectedLanguageId = langId;
      }

      if (CurrentUser.User != null && Int32.TryParse(userProperty?.Value ?? userProperty?.DefaultValue, out langId))
      {
        selectedLanguageId = langId;
      }

      if (activeLanguages.Find(lang => lang.Id == selectedLanguageId) == null)
      {
        selectedLanguageId = DEFAULTLANGUAGE;
      }

      Translation.Instance.CurrentLanguageId = selectedLanguageId;
      btnLanguage.Image = activeLanguages.Find(lang => lang.Id == selectedLanguageId).Image;

      ribbonControlHeader.Expanded = false;
      ribbonControlHeader.Refresh();
    }

    private void MainPanelResize(object sender, EventArgs e)
    {
      pnlBusy.Location = new Point((Size.Width - pnlBusy.Size.Width) / 2, (Size.Height - pnlBusy.Size.Height) / 2);
      if (Size.Height < 920)
        ribbonControlHeader.Expanded = false;
    }

    private void MainPanelScreenChanged(object sender, ScreenChangedEventArgs e)
    {
      try
      {
        RaiseScreenChangedEvent(e.Screen);

        headerLabel.Text = screenManagerPanel.CurrentScreen.TranslatedTitle;

        navigationLocationStatusStripLabel.Text =
          $"   {screenManagerPanel.CurrentScreen.TranslatedTitle} [{(Int32)screenManagerPanel.CurrentScreen.NavigationItem:0000}]";

        //Verwijder eerst alle "custom"
        foreach (var control in _customControlParentList)
        {
          DeleteControlsByTag(control, "Custom");
        }
        _customControlParentList.Clear();

        foreach (var tupleRibbonBar in screenManagerPanel.CurrentScreen.RibbonBars)
        {
          tupleRibbonBar.Item2.Tag = "Custom";
          var control = GetControlByName(tupleRibbonBar.Item1);
          if (control != null)
          {
            control.Controls.Add(tupleRibbonBar.Item2);
            control.PerformLayout();
            _customControlParentList.Add(control);
            tupleRibbonBar.Item2.Reinitialize();
          }
        }

        EnableDisableButtons();
        DetachButtonVisibility();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
      }
      finally
      {
        ribbonControlHeader.Refresh();
      }
    }

    private Control GetControlByName(string name)
    {
      return Controls.Find(name, true).FirstOrDefault();
    }

    private void DeleteControlsByTag(Control control, string tag)
    {
      foreach (Control c in control.Controls)
      {
        if (c.Tag != null && c.Tag.ToString() == tag)
          control.Controls.Remove(c);
      }
    }

    #endregion

    #region General Public Methods

    public void AddHistoryAction(TranslationKey translationKey, String description, params object[] messageArgs)
    {
      try
      {
        var desc = Translation.Instance.Translate("HistoryAction", translationKey.ToString(), description, messageArgs);

        var timestamp = DateTime.Now;

        if (!History.Business.HistoryActions.Instance.AddHistoryAction(
          translationKey.ToString(), description, timestamp.ToUniversalTime(), CurrentUser.User?.Id, CurrentUser.Computer?.Id,
          messageArgs))
        {
          return;
        }

        var itemCount = int.Parse(
          ApplicationSettings.Business.ApplicationSettings.Instance[
            (int)L3IC.OrderManager.General.Enums.ApplicationSettings.VisibleHistoryActionCount]);

        actionsStatusStripDropDownButton.Visible = itemCount > 0;

        if (!actionsStatusStripDropDownButton.Visible)
          return;

        actionsStatusStripDropDownButton.Text = $"{timestamp:dd-MM-yyyy HH:mm}: {desc}";
        actionsStatusStripDropDownButton.DropDownItems.Add(actionsStatusStripDropDownButton.Text);



        if (actionsStatusStripDropDownButton.DropDownItems.Count > itemCount)
        {
          actionsStatusStripDropDownButton.DropDownItems.RemoveAt(0);
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, description);
        throw;
      }
    }

    public void ShowBusyBoxPanel(bool value)
    {
      try
      {
        screenManagerPanel.Enabled = !value;
        Application.DoEvents();

        pnlBusy.Visible = value;

        if (value)
        {
          screenManagerPanel.SuspendLayout();
          pnlBusy.Refresh();
        }
        else
        {
          screenManagerPanel.ResumeLayout();
          screenManagerPanel.Refresh();
        }

        Cursor = value ? Cursors.WaitCursor : Cursors.Default;
      }
      catch (Exception ex)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, value);
      }
    }

    #endregion

    #region Standard-Menu-Buttons Event Handling

    private void QuickLogoffButtonClick(object sender, EventArgs e)
    {
      try
      {
        //if (!autoLogOff && Confirm(
        //      TranslationKey.Confirm_Logoff, "Logoff", "Are you sure you want to logoff?", MessageBoxButtons.YesNo)
        //    != DialogResult.Yes) return;
        //TODO Confirm setting
        ShowBusyBox = true;

        AddHistoryAction(TranslationKey.History_LogonForm_LoggedOff, "User: {0} logged off", CurrentUser.User.Username);

        CurrentUser.ClearCurrentUser();
        screenManagerPanel.SetMainWindow(NavigationItems.Logon);
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        ShowBusyBox = false;
      }
    }

    private void LogonLogoffButtonClick(object sender, EventArgs e)
    {
      try
      {
        ShowBusyBox = true;

        screenManagerPanel.SetMainWindow(NavigationItems.Logon);
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        ShowBusyBox = false;
      }
    }

    private void CheckForUpdateButtonClick(object sender, EventArgs e)
    {
      _calClickOnceByUser = true;
      CheckForClickOnceUpdates();
    }

    private void ProgramFolderButtonClick(object sender, EventArgs e)
    {
      try
      {
        if (!CurrentUser.HasPermission(ACICategories.GENERAL, ACIOptions.OPENPROGRAMFOLDER))
          return;

        var prc = new System.Diagnostics.Process();
        prc.StartInfo.FileName = System.Environment.CurrentDirectory;
        prc.Start();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void AboutButtonClick(object sender, EventArgs e)
    {
      try
      {
        bool showLogFiles = CurrentUser.HasPermission(ACICategories.GENERAL, ACIOptions.SHOWLOGFILES);
        using (var dialog = new AboutForm(Assembly.GetExecutingAssembly(), showLogFiles))
        {
          dialog.ShowDialog(this);
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    private void LogonAs(User inpersonatedUser)
    {
      Trace.WriteInformation("User {0} is attempting to logon as user '{1}'", Trace.GetMethodName(), CLASSNAME, CurrentUser.User != null ? CurrentUser.User.Username : "UNKNOWN", inpersonatedUser.Username);
      var oldUser = CurrentUser.User;
      try
      {
        ShowBusyBox = true;

        try
        {
          CurrentUser.SetCurrentUser(inpersonatedUser.Username, inpersonatedUser.Password, true);
          if (!CurrentUser.HasPermission(ACICategories.GENERAL, ACIOptions.LOGON))
          {
            throw new SecurityException(System.Environment.UserDomainName, inpersonatedUser.Username, "*****", Translations.LogonForm.NoAuthorisation);
          }
          Trace.WriteInformation("User succesfully authenticated by Domain or SQL. (User: {0})", Trace.GetMethodName(), CLASSNAME, CurrentUser.User);

          AddHistoryAction(TranslationKey.History_LogonForm_LoggedOnAs, "User: {0} logged on as user {1}", oldUser.Username, CurrentUser.User.Username);


        }
        catch (SecurityException ex)
        {
          string name = Trace.GetMethodName();
          Trace.WriteError("()", name, CLASSNAME, ex);
          DisplayError(TranslationKey.Error_Logon_LoginFailed, "Login Failed", "Login for the user is failed. Reason:\n\n {0}", ex.Message);
          AddHistoryAction(TranslationKey.History_LogonForm_LoginFailed, "Login for the user {0} is failed. Reason: {1}", inpersonatedUser.Username, ex.Message);
        }
        catch (Exception ex)
        {
          string name = Trace.GetMethodName();
          Trace.WriteError("()", name, CLASSNAME, ex);
          DisplayError(TranslationKey.Error_Logon_LoginFailed, "Login Failed", "Login for the user is failed. Reason:\n\n {0}", ex.Message);
          AddHistoryAction(TranslationKey.History_LogonForm_LoginFailed, "Login for the user {0} is failed. Reason: {1}", inpersonatedUser.Username, ex.Message);
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
        AddHistoryAction(TranslationKey.History_LogonForm_LoginFailed, "Login attempt has failed. Reason: {1}", ex.Message);
      }
      finally
      {
        ShowBusyBox = false;
        EnableDisableButtons();
      }
    }


    private void ExitButtonClick(object sender, EventArgs e)
    {
      Close();
    }

    private void HomeButtonClick(object sender, EventArgs e)
    {
      screenManagerPanel.GoToHome();
    }

    private void PreviousButtonClick(object sender, EventArgs e)
    {
      screenManagerPanel.GoToPreviousScreen();
    }

    private void NextButtonClick(object sender, EventArgs e)
    {
      screenManagerPanel.GoToNextScreen();
    }

    private void RefreshButtonItemClick(object sender, EventArgs e)
    {
      Refresh();
    }


    private void NewProjectButtonClick(object sender, EventArgs e)
    {
      Navigate(NavigationItems.NewProjectForm);
    }

    private void EnableDisableButtons()
    {
      try
      {
        Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);

        homeQuickButton.Enabled = CurrentUser.User != null;
        previousQuickButton.Enabled = CurrentUser.User != null && (screenManagerPanel.PreviousScreensCount > 1);
        nextQuickButton.Enabled = CurrentUser.User != null && (screenManagerPanel.NextScreensCount > 0);
        helpQuickButtonItem.Visible = !string.IsNullOrEmpty(
          ApplicationSettings.Business.ApplicationSettings.Instance[
            (int)L3IC.OrderManager.General.Enums.ApplicationSettings.HelpLocation]);
        quickLogoffButton.Visible = CurrentUser.User?.Username.Equals(_defaultUserName) == false;
        programFolderButton.Visible = CurrentUser.HasPermission(ACICategories.GENERAL, ACIOptions.OPENPROGRAMFOLDER);
        userProfileButton.Visible = CurrentUser.User != null && CurrentUser.HasPermission(ACICategories.USERPROFILE, ACIOptions.VIEW);
        logonAsButton.Visible = CurrentUser.User != null && CurrentUser.HasPermission(ACICategories.GENERAL, ACIOptions.LOGONAS);

        GenerateLogonAsButtons();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    #endregion

    private void SetAuthorisation()
    {
      try
      {
        userValueStatusStripLabel.Text = $"{CurrentUser.User?.Username ?? "- - -"} [{CurrentUser.ClientName ?? string.Empty}]";

        EnableDisableButtons();

        GenerateMenu();
        _nexAutoLogoutTime = DateTime.Now.AddMinutes(1);
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    #region Menu Handling

    private void Navigate(object sender, EventArgs e)
    {
      try
      {
        Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);

        ShowBusyBox = true;

        Type type = sender.GetType();
        string tagValue = "";
        switch (type.Name)
        {
          case "ToolStripMenuItem":
            tagValue = ((ToolStripMenuItem)sender).Tag.ToString();
            break;
          case "Button":
            tagValue = ((Button)sender).Tag.ToString();
            break;
          case "ButtonItem":
            tagValue = ((DevComponents.DotNetBar.ButtonItem)sender).Tag.ToString();
            break;
          default:
            break;
        }

        if (!int.TryParse(tagValue, out var nagivationItemId))
          throw new ApplicationException("Menubutton has an incorrect Id");

        switch (nagivationItemId)
        {
          case (int)NavigationItems.Home:
            screenManagerPanel.GoToHome();
            break;
          case (int)NavigationItems.Previous:
            screenManagerPanel.GoToPreviousScreen();
            break;
          case (int)NavigationItems.Next:
            screenManagerPanel.GoToNextScreen();
            break;
          case (int)NavigationItems.Test:
            screenManagerPanel.GoToTest();
            break;
          case (int)NavigationItems.NewProjectForm:
            screenManagerPanel.GoToNewProjectScreen();
            break;
          default:
            if (!screenManagerPanel.SetMainWindow((NavigationItems)nagivationItemId))
              AddHistoryAction(TranslationKey.History_NavigationFailed, "Navigation failed to '{0}'.", (NavigationItems)nagivationItemId);
            break;
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        ShowBusyBox = false;
      }
    }

    public void Navigate(NavigationItems navigationItem)
    {
      Navigate(navigationItem, EventArgs.Empty);
    }

    public void Navigate(NavigationItems navigationItem, EventArgs e)
    {
      try
      {
        Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);

        ShowBusyBox = true;

        switch (navigationItem)
        {
          case NavigationItems.Home:
            screenManagerPanel.GoToHome();
            break;
          case NavigationItems.Previous:
            screenManagerPanel.GoToPreviousScreen();
            break;
          case NavigationItems.Next:
            screenManagerPanel.GoToNextScreen();
            break;
          case NavigationItems.Test:
            screenManagerPanel.GoToTest();
            break;
          case NavigationItems.NewProjectForm:
            screenManagerPanel.GoToNewProjectScreen();
            break;
          default:
            if (!screenManagerPanel.SetMainWindow(navigationItem, e))
              AddHistoryAction(TranslationKey.History_NavigationFailed, "Navigation failed to '{0}'.", navigationItem);
            break;
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, navigationItem);
      }
      finally
      {
        ShowBusyBox = false;
      }
    }

    private void SetExpandStateOfMenu()
    {
      bool _menuState = true;
      
      var computerProperty = CurrentUser.GetComputerProperty((Int32)UserManagementProperties.ComputerMenuBarDefaultExpanded);
      if (Boolean.TryParse(computerProperty?.Value ?? computerProperty?.DefaultValue, out bool c))
      {
        _menuState = c;
      }

      if (CurrentUser.User != null)
      {
        var userProperty = CurrentUser.GetUserProperty((Int32)UserManagementProperties.UserMenuBarDefaultExpanded);
        if (Boolean.TryParse(userProperty?.Value ?? userProperty?.DefaultValue, out bool u))
        {
          _menuState = u;
        }
      }
      
      ribbonControlHeader.Expanded = _menuState;
      ribbonControlHeader.Refresh();
    }

    private void GenerateMenu()
    {
      try
      {


        ribbonControlHeader.AutoExpand = true;

        SetExpandStateOfMenu();



        new Windows.Forms.MenuGenerator.MenuGenerator(ribbonControlHeader, Navigate, Properties.Resources.ResourceManager).GenerateMenu();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
      finally
      {
        Initialize();
      }
    }

    //private void GenerateMenu()
    //{
    //  try
    //  {
    //    ribbonControlHeader.AutoExpand = true;
    //    ribbonControlHeader.Expanded = false;
    //    Application.DoEvents();
    //    ribbonControlHeader.SuspendLayout();
    //    ribbonControlHeader.Items.Clear();

    //    if (CurrentUser.User == null)
    //      return;

    //    foreach (var item in Settings.Navigation.TabItems.Cast<NavigationTabItem>().OrderBy(i => i.DisplayOrder))
    //    {
    //      if (item.Count > 0)
    //      {
    //        var tabItem = GetRibbonTab(item);
    //        if (tabItem.Panel != null)
    //          ribbonControlHeader.Items.Add(tabItem);
    //      }
    //      else
    //      {
    //        var button = GetRibbonButton(item, true);
    //        if (button.Enabled)
    //          ribbonControlHeader.Items.Add(button);
    //      }
    //    }

    //    foreach (var ribbonPanel in ribbonControlHeader.Controls)
    //    {
    //      if (!( ribbonPanel is RibbonPanel panel )) continue;
    //      foreach (var ribbonBar in panel.Controls.Cast<RibbonBar>())
    //        ribbonBar.Left = 10 * ribbonBar.TabIndex;
    //    }

    //    ribbonControlHeader.Reinitialize();
    //  }
    //  catch (Exception ex)
    //  {
    //    Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
    //    throw;
    //  }
    //  finally
    //  {
    //    base.Initialize(); // Initialize controls
    //    ribbonControlHeader.RecalcLayout();
    //    ribbonControlHeader.ResumeLayout(true);
    //  }

    //}

    private Windows.Forms.DevComponents2.Controls.ButtonItem GetRibbonButton(NavigationTabItem tabItem, Boolean header)
    {
      try
      {
        var buttonItem = new Windows.Forms.DevComponents2.Controls.ButtonItem
        {
          ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText,
          HotFontBold = true,
          Translate = true
        };

        if (header)
        {
          buttonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
          buttonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
        }
        else
        {
          buttonItem.ImagePaddingHorizontal = 45;
          buttonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
          buttonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
        }

        if (tabItem.Tag.Length > 0)
        {
          buttonItem.Tag = tabItem.Tag;
          buttonItem.Click += Navigate;
        }

        buttonItem.Name = tabItem.Name;
        buttonItem.Text = tabItem.Text;
        buttonItem.KeyTips = tabItem.KeyTips.Length > 0 ? tabItem.KeyTips : null;
        buttonItem.Image = tabItem.Image.Length > 0
                             ? (Bitmap)Properties.Resources.ResourceManager.GetObject(tabItem.Image)
                             : null;
        buttonItem.Enabled = tabItem.ACI == null || tabItem.ACI.Length != 2
                             || CurrentUser.HasPermission(tabItem.ACI[0], tabItem.ACI[1]);
        buttonItem.RecalcSize();

        return buttonItem;
      }
      catch (Exception ex)
      {
        Trace.WriteError("'({0},{1})", Trace.GetMethodName(), CLASSNAME, ex, tabItem, header);
        throw;
      }
    }

    private RibbonTabItem GetRibbonTab(NavigationTabItem tabItem)
    {
      try
      {
        var ribbonTabItem = new RibbonTabItem
        {
          ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText,
          HotFontBold = true,
          ImagePaddingHorizontal = 8,
          SubItemsExpandWidth = 14,
          Translate = true
        };

        if (tabItem.Tag.Length > 0)
        {
          ribbonTabItem.Tag = tabItem.Tag;
          ribbonTabItem.Click += Navigate;
        }
        ribbonTabItem.Name = tabItem.Name;
        ribbonTabItem.Text = tabItem.Text;
        ribbonTabItem.KeyTips = tabItem.KeyTips.Length > 0 ? tabItem.KeyTips : null;
        ribbonTabItem.Image = tabItem.Image.Length > 0
                                ? (Bitmap)Properties.Resources.ResourceManager.GetObject(tabItem.Image)
                                : null;

        if (tabItem.Count > 0)
        {
          var ribbonPanel = GetRibbonPanel();
          ribbonTabItem.Enabled = false;

          foreach (var bar in tabItem.Cast<NavigationTabBar>())
          {
            var ribbonBar = GetRibbonBar(bar);
            if (ribbonBar.Items.Count <= 0)
              continue;

            ribbonPanel.Controls.Add(ribbonBar);
            ribbonTabItem.Enabled = ribbonTabItem.Enabled || (Boolean)ribbonBar.Tag;
          }

          if (ribbonTabItem.Enabled && ribbonPanel.Controls.Count > 0)
          {
            ribbonControlHeader.Controls.Add(ribbonPanel);
            ribbonTabItem.Panel = ribbonPanel;
          }
        }

        ribbonTabItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
        ribbonTabItem.RecalcSize();

        return ribbonTabItem;
      }
      catch (Exception ex)
      {
        Trace.WriteError("'({0})", Trace.GetMethodName(), CLASSNAME, ex, tabItem);
        throw;
      }
    }

    private void GenerateLogonAsButtons()
    {
      foreach (ButtonItem button in logonAsButton.SubItems)
      {
        button.Click -= LogonAsButtonClick;
        button.Dispose();
      }
      logonAsButton.SubItems.Clear();
      if (CurrentUser.User != null && CurrentUser.HasPermission(ACICategories.GENERAL, ACIOptions.LOGONAS))
      {
        var users = new Users().GetAll();
        foreach (var user in users)
        {
          if (user.Id == CurrentUser.User.Id)
            continue;

          ButtonItem button = new ButtonItem
          {
            Translate = false,
            Text = user.Username,
            Tag = user,
            ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
          };
          switch (user.AccountType)
          {
            case AccountTypes.ADUser:
              button.Image = Resources.IE_User3_24;
              break;
            case AccountTypes.ADSuperUser:
              button.Image = Resources.IE_SuperUser3_24;
              break;
            case AccountTypes.DBUser:
              button.Image = Resources.IE_User_24;
              break;
            case AccountTypes.DBSuperUser:
              button.Image = Resources.IE_SuperUser_24;
              break;
          }
          button.Click += LogonAsButtonClick;
          logonAsButton.SubItems.Add(button);

        }
      }
    }

    private void LogonAsButtonClick(object sender, EventArgs e)
    {
      ButtonItem button = (ButtonItem)sender;
      LogonAs((User)button.Tag);

    }

    private RibbonPanel GetRibbonPanel()
    {
      var ribbonPanel = new RibbonPanel();
      ribbonControlHeader.Controls.Add(ribbonPanel);
      ribbonPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      ribbonPanel.Dock = DockStyle.Fill;
      //ribbonPanel.Location = new Point(0, 71);
      //ribbonPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
      //ribbonPanel.Size = new Size(1016, 67);
      ribbonPanel.TabIndex = 0;
      ribbonPanel.Visible = false;

      return ribbonPanel;
    }

    private RibbonBar GetRibbonBar(NavigationTabBar tabBar)
    {
      var ribbonBar = new RibbonBar
      {
        //AutoOverflowEnabled = true,
        Dock = DockStyle.Left,
        Tag = false
      };

      foreach (var buttonItem in tabBar.Cast<NavigationTabItem>().OrderBy(i => i.DisplayOrder))
      {
        var button = GetRibbonButton(buttonItem, false);

        if (!button.Enabled)
          continue;

        ribbonBar.Items.Add(button);
        ribbonBar.Tag = true;
      }

      ribbonBar.Name = tabBar.Name;
      ribbonBar.TabIndex = tabBar.DisplayOrder;
      ribbonBar.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      //ribbonBar.Location = new Point(3, 0);
      //ribbonBar.Size = new Size(519, 64);
      ribbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      ribbonBar.Text = tabBar.ShowName ? tabBar.Text : "";
      ribbonBar.TitleVisible = true;
      ribbonBar.Translate = true;

      return ribbonBar;
    }
    #endregion

    #region Translations

    private void InitTranslationButton()
    {
      try
      {
        var languageList = GlobalHandler.ActiveLanguages();

        // Remove existing buttons
        foreach (ToolStripMenuItem btn in btnLanguage.DropDownItems)
          btn.Click -= BtnLanguageOnClick;

        btnLanguage.DropDownItems.Clear();

        // Add new buttons
        foreach (var language in languageList.OrderBy(l => l.Name))
        {
          var btn = new ToolStripMenuItem
          {
            Name = $"btnLanguage{language.CultureName.ToUpper()}",
            Text = language.Name,
            Image = language.Image,
            Tag = language,
          };

          btn.Click += BtnLanguageOnClick;

          if (language.Id == Translation.Instance.CurrentLanguageId)
            btnLanguage.Image = language.Image;

          btnLanguage.DropDownItems.Add(btn);
        }

      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        KillClient();
      }
    }

    private void BtnLanguageOnClick(object sender, EventArgs eventArgs)
    {
      try
      {
        var language = (Language)((ToolStripMenuItem)sender).Tag;
        Translation.Instance.CurrentLanguageId = language.Id;
        btnLanguage.Image = language.Image;

        // Hide ribbon control to repaint buttons
        ribbonControlHeader.Expanded = false;
        ribbonControlHeader.Refresh();
        SetExpandStateOfMenu();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        KillClient();
      }
    }

    private void BtnLanguageButtonClick(object sender, EventArgs e)
    {
      btnLanguage.DropDown.Show();
    }

    private void TranslationCurrentLanguageChangedEvent(object sender, EventArgs e)
    {
      try
      {
        headerLabel.Text = screenManagerPanel.CurrentScreen.TranslatedTitle;

        navigationLocationStatusStripLabel.Text =
          $"   {screenManagerPanel.CurrentScreen.TranslatedTitle} [{(Int32)screenManagerPanel.CurrentScreen.NavigationItem:0000}]";

        userStatusStripLabel.Text = Translations.MainForm.UserStatusStripLabel;
        if (CurrentUser.User != null)
        {
          AddHistoryAction(TranslationKey.History_Language_Changed_By_User, "Language changed to {0} by {1}", (Languages)Translation.Instance.CurrentLanguageId, CurrentUser.User.Username);
        }
        else
        {
          AddHistoryAction(TranslationKey.History_Language_Changed, "Language changed to {0}", (Languages)Translation.Instance.CurrentLanguageId);
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    #endregion

    private void MainFormResizeBegin(object sender, EventArgs e)
    {
      SuspendLayout();
    }

    private void MainFormResizeEnd(object sender, EventArgs e)
    {
      ResumeLayout();
    }

    private void HelpQuickButtonItemClick(object sender, EventArgs e)
    {
      new PopupHelp().ShowDialog();
    }

    private void UserProfileButtonClick(object sender, EventArgs e)
    {
      try
      {
        ShowBusyBox = true;

        screenManagerPanel.SetMainWindow(NavigationItems.UserProfile);
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        ShowBusyBox = false;
      }
    }

    private void buttonDetach_Click(object sender, EventArgs e)
    {
      try
      {
        if (_detachedForms.Count >= _maxDetachedFormsCount)
          return;

        BasePageForm screen = screenManagerPanel.CurrentScreen;
        if (screen != null)
        {
          screen.Parent.Controls.Remove(screen);
          DetachedForm detachedForm = new DetachedForm(this);
          Dictionary<int, Screen> screenDictionary = new Dictionary<int, Screen>();

          int n = 0;
          foreach (Screen scrn in Screen.AllScreens.Where(x => x.Primary == false))
          {
            screenDictionary.Add(n, scrn);
            n++;
          }

          var nextScreen = screenDictionary.Count > 0 ? screenDictionary.ContainsKey(_detachedForms.Count) ? screenDictionary[_detachedForms.Count] : screenDictionary[screenDictionary.Count - 1] : Screen.AllScreens.First(x => x.Primary == true);
          if (nextScreen != null)
          {
            detachedForm.Left = nextScreen.Bounds.X;
            detachedForm.Top = nextScreen.Bounds.Y;
            detachedForm.Width = nextScreen.Bounds.Width;
            detachedForm.Height = nextScreen.Bounds.Height;
            detachedForm.StartPosition = FormStartPosition.Manual;
          }
          detachedForm.Attach(screen);
          detachedForm.Show();
          _detachedForms.Add(detachedForm);
          detachedForm.DetachedFormClosed += DetachedFormClosed;
          DetachButtonVisibility();
          screenManagerPanel.GoToPreviousScreen();
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("", nameof(buttonDetach_Click), CLASSNAME, ex);
        DisplayError(TranslationKey.CommonMessage_InternalError, ex);
      }
    }

    private void DetachedFormClosed(object sender, EventArgs e)
    {
      var form = sender as DetachedForm;
      if (form != null)
      {
        _detachedForms.Remove(form);
        DetachButtonVisibility();
      }
    }

    private void DetachButtonVisibility()
    {
      var currentScreen = screenManagerPanel.CurrentScreen;
      buttonDetach.Visible = _detachedForms.Count < _maxDetachedFormsCount
        && currentScreen != null
        && currentScreen.NavigationItem != NavigationItems.Logon
        && currentScreen.NavigationItem != NavigationItems.Home;
    }
  }
}

