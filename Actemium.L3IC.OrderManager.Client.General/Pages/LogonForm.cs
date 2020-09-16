using System;
using System.Drawing;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.UserManagement2;
using Actemium.UserManagement2.Business;
using Actemium.UserManagement2.Model;

namespace Actemium.L3IC.OrderManager.Client.General.Pages
{
  public partial class LogonForm : BasePageForm
  {
		private const string CLASSNAME = nameof(LogonForm);

    public bool Connecting { get; private set; }
    private User _defaultUser;

    public LogonForm()
    {
      InitializeComponent();
      Connecting = false;
      Translations.Initialize();
      NavigationItem = NavigationItems.Logon;
    }

    #region Initialisation
    
    private void LoadUserList()
    {
      try
      {
        usersComboBox.ValueMember = "Username";
        usersComboBox.DisplayMember = "Username";

        var savedUsers = new WindowsRegistryHandler().GetAllSavedUsers(out var lastUser);
        
        if (_defaultUser != null && !savedUsers.Exists(i => i.Username == _defaultUser.Username))
          savedUsers.Add(new SavedUser(_defaultUser.Username, "**********"));
        
        usersComboBox.DataSource = savedUsers;
				usersComboBox.SelectedValue = lastUser;
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    private void LoadDefaultSettings()
    {
      try
      {
        var computerDefaultUser = CurrentUser.GetComputerProperty((Int32)UserManagementProperties.ComputerDefaultUser);

        if (computerDefaultUser != null && !String.IsNullOrEmpty(computerDefaultUser.Value))
          _defaultUser = new Users().GetByUsername(computerDefaultUser.Value);


        var defaultNavigationItem = CurrentUser.GetComputerProperty((Int32)UserManagementProperties.ComputerDefaultNavigationItem);

        if (defaultNavigationItem == null || String.IsNullOrEmpty(defaultNavigationItem.Value) || !Int32.TryParse(
              defaultNavigationItem.Value, out var defaultNavigationItemId))
        {
          return;
        }

        if (Enum.IsDefined(typeof(NavigationItems), defaultNavigationItemId))
          GlobalHandler.HomeNavigationItem = (NavigationItems)defaultNavigationItemId;
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }
    #endregion

    #region Entryfield & Button Handling
    private void UsersComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      if (usersComboBox.SelectedIndex > -1)
      {
        passwordTextBox.Text = ((SavedUser)usersComboBox.SelectedItem).Password;
      }
    }
  
    private void LogonButtonClick(object sender, EventArgs e)
    {
      Logon(null);
    }

    private void LogoffButtonClick(object sender, EventArgs e)
    {
      LogOff(false);
    }

		private void LogonDefaultButtonClick(object sender, EventArgs e)
		{
      if (_defaultUser != null && (CurrentUser.User == null || CurrentUser.User.Id != _defaultUser.Id))
        Logon(_defaultUser);
      else
        DisplayInfo(TranslationKey.Message_NoDefaultUserConfigured, "No default user configured", "There is no default user configured for this computer.");
		}

    private void EnableDisableButtons()
    {
      usersComboBox.Enabled = CurrentUser.User == null;
      passwordTextBox.Enabled = CurrentUser.User == null;
      logonButton.Visible = CurrentUser.User == null;
      logonButton.Enabled = CurrentUser.User == null;
      logoffButton.Visible = CurrentUser.User != null;
      logoffButton.Enabled = CurrentUser.User != null;
      logonDefaultButton.Enabled = _defaultUser != null && CurrentUser.User?.Username != _defaultUser.Username;
    }
    #endregion

    private void Logon(User autoLoginUser)
    {
      Trace.WriteInformation("User is attempting to logon with username '{0}' (passwordLength='{1}')", Trace.GetMethodName(), CLASSNAME, autoLoginUser != null ? autoLoginUser.Username : usersComboBox.Text, autoLoginUser != null ? 0 : passwordTextBox.Text.Length);

      try
      {
				ShowBusyBox = true;
        
        SavedUser user;
        if (autoLoginUser == null)
        {
          user = (SavedUser)usersComboBox.SelectedItem;
          if (user == null)
            user = new SavedUser(usersComboBox.Text, passwordTextBox.Text);
          else
            user.Password = passwordTextBox.Text;
        }
        else
        {
          user = new SavedUser(autoLoginUser.Username, autoLoginUser.Password);
        }

        Connecting = true;

        try
        { 
          CurrentUser.SetCurrentUser(user.Username, user.Password, autoLoginUser != null);
          var usr = CurrentUser.User;
          if (!CurrentUser.HasPermission(ACICategories.GENERAL, ACIOptions.LOGON))
          {
            throw new SecurityException(Environment.UserDomainName, user.Username, "*****", Translations.LogonForm.NoAuthorisation);
          }
          Trace.WriteInformation("User succesfully authenticated by Domain or SQL. (User: {0})", Trace.GetMethodName(), CLASSNAME, CurrentUser.User);
          if (autoLoginUser == null)
          {
            AddHistoryAction(TranslationKey.History_LogonForm_LoggedOn, "User: {0} logged on", CurrentUser.User.Username);
          }
          else
          {
            AddHistoryAction(TranslationKey.History_Automatic_LogOn, "User: {0} logged on as default user", CurrentUser.User.Username);
          }
          new WindowsRegistryHandler().SaveUser(user);
        }
        catch (SecurityException ex)
        {
          string name = Trace.GetMethodName();
          Trace.WriteError("()", name, CLASSNAME, ex);
          DisplayError(TranslationKey.Error_Logon_LoginFailed, "Login Failed", "Login for the user is failed. Reason:\n\n {0}", ex.Message);
          AddHistoryAction(TranslationKey.History_LogonForm_LoginFailed, "Login for the user {0} is failed. Reason: {1}", user.Username, ex.Message);
          passwordTextBox.Clear();
        }
        catch (Exception ex)
        {
          string name = Trace.GetMethodName();
          Trace.WriteError("()", name, CLASSNAME, ex);
          DisplayError(TranslationKey.Error_Logon_LoginFailed, "Login Failed", "Login for the user is failed. Reason:\n\n {0}", ex.Message);
          AddHistoryAction(TranslationKey.History_LogonForm_LoginFailed, "Login for the user {0} is failed. Reason: {1}", user.Username, ex.Message);
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

		private void LogOff(Boolean autoLogOff)
		{
			try
			{
			  if (!autoLogOff && Confirm(
			        TranslationKey.Confirm_Logoff, "Logoff", "Are you sure you want to logoff?", MessageBoxButtons.YesNo)
			      != DialogResult.Yes)
        {
          return;
        }

        ShowBusyBox = true;
			  if (!autoLogOff)
			  {
			    AddHistoryAction(TranslationKey.History_LogonForm_LoggedOff, "User: {0} logged off", CurrentUser.User.Username);
        }
			  CurrentUser.ClearCurrentUser();
			  LoadUserList();
			}
			catch (Exception ex)
			{
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
			}
			finally
			{
				ShowBusyBox = false;
				EnableDisableButtons();
			}
		}



	  private void RefreshTimerTick(object sender, EventArgs e)
    {
    	try
    	{
				if (DesignMode)
					return;

	      if (!Visible)
          return;

        refreshTimer.Stop();

	      //auto logon:
	      if (logonButton.Enabled && _defaultUser != null)
	      {
	        Logon(_defaultUser);
	      }
	      else if (GlobalHandler.AutoLogout)
	      {
	        GlobalHandler.AutoLogout = false;
	        LogOff(true);
	      }
	    }
    	catch (Exception ex)
    	{
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
    	}
    }

		private void LogonFormResize(object sender, EventArgs e)
    {
      logoPictureBox.Location = new Point((Size.Width - logoPictureBox.Size.Width) / 2, (Size.Height - logoPictureBox.Size.Height) / 12 * 2);
      autorisationGroupBox.Location = new Point((Size.Width - logoPictureBox.Size.Width) / 2, (Size.Height - logoPictureBox.Size.Height) / 12 * 9);
    }

		public override void ActivateFromMain(EventArgs e)
    {
      try
      {
        base.ActivateFromMain(e);

        LoadDefaultSettings();
        LoadUserList();

        refreshTimer.Interval = 1;
        refreshTimer.Start();

	      EnableDisableButtons();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

	}
}
