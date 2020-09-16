using System;
using System.Linq;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.PopupPages;
using Actemium.L3IC.OrderManager.General;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.UserManagement2;
using Actemium.UserManagement2.Business;
using Actemium.UserManagement2.Model;

namespace Actemium.L3IC.OrderManager.Client.General.Pages
{
  public partial class UserProfileForm : BasePageForm
  {
    private const string CLASSNAME = nameof(UserProfileForm);
    public User User { get; private set; }

    public UserProfileForm()
    {
      InitializeComponent();

      NavigationItem = NavigationItems.UserProfile;
      Title = "User Profile";
      ACICategory = ACICategories.USERPROFILE;
    }

    public override void ActivateFromMain(EventArgs e)
    {
      base.ActivateFromMain(e);
      User = CurrentUser.User;

      Refresh();
    }

    public override void Refresh()
    {
      base.Refresh();
      if (User != null)
      {



        if (!Enum.TryParse(
          ApplicationSettings.Business.ApplicationSettings.Instance[
            (int)L3IC.OrderManager.General.Enums.ApplicationSettings.NameAbbreviationStyle], out NameAbbreviationStyle style))
        {
          DisplayError(TranslationKey.CommonMessage_InternalError);
          return;
        }

        NameAbbreviationLabelX.Text = NameAbbreviation.GetAbbreviation(
          string.IsNullOrEmpty(User.Name) ? User.Username : User.Name, User.SurName, style);
        FullNameLabelX.Text = string.IsNullOrEmpty(User.SurName) ? string.IsNullOrEmpty(User.Name) ? User.Username : User.Name : $"{User.Name} {User.SurName}";
        UsernameLabelX.Text = $"{User.Username}";
      }

      EnableDisableControls();
    }

    public void EnableDisableControls()
    {
      ChangePasswordLinkLabel.Visible = CurrentUser.HasPermission(ACICategory, ACIOptions.CHANGEPASSWORD) && (User.AccountType == AccountTypes.DBSuperUser || User.AccountType == AccountTypes.DBUser);
      ChangePropertiesLinkLabel.Visible = CurrentUser.HasPermission(ACICategory, ACIOptions.CHANGEPROPERTIES) && new ViewUserPropertyValues().GetByUser(User.Id).Any();
    }

    private void ChangePasswordLinkLabelLinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = User;
        if (selectedItem == null)
          return;

        using (var popupForm = new ChangePasswordPopupForm(User))
        {
          var result = popupForm.ShowDialog(this);
          if (result != DialogResult.OK)
            return;

          ShowBusyBox = true;

          var userResult = popupForm.UserResult;

          if (userResult == null)
            return;

          new Users().Modify(userResult);
            AddHistoryAction(
              TranslationKey.History_UserProfile_PasswordChanged, "User '{0}' changed his/her password.", userResult.Username);
            Trace.WriteInformation(
              "User password modified by user: UserName= {0}", Trace.GetMethodName(), CLASSNAME, userResult.Username);
          
        }
      }
      catch (Exception ex)
      {
        
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
        ShowBusyBox = false;
      }
      finally
      {
        Refresh();
        ShowBusyBox = false;
      }
    }

    private void ChangePropertiesLinkLabelLinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = User;
        if (selectedItem == null)
          return;

        using (var popupForm = new PropertiesPopupForm(selectedItem))
        {
          var result = popupForm.ShowDialog(this);
        }
      }
      catch (Exception ex)
      {
        
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
        ShowBusyBox = false;
      }
      finally
      {
        Refresh();
        ShowBusyBox = false;
      }
    }
  }
}
