using System;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.UserManagement2;
using Actemium.UserManagement2.Business;
using Actemium.UserManagement2.Model;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  public partial class UserManagement2AddModifyPopupForm : BasePopupForm
  {
    private const string CLASSNAME = nameof(UserManagement2AddModifyPopupForm);
    private readonly User _user;
    private readonly Group _group;
    private readonly Computer _computer;

    public User UserResult { get; private set; }
    public Group GroupResult { get; private set; }
    public Computer ComputerResult { get; private set; }

    public UserManagement2AddModifyPopupForm()
    {
      InitializeComponent();
      InitializeTranslations();
    }
    
    public UserManagement2AddModifyPopupForm(User user)
      : this()
    {
      NavigationItem = NavigationItems.UserManagement;
      ACICategory = ACICategories.USERMANAGEMENT;
      _user = user;
    }

    public UserManagement2AddModifyPopupForm(Group group)
      : this()
    {
      NavigationItem = NavigationItems.GroupManagement;
      ACICategory = ACICategories.GROUPMANAGEMENT;
      _group = group;
    }

    public UserManagement2AddModifyPopupForm(Computer computer)
      : this()
    {
      NavigationItem = NavigationItems.ComputerManagement;
      ACICategory = ACICategories.COMPUTERMANAGEMENT;
      _computer = computer;
    }

    public override void ActivateFromMain(EventArgs e)
    {
      try
      {
        base.ActivateFromMain(e);

        if (!CurrentUser.HasPermission(ACICategory, ACIOptions.VIEW))
        {
          throw new SecurityException(CurrentUser.User.Username, Translations.General.NoAuthorisation);
        }
        Show();
        try
        {
          ShowBusyBox = true;
          EnableDisableControls();

          FillFields();

          
        }
        catch (Exception ex)
        {
          Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
          throw;
        }
        finally
        {
          ShowBusyBox = false;
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public override void DeActivateFromMain()
    {
      try
      {
        base.DeActivateFromMain();

        CurrentUser.ClearPermissions();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }
    

    private void FillFields()
    {
      
      try
      {
        switch (NavigationItem)
        {
          case NavigationItems.UserManagement:
            UserPanelX.Visible = true;
            GroupPanelX.Visible = false;
            ComputerPanelX.Visible = false;
            if (_user == null)
            {
              Text = Translations.UserManagement2AddModifyPopupForm.AddUser;
              return;
            }
            Text = string.Format(Translations.UserManagement2AddModifyPopupForm.ModifyUser, _user.Username);
            FillFields(_user);
            break;
          case NavigationItems.GroupManagement:
            UserPanelX.Visible = false;
            GroupPanelX.Visible = true;
            ComputerPanelX.Visible = false;
            if (_group == null)
            {
              Text = Translations.UserManagement2AddModifyPopupForm.AddGroup;
              return;
            }
            Text = string.Format(Translations.UserManagement2AddModifyPopupForm.ModifyGroup, _group.Name);
            FillFields(_group);
            break;
          case NavigationItems.ComputerManagement:
            UserPanelX.Visible = false;
            GroupPanelX.Visible = false;
            ComputerPanelX.Visible = true;
            if (_computer == null)
            {
              Text = Translations.UserManagement2AddModifyPopupForm.AddComputer;
              return;
            }
            Text = string.Format(Translations.UserManagement2AddModifyPopupForm.ModifyComputer, _computer.HostName);
            FillFields(_computer);
            break;
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    private void FillFields(User user)
    {
      UsersIsSuperUserCheckBoxX.Enabled = UsersIsSuperUserCheckBoxX.Enabled && !user.Username.Equals("Actemium");

      UsersUsernameTextBoxX.Text = user.Username;
      UsersNameTextBoxX.Text = user.Name;
      UsersSurNameTextBoxX.Text = user.SurName;
      UsersPasswordTextBoxX.Text = user.Password;
      UsersConfirmPasswordTextBoxX.Text = user.Password;
      UsersIsSuperUserCheckBoxX.Checked = user.AccountType == AccountTypes.DBSuperUser;
    }

    private void FillFields(Group group)
    {
      GroupsNameTextBoxX.Text = group.Name;
      GroupsDescriptionTextBoxX.Text = group.Description;
      GroupsDomainGroupIdentifierTextBoxX.Text = group.DomainGroupIdentifier;
    }

    private void FillFields(Computer computer)
    {
      ComputersHostNameTextBoxX.Text = computer.HostName;
      ComputersDescriptionTextBoxX.Text = computer.Description;
      ComputersACIManagedCheckBoxX.Checked = computer.ACIManaged;
    }

    private void EnableDisableControls()
    {
      errorProvider.Clear();
      UsersIsSuperUserCheckBoxX.Enabled = CurrentUser.User.AccountType == AccountTypes.DBSuperUser
                                          || CurrentUser.User.AccountType == AccountTypes.ADSuperUser;
      UsersShowPasswordCheckBoxX.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.SHOWPASSWORD);

      GroupsDomainGroupIdentifierTextBoxX.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.SETUPDOMAINGROUPIDENTIFIER);

      ComputersACIManagedCheckBoxX.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.SETUPCOMPUTERTOBEACIMANAGED);

      if (ApplicationSettings.Business.ApplicationSettings.Instance[(Int32)Actemium.L3IC.OrderManager.General.Enums.ApplicationSettings.EmptyPasswordAllowed] == "True")
      {

        UserEmptyPasswordCheckbox.Visible = true;
        UserEmptyPasswordLabel.Visible = true;

        if (UserEmptyPasswordCheckbox.Checked)
        {
          UsersPasswordTextBoxX.Enabled = false;
          UsersConfirmPasswordTextBoxX.Enabled = false;
          UsersShowPasswordCheckBoxX.Enabled = false;
          UsersPasswordTextBoxX.Text = "";
          UsersConfirmPasswordTextBoxX.Text = "";
        }
        else
        {
          UsersPasswordTextBoxX.Enabled = true;
          UsersConfirmPasswordTextBoxX.Enabled = true;
          UsersShowPasswordCheckBoxX.Enabled = true;
        }
      }
      else
      {
        UserEmptyPasswordCheckbox.Visible = false;
        UserEmptyPasswordLabel.Visible = false;
      }

    }

    private User CheckUserConstraints()
    {
      try
      {
        var result = _user ?? new User();

        Boolean hasError = false;
        errorProvider.Clear();

        
        if (UsersUsernameTextBoxX.Text.Length <= 0 || UsersUsernameTextBoxX.Text.Length > 50)
        {
          hasError = true;
          errorProvider.SetError(UsersUsernameTextBoxX, Translations.General.MandatoryData);
        }
        else
        {
          result.Username = UsersUsernameTextBoxX.Text;
        }

        if (UserEmptyPasswordCheckbox.Checked != true)
        {
          if (UsersPasswordTextBoxX.Text.Length <= 0 || UsersPasswordTextBoxX.Text.Length > 255)
          {
            hasError = true;
            errorProvider.SetError(UsersPasswordTextBoxX, Translations.General.MandatoryData);
          }
          else
          {
            if (!UsersShowPasswordCheckBoxX.Checked)
            {
              if (UsersConfirmPasswordTextBoxX.Text.Length <= 0 || UsersConfirmPasswordTextBoxX.Text.Length > 255)
              {
                hasError = true;
                errorProvider.SetError(UsersConfirmPasswordTextBoxX, Translations.General.MandatoryData);
              }
              else if (string.CompareOrdinal(UsersPasswordTextBoxX.Text, UsersConfirmPasswordTextBoxX.Text) != 0)
              {
                hasError = true;
                errorProvider.SetError(UsersPasswordTextBoxX, Translations.General.PasswordMismatch);
                errorProvider.SetError(UsersConfirmPasswordTextBoxX, Translations.General.PasswordMismatch);
              }
            }
            if (!hasError)
            {
              result.Password = UsersPasswordTextBoxX.Text;
            }
          }
        }
        else
        {
          result.Password = "";
        }

        result.Name = UsersNameTextBoxX.Text;
        result.SurName = UsersSurNameTextBoxX.Text;
        result.AccountType = UsersIsSuperUserCheckBoxX.Checked ? AccountTypes.DBSuperUser : AccountTypes.DBUser;

        if (result.Name == null || new Users().GetAll().Find(
              g => g.Id != result.Id && String.Equals(
                     g.Username, result.Username, StringComparison.InvariantCultureIgnoreCase))
            == null)
        {
          return hasError ? null : result;
        }

        errorProvider.SetError(UsersUsernameTextBoxX, Translations.General.MustBeUnique);

        return null;
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    private Group CheckGroupConstraints()
    {
      try
      {
        var result = _group ?? new Group();

        Boolean hasError = false;
        errorProvider.Clear();

        if (GroupsNameTextBoxX.Text.Length <= 0 || GroupsNameTextBoxX.Text.Length > 50)
        {
          hasError = true;
          errorProvider.SetError(GroupsNameTextBoxX, Translations.General.MandatoryData);
        }
        else
        {
          result.Name = GroupsNameTextBoxX.Text;
        }

        if (GroupsDescriptionTextBoxX.Text.Length <= 0 || GroupsDescriptionTextBoxX.Text.Length > 255)
        {
          hasError = true;
          errorProvider.SetError(GroupsDescriptionTextBoxX, Translations.General.MandatoryData);
        }
        else
        {
          result.Description = GroupsDescriptionTextBoxX.Text;
        }

        result.DomainGroupIdentifier = GroupsDomainGroupIdentifierTextBoxX.Text;

        if (result.Name == null || new Groups().GetAll().Find(
              g => g.Id != result.Id && String.Equals(g.Name, result.Name, StringComparison.InvariantCultureIgnoreCase)) == null)
        {
          return hasError ? null : result;
        }

        errorProvider.SetError(GroupsNameTextBoxX, Translations.General.MustBeUnique);

        return null;
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    private Computer CheckComputerConstraints()
    {
      try
      {
        var result = _computer ?? new Computer();

        Boolean hasError = false;
        errorProvider.Clear();

        if (ComputersHostNameTextBoxX.Text.Length <= 0 || ComputersHostNameTextBoxX.Text.Length > 50)
        {
          hasError = true;
          errorProvider.SetError(ComputersHostNameTextBoxX, Translations.General.MandatoryData);
        }
        else
        {
          result.HostName = ComputersHostNameTextBoxX.Text;
        }

        if (ComputersDescriptionTextBoxX.Text.Length <= 0 || ComputersDescriptionTextBoxX.Text.Length > 255)
        {
          hasError = true;
          errorProvider.SetError(ComputersDescriptionTextBoxX, Translations.General.MandatoryData);
        }
        else
        {
          result.Description = ComputersDescriptionTextBoxX.Text;
        }

        result.ACIManaged = ComputersACIManagedCheckBoxX.Checked;

        if (result.HostName == null || new Computers().GetAll().Find(
              g => g.Id != result.Id && String.Equals(
                     g.HostName, result.HostName, StringComparison.InvariantCultureIgnoreCase))
            == null)
        {
          return hasError ? null : result;
        }

        errorProvider.SetError(ComputersHostNameTextBoxX, Translations.General.MustBeUnique);

        return null;
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }


    #region Translations

    private void InitializeTranslations()
    {
      Translations.Initialize();
    }

    #endregion

    private void UserManagement2AddModifyPopupFormActivated(object sender, EventArgs e)
    {
      ActivateFromMain(e);
    }

    private void UserManagement2AddModifyPopupFormFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
      DeActivateFromMain();
    }

    private void UsersShowPasswordCheckBoxXCheckedChanged(object sender, EventArgs e)
    {
      UsersConfirmPasswordTextBoxX.Enabled = !UsersShowPasswordCheckBoxX.Checked;
      UsersConfirmPasswordTextBoxX.Text = UsersShowPasswordCheckBoxX.Checked ? String.Empty : UsersPasswordTextBoxX.Text;
      UsersPasswordTextBoxX.UseSystemPasswordChar = !UsersShowPasswordCheckBoxX.Checked;
    }

    private void OkButtonXClick(object sender, EventArgs e)
    {
      try
      {
        switch (NavigationItem)
        {
          case NavigationItems.UserManagement:
            UserResult = CheckUserConstraints();
            if (UserResult == null)
            {
              return;
            }
            break;
          case NavigationItems.GroupManagement:
            GroupResult = CheckGroupConstraints();
            if (GroupResult == null)
            {
              return;
            }
            break;
          case NavigationItems.ComputerManagement:
            ComputerResult = CheckComputerConstraints();
            if (ComputerResult == null)
            {
              return;
            }
            break;
        }

        DialogResult = DialogResult.OK;
        Close();
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    private void UserEmptyPasswordCheckbox_CheckedChanged(object sender, EventArgs e)
    {
      EnableDisableControls();
     
    }
  }
}
