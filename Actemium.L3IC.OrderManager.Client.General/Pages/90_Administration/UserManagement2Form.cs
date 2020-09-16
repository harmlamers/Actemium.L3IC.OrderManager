using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Base.PropertyGrids;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.Helpers;
using Actemium.L3IC.OrderManager.Client.General.PopupPages;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Translations;
using Actemium.UserManagement2;
using Actemium.UserManagement2.Business;
using Actemium.UserManagement2.Model;
using Actemium.Windows.Forms.DevComponents2.Controls;
using Actemium.Windows.Forms.MenuGenerator;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
  public partial class UserManagement2Form : BasePageForm
  {
    private const string CLASSNAME = nameof(UserManagement2Form);

    public bool IsRefreshing => IsRefreshingBottomGrid || IsRefreshingTopGrid;

    public bool IsRefreshingTopGrid { get; private set; }
    public bool IsRefreshingBottomGrid { get; private set; }
    private List<PropertyGridElement> _lastGivenTopPropertyGridElementList = new List<PropertyGridElement>();
    private readonly Dispatcher _guiThread = Dispatcher.CurrentDispatcher;
    private readonly string _topGridObject = "";
    private readonly string _bottomGridObject = "ACI";

    private List<UMHelper.ACIHelper> _aciHelpers;

    private RibbonBar ManageRibbonBar { get; set; }
    private RibbonBar ACIRibbonBar { get; set; }
    private ButtonItem AddButtonItem { get; set; }
    private ButtonItem ModifyButtonItem { get; set; }
    private ButtonItem DeleteButtonItem { get; set; }
    private ButtonItem PropertiesButtonItem { get; set; }
    private ButtonItem UsersButtonItem { get; set; }
    private ButtonItem GroupsButtonItem { get; set; }
    private ButtonItem ActivateButtonItem { get; set; }
    private ButtonItem DeactivateButtonItem { get; set; }
    private ButtonItem GrantAllACIButtonItem { get; set; }
    private ButtonItem RevokeAllACIButtonItem { get; set; }
    private ButtonItem GrantSelectedACIButtonItem { get; set; }
    private ButtonItem RevokeSelectedACIButtonItem { get; set; }



    private void CreateAndInitializeButtons()
    {
      try
      {
        var addImage = Properties.Resources.IE_UserAdd_24;
        var modifyImage = Properties.Resources.IE_UserModify_24;
        var deleteImage = Properties.Resources.IE_UserDelete_24;
        var propertiesImage = Properties.Resources.IE_UserProperties_24;
        var memberShipImage = Properties.Resources.IE_GroupManagement_24;
        var activateImage = Properties.Resources.IE_UserActivate_24;
        var deactivateImage = Properties.Resources.IE_UserDeactivate_24;

        switch (NavigationItem)
        {
          case NavigationItems.GroupManagement:
            addImage = Properties.Resources.IE_GroupAdd_24;
            modifyImage = Properties.Resources.IE_GroupModify_24;
            deleteImage = Properties.Resources.IE_GroupDelete_24;
            propertiesImage = Properties.Resources.IE_GroupProperties_24;
            memberShipImage = Properties.Resources.IE_UserManagement_24;
            break;
          case NavigationItems.ComputerManagement:
            addImage = Properties.Resources.IE_ComputerAdd_16;
            modifyImage = Properties.Resources.IE_ComputerModify_16;
            deleteImage = Properties.Resources.IE_ComputerDelete_24;
            propertiesImage = Properties.Resources.IE_ComputerProperties_24;
            break;
        }

        // Add ButtonItem
        AddButtonItem = MenuGenerator.CreateButtonItem(addImage, nameof(AddButtonItem), "Add", false, null, true);
        ModifyButtonItem = MenuGenerator.CreateButtonItem(modifyImage, nameof(ModifyButtonItem), "Modify", false, null, true);
        DeleteButtonItem = MenuGenerator.CreateButtonItem(deleteImage, nameof(DeleteButtonItem), "Delete", false, null, true);
        PropertiesButtonItem = MenuGenerator.CreateButtonItem(propertiesImage, nameof(PropertiesButtonItem), "Properties", false, null, true);
        UsersButtonItem = MenuGenerator.CreateButtonItem(memberShipImage, nameof(UsersButtonItem), "Users", false, null, true);
        GroupsButtonItem = MenuGenerator.CreateButtonItem(memberShipImage, nameof(GroupsButtonItem), "Groups", false, null, true);
        ActivateButtonItem = MenuGenerator.CreateButtonItem(activateImage, nameof(ActivateButtonItem), "Activate", false, null, true);
        DeactivateButtonItem = MenuGenerator.CreateButtonItem(deactivateImage, nameof(DeactivateButtonItem), "Deactivate", false, null, true);
        GrantAllACIButtonItem = MenuGenerator.CreateButtonItem(Properties.Resources.IE_GrantAll_24, nameof(GrantAllACIButtonItem), "Grant All", false, null, true);
        RevokeAllACIButtonItem = MenuGenerator.CreateButtonItem(Properties.Resources.IE_RevokeAll_24, nameof(RevokeAllACIButtonItem), "Revoke All", false, null, true);
        GrantSelectedACIButtonItem = MenuGenerator.CreateButtonItem(Properties.Resources.IE_GrantSelected_24, nameof(GrantSelectedACIButtonItem), "Grant Selected", false, null, true);
        RevokeSelectedACIButtonItem = MenuGenerator.CreateButtonItem(Properties.Resources.IE_RevokeSelected_24, nameof(RevokeSelectedACIButtonItem), "Revoke Selected", false, null, true);

        AddButtonItem.Click += AddButtonItemClick;
        ModifyButtonItem.Click += ModifyButtonItemClick;
        DeleteButtonItem.Click += DeleteButtonItemClick;
        PropertiesButtonItem.Click += PropertiesButtonItemClick;
        UsersButtonItem.Click += MembershipButtonItemClick;
        GroupsButtonItem.Click += MembershipButtonItemClick;
        ActivateButtonItem.Click += ActivateButtonItemClick;
        DeactivateButtonItem.Click += DeactivateButtonItemClick;
        GrantAllACIButtonItem.Click += GrantAllACIButtonItemClick;
        RevokeAllACIButtonItem.Click += RevokeAllACIButtonItemClick;
        GrantSelectedACIButtonItem.Click += GrantSelectedACIButtonItemClick;
        RevokeSelectedACIButtonItem.Click += RevokeSelectedACIButtonItemClick;


        AddButtonItem.Enabled = false;
        ModifyButtonItem.Enabled = false;
        DeleteButtonItem.Enabled = false;
        PropertiesButtonItem.Enabled = false;
        UsersButtonItem.Enabled = false;
        GroupsButtonItem.Enabled = false;
        ActivateButtonItem.Enabled = false;
        DeactivateButtonItem.Enabled = false;
        GrantAllACIButtonItem.Enabled = false;
        GrantSelectedACIButtonItem.Enabled = false;
        RevokeAllACIButtonItem.Enabled = false;
        RevokeSelectedACIButtonItem.Enabled = false;

        switch (NavigationItem)
        {
          case NavigationItems.UserManagement:
            AddButtonItem.Visible = true;
            ModifyButtonItem.Visible = true;
            DeleteButtonItem.Visible = false;
            PropertiesButtonItem.Visible = true;
            UsersButtonItem.Visible = false;
            GroupsButtonItem.Visible = true;
            ActivateButtonItem.Visible = true;
            DeactivateButtonItem.Visible = true;
            GrantAllACIButtonItem.Visible = true;
            GrantSelectedACIButtonItem.Visible = true;
            RevokeAllACIButtonItem.Visible = true;
            RevokeSelectedACIButtonItem.Visible = true;
            break;
          case NavigationItems.GroupManagement:
            AddButtonItem.Visible = true;
            ModifyButtonItem.Visible = true;
            DeleteButtonItem.Visible = true;
            PropertiesButtonItem.Visible = true;
            UsersButtonItem.Visible = true;
            GroupsButtonItem.Visible = false;
            ActivateButtonItem.Visible = false;
            DeactivateButtonItem.Visible = false;
            GrantAllACIButtonItem.Visible = true;
            GrantSelectedACIButtonItem.Visible = true;
            RevokeAllACIButtonItem.Visible = true;
            RevokeSelectedACIButtonItem.Visible = true;
            break;
          case NavigationItems.ComputerManagement:
            AddButtonItem.Visible = true;
            ModifyButtonItem.Visible = true;
            DeleteButtonItem.Visible = true;
            PropertiesButtonItem.Visible = true;
            UsersButtonItem.Visible = false;
            GroupsButtonItem.Visible = false;
            ActivateButtonItem.Visible = false;
            DeactivateButtonItem.Visible = false;
            GrantAllACIButtonItem.Visible = true;
            GrantSelectedACIButtonItem.Visible = true;
            RevokeAllACIButtonItem.Visible = true;
            RevokeSelectedACIButtonItem.Visible = true;
            break;
        }

        // Add RibbonBar
        var baseItems = new DevComponents.DotNetBar.BaseItem[]
        {
          AddButtonItem,
          ModifyButtonItem,
          DeleteButtonItem,
          PropertiesButtonItem,
          UsersButtonItem,
          GroupsButtonItem,
          ActivateButtonItem,
          DeactivateButtonItem
        };

        ManageRibbonBar = MenuGenerator.CreateRibbonBar(baseItems, nameof(ManageRibbonBar), Translations.General.Manage);

        var aciBaseItems = new DevComponents.DotNetBar.BaseItem[]
                        {
                          GrantAllACIButtonItem,
                          GrantSelectedACIButtonItem,
                          RevokeAllACIButtonItem,
                          RevokeSelectedACIButtonItem
                        };

        ACIRibbonBar = MenuGenerator.CreateRibbonBar(aciBaseItems, nameof(ACIRibbonBar), Translations.UserManagement2Form.ACI);

        EnableDisableControls();
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void RevokeSelectedACIButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }
      switch (NavigationItem)
      {
        case NavigationItems.UserManagement:
          RevokeSelected(GetSelected() as User);
          break;
        case NavigationItems.GroupManagement:
          RevokeSelected(GetSelected() as Group);
          break;
        case NavigationItems.ComputerManagement:
          RevokeSelected(GetSelected() as Computer);
          break;
        default:
          break;
      }
    }

    private void GrantSelectedACIButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }
      if (!bottomSuperGrid?.SelectedObjects?.Any() ?? false)
        return;

      switch (NavigationItem)
      {
        case NavigationItems.UserManagement:
          GrantSelected(GetSelected() as User);
          break;
        case NavigationItems.GroupManagement:
          GrantSelected(GetSelected() as Group);
          break;
        case NavigationItems.ComputerManagement:
          GrantSelected(GetSelected() as Computer);
          break;
        default:
          break;
      }
    }

    private void RevokeAllACIButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }
      switch (NavigationItem)
      {
        case NavigationItems.UserManagement:
          RevokeAll(GetSelected() as User);
          break;
        case NavigationItems.GroupManagement:
          RevokeAll(GetSelected() as Group);
          break;
        case NavigationItems.ComputerManagement:
          RevokeAll(GetSelected() as Computer);
          break;
        default:
          break;
      }
    }

    private void GrantAllACIButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }
      switch (NavigationItem)
      {
        case NavigationItems.UserManagement:
          GrantAll(GetSelected() as User);
          break;
        case NavigationItems.GroupManagement:
          GrantAll(GetSelected() as Group);
          break;
        case NavigationItems.ComputerManagement:
          GrantAll(GetSelected() as Computer);
          break;
        default:
          break;
      }
    }

    private void DeleteButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }
      switch (NavigationItem)
      {
        case NavigationItems.GroupManagement:
          var topGridSelectedGroup = topSupergrid?.SelectedObjects?.FirstOrDefault() as Group;
          if (Confirm(
                TranslationKey.Confirm_UserGroup_Delete, "Delete", "Are you sure you want to delete the group {0}",
                MessageBoxButtons.OKCancel, topGridSelectedGroup?.Name) == DialogResult.OK)
          {
            Delete(topGridSelectedGroup);
          }
          break;
        case NavigationItems.ComputerManagement:
          var topGridSelectedComputer = topSupergrid?.SelectedObjects?.FirstOrDefault() as Computer;
          if (Confirm(
                TranslationKey.Confirm_Computer_Delete, "Delete", "Are you sure you want to delete the computer {0}",
                MessageBoxButtons.OKCancel, topGridSelectedComputer?.HostName) == DialogResult.OK)
          {
            Delete(topGridSelectedComputer);
          }
          break;
      }
    }

    private void DeactivateButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }
      if (NavigationItem == NavigationItems.UserManagement)
      {
        var topGridSelected = topSupergrid?.SelectedObjects?.FirstOrDefault() as User;
        if (Confirm(
              TranslationKey.Confirm_User_Deactivate, "Deactivation", "Are you sure you want to deactivate the user {0}",
              MessageBoxButtons.OKCancel, topGridSelected?.Username) == DialogResult.OK)
        {
          Deactivation(topGridSelected);
        }
      }
    }

    private void ActivateButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }
      if (NavigationItem == NavigationItems.UserManagement)
      {
        var topGridSelected = GetSelected() as User;
        if (Confirm(
              TranslationKey.Confirm_User_Activate, "Activation", "Are you sure you want to activate the user {0}",
              MessageBoxButtons.OKCancel, topGridSelected?.Username) == DialogResult.OK)
        {
          Activate(topGridSelected);
        }
      }
    }

    private void MembershipButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }
      var topGridSelected = GetSelected();
      switch (NavigationItem)
      {
        case NavigationItems.UserManagement:
          MembershipScreen(topGridSelected as User);
          break;
        case NavigationItems.GroupManagement:
          MembershipScreen(topGridSelected as Group);
          break;
      }
    }

    private void PropertiesButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }

      var topGridSelected = GetSelected();
      switch (NavigationItem)
      {
        case NavigationItems.UserManagement:
          PropertyScreen(topGridSelected as User);
          break;
        case NavigationItems.GroupManagement:
          PropertyScreen(topGridSelected as Group);
          break;
        case NavigationItems.ComputerManagement:
          PropertyScreen(topGridSelected as Computer);
          break;
      }
    }

    private void ModifyButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }
      var topGridSelected = GetSelected();
      switch (NavigationItem)
      {
        case NavigationItems.UserManagement:
          ModifyScreen(topGridSelected as User);
          break;
        case NavigationItems.GroupManagement:
          ModifyScreen(topGridSelected as Group);
          break;
        case NavigationItems.ComputerManagement:
          ModifyScreen(topGridSelected as Computer);
          break;
      }
    }

    private void AddButtonItemClick(object sender, EventArgs e)
    {
      var triggerButton = (ButtonItem)sender;
      Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

      EnableDisableControls();
      if (!triggerButton.Enabled)
      {
        Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
        DisplayWarning(TranslationKey.CommonMessage_JustModified);
        return;
      }

      AddScreen();
    }

    public void Activate(User user)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedUser = user;

        ShowBusyBox = true;

        selectedUser.IsActive = true;
        new Users().Modify(selectedUser);
        AddHistoryAction(TranslationKey.History_UserManagementForm_Activated, "User '{0}' activated.", selectedUser.Username);
        Trace.WriteInformation("User activated: GroupName={0}", Trace.GetMethodName(), CLASSNAME, selectedUser.Username);
      }
      catch (Exception ex)
      {
        
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
      }
      finally
      {
        Refresh();
        ShowBusyBox = false;
      }
    }

    public void Deactivation(User user)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedUser = user;
        ShowBusyBox = true;

        selectedUser.IsActive = false;
        new Users().Modify(selectedUser);
        AddHistoryAction(TranslationKey.History_UserManagementForm_Deactivated, "User '{0}' deactivated.", selectedUser.Username);
        Trace.WriteInformation("User deactivated: GroupName={0}", Trace.GetMethodName(), CLASSNAME, selectedUser.Username);
      }
      catch (Exception ex)
      {
        
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
      }
      finally
      {
        Refresh();
        ShowBusyBox = false;
      }
    }

    public void GrantAll(User user)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in _aciHelpers)
        {
          if (aciHelper.Own)
            continue;

          aciHelper.Own = true;
          GrantRevoke(user, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void GrantAll(Group group)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in _aciHelpers)
        {
          if (aciHelper.Own)
            continue;

          aciHelper.Own = true;
          GrantRevoke(group, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void GrantAll(Computer computer)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in _aciHelpers)
        {
          if (aciHelper.Own)
            continue;

          aciHelper.Own = true;
          GrantRevoke(computer, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void RevokeAll(User user)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in _aciHelpers)
        {
          if (!aciHelper.Own)
            continue;

          aciHelper.Own = false;
          GrantRevoke(user, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void RevokeAll(Group group)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in _aciHelpers)
        {
          if (!aciHelper.Own)
            continue;

          aciHelper.Own = false;
          GrantRevoke(group, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void RevokeAll(Computer computer)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in _aciHelpers)
        {
          if (!aciHelper.Own)
            continue;

          aciHelper.Own = false;
          GrantRevoke(computer, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void GrantSelected(User user)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in bottomSuperGrid.SelectedObjects.OfType<UMHelper.ACIHelper>().ToList())
        {
          if (aciHelper.Own)
            continue;

          aciHelper.Own = true;
          GrantRevoke(user, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void GrantSelected(Group group)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in bottomSuperGrid.SelectedObjects.OfType<UMHelper.ACIHelper>().ToList())
        {
          if (aciHelper.Own)
            continue;

          aciHelper.Own = true;
          GrantRevoke(group, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void GrantSelected(Computer computer)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in bottomSuperGrid.SelectedObjects.OfType<UMHelper.ACIHelper>().ToList())
        {
          if (aciHelper.Own)
            continue;

          aciHelper.Own = true;
          GrantRevoke(computer, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void RevokeSelected(User user)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in bottomSuperGrid.SelectedObjects.OfType<UMHelper.ACIHelper>().ToList())
        {
          if (!aciHelper.Own)
            continue;

          aciHelper.Own = false;
          GrantRevoke(user, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void RevokeSelected(Group group)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in bottomSuperGrid.SelectedObjects.OfType<UMHelper.ACIHelper>().ToList())
        {
          if (!aciHelper.Own)
            continue;

          aciHelper.Own = false;
          GrantRevoke(group, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void RevokeSelected(Computer computer)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        ShowBusyBox = true;

        foreach (var aciHelper in bottomSuperGrid.SelectedObjects.OfType<UMHelper.ACIHelper>().ToList())
        {
          if (!aciHelper.Own)
            continue;

          aciHelper.Own = false;
          GrantRevoke(computer, aciHelper);
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
        ShowBusyBox = false;
      }
    }

    public void Delete(Group group)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);

      try
      {

        var selectedItem = group;
        if (selectedItem == null)
          return;

        ShowBusyBox = true;
        new Groups().Delete(selectedItem);
        AddHistoryAction(TranslationKey.History_GroupManagementForm_Deleted, "User group '{0}' deleted.", selectedItem.Name);
        Trace.WriteInformation("Group deleted: GroupName={0}, DomainGroupId={1}", Trace.GetMethodName(), CLASSNAME, selectedItem.Name, selectedItem.Description);
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

    public void Delete(Computer computer)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = computer;
        if (selectedItem == null)
          return;

        ShowBusyBox = true;
        AddHistoryAction(TranslationKey.History_ComputerManagementForm_Deleted, "Computer '{0}' deleted.", selectedItem.HostName);
        Trace.WriteInformation("Computer: HostName={0}, Description={1}", Trace.GetMethodName(), CLASSNAME, selectedItem.HostName, selectedItem.Description);
        new Computers().Delete(selectedItem);
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

    public void PropertyScreen(User user)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = user;
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

    public void PropertyScreen(Group group)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = group;
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

    public void PropertyScreen(Computer computer)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = computer;
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

    public void MembershipScreen(User user)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = user;
        if (selectedItem == null)
          return;

        using (var popupForm = new MembershipPopupForm(selectedItem))
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

    public void MembershipScreen(Group group)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = group;
        if (selectedItem == null)
          return;

        using (var popupForm = new MembershipPopupForm(selectedItem))
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

    public void AddScreen()
    {
      switch (NavigationItem)
      {
        case NavigationItems.UserManagement:
          AddModifyScreen(null as User);
          break;
        case NavigationItems.GroupManagement:
          AddModifyScreen(null as Group);
          break;
        case NavigationItems.ComputerManagement:
          AddModifyScreen(null as Computer);
          break;
      }
    }

    public void ModifyScreen(User user)
    {
      AddModifyScreen(user);
    }

    public void ModifyScreen(Group group)
    {
      AddModifyScreen(group);
    }

    public void ModifyScreen(Computer computer)
    {
      AddModifyScreen(computer);
    }

    public void AddModifyScreen(User user)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = user;
        using (var popupForm = new UserManagement2AddModifyPopupForm(user))
        {
          var result = popupForm.ShowDialog(this);
          if (result != DialogResult.OK)
            return;

          ShowBusyBox = true;

          var userResult = popupForm.UserResult;
          var add = selectedItem == null;
          var modify = !add;

          if (userResult == null)
            return;

          if (modify && (Confirm(
                                TranslationKey.Confirm_User_Modify, "Modify User",
                                "Are you sure to modify this user?", MessageBoxButtons.YesNo) == DialogResult.Yes))
          {
            new Users().Modify(userResult);
            AddHistoryAction(
              TranslationKey.History_UserManagementForm_Modified, "User '{0}' modified.", userResult.Username);
            Trace.WriteInformation(
              "User modified: UserName= {0}", Trace.GetMethodName(), CLASSNAME, userResult.Username);
          }
          else if (add)
          {
            userResult.IsActive = true;
            new Users().Add(userResult);
            AddHistoryAction(
              TranslationKey.History_UserManagementForm_Added, "User '{0}' added.", userResult.Username);
            Trace.WriteInformation(
              "User added: GroupName= {0}", Trace.GetMethodName(), CLASSNAME, userResult.Username);
          }

          Refresh();
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

    public void AddModifyScreen(Group group)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = group;
        using (var popupForm = new UserManagement2AddModifyPopupForm(group))
        {
          var result = popupForm.ShowDialog(this);
          if (result != DialogResult.OK)
            return;

          ShowBusyBox = true;

          var groupResult = popupForm.GroupResult;
          var add = selectedItem == null;
          var modify = !add;

          if (groupResult == null)
            return;

          if (modify && Confirm(TranslationKey.Confirm_UserGroup_Modify, "Modify User group", "Are you sure you want to modify this user group?", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {
            new Groups().Modify(groupResult);
            AddHistoryAction(TranslationKey.History_GroupManagementForm_Modified, "User group '{0}' modified.", groupResult.Name);
            Trace.WriteInformation("Group modified: GroupName={0}", Trace.GetMethodName(), CLASSNAME, groupResult.Name);
          }
          else if (add)
          {
            new Groups().Add(groupResult);
            groupResult = new Groups().GetAll().First(i => i.Name == groupResult.Name);
            AddHistoryAction(TranslationKey.History_GroupManagementForm_Added, "User group '{0}' added.", groupResult.Name);
            Trace.WriteInformation("Group added: GroupName={0}", Trace.GetMethodName(), CLASSNAME, groupResult.Name);
          }
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

    public void AddModifyScreen(Computer computer)
    {
      Trace.WriteVerbose("()", Trace.GetMethodName(), CLASSNAME);
      try
      {
        var selectedItem = computer;
        using (var popupForm = new UserManagement2AddModifyPopupForm(computer))
        {
          var result = popupForm.ShowDialog(this);
          if (result != DialogResult.OK)
            return;

          ShowBusyBox = true;

          var computerResult = popupForm.ComputerResult;
          var add = selectedItem == null;
          var modify = !add;

          if (computerResult == null)
            return;

          if (modify && (Confirm(TranslationKey.Confirm_Computer_Modify, "Modify Computer", "Are you sure to modify this user computer?", MessageBoxButtons.YesNo) == DialogResult.Yes))
          {
            new Computers().Modify(computerResult);
            AddHistoryAction(TranslationKey.History_ComputerManagementForm_Modified, "Computer '{0}' modified.", computerResult.HostName);
            Trace.WriteInformation("Computer modified: HostName={0}", Trace.GetMethodName(), CLASSNAME, computerResult.HostName);
          }
          else if (add)
          {
            new Computers().Add(computerResult);
            computerResult = new Computers().GetAll().First(i => i.HostName == computerResult.HostName);
            AddHistoryAction(TranslationKey.History_ComputerManagementForm_Added, "Computer '{0}' added.", computerResult.HostName);
            Trace.WriteInformation("Computer added: hostName={0}", Trace.GetMethodName(), CLASSNAME, computerResult.HostName);
          }
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

    public void GrantRevoke(User user, UMHelper.ACIHelper aciHelper)
    {
      if (aciHelper.Own)
      {
        var aciItem = new UserAccessControlList(aciHelper.Id, user.Id);
        new UserAccessControlLists().Add(aciItem);
        AddHistoryAction(TranslationKey.History_UserManagementForm_ACIGranted, "User {0} granted right {2} - {3} for user {1}", CurrentUser.User.Username, user.Username, aciHelper.Category, aciHelper.Action);
      }
      else
      {
        var aciItem = new UserAccessControlList(aciHelper.Id, user.Id);
        new UserAccessControlLists().Delete(aciItem);
        AddHistoryAction(TranslationKey.History_UserManagementForm_ACIRevoked, "User {0} revoked right {2} - {3} for user {1}", CurrentUser.User.Username, user.Username, aciHelper.Category, aciHelper.Action);
      }
    }

    public void GrantRevoke(Group group, UMHelper.ACIHelper aciHelper)
    {
      if (aciHelper.Own)
      {
        var aciItem = new GroupAccessControlList(aciHelper.Id, group.Id);
        new GroupAccessControlLists().Add(aciItem);
        AddHistoryAction(TranslationKey.History_GroupManagementForm_ACIGranted, "User {0} granted right {2} - {3} for group {1}", CurrentUser.User.Username, group.Name, aciHelper.Category, aciHelper.Action);
      }
      else
      {
        var aciItem = new GroupAccessControlList(aciHelper.Id, group.Id);
        new GroupAccessControlLists().Delete(aciItem);
        AddHistoryAction(TranslationKey.History_GroupManagementForm_ACIRevoked, "User {0} revoked right {2} - {3} for group {1}", CurrentUser.User.Username, group.Name, aciHelper.Category, aciHelper.Action);
      }
    }

    public void GrantRevoke(Computer computer, UMHelper.ACIHelper aciHelper)
    {
      if (aciHelper.Own)
      {
        var aciItem = new ComputerAccessControlList(aciHelper.Id, computer.Id);
        new ComputerAccessControlLists().Add(aciItem);
        AddHistoryAction(TranslationKey.History_ComputerManagementForm_ACIGranted, "User {0} granted right {2} - {3} for computer {1}", CurrentUser.User.Username, computer.HostName, aciHelper.Category, aciHelper.Action);
      }
      else
      {
        var aciItem = new ComputerAccessControlList(aciHelper.Id, computer.Id);
        new ComputerAccessControlLists().Delete(aciItem);
        AddHistoryAction(TranslationKey.History_ComputerManagementForm_ACIRevoked, "User {0} revoked right {2} - {3} for computer {1}", CurrentUser.User.Username, computer.HostName, aciHelper.Category, aciHelper.Action);
      }
    }

    public UserManagement2Form(NavigationItems navigationItem)
    {
      InitializeComponent();


      NavigationItem = navigationItem;
      switch (NavigationItem)
      {
        case NavigationItems.UserManagement:
          Title = "User Management - Users";
          ACICategory = ACICategories.USERMANAGEMENT;
          _topGridObject = "User";
          break;
        case NavigationItems.GroupManagement:
          Title = "User Management - Groups";
          ACICategory = ACICategories.GROUPMANAGEMENT;
          _topGridObject = "Group";
          break;
        case NavigationItems.ComputerManagement:
          Title = "User Management - Computers";
          ACICategory = ACICategories.COMPUTERMANAGEMENT;
          _topGridObject = "Computer";
          break;
      }

      CreateAndInitializeButtons();
      ConfigureSuperGrid();
    }


    private void AddButtonRibbonBars()
    {
      try
      {
        RibbonBars.Add(new Tuple<string, RibbonBar>("tiManagement", ManageRibbonBar));
        RibbonBars.Add(new Tuple<string, RibbonBar>("tiManagement", ACIRibbonBar));
      }
      catch (Exception ex)
      {
        var name = Trace.GetMethodName();
        Trace.WriteError("", name, CLASSNAME, ex);
      }
    }


    private void RefreshTopGrid()
    {

      try
      {
        if (IsRefreshingTopGrid)
          return;

        topSupergrid.PrimaryGrid.Footer.Text = Translations.General.LoadingData;
        Task.Factory.StartNew(LoadTopDataTask).ContinueWith(OnTopContinuationFunction);
        topSupergrid.IdentifyingColumn = _topGridObject;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void OnTopContinuationFunction(Task<DataTable> t)
    {
      try
      {
        _guiThread.Invoke(() =>
                          {
                            topSupergrid.RememberSelection();
                            topSupergrid.RestoreSelectionAfterRefresh();
                            topSupergrid.SuspendLayout();
                            topSupergrid.PrimaryGrid.Footer.Text = " ";
                            topSupergrid.RefreshData(t.Result);
                            topSupergrid.ResumeLayout(false);
                            topSupergrid.PerformLayout();
                          });
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        IsRefreshingTopGrid = false;
      }
    }

    private DataTable LoadTopDataTask()
    {
      try
      {
        IsRefreshingTopGrid = true;

        topSupergrid.SuspendLayout();

        switch (NavigationItem)
        {
          case NavigationItems.UserManagement:
            return GetUserDataTable();
          case NavigationItems.GroupManagement:
            return GetGroupDataTable();
          case NavigationItems.ComputerManagement:
            return GetComputerDataTable();
          default:
            return null;
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }

    private void RefreshBottomGrid()
    {

      try
      {
        if (IsRefreshingBottomGrid)
          return;

        bottomSuperGrid.PrimaryGrid.Footer.Text = Translations.General.LoadingData;
        Task.Factory.StartNew(LoadBottomDataTask).ContinueWith(OnBottomContinuationFunction);
        bottomSuperGrid.IdentifyingColumn = _bottomGridObject;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void OnBottomContinuationFunction(Task<DataTable> t)
    {
      try
      {
        _guiThread.Invoke(() =>
                          {
                            bottomSuperGrid.SuspendLayout();
                            bottomSuperGrid.PrimaryGrid.Footer.Text = " ";
                            bottomSuperGrid.PrimaryGrid.InvalidateLayout();
                            bottomSuperGrid.PrimaryGrid.Columns.Clear();
                            bottomSuperGrid.RefreshData(t.Result);
                            bottomSuperGrid.ResumeLayout(false);
                            bottomSuperGrid.PerformLayout();
                          });
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        IsRefreshingBottomGrid = false;
      }
    }

    private DataTable LoadBottomDataTask()
    {
      try
      {
        IsRefreshingBottomGrid = true;

        bottomSuperGrid.SuspendLayout();

        return GetACIDataTable();
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }

    public DataTable GetUserDataTable()
    {
      try
      {
        var userList = new Users().GetAll();
        var userDataTable = UMHelper.Instance.GetDataTable(userList);

        return userDataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }

    public DataTable GetGroupDataTable()
    {
      try
      {
        var groupList = new Groups().GetAll();
        var groupDataTable = UMHelper.Instance.GetDataTable(groupList);

        return groupDataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }

    public DataTable GetComputerDataTable()
    {
      try
      {
        var computerList = new Computers().GetAll();
        var computerDataTable = UMHelper.Instance.GetDataTable(computerList);

        return computerDataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }

    public DataTable GetACIDataTable()
    {
      try
      {
        var aciItems = new AccessControlItems().GetAll().OrderBy(x => x.Category).ThenBy(y => y.Action).ToList();
        var userACIList = new UserAccessControlLists().GetAll();
        var groupACIList = new GroupAccessControlLists().GetAll();
        var computerACIList = new ComputerAccessControlLists().GetAll();
        _aciHelpers = new List<UMHelper.ACIHelper>();

        switch (NavigationItem)
        {
          case NavigationItems.UserManagement:
            if (!(GetSelected() is User user))
              return UMHelper.Instance.GetDataTable(aciItems);
            var userGroupList = new UserGroupLists().GetByUserId(user.Id);
            _aciHelpers = UMHelper.Instance.GetList(user, aciItems, userGroupList, userACIList, groupACIList).OrderBy(x => x.Category).ThenBy(y => y.Action).ToList();
            return UMHelper.Instance.GetDataTable<User>(_aciHelpers);
          case NavigationItems.GroupManagement:
            if (!(GetSelected() is Group group))
              return UMHelper.Instance.GetDataTable(aciItems);

            _aciHelpers = UMHelper.Instance.GetList(group, aciItems, groupACIList).OrderBy(x => x.Category).ThenBy(y => y.Action).ToList();
            return UMHelper.Instance.GetDataTable<Group>(_aciHelpers);
          case NavigationItems.ComputerManagement:
            if (!(GetSelected() is Computer computer))
              return UMHelper.Instance.GetDataTable(aciItems);

            _aciHelpers = UMHelper.Instance.GetList(computer, aciItems, computerACIList).OrderBy(x => x.Category).ThenBy(y => y.Action).ToList();
            return UMHelper.Instance.GetDataTable<Computer>(_aciHelpers);
          default:
            return UMHelper.Instance.GetDataTable(aciItems);
        }

      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }


    #region User Handling (Upper Left Grid)

    #region Grid Handling
    private object GetSelected()
    {
      try
      {
        return topSupergrid?.SelectedObjects?.FirstOrDefault();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    #endregion

    #region Button Handling
    private void EnableDisableControls()
    {
      try
      {
        var topGridSelected = topSupergrid?.SelectedObjects?.FirstOrDefault();
        var anythingTopSelected = topGridSelected != null;

        var bottomGridSelected = bottomSuperGrid?.SelectedObjects?.FirstOrDefault();
        var anythingBottomSelected = bottomGridSelected != null;

        AddButtonItem.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.ADD);
        ModifyButtonItem.Enabled = anythingTopSelected && CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
        PropertiesButtonItem.Enabled = anythingTopSelected && CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
        GrantAllACIButtonItem.Enabled = anythingTopSelected && CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
        RevokeAllACIButtonItem.Enabled = anythingTopSelected && CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
        GrantSelectedACIButtonItem.Enabled = anythingTopSelected && anythingBottomSelected && CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
        RevokeSelectedACIButtonItem.Enabled = anythingTopSelected && anythingBottomSelected && CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);

        switch (NavigationItem)
        {
          case NavigationItems.UserManagement:
            var selectedUser = topGridSelected as User;
            ActivateButtonItem.Enabled = anythingTopSelected && !selectedUser.IsActive && (selectedUser.AccountType == AccountTypes.DBSuperUser || selectedUser.AccountType == AccountTypes.DBUser) && CurrentUser.HasPermission(ACICategory, ACIOptions.ACTIVATE) && !selectedUser.Username.Equals("Actemium");
            DeactivateButtonItem.Enabled = anythingTopSelected && selectedUser.IsActive && (selectedUser.AccountType == AccountTypes.DBSuperUser || selectedUser.AccountType == AccountTypes.DBUser) && CurrentUser.HasPermission(ACICategory, ACIOptions.DEACTIVATE) && !selectedUser.Username.Equals("Actemium");
            GroupsButtonItem.Enabled = anythingTopSelected && (selectedUser.AccountType == AccountTypes.DBSuperUser || selectedUser.AccountType == AccountTypes.DBUser) && CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
            ModifyButtonItem.Enabled = ModifyButtonItem.Enabled
                                       && (selectedUser.AccountType == AccountTypes.DBSuperUser
                                            || selectedUser.AccountType == AccountTypes.DBUser);
            break;
          case NavigationItems.GroupManagement:
            var selectedGroup = topGridSelected as Group;
            DeleteButtonItem.Enabled = anythingTopSelected && CurrentUser.HasPermission(ACICategory, ACIOptions.DELETE);
            UsersButtonItem.Enabled = anythingTopSelected && CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
            break;
          case NavigationItems.ComputerManagement:
            var selectedComputer = topGridSelected as Computer;
            DeleteButtonItem.Enabled = anythingTopSelected && CurrentUser.HasPermission(ACICategory, ACIOptions.DELETE);
            break;
        }

        if (bottomSuperGrid == null)
          return;

        var somethingSelected = bottomSuperGrid.SelectedObjects?.Any() ?? false;
        bottomSuperGrid.PrimaryGrid.AllowEdit = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
        bottomSuperGrid.PrimaryGrid.ShowEditingImage = true;


      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    private void BottomSuperGridSelectionChanged(object sender, GridEventArgs e)
    {
      EnableDisableControls();
    }

    private void BottomSuperGridDataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
    {
      e.GridPanel.Columns["Id"].Visible = false;
      e.GridPanel.Columns["Id"].AllowEdit = false;
      e.GridPanel.Columns["Id"].AllowEdit = false;
      e.GridPanel.Columns["Id"].HeaderText = Translations.UserManagement2Form.ACIId;
      e.GridPanel.Columns["Category"].AllowEdit = false;
      e.GridPanel.Columns["Category"].HeaderText = Translations.UserManagement2Form.ACICategory;
      e.GridPanel.Columns["Action"].AllowEdit = false;
      e.GridPanel.Columns["Action"].HeaderText = Translations.UserManagement2Form.ACIAction;
      if (e.GridPanel.Columns["Granted"] != null)
      {
        e.GridPanel.Columns["Granted"].HeaderText = Translations.UserManagement2Form.ACIGranted;
      }
      if (e.GridPanel.Columns["GroupGranted"] != null)
      {
        e.GridPanel.Columns["GroupGranted"].AllowEdit = false;
        e.GridPanel.Columns["GroupGranted"].HeaderText = Translations.UserManagement2Form.ACIGroupGranted;
      }
    }




    #endregion
    #endregion


    #region ControlBase and Form Implementation
    public override void ActivateFromMain(EventArgs e)
    {
      try
      {
        base.ActivateFromMain(e);

        if (!CurrentUser.HasPermission(ACICategory, ACIOptions.VIEW))
        {
          const TranslationKey transKey = TranslationKey.CommonMessage_NoAuthorization;
          throw new SecurityException(CurrentUser.User.Username, Translation.Instance.Translate(this, transKey, transKey.GetCommonMessage()));
        }

        AddButtonRibbonBars();
        Refresh();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public override void Refresh()
    {
      try
      {
        ShowBusyBox = true;

        UpdateTopPropertyGrid(_lastGivenTopPropertyGridElementList);
        RefreshTopGrid();
        RefreshBottomGrid();
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



    public override bool DeActivateAllowed()
    {
      return true;
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

    private void UserManagementFormResize(object sender, EventArgs e)
    {
      try
      {
        //pnlTop.Height = (Int32)((Height - 20) * 0.5);
        //pnlBottomLeft.Width = (Int32)((Width - 20) * 0.5);
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }
    #endregion

    private void TopSupergridSelectionChanged(object sender, DevComponents.DotNetBar.SuperGrid.GridEventArgs e)
    {
      try
      {
        List<PropertyGridElement> propList = new List<PropertyGridElement>();

        foreach (var selectedObject in topSupergrid.SelectedObjects)
        {
          switch (NavigationItem)
          {
            case NavigationItems.UserManagement:
              propList.AddRange(new UMHelper().CreatePropertyGridElements((User)selectedObject));
              break;
            case NavigationItems.GroupManagement:
              propList.AddRange(new UMHelper().CreatePropertyGridElements((Group)selectedObject));
              break;
            case NavigationItems.ComputerManagement:
              propList.AddRange(new UMHelper().CreatePropertyGridElements((Computer)selectedObject));
              break;
            default:
              break;
          }
        }

        UpdateTopPropertyGrid(propList);
        RefreshBottomGrid();

        EnableDisableControls();
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    public void UpdateTopPropertyGrid(List<PropertyGridElement> propertyGridElementList)
    {
      try
      {
        _lastGivenTopPropertyGridElementList = propertyGridElementList;

        Task.Factory.StartNew(InitializeTopPropertyGridElements)
          .ContinueWith(ApplyTopPropertyGridElements);
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void InitializeTopPropertyGridElements()
    {
      try
      {
        foreach (PropertyGridElement element in _lastGivenTopPropertyGridElementList)
        {
          element.Initialize();
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void ApplyTopPropertyGridElements(Task t)
    {
      try
      {
        _guiThread.Invoke(() =>
                          {
                            topPropertyGrid.Item.Clear();
                            foreach (PropertyGridElement element in _lastGivenTopPropertyGridElementList)
                            {
                              string sValue = "";
                              if (element.Value != null)
                              {
                                sValue = element.Value;
                              }
                              topPropertyGrid.Item.Add(element.Name, element.Value, true, element.Category, sValue, true);
                            }
                            topPropertyGrid.Refresh();
                          });
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    #region Configure SuperGrid & SuperGrid functions
    private void ConfigureSuperGrid()
    {
      topSupergrid.ApplyProjectDefaults();
      topSupergrid.IdentifyingColumn = _topGridObject;
      topSupergrid.PrimaryGrid.MultiSelect = false;
      topSupergrid.DisplayNumberOfItems = true;
      topSupergrid.PrimaryGrid.DefaultRowHeight = 30;
      topSupergrid.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells;

      bottomSuperGrid.ApplyProjectDefaults();
      bottomSuperGrid.IdentifyingColumn = _bottomGridObject;
      bottomSuperGrid.PrimaryGrid.MultiSelect = true;
      bottomSuperGrid.DisplayNumberOfItems = true;
      bottomSuperGrid.PrimaryGrid.DefaultRowHeight = 30;
      bottomSuperGrid.PrimaryGrid.MouseEditMode = MouseEditMode.SingleClick;
      bottomSuperGrid.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells;
    }
    #endregion

    private void BottomSuperGridCellValueChanged(object sender, GridCellValueChangedEventArgs e)
    {
      try
      {
        if (!CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY))
          return;

        if (e.GridCell.GridColumn.Name.Equals("GroupGranted"))
        {
          e.GridCell.CancelEdit();
          return;
        }

        var row = (UMHelper.ACIHelper)e.GridCell.GridRow.GetCell(_bottomGridObject).Value;
        row.Own = (bool)e.NewValue;

        switch (NavigationItem)
        {
          case NavigationItems.UserManagement:
            GrantRevoke(GetSelected() as User, row);
            break;
          case NavigationItems.GroupManagement:
            GrantRevoke(GetSelected() as Group, row);
            break;
          case NavigationItems.ComputerManagement:
            GrantRevoke(GetSelected() as Computer, row);
            break;
          default:
            break;
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
      }
    }
  }
}
