using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Helpers;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.UserManagement2;
using Actemium.UserManagement2.Business;
using Actemium.UserManagement2.Model;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  public partial class MembershipPopupForm : BasePopupForm
  {
    private const string CLASSNAME = nameof(MembershipPopupForm);
    private const string OBJECT = "Object";

    private readonly User _user;
    private readonly Group _group;

    private DataTable _loadDataResult;
    private readonly Dispatcher _guiThread = Dispatcher.CurrentDispatcher;

    public bool IsRefreshing { get; private set; }


    private MembershipPopupForm()
    {
      InitializeComponent();
      InitializeTranslations();
      ConfigureSuperGrid();
    }

    public MembershipPopupForm(User user)
      : this()
    {
      _user = user;
      lblTitle.Text = string.Format(Translations.MembershipPopupForm.TitleUser, _user.Username);
      ACICategory = ACICategories.USERMANAGEMENT;
    }

    public MembershipPopupForm(Group group)
      : this()
    {
      _group = group;
      lblTitle.Text = string.Format(Translations.MembershipPopupForm.TitleGroup, _group.Name);
      ACICategory = ACICategories.GROUPMANAGEMENT;
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
        Refresh();
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

    #region Translations

    private void InitializeTranslations()
    {
      Translations.Initialize();
    }

    #endregion

    #region Configure SuperGrid & SuperGrid functions
    private void ConfigureSuperGrid()
    {
      MembershipSupergrid.ApplyProjectDefaults();
      MembershipSupergrid.IdentifyingColumn = OBJECT;
      MembershipSupergrid.PrimaryGrid.MultiSelect = false;
      MembershipSupergrid.DisplayNumberOfItems = true;
      MembershipSupergrid.PrimaryGrid.DefaultRowHeight = 30;
      MembershipSupergrid.PrimaryGrid.MouseEditMode = MouseEditMode.SingleClick;
      MembershipSupergrid.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells;
    }
    #endregion

    public DataTable GetDataTable()
    {
      try
      {
        if (_user != null)
        {
          List<UserGroupList> userGroupList = new UserGroupLists().GetByUserId(_user.Id);
          List<Group> groups = new Groups().GetAll();
          var list = UMMembershipHelper.Instance.GetList(_user, userGroupList, groups).OrderBy(i => i.Name).ToList();
          return UMMembershipHelper.Instance.GetDataTable(list);
        }
        else
        {
          List<UserGroupList> userGroupList = new UserGroupLists().GetByGroupId(_group.Id);
          List<User> users = new Users().GetAll();
          var list = UMMembershipHelper.Instance.GetList(_group, userGroupList, users).OrderBy(i => i.Name).ToList();
          return UMMembershipHelper.Instance.GetDataTable(list);
        }
        
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }

    public override void Refresh()
    {
      try
      {
        ShowBusyBox = true;
        RefreshGrid();

        EnableDisableControls();
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

    private void RefreshGrid()
    {

      try
      {
        if (IsRefreshing)
          return;

        MembershipSupergrid.PrimaryGrid.Footer.Text = Translations.General.LoadingData;
        Task.Factory.StartNew(LoadDataTask).ContinueWith(OnContinuationFunction);
        MembershipSupergrid.IdentifyingColumn = OBJECT;
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private DataTable LoadDataTask()
    {
      try
      {
        IsRefreshing = true;

        MembershipSupergrid.SuspendLayout();

        return GetDataTable();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }

    private void OnContinuationFunction(Task<DataTable> t)
    {
      try
      {
        _guiThread.Invoke(() =>
                          {
                            _loadDataResult = t.Result;
                            MembershipSupergrid.SuspendLayout();
                            MembershipSupergrid.PrimaryGrid.Footer.Text = " ";
                            MembershipSupergrid.RefreshData(_loadDataResult);
                            MembershipSupergrid.ResumeLayout(false);
                            MembershipSupergrid.PerformLayout();
                          });
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", nameof(OnContinuationFunction), CLASSNAME, ex);
      }
      finally
      {
        IsRefreshing = false;
      }
    }

    private void EnableDisableControls()
    {
      if (MembershipSupergrid == null)
        return;

      var somethingSelected = MembershipSupergrid.SelectedObjects?.Any() ?? false;
      MembershipSupergrid.PrimaryGrid.AllowEdit = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
      MembershipSupergrid.PrimaryGrid.ShowEditingImage = true;
      MembershipSupergrid.CellValueChanged -= MembershipSupergridCellValueChanged;
      MembershipSupergrid.CellValueChanged += MembershipSupergridCellValueChanged;
    }

    private void MembershipSupergridCellValueChanged(object sender, GridCellValueChangedEventArgs e)
    {
      try
      {
        if (!CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY))
          return;

        if (_user != null && (_user.AccountType == AccountTypes.ADUser || _user.AccountType == AccountTypes.ADSuperUser))
        {
          DisplayWarning(TranslationKey.Message_UserGroup_ModifyNotAllowed, "Action not allowed", "It is not allowed to modify group assignments for domain users.");
          return;
        }

        if (_user != null)
        {
          var row = (UMMembershipHelper.GroupHelper)e.GridCell.GridRow.GetCell(OBJECT).Value;
          row.Member = (bool)e.NewValue;
          if (!row.Member)
          {
            var userGroupList = new UserGroupList(_user.Id, row.Id);
            new UserGroupLists().Delete(userGroupList);
            AddHistoryAction(TranslationKey.History_MembershipPopupForm_Deleted, "User {0} deleted user {1} from group {2}", CurrentUser.User.Username, _user.Username, row.Name);
          }
          else
          {
            var userGroupList = new UserGroupList(_user.Id, row.Id);
            new UserGroupLists().Add(userGroupList);
            AddHistoryAction(TranslationKey.History_MembershipPopupForm_Added, "User {0} added user {1} to group {2}", CurrentUser.User.Username, _user.Username, row.Name);
          }
          
        }
        else if (_group != null)
        {
          var row = (UMMembershipHelper.UserHelper)e.GridCell.GridRow.GetCell(OBJECT).Value;
          row.Member = (bool)e.NewValue;

          if(row.AccountType == AccountTypes.ADUser || row.AccountType == AccountTypes.ADSuperUser)
          {
            DisplayWarning(TranslationKey.Message_UserGroup_ModifyNotAllowed, "Action not allowed", "It is not allowed to modify group assignments for domain users.");
            return;
          }

          if (!row.Member)
          {
            var userGroupList = new UserGroupList(row.Id, _group.Id);
            new UserGroupLists().Delete(userGroupList);
            AddHistoryAction(TranslationKey.History_MembershipPopupForm_Deleted, "User {0} deleted user {1} from group {2}", CurrentUser.User.Username, row.Username, _group.Name);
          }
          else
          {
            var userGroupList = new UserGroupList(row.Id, _group.Id);
            new UserGroupLists().Add(userGroupList);
            AddHistoryAction(TranslationKey.History_MembershipPopupForm_Added, "User {0} added user {1} to group {2}", CurrentUser.User.Username, row.Username, _group.Name);
          }
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
      }
      finally
      {
        Refresh();
      }
    }

    private void MembershipPopupFormActivated(object sender, EventArgs e)
    {
      ActivateFromMain(e);
    }

    private void MembershipPopupFormFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
      DeActivateFromMain();
    }
  }
}
