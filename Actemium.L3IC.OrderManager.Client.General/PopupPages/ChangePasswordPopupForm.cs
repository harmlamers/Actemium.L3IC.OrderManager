using System;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.UserManagement2;
using Actemium.UserManagement2.Model;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  public partial class ChangePasswordPopupForm : BasePopupForm
  {
    private const string CLASSNAME = nameof(ChangePasswordPopupForm);
    private readonly User _user;

    public User UserResult { get; private set; }

    public ChangePasswordPopupForm()
    {
      InitializeComponent();
      InitializeTranslations();
    }

    public ChangePasswordPopupForm(User user)
      : this()
    {
      ACICategory = ACICategories.USERPROFILE;
      _user = user;
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

        ShowBusyBox = true;
        EnableDisableControls();
        Text = Translations.UserProfileForm.ChangePassword;
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

    private void EnableDisableControls()
    {
      errorProvider.Clear();

      if (ApplicationSettings.Business.ApplicationSettings.Instance[(Int32)Actemium.L3IC.OrderManager.General.Enums.ApplicationSettings.EmptyPasswordAllowed] == "True" && CurrentUser.HasPermission(ACICategory, ACIOptions.USERCANUSEEMPTYPASSWORD))
      {
        UserEmptyPasswordLabel.Visible = true;
        UserEmptyPasswordCheckbox.Visible = true;

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
        UserEmptyPasswordLabel.Visible = false;
        UserEmptyPasswordCheckbox.Visible = false;
      }


    }

    private User CheckUserConstraints()
    {
      try
      {
        var result = _user;

        Boolean hasError = false;
        errorProvider.Clear();

        if (!_user.Password.Equals(OldPasswordTextBoxX.Text))
        {
          hasError = true;
          errorProvider.SetError(OldPasswordTextBoxX, Translations.General.WrongPassword);
        }

        if (UserEmptyPasswordCheckbox.Checked == false)
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
              result.Password = UsersPasswordTextBoxX.Text;
          }
        }
        else
        {
          result.Password = "";
        }

        return !hasError ? result : null;
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

        UserResult = CheckUserConstraints();
        if (UserResult == null)
        {
          return;
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
